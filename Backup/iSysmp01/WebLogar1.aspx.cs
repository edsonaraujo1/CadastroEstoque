using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace iSysmp01
{
    public partial class WebLogar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Browser.Browser.Equals("IE") && Request.Browser.MajorVersion >= 5)
            //{
            //    Response.Write("<table width='304' height='257' border='0' align='center' cellpadding='0' cellspacing='0'>" +
            //                   "<tr><th height='161' scope='col'><img src='imagens/ie_erro.jpg' width='147' height='139'></th>" +
            //                   "</tr><tr><td><div align='center'><p><font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b><font color='#FF0000'>DESCULPE</font></b> por Motivos de Incompatibilidade<br>" +
            //                   "com o IE este sistema n&atilde;o e suportado!!!<br>Utilize outro Navegador<b>.<br>Sugest&atilde;o:<br>" +
            //                   "Chrome, FireFox, Opera </b>ou<b> Safari<br></b>(<b>OBRIGADO !!!</b>)</font></p></div></td></tr></table>");
            //    Response.End();
            //}


            string strCon8 = Application.Get("strConString").ToString();

            //string strCom = "Persist Security Info=False;server=localhost;database=sistema;uid=root;server=localhost;database=sistema;uid=root;pwd=12345";

            string faz_log = Request.QueryString.Get("login");
            string entra_log = Request.QueryString.Get("entra");
            if (entra_log == "Primeiro")
            {
                Session.Clear();
                Session.RemoveAll();
            }


            if (faz_log == "sair")
            {

                // Recupera Sessao
                String strSessao3 = (string)Session["usuarSessa"];
                String nome_3 = strSessao3;
                string sessa_online_minha = "";
                sessa_online_minha = Session.SessionID;

                using (MySqlConnection connection7 = new MySqlConnection(strCon8))
                {
                    MySqlCommand cmd7;
                    connection7.Open();

                    try
                    {
                        cmd7 = connection7.CreateCommand();
                        cmd7.CommandText = "DELETE FROM useronline WHERE sessao = '" + sessa_online_minha + "'";
                        cmd7.ExecuteNonQuery();
                        cmd7.Dispose();

                    }
                    catch (Exception)
                    {

                    }
                    //connection7.Close();
                }
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("WebLogar1.aspx");
                Response.End();

            }
            else
            {

                // Recupera Sessao
                String strSessao3X = (string)Session["usuarSessa"];
                String nome_3X = strSessao3X;
                if (nome_3X == null)
                {
                    Session.Clear();
                    Session.RemoveAll();
                    this.txtnome3.Focus();

                }
                else
                {
                    Response.Redirect("WebSistem1.aspx");
                    Response.End();
                }
            }
        }
        public static string GetMD5Hash(string input)
        {
            // Criptografia em Md5
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            string logindobando = "";
            string senhadobando = "";
            string senha64base = "";
            string senhaMD5 = "";
            string programasbanco = "";
            string contabanco = "";
            string acessobanco = "";
            string hora1banco = "";
            string hora2banco = "";
            string semanabanco = "";
            string tipobanco = "";
            string entradabanco = "";
            string saidabanco = "";

            string retnome_3 = this.txtnome3.Value;
            string retsenh_3 = this.txtpass03.Value;

            string strCon8 = Application.Get("strConString").ToString();

            //string strCom = "Persist Security Info=False;server=localhost;database=sistema;uid=root;server=localhost;database=sistema;uid=root;pwd=12345";

            using (MySqlConnection connection = new MySqlConnection(strCon8))
            {
                MySqlCommand cmd;
                MySqlDataReader dr;
                connection.Open();

                try
                {

                    cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT login,senha2,programas,conta,acesso,hora1,hora2,semana,tipo,entrada,saida FROM tt_ser_01 WHERE login = '" + retnome_3.ToUpper() + "'";

                    dr = cmd.ExecuteReader();

                    // Mostra registros na tela
                    if (dr.Read())
                    {
                        logindobando = dr["login"].ToString();
                        senhadobando = dr["senha2"].ToString();
                        programasbanco = dr["programas"].ToString();
                        contabanco = dr["conta"].ToString();
                        acessobanco = dr["acesso"].ToString();
                        hora1banco = dr["hora1"].ToString();
                        hora2banco = dr["hora2"].ToString();
                        semanabanco = dr["semana"].ToString();
                        tipobanco = dr["tipo"].ToString();
                        entradabanco = dr["entrada"].ToString();
                        saidabanco = dr["saida"].ToString();

                        senha64base = senhadobando;

                        senhaMD5 = GetMD5Hash(this.txtpass03.Value);
                    }


                    if (this.txtnome3.Value.ToUpper() == logindobando && senhaMD5 == senha64base)
                    {

                        // Verificar horario //
                        string hora_atual = DateTime.Now.ToString("HH:mm");
                        DateTime ho_atu = Convert.ToDateTime(hora_atual);

                        string hora_banco = hora1banco;
                        DateTime ho_ban1 = Convert.ToDateTime(hora_banco);

                        string hora_banco2 = hora2banco;
                        DateTime ho_ban2 = Convert.ToDateTime(hora_banco2);

                        // Gravando uma Variavel de Sessao
                        Session["usuarSessa"] = logindobando;
                        Session["senhrSessa"] = senha64base;
                        Session["ID_sessao"] = Session.SessionID;


                        //Verifica se Conta nao esta Bloqueada
                        if (contabanco == "BLOQUEADA")
                        {
                            Response.Redirect("SemBloqueado.aspx");
                            Response.End();
                        }


                        Funcoes1 buscar_semana = new Funcoes1();
                        string buscar_semana2 = buscar_semana.verificadiasemana(logindobando, strCon8);

                        if (buscar_semana2 == "NAO_FAZ")
                        {
                            Response.Redirect("SemPermissao2.aspx");
                            Response.End();
                        }



                        if (ho_atu >= ho_ban1 && ho_atu <= ho_ban2)
                        {
                            //Gravar log de Eventos
                            string ip_log = Request.ServerVariables["Request_ADDR"];
                            string dat_log = DateTime.Now.ToString("d");
                            string hor1_log = DateTime.Now.ToString("HH:mm:ss");
                            string evento_log = "ENTRADA NO SISTEMA";
                            string arquivo_log = Request.ServerVariables["SCRIPT_NAME"];
                            string user_log = retnome_3.ToUpper();

                            if (ip_log == null)
                            {
                                ip_log = "127.0.0.0";
                            }

                            // Regra de Inclusao
                            using (MySqlConnection connection2 = new MySqlConnection(strCon8))
                            {
                                MySqlCommand cmd2;
                                connection2.Open();

                                try
                                {
                                    cmd2 = connection2.CreateCommand();
                                    cmd2.CommandText = "INSERT INTO log_user_event (IP,DATA,EVENTO,HORA,USUARIO,ARQUIVO)" +
                                                                             "VALUES(@ip, @data, @evento, @hora, @usuario, @arquivo)";
                                    cmd2.Parameters.AddWithValue("@ip", ip_log);
                                    cmd2.Parameters.AddWithValue("@data", dat_log);
                                    cmd2.Parameters.AddWithValue("@evento", evento_log);
                                    cmd2.Parameters.AddWithValue("@hora", hor1_log);
                                    cmd2.Parameters.AddWithValue("@usuario", user_log);
                                    cmd2.Parameters.AddWithValue("@arquivo", arquivo_log);
                                    cmd2.ExecuteNonQuery();
                                    cmd2.Dispose();



                                }
                                catch (Exception)
                                {
                                    Response.Write("<br> Não foi Incluido !!!<br>");
                                    //throw;
                                }

                                //connection2.Close();

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
                            string sessa_online = Session.SessionID;

                            string usuario_on = "";
                            string sessao_on = "";
                            string hora_on = "";
                            //string id_on = "";

                            // Regra de Pesquisa
                            using (MySqlConnection connection3 = new MySqlConnection(strCon8))
                            {
                                MySqlCommand cmd3;
                                MySqlDataReader dr3;
                                connection3.Open();

                                try
                                {
                                    cmd3 = connection3.CreateCommand();
                                    cmd3.CommandText = "SELECT usuario,sessao,hora FROM useronline WHERE usuario = '" + user_log + "'";

                                    dr3 = cmd3.ExecuteReader();

                                    if (dr3.Read())
                                    {
                                        usuario_on = dr3["usuario"].ToString();
                                        sessao_on = dr3["sessao"].ToString();
                                        hora_on = dr3["hora"].ToString();
                                        //id_on = dr3["id"].ToString();

                                    }


                                    if (sessao_on == sessa_online)
                                    {
                                        // Entra sem avisar
                                        //Conexao.Open();

                                        using (MySqlConnection connection4 = new MySqlConnection(strCon8))
                                        {
                                            MySqlCommand cmd4;
                                            connection4.Open();

                                            try
                                            {
                                                cmd4 = connection4.CreateCommand();
                                                cmd4.CommandText = "UPDATE useronline SET hora = @hora_on WHERE usuario = '" + user_log.ToUpper() + "' AND sessao = '" + sessao_on + "'";
                                                cmd4.Parameters.AddWithValue("@hora_on", hor_online);
                                                cmd4.ExecuteNonQuery();
                                                cmd4.Dispose();

                                            }
                                            catch
                                            {


                                                // Regra de Inclusao
                                                using (MySqlConnection connection5 = new MySqlConnection(strCon8))
                                                {
                                                    MySqlCommand cmd5;
                                                    connection5.Open();

                                                    try
                                                    {
                                                        cmd5 = connection5.CreateCommand();
                                                        cmd5.CommandText = "INSERT INTO useronline (timestamp,ip,arquivo,data,hora,usuario,sessao)" +
                                                                            "VALUES(@stamp_usr, @ip_usr, @arquivo_usr, @data_usr, @hora_usr, @usuario_usr, @sessao_usr)";
                                                        cmd5.Parameters.AddWithValue("@stamp_usr", time_stampin);
                                                        cmd5.Parameters.AddWithValue("@ip_usr", ip_online);
                                                        cmd5.Parameters.AddWithValue("@arquivo_usr", arq_online);
                                                        cmd5.Parameters.AddWithValue("@data_usr", dat_online);
                                                        cmd5.Parameters.AddWithValue("@hora_usr", hor_online);
                                                        cmd5.Parameters.AddWithValue("@usuario_usr", use_online);
                                                        cmd5.Parameters.AddWithValue("@sessao_usr", sessa_online);
                                                        cmd5.ExecuteNonQuery();
                                                        cmd5.Dispose();

                                                    }
                                                    catch (Exception)
                                                    {
                                                        //Response.Write("<br> Não foi Incluido !!!<br>");
                                                        //throw;
                                                    }

                                                    //connection5.Close();
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        // Consulta de o usuario on-line existe
                                        // Regra de Pesquisa
                                        using (MySqlConnection connection6 = new MySqlConnection(strCon8))
                                        {
                                            MySqlCommand cmd6;
                                            MySqlDataReader dr6;
                                            connection6.Open();

                                            try
                                            {
                                                cmd6 = connection6.CreateCommand();
                                                cmd6.CommandText = "SELECT usuario,sessao,hora FROM useronline WHERE usuario = '" + retnome_3.ToUpper() + "'";

                                                dr6 = cmd6.ExecuteReader();

                                                if (dr6.Read())
                                                {
                                                    usuario_on = dr6["usuario"].ToString();
                                                    sessao_on = dr6["sessao"].ToString();
                                                    hora_on = dr6["hora"].ToString();
                                                    //id_on = dr6["id"].ToString();

                                                }

                                                if (usuario_on != "")
                                                {
                                                    Session["usuarSessa"] = logindobando.ToString();
                                                    Response.Redirect("OutraSessao.aspx");
                                                    Response.End();


                                                }
                                                else
                                                {

                                                    using (MySqlConnection connection5 = new MySqlConnection(strCon8))
                                                    {
                                                        MySqlCommand cmd5;
                                                        connection5.Open();

                                                        try
                                                        {
                                                            cmd5 = connection5.CreateCommand();
                                                            cmd5.CommandText = "INSERT INTO useronline (timestamp,  ip,      arquivo,      data,      hora,      usuario,      sessao)" +
                                                                                               "VALUES(@stamp_usr, @ip_usr, @arquivo_usr, @data_usr, @hora_usr, @usuario_usr, @sessao_usr)";
                                                            cmd5.Parameters.AddWithValue("@stamp_usr", time_stampin);
                                                            cmd5.Parameters.AddWithValue("@ip_usr", ip_online);
                                                            cmd5.Parameters.AddWithValue("@arquivo_usr", arq_online);
                                                            cmd5.Parameters.AddWithValue("@data_usr", dat_online);
                                                            cmd5.Parameters.AddWithValue("@hora_usr", hor_online);
                                                            cmd5.Parameters.AddWithValue("@usuario_usr", use_online);
                                                            cmd5.Parameters.AddWithValue("@sessao_usr", sessa_online);
                                                            cmd5.ExecuteNonQuery();
                                                            cmd5.Dispose();

                                                        }
                                                        catch (Exception)
                                                        {
                                                            //Response.Write("<br> Não foi Incluido !!!<br>");
                                                            //throw;
                                                        }

                                                        //connection5.Close();
                                                    }
                                                    Response.Redirect("WebLogar1.aspx");
                                                    Response.End();
                                                }

                                            }
                                            catch (Exception)
                                            {


                                                //Response.Redirect("OutraSessao.aspx");
                                                //Response.End();
                                                //throw;

                                            }
                                        }

                                    }

                                }
                                catch (Exception)
                                {

                                    //Response.Redirect("OutraSessao.aspx");
                                    //Response.End();

                                    //throw;
                                }
                                //connection3.Close();
                            }


                            //Response.Write("não entrar nesse horario " + ho_atu.ToString("HH:mm"));
                            Response.Redirect("WebSistem1.aspx");
                            Response.End();
                            //throw;

                        }
                        else
                        {
                            //Response.Write("não entrar nesse horario " + ho_atu.ToString("HH:mm"));
                            Response.Redirect("SemPermissao.aspx");
                            Response.End();

                        }
                    }
                    else
                    {
                        lblmensage1.Text = "ERRO: Login ou senha incorretos !!!";
                        this.txtnome3.Focus();
                        //Response.End();
                    }

                }
                catch
                {
                    lblmensage1.Text = "ERRO(1): Não Foi possivel Conectar !!!";
                    //throw;
                }
            }


        }


        
    }
}