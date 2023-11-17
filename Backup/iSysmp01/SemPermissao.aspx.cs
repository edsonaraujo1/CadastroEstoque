using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSysmp01
{
    public partial class SemPermissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera Sessao
            String strSessao3 = (string)Session["usuarSessa"];
            String strSenha3 = (string)Session["senhrSessa"];

            this.lblusuario.Text = strSessao3;
            this.lblHora1.Text = DateTime.Now.ToString("HH:mm");

            // Apagar Sessao
            Session["usuarSessa"] = "";
            Session["senhrSessa"] = "";
            Session.Clear();
            Session.RemoveAll();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();

            Response.Redirect("WebLogar1.aspx");
            Response.End();

        }
    }
}