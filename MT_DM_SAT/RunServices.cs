using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MT_DM_SAT
{
    partial class RunServices : ServiceBase
    {
        AutoResetEvent StopRequest = new AutoResetEvent(false);
        public Thread oThread = null;
        public RunServices()
        {
            ServiceName = "ENGINE_DM_CFDI_DES";
        }

        protected override void OnStart(string[] args)
        {
            /**--ENGINE WEBSERVICE--**/
            //ThreadStart start = new ThreadStart(ENGINE_WS);

            /**----**/
            ThreadStart start = new ThreadStart(ENGINE_CREATE);
            oThread = new Thread(start);
            oThread.Start();
        }

        public void ENGINE_CREATE()
        {
            int li_sleep = (1000 * 60);
            li_sleep = li_sleep * 60;
            li_sleep = li_sleep*60;
            li_sleep = li_sleep * 12;
            try
            {
                do
                {
                    App_Data.Engine OEngine = new App_Data.Engine();
                    OEngine.Start();
                    Thread.Sleep(li_sleep);

                }while(1==1);
            }
            catch (Exception Ex)
            {
                return;
            }
        }


        protected override void OnStop()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void OnDebug()
        {
            OnStart(null);
        }
    }
}
