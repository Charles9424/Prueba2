using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT.App_Data
{
    internal class Engine
    {
        public void Start() 
        {
            //INICIALIZACIONE
            string ls_error = null;
            App_DB.Query oQuerys=new App_DB.Query();
            int consecutivo_consulta = 0;
            try
            {
                //OPTIENE CONEXION DB
                ls_error = oQuerys.Set_conn();
                if (!String.IsNullOrEmpty(ls_error))
                {
                    throw new Exception(ls_error);
                }

                //OBTIENE LISTADO DE CONSULTAS PENDIENTES
                DataTable oDT_ConsultaP = oQuerys.WS_CONSULTAR_PEDIENTE(ref ls_error);
                if (!String.IsNullOrEmpty(ls_error))
                {
                    throw new Exception(ls_error);
                }

                App_Data.Proc_Engine proc_Engine = new App_Data.Proc_Engine();
                // OBTIENE EL CONSECUTIVO EN ORDEN DE LA TABLA 
                foreach (DataRow oDR_ConsultaR in oDT_ConsultaP.Rows)
                {
                    consecutivo_consulta = Convert.ToInt32(oDR_ConsultaR[1]);

                    int ls_oPROCESAR=proc_Engine.DMSAT(oQuerys, consecutivo_consulta, ref ls_error);
                    if (!String.IsNullOrEmpty(ls_error))
                    {
                        throw new Exception(ls_error);
                    }
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
