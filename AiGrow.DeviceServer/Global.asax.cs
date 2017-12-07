using System;
using System.Threading;

namespace AiGrow.DeviceServer
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //  new MQTTHandler().Subscribe();

            new Thread(delegate()
            {
                new MQTTHandler().Initiate();
            }).Start();

            //new Thread(delegate()
            //{
            //    new NewMQTT().Initiate();
            //}).Start();

            // new MQTTHandler().Subscribe();        
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}