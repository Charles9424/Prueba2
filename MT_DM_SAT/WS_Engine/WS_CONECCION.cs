using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MT_DM_SAT.WS_Engine
{
    internal class WS_CONECCION
    {
        /*
        private static string ObtenerResultadoPost(string as_token, string as_url, string as_contenido, ref string as_error) 
        {
            try 
            {
                var return_httpclient = Task.Run(() => MainAsyncPost(as_token, as_url, as_contenido));
                return return_httpclient.Result;    
            }
            catch(Exception ex) 
            { 
                as_error= ex.InnerException+" "+ ex.Message;
                return "";
            }
        }
        private static async Task<string> MainAsyncPost(string as_token, string as_url, string as_contenido) 
        {
            HttpClient clientTest = new HttpClient();
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, as_url);
            httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", as_token);
            httpRequest.Content = new StringContent(as_contenido, Encoding.UTF8, "application/json");

            var response = await clientTest.SendAsync(httpRequest);

            return response.Content.ReadAsStringAsync().Result;
        }

        public static string Solicitud_CFDI(string as_contenido, ref string as_error) 
        {
            string ls_url = "https://172.0.0.0/DESCARGA/MASIVA_CFDI";
            string ls_error = "";
            string ls_resultado = ObtenerResultadoPost("", ls_url, as_contenido, ref ls_error);
            /*byte[] byte_resultado = Convert.FromBase64String(ls_resultado);
            var ls_conversion = Encoding.UTF8.GetString(byte_resultado);  
            var jsonLinq = JsonObject.Parse(ls_conversion);
            return ls_resultado;
        }

        public static string Solicitud_METADATA(string as_contenido)
        {
            string ls_url = "https://172.0.0.0/DESCARGA/MASIVA_METADATA";
            string ls_error = "";
            string ls_resultado = ObtenerResultadoPost("", ls_url, as_contenido, ref ls_error);
            byte[] byte_resultado = Convert.FromBase64String(ls_resultado);
            var ls_conversion = Encoding.UTF8.GetString(byte_resultado);
            var jsonLinq = JsonObject.Parse(ls_conversion);
            return null;
        }
    */
    }

}
