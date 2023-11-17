using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSysmp01
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera Sessao
            String strSessao3 = (string)Session["usuarSessa"];
            String nome_3 = strSessao3;
            if (nome_3 == null)
            {
                nome_3 = "";
                Response.Redirect("WebLogar1.aspx");
                Response.End();

            }
            else
            {

                this.lblUsuario_adm.Text = strSessao3;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebSistem8.aspx");
        }

    }
}