using AdoNetCore.AseClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MT_DM_SAT.App_Data
{
    internal class Procesar_Consulta_Prog
    {
        /*
        public static int Procesar_Tipo(int Concecutivo_conuslta, ref string as_error)
        {
            DataTable dt_return = null;
            DataTable DT_CONSULTA_PARAMETROS;
           // string des_serializacion = null;
            try
            {
                DT_CONSULTA_PARAMETROS = DBs.Sybase.DMSAT_CONSULTA(Concecutivo_conuslta, ref as_error);
                Models.Parametros_Envio Content = new Models.Parametros_Envio();
                Models.Parametros_Entrada Content_Ent = new Models.Parametros_Entrada();

                string Serializacion = null;
                string Enviar_CFDI = null;
                DataTable DT_CONSULTA_FIELD = null;
                DataTable DT_CONSULTA_COMPROBANTE= null;
                DataTable DT_CONSULTA_RFC = null;
                DataTable Update_Estatus = null; 

                foreach (DataRow row in DT_CONSULTA_PARAMETROS.Rows)
                {
                    //|         
                    int tipo_consulta = Convert.ToInt32(row[1].ToString());
                    string numero_empresa = row[4].ToString();

                    //Obtiene el certificado y key
                    DT_CONSULTA_FIELD = DBs.Sybase.CONSULTA_FIELD(numero_empresa, ref as_error); 
                    string key_ = DT_CONSULTA_FIELD.Rows[0][0].ToString();
                    string certificado_ = DT_CONSULTA_FIELD.Rows[0][1].ToString();

                    //Obtiene el tipo de comprobante
                    DT_CONSULTA_COMPROBANTE = DBs.Sybase.DM_CONSULTA_COMPROBANTE(Convert.ToInt32(row[11].ToString()), ref as_error);
                    string Contraseña = "";

                    //Obtener el rfc y nombre de la empresa

                    DT_CONSULTA_RFC = DBs.Sybase.DM_CONSLTA_EMPRESA(numero_empresa, ref as_error);

                    Content.Tipo_Solicitud = DT_CONSULTA_COMPROBANTE.Rows[0][0].ToString();
                    Content.Certificado_base64 = certificado_;
                    Content.Key_base64 = key_;
                    Content.Contraseña = "";
                    Content.Fecha_Inicio = Convert.ToDateTime(row[8].ToString());
                    Content.Fecha_Fin = Convert.ToDateTime(row[9].ToString());
                    Content.Tipo_Comprobante= DT_CONSULTA_COMPROBANTE.Rows[0][0].ToString();
                    Content.RFC_Solicitante = DT_CONSULTA_RFC.Rows[0][2].ToString();
                    Content.RFC_Emisor = DT_CONSULTA_RFC.Rows[0][2].ToString();
                    string st_Enviar_CFDI;
                    switch (tipo_consulta)
                    {

                        case 1:

                           
                            

                                Serializacion = JsonConvert.SerializeObject(Content);
                                Enviar_CFDI = WS_Engine.WS_CONECCION.Solicitud_CFDI(Serializacion, ref as_error);
                                Content_Ent.cadena_resutado = Enviar_CFDI.ToString();
                                var desserializacion = JsonConvert.DeserializeObject<Models.Parametros_Entrada>(Enviar_CFDI);
                                st_Enviar_CFDI = Enviar_CFDI.ToString(); 

                                Update_Estatus = DBs.Sybase.DM_UPDATE_ESTATUS(  Concecutivo_conuslta,
                                                                                Concecutivo_conuslta,
                                                                                Content_Ent.cadena_resutado,
                                                                                st_Enviar_CFDI,
                                                                                Content_Ent.clave_estatus_code,
                                                                                Content_Ent.clace_estatus_message,
                                                                                Content_Ent.estatus_sat,
                                                                                
                                                                                ref as_error
                                                                               );

                            break;

                        case 2:

                            Serializacion = JsonConvert.SerializeObject(Content);
                            Enviar_CFDI = WS_Engine.WS_CONECCION.Solicitud_CFDI(Serializacion, ref as_error);
                           var des_serializacion = JsonConvert.DeserializeObject<Models.Parametros_Entrada>(Enviar_CFDI);
                            Content_Ent.cadena_resutado = Enviar_CFDI.ToString();
                            st_Enviar_CFDI = Enviar_CFDI.ToString();
                          /*
                            Content_Ent.clave_estatus_code = Enviar_CFDI.Rows[0][0].ToString();
                            Content_Ent.clace_estatus_message = Enviar_CFDI.Rows[0][1].ToString();
                            Content_Ent.clave_estatus_code = Enviar_CFDI.Rows[0][2].ToString();
                            Content_Ent.cadena_envio = Enviar_CFDI.Rows[0][3].ToString();
                            Content_Ent.uuid = Enviar_CFDI.Rows[0][4].ToString();
                          */
        /*
                            Update_Estatus = DBs.Sybase.DM_UPDATE_ESTATUS(Concecutivo_conuslta,
                                                                            Concecutivo_conuslta,
                                                                            Content_Ent.cadena_resutado,
                                                                            st_Enviar_CFDI,
                                                                            Content_Ent.clave_estatus_code,
                                                                            Content_Ent.clace_estatus_message,
                                                                            Content_Ent.estatus_sat,

                                                                            ref as_error
                                                                            );
                            break;

                        default:
                            return 0;

                    }
                }

                    return 1;
            }
            catch 
            {
                return 0;
            }
       
        }
        */
    }

}
