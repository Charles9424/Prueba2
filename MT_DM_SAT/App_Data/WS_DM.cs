using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT.App_Data
{
    internal class WS_DM
    {
        private string Post(string as_url, string as_content, ref  string ras_error) 
        {
            string ls_return = Task.Run(() => AsynPost(as_url, as_content )).Result;
            if(String.IsNullOrEmpty(ls_return) )
            {
                ras_error = "No se obtuvo respuesta de WS DOMUS.Params";
                return null;
            }
            return ls_return;
        }   
        private async Task<string> AsynPost(string as_url, string as_content)
        {
            HttpClient oHttpClient = new HttpClient();
            HttpRequestMessage oHttpRequest = new HttpRequestMessage(HttpMethod.Post, as_url);
            oHttpRequest.Content = new StringContent(as_content, Encoding.UTF8, "application/json");
            var response = await oHttpClient.SendAsync(oHttpRequest);
            return response.Content.ReadAsStringAsync().Result;
        }

        public string Solicitud_CFDI(string as_contenido, ref string as_error)
        {
            string ls_url = "http://172.16.72.120/WS_DESCARGA_MASIVA/DESCARGA/MASIVA_CFDI";
            string ls_error = "";
            string ls_resultado = Post(ls_url, as_contenido , ref ls_error);
            /*byte[] byte_resultado = Convert.FromBase64String(ls_resultado);
            var ls_conversion = Encoding.UTF8.GetString(byte_resultado);  
            var jsonLinq = JsonObject.Parse(ls_conversion);*/
            return ls_resultado;
        }

        public string Solicitud_METADATA(string as_contenido, ref string as_error)
        {
            string ls_url = "http://172.16.72.120/WS_DESCARGA_MASIVA/DESCARGA/MASIVA_METADATA";
            string ls_error = "";
            string ls_resultado = Post(ls_url, as_contenido, ref ls_error);
            /*byte[] byte_resultado = Convert.FromBase64String(ls_resultado);
            var ls_conversion = Encoding.UTF8.GetString(byte_resultado);  
            var jsonLinq = JsonObject.Parse(ls_conversion);*/
            return ls_resultado;
        }



    }
}
