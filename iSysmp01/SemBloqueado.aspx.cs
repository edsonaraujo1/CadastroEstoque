using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSysmp01
{
    public partial class SemBloqueado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera Sessao
            String strSessao3 = (string)Session["usuarSessa"];
            this.lblusuario.Text = strSessao3;

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