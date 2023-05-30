using AdoNetCore.AseClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT.App_DB
{
    internal class Query
    {
        private AseConnection? iAse_conn { get; set; }
        //Desarrollo
        private Domus.ARR.Desarrollo oDomus { get; set; }
        //Produccion
        //private Domus.ARR.Produccion oDomus {get; set; }

        public DataTable WS_CONSULTAR_PEDIENTE(ref string ras_error)
        {
            try
            {
                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;
                    }
                }
                DateTime dt = DateTime.Now;
                AseCommand cmd = new AseCommand("DMSTA_CONSULTAR_CLAVE_PROG", iAse_conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@adt_fecha_actual", (object)dt ?? DBNull.Value);

                DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);

                if (!String.IsNullOrEmpty(ras_error))
                {
                    ras_error = "Exception Error (Querys.WS_CONSULTAR_PEDIENTE): " + ras_error;
                    return null;
                }
                return DT_Consulta;

            }
            catch (Exception Ex)
            {
                ras_error = "Exception Error (Querys.WS_CONSULTAR_PEDIENTE): " + Ex.Message + ". " + Ex.InnerException;
                return null;
            }
        }

        public DataTable DM_CONSLTA_EMPRESA(string numero_empresa, ref string ras_error)
        {
            try
            {

                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;
                    }
                }
                    AseCommand cmd = new AseCommand("DMSAT_CONSULTA_EMPRESA", iAse_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@numero_empresa", (object)numero_empresa ?? DBNull.Value);

                    DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);
                    if (!String.IsNullOrEmpty(ras_error))
                    {
                        ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + ras_error;
                        return null;
                    }
                    return DT_Consulta;
                

            }
            catch (Exception Ex)
            {
                ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + Ex.Message + ". " + Ex.InnerException;
                return null;
            }
        }

        public DataTable DMSAT_CONSULTA(decimal consecutivo_consulta, ref string ras_error)
        {
            try
            {
                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;

                    }
                }
                AseCommand cmd = new AseCommand("CONSULTA_DMSAT_CONSULTA_PENDIENTE", iAse_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ai_consecutivo_consulta", (object)consecutivo_consulta ?? DBNull.Value);


                    DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);

                    if (!String.IsNullOrEmpty(ras_error))
                    {
                        ras_error = "Exception Error (Querys.DMSAT_CONSULTA): " + ras_error;
                        return null;
                    }
                    return DT_Consulta;

                
                return null;
            }
            catch (Exception Ex)
            {
                {
                    ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + Ex.Message + ". " + Ex.InnerException;
                    return null;
                }
            }

        }

        public DataTable CONSULTA_FIELD(string numero_empresa, ref string ras_error) 
        {
            try
            {
                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;

                    }
                }
                    AseCommand cmd = new AseCommand("DMSAT_CONSULTA_FIELD", iAse_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@as_numero_empresa",(object)numero_empresa ?? DBNull.Value);


                    DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);

                    if (!String.IsNullOrEmpty(ras_error))
                    {
                        ras_error = "Exception Error (Querys.CONSULTA_FIELD): " + ras_error;
                        return null;
                    }

                return DT_Consulta; 
            }
            catch (Exception Ex)
            {
                ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + Ex.Message + ". " + Ex.InnerException;
                return null;
            }
        }

        public DataTable CONSULTA_PFX(string numero_empresa, ref string ras_error)
        {
            try
            {
                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;

                    }
                }
                AseCommand cmd = new AseCommand("DMSAT_CONSULTA_PFX", iAse_conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@as_numero_empresa", (object)numero_empresa ?? DBNull.Value);


                DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);

                if (!String.IsNullOrEmpty(ras_error))
                {
                    ras_error = "Exception Error (Querys.DMSAT_CONSULTA_PFX): " + ras_error;
                    return null;
                }

                return DT_Consulta;
            }
            catch (Exception Ex)
            {
                ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + Ex.Message + ". " + Ex.InnerException;
                return null;
            }
        }

        public DataTable DM_CONSULTA_COMPROBANTE (decimal clave_comprobante, ref string ras_error)
        {
            try
            {
                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;

                    }
                }
                    AseCommand cmd = new AseCommand("DMSAT_CONSULTAR_COMPROBANTE", iAse_conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ai_clave_tipo_comprobante", (object)clave_comprobante ?? DBNull.Value);
                    DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);

                    if (!String.IsNullOrEmpty(ras_error))
                    {
                        ras_error = "Exception Error (Querys.CONSULTA_FIELD): " + ras_error;
                        return null;
                    }
                return DT_Consulta;


            }
            catch (Exception Ex)
            {
                ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + Ex.Message + ". " + Ex.InnerException;
                return null;
            }
        }

        public  DataTable DM_UPDATE_ESTATUS(decimal adec_consecutivo_consulta,
                                                    decimal adec_consecutivo_prog,
                                                    string as_envio,
                                                    string as_resultado,
                                                    string as_estatus_code,
                                                    string as_estatus_clave_massage,
                                                    string as_update_estatus,
                                                    ref string ras_error)
        {
            try
            {
                if (iAse_conn == null)
                {
                    string ls_return = Set_conn();
                    if (!String.IsNullOrEmpty(ls_return))
                    {
                        ras_error = "Internal Error (Querys.SetConn): Error SetConnection";
                        return null;

                    }
                }
                AseCommand cmd = new AseCommand("DMSAT_ACT_ESTATUS_SAT_PROCESO", iAse_conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@ai_clave_tipo_comprobante", (object)adec_consecutivo_consulta ?? DBNull.Value);
                cmd.Parameters.Add("@adec_consecutivo_consulta", (object)adec_consecutivo_consulta ?? DBNull.Value);
                cmd.Parameters.Add("@adec_consecutivo_prog", (object)adec_consecutivo_prog ?? DBNull.Value);
                cmd.Parameters.Add("@as_cadena_original", (object)as_envio ?? DBNull.Value);
                cmd.Parameters.Add("@as_cadena_result", (object)as_resultado ?? DBNull.Value);
                cmd.Parameters.Add("@as_clave_estatus_code", (object)as_estatus_code ?? DBNull.Value);
                cmd.Parameters.Add("@as_clave_estatus_message", (object)as_estatus_clave_massage ?? DBNull.Value)  ;
                cmd.Parameters.Add("@as_update_estatus", (object)as_update_estatus ?? DBNull.Value);
                DataTable DT_Consulta = oDomus.Execute(iAse_conn, cmd, ref ras_error);

                if (!String.IsNullOrEmpty(ras_error))
                {
                    ras_error = "Exception Error (Querys.CONSULTA_FIELD): " + ras_error;
                    return null;
                }
                return DT_Consulta;

            }
            catch(Exception Ex)
            {
                ras_error = "Exception Error (Querys.DM_CONSLTA_EMPRESA): " + Ex.Message + ". " + Ex.InnerException;
                return null;
            }
        }


        public void Dispose() 
        {
            string ls_error = "";
            if (iAse_conn != null)
                oDomus.Dispose(iAse_conn, ref ls_error);
        }

        public string Set_conn() 
        {
            string ls_error = "";
                // Desarrollo
                oDomus = new Domus.ARR.Desarrollo();
            // Produccion
            //  oDomus = new Domus.ARR.Produccion();
            iAse_conn = (AseConnection)oDomus.Con_SRC("ENGINE_DM_CFDI_DES", ref ls_error);
            return ls_error;
                
        }

    }
}
