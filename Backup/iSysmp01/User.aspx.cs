using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace iSysmp01
{
    public partial class User : System.Web.UI.Page
    {
        private string strConx()
        {
            return Application.Get("strConString").ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera Sessao
            String strSessao3 = (string)Session["usuarSessa"];
            String ID_Sessao = (string)Session["ID_sessao"];
            String nome_3 = strSessao3;
            if (nome_3 == null)
            {
                nome_3 = "";
                this.lbluser_online.Text = "off-line";

            }
            else
            {

                using (MySqlConnection connection8 = new MySqlConnection(strConx()))
                {
                    MySqlCommand cmd8;
                    MySqlDataReader dr8;
                    connection8.Open();
                    int conta_2 = 0;
                    try
                    {
                        cmd8 = connection8.CreateCommand();
                        cmd8.CommandText = "SELECT * FROM useronline";

                        dr8 = cmd8.ExecuteReader();

                        while (dr8.Read())
                        {
                            conta_2 = conta_2 + 1;
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                    }

                    //connection8.Close();

                    //int conta = +1;
                    this.lbluser_online.Text = conta_2 + " Usuario(s) on-line";
                }
                // Verifica se a Sessao Expirou 
                string hora_atual4 = DateTime.Now.ToString("HH:mm:ss");
                DateTime hora_sistem = Convert.ToDateTime(hora_atual4);

                using (MySqlConnection connection6 = new MySqlConnection(strConx()))
                {
                    MySqlCommand cmd6;
                    MySqlDataReader dr6;
                    connection6.Open();

                    try
                    {
                        cmd6 = connection6.CreateCommand();
                        cmd6.CommandText = "SELECT hora,usuario,sessao FROM useronline";

                        dr6 = cmd6.ExecuteReader();

                        while (dr6.Read())
                        {
                            string hora_bb = dr6["hora"].ToString();
                            string nom_bb = dr6["usuario"].ToString();
                            //string id_bb = dr6["id"].ToString();
                            //int id_bb2 = Convert.ToInt32(id_bb);

                            string hora_banco4 = dr6["hora"].ToString();
                            DateTime hora_Sql = Convert.ToDateTime(hora_banco4);

                            TimeSpan diff = hora_Sql - hora_sistem;

                            // Verificar numero de Horas
                            string hor_2 = diff.TotalHours.ToString();
                            decimal hor_3 = Convert.ToDecimal(hor_2);
                            int hor_4 = (int)hor_3;
                            int hor_5 = Math.Abs(hor_4);

                            if (hor_5 > 2)
                            {
                                MySqlConnection connection7 = new MySqlConnection(strConx());
                                MySqlCommand cmd7;
                                connection7.Open();

                                try
                                {
                                    cmd7 = connection7.CreateCommand();
                                    cmd7.CommandText = "DELETE FROM useronline WHERE usuario = '" + nom_bb + "'";
                                    cmd7.ExecuteNonQuery();
                                    cmd7.Dispose();

                                }
                                catch (Exception)
                                {

                                }
                                connection7.Close();
                            }
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
                //connection6.Close();

                string sessa_online = "";
                //sessa_online = String.Format("Session ID: {0}", Session.SessionID);
                sessa_online = Session.SessionID;
                //sessa_online = Request.ServerVariables["cookies"];
                string se_comp = "";
                string id_sess = "";
                // Verificar se a Sessao e igual
                using (MySqlConnection connection9 = new MySqlConnection(strConx()))
                {
                    MySqlCommand cmd9;
                    MySqlDataReader dr9;
                    connection9.Open();

                    try
                    {
                        cmd9 = connection9.CreateCommand();
                        cmd9.CommandText = "SELECT sessao,usuario FROM useronline WHERE usuario = '" + nome_3 + "'";

                        dr9 = cmd9.ExecuteReader();

                        if (!dr9.Read())
                        {
                            // Registro nao existe

                            string ip_log = Request.ServerVariables["Request_ADDR"];
                            string dat_log = DateTime.Now.ToString("d");
                            string hor1_log = DateTime.Now.ToString("HH:mm:ss");
                            //string evento_log = "ENTRADA NO SISTEMA";
                            string arquivo_log = Request.ServerVariables["SCRIPT_NAME"];
                            string user_log = nome_3.ToUpper();


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

                            long time_stampin = DateTime.Now.Ticks;
                            string ip_online = ip_log;
                            string arq_online = arquivo_log;
                            string dat_online = dat_log;
                            string hor_online = hor1_log;
                            string use_online = user_log;

                            //string usuario_on = "";
                            //string sessao_on = "";
                            //string hora_on = "";
                            //string id_on = "";

                            // Regra de Inclusao
                            using (MySqlConnection connection10 = new MySqlConnection(strConx()))
                            {
                                MySqlCommand cmd10;
                                connection10.Open();

                                try
                                {
                                    cmd10 = connection10.CreateCommand();
                                    cmd10.CommandText = "INSERT INTO useronline (timestamp,ip,arquivo,data,hora,usuario,sessao)" +
                                                        "VALUES(@stamp_usr, @ip_usr, @arquivo_usr, @data_usr, @hora_usr, @usuario_usr, @sessao_usr)";
                                    cmd10.Parameters.AddWithValue("@stamp_usr", time_stampin);
                                    cmd10.Parameters.AddWithValue("@ip_usr", ip_online);
                                    cmd10.Parameters.AddWithValue("@arquivo_usr", arq_online);
                                    cmd10.Parameters.AddWithValue("@data_usr", dat_online);
                                    cmd10.Parameters.AddWithValue("@hora_usr", hor_online);
                                    cmd10.Parameters.AddWithValue("@usuario_usr", use_online);
                                    cmd10.Parameters.AddWithValue("@sessao_usr", sessa_online);
                                    cmd10.ExecuteNonQuery();
                                    cmd10.Dispose();

                                }
                                catch (Exception)
                                {
                                    //Response.Write("<br> Não foi Incluido !!!<br>");
                                    //throw;
                                }

                                //connection5.Close();
                            }




                            //Response.Redirect("Menssagem1.aspx");
                            //Response.End();
                            //Response.Write("Registro não Existe !! <br>");

                        }
                        else
                        {

                            id_sess = dr9["usuario"].ToString();
                            se_comp = dr9["sessao"].ToString();

                            if (se_comp == sessa_online)
                            {
                                //Response.Write("Sessao e igual !! <br>");
                            }
                            else
                            {
                                //Response.Write("Sessao nao e igual !! <br>");
                                string dat_a = DateTime.Now.ToString("d");
                                String sNomefunction = "Mensagem";
                                String sScript = "alert('Ola..." + nome_3 + " Voce entrou no Sistema em outro Computador isso pode interferir no uso do Sistema Sua Sessao neste Micro sera ENCERRADA em " + dat_a + "')";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), sNomefunction, sScript, true);


                                // verificar se eu quero ou nao manter a sessao



                                //Session.Clear();
                                //Session.RemoveAll();

                                //Response.Redirect("Menssagem1.aspx");
                                //Response.End();

                            }

                        }


                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                }
                //connection9.Close();



            }

        }
    }
}