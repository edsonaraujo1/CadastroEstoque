using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace iSysmp01
{
    public partial class WebUsuarios : System.Web.UI.Page
    {
        private string strConx()
        {
            return Application.Get("strConString").ToString();
        }

        private string strNomeUser()
        {
            String strSessao3 = (string)Session["usuarSessa"];
            String nome_3 = strSessao3;

            return nome_3;
        }
        private string strPassUser()
        {
            String strSenha3 = (string)Session["senhrSessa"];
            string pass_03 = strSenha3;
            return pass_03;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string tabelaper = "tt_ser_01";
            String Form_user = "WebUsuarios";

            // *** Inicio da rotina de verificação
            String nome_3 = strNomeUser();
            if (nome_3 == null)
            {
                nome_3 = "";
                Response.Redirect("WebLogar1.aspx");
                Response.End();
            }
            else
            {

                // Verifica se Usuario tem permissao para uso

                // *****************************************************************************************
                string nodo_Form = Form_user;   // <<< **** Não esquecer de colocar o nome do Form **** >>>
                // *****************************************************************************************

                Funcoes1 busca_pro = new Funcoes1();
                string busca_pro1 = busca_pro.progr_user(nodo_Form, nome_3, strConx());

                if (busca_pro1 == "NAO_FAZ")
                {
                    Response.Redirect("Acessedenied.aspx");
                    Response.End();
                }

                // Verificar quais botoes pode ser usado

                string per_1 = "";
                string per_2 = "";
                string per_3 = "";
                string per_4 = "";

                // ******  Inicio da Busca do Programa
                using (MySqlConnection connection6 = new MySqlConnection(strConx()))
                {
                    MySqlCommand cmd6;
                    MySqlDataReader dr6;
                    connection6.Open();
                    try
                    {
                        cmd6 = connection6.CreateCommand();
                        cmd6.CommandText = "SELECT * FROM permissoes WHERE login = '" + nome_3 + "' AND tabela = '" + tabelaper.ToUpper() + "'";
                        dr6 = cmd6.ExecuteReader();

                        if (dr6.Read())
                        {
                            per_1 = dr6["incluir"].ToString();
                            per_2 = dr6["alterar"].ToString();
                            per_3 = dr6["excluir"].ToString();
                            per_4 = dr6["imprimir"].ToString();
                        }

                        if (per_1 == "SIM") { this.Incluir.Enabled = true; }
                        if (per_2 == "SIM") { this.Alterar.Enabled = true; }
                        if (per_3 == "SIM") { this.Excluir.Enabled = true; }
                        if (per_4 == "SIM") { this.Imprimir1.Enabled = true; }
                    }
                    catch { }
                }
                // Fim da Verificacao dos botoes

            }

            if (!Page.IsPostBack)
            {

                // Consulta para voltar a mesma tela

                if (Request.QueryString["codigo"] != null)
                {
                    this.Fotoprod1.Enabled = true;

                    string cod_ret = "";
                    cod_ret = Request.QueryString["codigo"];

                    String query = "";
                    query = "SELECT * FROM tt_ser_01 WHERE login = '" + cod_ret + "'";


                    using (MySqlConnection con = new MySqlConnection(strConx()))
                    {
                        MySqlDataReader dr;
                        MySqlCommand command = con.CreateCommand();
                        command.CommandText = query;

                        try
                        { con.Open(); }
                        catch { }

                        try
                        {

                            dr = command.ExecuteReader();
                            // Mostra registros na tela
                            if (dr.Read())
                            {

                                this.txtid.Value = dr["id"].ToString();
                                this.txtlogin.Text = dr["login"].ToString();
                                this.txtsenha.Text = dr["senha2"].ToString();
                                this.txtData.Text = dr["data"].ToString();
                                this.txtNome.Value = dr["nome_l"].ToString();
                                this.txtMaquina.Value = dr["maquina"].ToString();
                                this.txtConta.ClearSelection();
                                this.txtConta.Items.Insert(0, dr["conta"].ToString());
                                this.txtPrograma.Value = dr["programas"].ToString();
                                this.txtHora1.Value = dr["hora1"].ToString();
                                this.txtHora2.Value = dr["hora2"].ToString();
                                this.txtTipo.ClearSelection();
                                this.txtTipo.Items.Insert(0, dr["tipo"].ToString());
                                this.txtSemana.Value = dr["semana"].ToString();
                                this.txtEmail.Value = dr["e_mail"].ToString();
                                this.txtfoto1.ImageUrl = dr["foto"].ToString();

                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    this.Fotoprod1.Enabled = false;
                }
            }

        }

        protected void Fotoprod1_Click(object sender, EventArgs e)
        {

        }

        protected void Imprimir1_Click(object sender, EventArgs e)
        {

        }

        protected void Lista_Click(object sender, EventArgs e)
        {
            Response.Redirect("GridUsuarios.aspx?codigo=" + this.txtid.Value);
        }

        protected void Excluir_Click1(object sender, EventArgs e)
        {

        }

        protected void Alterar_Click(object sender, EventArgs e)
        {

        }

        protected void Incluir_Click(object sender, EventArgs e)
        {


            this.txtData.Text = DateTime.Now.ToString("d");
            this.Salvar.Visible = true;
            this.Incluir.Visible = false;
            this.Excluir.Enabled = false;
            this.Alterar.Enabled = false;

            this.Cancelar.Visible = true;
            this.Salvar.Visible = true;

            this.Limpar.Visible = false;
            this.Lista.Enabled = false;
            this.Consulta.Enabled = false;
            this.Inicio.Enabled = false;
            this.Proximo.Enabled = false;
            this.Anterior.Enabled = false;
            this.Fim.Enabled = false;
            this.Imprimir1.Enabled = false;
            this.Fotoprod1.Enabled = false;

            this.lblmensagem1.Text = "";
            this.lblmodulo1.Text = "Inclusão";


        }

        protected void Salvar_Click(object sender, EventArgs e)
        {

            if (ValidarEmail(txtEmail.Value) == false)
            {
                this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Email com formato incorreto!</font>";
            }
            else
            {
                this.lblmensagem1.Text = "";
            }
        }

        protected void Consulta_Click(object sender, EventArgs e)
        {
            this.lblmensagem1.Text = "";
            String query = "";

            if (this.txtlogin.Text != "")
            {
                query = "SELECT * FROM tt_ser_01 WHERE login = '" + this.txtlogin.Text + "'";
            }

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                { con.Open(); }
                catch
                { this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>"; }

                try
                {
                    dr = command.ExecuteReader();
                    // Mostra registros na tela
                    if (dr.Read())
                    {

                        this.txtid.Value = dr["id"].ToString();
                        this.txtlogin.Text = dr["login"].ToString();
                        this.txtsenha.Text = dr["senha2"].ToString();
                        this.txtData.Text = dr["data"].ToString();
                        this.txtNome.Value = dr["nome_l"].ToString();
                        this.txtMaquina.Value = dr["maquina"].ToString();
                        this.txtConta.ClearSelection();
                        this.txtConta.Items.Insert(0, dr["conta"].ToString());
                        this.txtPrograma.Value = dr["programas"].ToString();
                        this.txtHora1.Value = dr["hora1"].ToString();
                        this.txtHora2.Value = dr["hora2"].ToString();
                        this.txtTipo.ClearSelection();
                        this.txtTipo.Items.Insert(0, dr["tipo"].ToString());
                        this.txtSemana.Value = dr["semana"].ToString();
                        this.txtEmail.Value = dr["e_mail"].ToString();
                        this.txtfoto1.ImageUrl = dr["foto"].ToString();

                    }

                    if (dr.HasRows)
                    { }
                    else
                    {
                        limpa_campos();
                        this.lblmensagem1.Text = "<font color='#FF0000'>Regitro não Encontrado !!!</font>";
                    }
                }
                catch
                {

                    limpa_campos();
                    this.lblmensagem1.Text = "<font color='#FF0000'>Regitro não Encontrado !!!</font>";
                }

            }

        }

        protected void Inicio_Click(object sender, EventArgs e)
        {

        }

        protected void Anterior_Click(object sender, EventArgs e)
        {

        }

        protected void Proximo_Click(object sender, EventArgs e)
        {

        }

        protected void Fim_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Limpar_Click(object sender, EventArgs e)
        {
            limpa_campos();

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar.Visible = false;
            this.Salvar.Visible = false;

            this.Limpar.Visible = true;
            this.Lista.Enabled = true;
            this.Consulta.Enabled = true;
            this.Inicio.Enabled = true;
            this.Proximo.Enabled = true;
            this.Anterior.Enabled = true;
            this.Fim.Enabled = true;
            this.Imprimir1.Enabled = true;
            this.Incluir.Visible = true;
            this.Fotoprod1.Enabled = false;
            this.lblmensagem1.Text = "";
            this.lblmodulo1.Text = "";
            this.txtData.Text = "";
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebSistem8.aspx");
        }

        public void limpa_campos()
        {
            this.lblmensagem1.Text = "";
            this.txtid.Value = "";
            this.txtlogin.Text = "";
            this.txtsenha.Text = "";
            this.txtData.Text = "";
            this.txtNome.Value = "";
            this.txtMaquina.Value = "";
            this.txtConta.ClearSelection();
            this.txtConta.Items.Clear();
            this.txtConta.Items.Insert(0, "");
            this.txtPrograma.Value = "";
            this.txtHora1.Value = "";
            this.txtHora2.Value = "";
            this.txtTipo.ClearSelection();
            this.txtTipo.Items.Clear();
            this.txtTipo.Items.Insert(0, "");
            this.txtSemana.Value = "";
            this.txtEmail.Value = "";
            this.txtfoto1.ImageUrl = "";
            this.Fotoprod1.Enabled = false;


        }


        //Validar Email
        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Fotoprod1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CapturaUser.aspx?produto=" + this.txtlogin.Text + "&inf=" + this.txtid.Value);
        }
    }
}