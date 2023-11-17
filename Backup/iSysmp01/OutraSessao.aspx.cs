using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace iSysmp01
{
    public partial class OutraSessao : System.Web.UI.Page
    {
        private string strConx()
        {
            return Application.Get("strConString").ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera Sessao
            string strSessao3 = (string)Session["usuarSessa"];
            lblnome_33.Text = strSessao3;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Recupera Sessao
            String strSessao3 = (string)Session["usuarSessa"];
            String ID_Sessao = (string)Session["ID_sessao"];
            String nome_3 = strSessao3;


            MySqlConnection connection10 = new MySqlConnection(strConx());
            MySqlCommand cmd10;
            connection10.Open();
            //int id_ss_bb2 = Convert.ToInt32(id_ss_bb);
            try
            {
                cmd10 = connection10.CreateCommand();
                cmd10.CommandText = "DELETE FROM useronline WHERE usuario = '" + nome_3 + "'";
                cmd10.ExecuteNonQuery();
                cmd10.Dispose();

            }
            catch (Exception)
            {

            }
            connection10.Close();

            //Gravar log de Eventos
            string ip_log = Request.ServerVariables["Request_ADDR"];
            string dat_log = DateTime.Now.ToString("d");
            string hor1_log = DateTime.Now.ToString("HH:mm:ss");
            //string evento_log = "ENTRADA NO SISTEMA";
            string arquivo_log = Request.ServerVariables["SCRIPT_NAME"];
            string user_log = nome_3;

            if (ip_log == null)
            {
                ip_log = "127.0.0.0";
            }
            // Grava Usuario on-line logado em Sessao
            string t1 = DateTime.Now.ToString("HH:mm:ss");
            DateTime t2 = Convert.ToDateTime(t1);
            string ti1 = t2.TimeOfDay.Ticks.ToString();
            //string time_stampin = ti1.ToString();
            //int time_stampin2 = Convert.ToInt32(time_stampin);
            string hora_par = DateTime.Now.ToString("HH:mm:ss");
            var parse1 = TimeSpan.Parse(hora_par);

            int time_stampin = 1235465480;
            string ip_online = ip_log;
            string arq_online = arquivo_log;
            string dat_online = dat_log;
            string hor_online = hor1_log;
            string use_online = user_log;
            string sessa_online = ID_Sessao;

            // Inclusao nova Sessao de Usuario
            MySqlConnection connection6 = new MySqlConnection(strConx());
            MySqlCommand cmd6;
            connection6.Open();

            try
            {
                cmd6 = connection6.CreateCommand();
                cmd6.CommandText = "INSERT INTO useronline (timestamp,ip,arquivo,data,hora,usuario,sessao)" +
                                    "VALUES(@stamp_usr, @ip_usr, @arquivo_usr, @data_usr, @hora_usr, @usuario_usr, @sessao_usr)";
                cmd6.Parameters.AddWithValue("@stamp_usr", time_stampin);
                cmd6.Parameters.AddWithValue("@ip_usr", ip_online);
                cmd6.Parameters.AddWithValue("@arquivo_usr", arq_online);
                cmd6.Parameters.AddWithValue("@data_usr", dat_online);
                cmd6.Parameters.AddWithValue("@hora_usr", hor_online);
                cmd6.Parameters.AddWithValue("@usuario_usr", use_online);
                cmd6.Parameters.AddWithValue("@sessao_usr", sessa_online);
                cmd6.ExecuteNonQuery();
                cmd6.Dispose();

            }
            catch (Exception)
            {
                //Response.Write("<br> Não foi Incluido !!!<br>");
                //throw;
            }

            connection6.Close();

            Response.Redirect("WebSistem1.aspx");
            Response.End();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("WebLogar1.aspx");
            Response.End();

        }
    }
}