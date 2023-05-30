using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT.App_Data
{
    internal class Parametros_PFX
    {
        string cer = "";
        string key = "";
        string clavePrivada = "";
        string ArchivoPFX = "";
        string ArchivoKPEM = "";
        string ArchivoCPEM = "";

        public string error = "";
        public string mensajeExito = "";

        public Parametros_PFX(string cer_, string key_, string clavePrivada_, string archivoPfx_, string pathTemp)
        {
            cer = cer_;
            key = key_;
            clavePrivada = clavePrivada_;

            ArchivoKPEM = pathTemp + "k.pem";
            ArchivoCPEM = pathTemp + "c.pem";
            ArchivoPFX = archivoPfx_;

        }

        public bool crearPFX()
        {
            bool exito = false;

            if (!System.IO.File.Exists(cer))
            {
                error = "No exixte el archivo cer en el sistema";
                return false;
            }
            if (!System.IO.File.Exists(key))
            {
                error = "No exixte el archivo key en el sistema";
                return false;
            }

            if (clavePrivada.Trim().Equals(""))
            {
                error = "No existe una clave privada aun en el sistema";
                return false;
            }

            //creamos objetos Process

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            System.Diagnostics.Process proc2= new System.Diagnostics.Process();
            System.Diagnostics.Process proc3 = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc2.EnableRaisingEvents = false;  
            proc3.EnableRaisingEvents = false;

            //openssl x509  -inform DER -in certificado.cer - out certificado.pm
            proc.StartInfo.FileName = "openssl";
            proc.StartInfo.Arguments= "x509 -inform DER -in \"" + cer + "\" -out\"" + ArchivoCPEM + "\"";
            proc.StartInfo.WorkingDirectory = @"C:\Program Files\OpenSSl-Win64\bin\";
            proc.Start();
            proc.WaitForExit();


            proc2.StartInfo.FileName = "openssl";
            proc2.StartInfo.Arguments = "x509 -inform DER -in \"" + key + "\" -out\"" + clavePrivada + "\"";
            proc2.StartInfo.WorkingDirectory = @"C:\Program Files\OpenSSl-Win64\bin\";
            proc2.Start();
            proc2.WaitForExit();


            proc3.StartInfo.FileName = "openssl";
            proc3.StartInfo.Arguments = "x509 -inform DER -in \"" + key + "\" -out\"" + clavePrivada + "\"";
            proc3.StartInfo.WorkingDirectory = @"C:\Program Files\OpenSSl-Win64\bin\";
            proc3.Start();
            proc3.WaitForExit();


            proc.Dispose();
            proc2.Dispose();
            proc3.Dispose();

            if (System.IO.File.Exists(ArchivoPFX)) 
            mensajeExito = "Se ha creado el archivo PFX";
            else
            {
                error = "Error al crear archivo pfx";
                if(System.IO.File.Exists(ArchivoCPEM)) System.IO.File.Delete(ArchivoCPEM);
                if (System.IO.File.Exists(ArchivoKPEM)) System.IO.File.Delete(ArchivoKPEM);

            }

            if (System.IO.File.Exists(ArchivoCPEM)) System.IO.File.Delete(ArchivoCPEM);
            if (System.IO.File.Exists(ArchivoKPEM)) System.IO.File.Delete(ArchivoKPEM);

            return true;


        }

    }
}
