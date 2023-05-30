
using MT_DM_SAT;
using System;
using System.ServiceProcess;


namespace EngineDM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new RunServices())
            {
                //ServiceBase.Run(service); //PROD
                
                service.OnDebug();  //DESS

            }
        }
    }



}