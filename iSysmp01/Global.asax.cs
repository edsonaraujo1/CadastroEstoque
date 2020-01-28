using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace iSysmp01
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            // Classe de String de Conexao
            string w_SERVER;
            string w_DATA;
            string w_USER;
            string w_PASS;
            string w_LOCAL;
            int itipo = 0;

            w_SERVER = "";
            w_DATA = "";
            w_USER = "";
            w_PASS = "";
            w_LOCAL = "";

            itipo = 1;

            if (itipo == 1)
            {
                w_SERVER = "192.168.1.61";
                w_DATA = "sistema";
                w_USER = "sindificios";
                w_PASS = "@12XLSIN_!?";
                w_LOCAL = "Rede";
            }
            else
            {
                w_SERVER = "localhost";
                w_DATA = "sistema";
                w_USER = "root";
                w_PASS = "12345";
                w_LOCAL = "Local";
            }

            string strCom = ("Persist Security Info=False;server=" + w_SERVER.ToString() + ";database=" + w_DATA.ToString() + ";uid=" + w_USER.ToString() + ";server=" + w_SERVER.ToString() + ";database=" + w_DATA.ToString() + ";uid=" + w_USER.ToString() + ";pwd=" + w_PASS.ToString() + "");

            Application["strConString"] = strCom;

            Application["ambiente"] = w_LOCAL.ToString();
 

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
