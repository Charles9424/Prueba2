using AdoNetCore.AseClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT.App_Data
{
    internal class Proc_Engine
    {
        public int DMSAT(App_DB.Query oQuerys, decimal adec_consecutivo_consulta, ref string res_error)
        {
            try
            {
                Models.Parametros_Envio Content = new Models.Parametros_Envio();
                Models.Parametros_Entrada Content_Ent = new Models.Parametros_Entrada();

                string Serializacion = null;
                string Enviar_CFDI = null;
                DataTable oDT_CONSULTA_FIELD = null;
                DataTable oDT_CONSULTA_COMPROBANTE = null;
                DataTable oDT_CONSULTA_PFX = null;
                DataTable oDT_CONSULTA_RFC = null;
                DataTable oDT_Update_Estatus = null;
                App_Data.WS_DM oWs = new App_Data.WS_DM();
                string ruta= "C:\\Users\\CarlosGo\\Desktop\\Carpeta prueba\\";


                DataTable oDT_CONSULTA_PARAMETROS = oQuerys.DMSAT_CONSULTA(adec_consecutivo_consulta, ref res_error);
                foreach (DataRow oDR_CONSULTA_P in oDT_CONSULTA_PARAMETROS.Rows)
                {
                    int li_tipo_consulta = Convert.ToInt32(oDR_CONSULTA_P[1]);
                    string ls_numer_empresa = oDR_CONSULTA_P[4].ToString();

                    
                    //OBTIENE EL CERTIFICADO Y KEY
                    oDT_CONSULTA_FIELD = oQuerys.CONSULTA_FIELD(ls_numer_empresa, ref res_error);
                    string ls_key_ = oDT_CONSULTA_FIELD.Rows[0][0].ToString();
                    string ls_cert_ = oDT_CONSULTA_FIELD.Rows[0][1].ToString();

                    byte[] Certificado_byte = Convert.FromBase64String(ls_key_);
                    System.IO.File.WriteAllBytes(ruta +"Certificado.cer", Certificado_byte);

                    byte[] key_byte = Convert.FromBase64String(ls_key_);
                    System.IO.File.WriteAllBytes(ruta + "Key.key", key_byte);



                    // OBTIENE EL ARCHIVO PFX
                    oDT_CONSULTA_PFX = oQuerys.CONSULTA_PFX(ls_numer_empresa, ref res_error);

                    string ls_pfx = oDT_CONSULTA_PFX.Rows[0][0].ToString() ;

                    //OBTIENE EL TIPO DE COMPROBANTE
                    oDT_CONSULTA_COMPROBANTE = oQuerys.DM_CONSULTA_COMPROBANTE(Convert.ToDecimal(oDR_CONSULTA_P[10]), ref res_error);

                    Content.Contrasena = "VAR921119BY";
                   // Content.Contrasena = "var921119by";

                    //OBTENER EL RFC Y NOMBRE DE LA EMPRESA

                    oDT_CONSULTA_RFC = oQuerys.DM_CONSLTA_EMPRESA(ls_numer_empresa, ref res_error);

                    
                    Content.Tipo_Solicitud = oDT_CONSULTA_COMPROBANTE.Rows[0][0].ToString();
                    Content.Certificado_base64 = ls_cert_;
                     Content.Key_base64 = ls_key_;
                   /* App_Data.Parametros_PFX oPfx = new App_Data.Parametros_PFX(ruta+"Certificado.cer", ruta+"Key.key", Content.Contrasena, ruta+ "PFX.pfx", ruta);
                    
                    if (!oPfx.crearPFX())
                    {
                        string err = "err";
                    }
                    
                    */

                    /*
                    //byte[] Pfx_Byte = System.IO.File.ReadAllBytes("C:\\Users\\CarlosGo\\Desktop\\Carpeta prueba\\PFX.pfx");
                    //Content.Pfx_base64 = Convert.ToBase64String(Pfx_Byte);
                    //Content.Pfx_base64 = ls_pfx;
                    */

                    Content.Fecha_Inicio =  Convert.ToDateTime(oDR_CONSULTA_P[8]);
                    Content.Fecha_Fin = Convert.ToDateTime(oDR_CONSULTA_P[9]);
                    Content.Tipo_Comprobante = oDT_CONSULTA_COMPROBANTE.Rows[0][0].ToString();
                    Content.RFC_Solicitante = oDT_CONSULTA_RFC.Rows[0][2].ToString();
                    Content.RFC_Receptor = oDT_CONSULTA_RFC.Rows[0][2].ToString();
                    string st_Enviar_CFDI;

                    switch (li_tipo_consulta)
                    {

                        case 1:
                            Content.Tipo_Solicitud = "CFDI";
                            // SERIALIZA EL CONTENIDO 
                            Serializacion = JsonConvert.SerializeObject(Content);
                            // ENVIA SERIALIZADO A A WEB-SERVICES
                             string ls_respuesta_Ws = oWs.Solicitud_CFDI(Serializacion, ref res_error);
                            Content_Ent.cadena_resutado = ls_respuesta_Ws.ToString();
                            var desserializacion = JsonConvert.DeserializeObject<Models.Parametros_Entrada>(ls_respuesta_Ws);
                            st_Enviar_CFDI = ls_respuesta_Ws.ToString();
                            // SE ACTUALIZA EL ESTATUS
                            oDT_Update_Estatus = oQuerys.DM_UPDATE_ESTATUS(adec_consecutivo_consulta,adec_consecutivo_consulta,
                                                                                Content_Ent.cadena_resutado,st_Enviar_CFDI,
                                                                                Content_Ent.clave_estatus_code, Content_Ent.clace_estatus_message,
                                                                                Content_Ent.estatus_sat,ref res_error
                                                                               );
                            break;
                        case 2:
                            Content.Tipo_Solicitud = "METADATA";
                            // SERIALIZA EL CONTENIDO 
                            Serializacion = JsonConvert.SerializeObject(Content);
                            // ENVIA SERIALIZADO A A WEB-SERVICES

                            ls_respuesta_Ws = oWs.Solicitud_METADATA(Serializacion, ref res_error);
                            st_Enviar_CFDI = Enviar_CFDI.ToString();
                            Content_Ent.cadena_resutado = ls_respuesta_Ws.ToString();
                            desserializacion = JsonConvert.DeserializeObject<Models.Parametros_Entrada>(ls_respuesta_Ws);
                            st_Enviar_CFDI = ls_respuesta_Ws.ToString();
                            // SE ACTUALIZA EL ESTATUS
                            oDT_Update_Estatus = oQuerys.DM_UPDATE_ESTATUS(adec_consecutivo_consulta, adec_consecutivo_consulta,
                                                                            Content_Ent.cadena_resutado, st_Enviar_CFDI,
                                                                            Content_Ent.clave_estatus_code, Content_Ent.clace_estatus_message,
                                                                            Content_Ent.estatus_sat,  ref res_error
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
    }
}
