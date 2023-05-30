using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT.Models
{
    internal class Parametros_Envio
    {
        public string Certificado_base64 { get; set; }  
        public string Key_base64 { get; set; }

       // public string Pfx_base64 { get; set; }
        public string Contrasena { get; set; }
        public DateTime? Fecha_Inicio { get; set; }  
        public DateTime? Fecha_Fin {  get; set; }
        public string Tipo_Solicitud { get; set; }
        public string Tipo_Comprobante { get; set; }    
        public string RFC_Emisor { get; set; }
        public string RFC_Receptor { get; set; }
        public string RFC_Solicitante { get; set; }
        public string RFC_Terceros { get; set; }
        public string Usuario { get; set; }
        public string Maquina { get; set;}

    }
}
