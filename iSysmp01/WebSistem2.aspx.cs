using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSysmp01
{
    public partial class WebSistem2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String strSessao3 = (string)Session["usuarSessa"];
            String nome_3 = strSessao3;
            // *** Inicio da rotina de verificação

            if (nome_3 == null)
            {

                nome_3 = "";
                Response.Redirect("WebLogar1.aspx");
                Response.End();

            }


        }
    }
}