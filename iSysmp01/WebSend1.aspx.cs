using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace iSysmp01
{
    public partial class WebSend1 : System.Web.UI.Page
    {
        private string strConx()
        {
            return Application.Get("strConString").ToString();
        }

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

                CarregaCombo();

            }

        }
        public void CarregaCombo()
        {

            String queryx = "";

            queryx = "SELECT usuario FROM useronline ORDER BY usuario ASC";

            using (MySqlConnection conx = new MySqlConnection(strConx()))
            {
                MySqlCommand cmdx = new MySqlCommand(queryx, conx);
                MySqlDataReader drx;
                conx.Open();

                drx = cmdx.ExecuteReader();

                if (drx.HasRows)
                {

                    this.txtUsuarios.ClearSelection();
                    this.txtUsuarios.DataSource = drx;
                    this.txtUsuarios.DataTextField = "usuario";
                    this.txtUsuarios.DataValueField = "usuario";
                    this.txtUsuarios.DataBind();
                    this.txtUsuarios.Items.Insert(0, "-- Selecione o Usuário --");

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebSistem8.aspx");
        }

    }
}