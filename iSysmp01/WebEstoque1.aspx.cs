using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace iSysmp01
{
    public partial class WebEstoque1 : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {

                if (this.txtidforne.Value == "")
                {

                    CarregaCombo();

                }


            }
            string tabelaper = "Estoque";
            String Form_user = "WebForm3";

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

                if (Request.QueryString["codigo"] != "")
                {
                    this.Fotoprod1.Enabled = true;

                    int cod_ret = 0;
                    cod_ret = Convert.ToInt32(Request.QueryString["codigo"]);

                    String query = "";
                    query = "SELECT * FROM estoque WHERE codigo = '" + cod_ret + "'";


                    //Request.QueryString["codigo"] = "";

                    using (MySqlConnection con = new MySqlConnection(strConx()))
                    {
                        MySqlDataReader dr;
                        MySqlCommand command = con.CreateCommand();
                        command.CommandText = query;

                        try
                        {
                            con.Open();

                        }
                        catch { }

                        try
                        {

                            dr = command.ExecuteReader();
                            // Mostra registros na tela
                            if (dr.Read())
                            {

                                this.txtid.Value = dr["id"].ToString();
                                this.txtCodigo.Value = dr["codigo"].ToString();
                                this.txtData.Text = dr["data"].ToString();
                                this.txtDescricao.Value = dr["descricao"].ToString();
                                this.txtUnidade.Value = dr["unidade"].ToString();
                                this.txtQtd.Value = dr["qtd_estq"].ToString();
                                this.txtMini.Value = dr["qtd_mini"].ToString();
                                this.txtClasse.Text = dr["classe"].ToString();
                                this.txtVencto.Text = dr["vencimento"].ToString();
                                this.txtFornecedor.ClearSelection();
                                this.txtFornecedor.Items.Insert(0, dr["fornecedor"].ToString());
                                this.txtidforne.Value = dr["fornecedor"].ToString();
                                this.txtRefere.Value = dr["referencia"].ToString();
                                this.txtSaldo.Value = dr["saldo"].ToString();
                                this.txtValor.Value = dr["valor"].ToString();
                                this.txtObs.Value = dr["obs"].ToString();
                                this.foto1.ImageUrl = dr["foto"].ToString();
                                this.lblBarra1.Text = "!0000000000" + this.txtCodigo.Value + "!";

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
            if (this.txtCodigo.Value != "" || this.txtCodigo.Value != null)
            {
                this.Fotoprod1.Enabled = true;
            }

        }
        protected void Fotoprod1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CapturaEstq.aspx?produto=" + this.txtDescricao.Value + "&inf=" + this.txtCodigo.Value);
        }

        protected void Imprimir1_Click(object sender, EventArgs e)
        {

        }

        protected void Lista_Click(object sender, EventArgs e)
        {
            Response.Redirect("GridEstoque.aspx?codigo=" + this.txtid.Value);
        }

        protected void Excluir_Click(object sender, EventArgs e)
        {

        }

        protected void Alterar_Click(object sender, EventArgs e)
        {

            if (this.txtCodigo.Value != "")
            {

                using (MySqlConnection Conexao = new MySqlConnection(strConx()))
                {
                    MySqlCommand Query = new MySqlCommand();
                    MySqlCommand command = Conexao.CreateCommand();

                    Query.Connection = Conexao;
                    try
                    {

                        String nome_3 = strNomeUser();
                        if (nome_3 == null)
                        {

                            nome_3 = "";
                            Response.Redirect("WebLogar1.aspx");
                            Response.End();

                        }

                        int id1 = Convert.ToInt32(this.txtid.Value);
                        string codigo = this.txtCodigo.Value;
                        string data = this.txtData.Text;
                        string descricao = this.txtDescricao.Value;
                        int unidade = Convert.ToInt32(this.txtUnidade.Value);
                        int qtd = Convert.ToInt32(this.txtQtd.Value);
                        int min = Convert.ToInt32(this.txtMini.Value);
                        string classe = this.txtClasse.Text;
                        string vencimento = this.txtVencto.Text;
                        string fornecedor = this.txtFornecedor.SelectedItem.ToString();
                        string referencia = this.txtRefere.Value;
                        double saldo = Convert.ToDouble(this.txtSaldo.Value);
                        string log = nome_3 + " - " + DateTime.Now.ToString() + "- AL ";
                        double valor = Convert.ToDouble(this.txtValor.Value);
                        string obs = this.txtObs.Value;


                        //string sal = saldo.ToString().Replace(",", ".");
                        //string val = valor.ToString().Replace(",", ".");


                        Conexao.Open();

                        //string de inclusão de dados no Mysql 
                        Query.CommandText = "UPDATE `estoque` SET `data` = '" + data + "', `classe` = '" + classe + "', `unidade` = " + unidade + ", `qtd_estq` = " + qtd + ", `qtd_mini` = " + min + ", `vencimento` = '" + vencimento + "', `fornecedor` = '" + fornecedor + "', `referencia` = '" + referencia + "', `saldo` = " + saldo + ", `valor` = " + valor + ", `obs` = '" + obs + "'  WHERE `id` = " + id1 + "";
                        Query.ExecuteNonQuery();
                        Query.Dispose();
                        try
                        {
                            this.lblmensagem1.Text = "<font color='#2E8B57'>Registro Alterado com Sucesso!!!</font>";
                        }
                        catch
                        {
                            this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Registro não Alterado !!!</font>";
                        }
                    }
                    catch
                    {
                        this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: No Processo !!!</font>";

                    }
                    //Conexao.Close();
                }
            }
            else
            {
                this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Não foi possivel Alterar !!";
            }
        }

        protected void Incluir_Click(object sender, EventArgs e)
        {


            this.txtid.Value = "";
            this.txtCodigo.Value = "";
            this.txtData.Text = "";
            this.txtDescricao.Value = "";
            this.txtUnidade.Value = "";
            this.txtQtd.Value = "";
            this.txtMini.Value = "";
            this.txtClasse.Text = "";
            this.txtVencto.Text = "";
            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            this.txtidforne.Value = "";
            this.txtRefere.Value = "";
            this.txtSaldo.Value = "";
            this.txtValor.Value = "";
            this.txtObs.Value = "";
            this.foto1.ImageUrl = "";
            //this.txtCodigo.Focus();
            this.Incluir.Enabled = true;
            this.lblmensagem1.Text = "";
            this.lblBarra1.Text = "";


            CarregaCombo();

            int novcodigo = 0;

            String query = "";
            query = "SELECT * FROM `estoque` ORDER BY  `codigo` DESC";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command2 = con.CreateCommand();
                command2.CommandText = query;

                try
                { con.Open(); }
                catch
                { }


                try
                {
                    dr = command2.ExecuteReader();
                    if (dr.Read())
                    {

                        string codigo = dr["codigo"].ToString();
                        int acumul = Convert.ToInt32(codigo);

                        acumul += 1;
                        novcodigo = acumul;
                        this.txtCodigo.Value = novcodigo.ToString();
                    }
                }
                catch
                { }
            }

            this.txtData.Text = DateTime.Now.ToString("d");
            this.txtUnidade.Value = "0";
            this.txtQtd.Value = "0";
            this.txtMini.Value = "0";
            this.Salvar.Visible = true;
            this.Incluir.Visible = false;
            this.Excluir.Enabled = false;
            this.Alterar.Enabled = false;

            this.Button3.Visible = false;
            this.Cancelar.Visible = true;

            this.Lista.Enabled = false;
            this.Consulta.Enabled = false;
            this.Inicio.Enabled = false;
            this.Proximo.Enabled = false;
            this.Anterior.Enabled = false;
            this.Fim.Enabled = false;
            this.Imprimir1.Enabled = false;
            this.Fotoprod1.Enabled = false;
            this.Salvar.Visible = true;
            this.lblmensagem1.Text = "";
            this.lblmodulo1.Text = "Inclusão";
            this.txtCodigo.Disabled = false;
            this.txtDescricao.Focus();
        }

        protected void Consulta_Click(object sender, EventArgs e)
        {
            this.lblmensagem1.Text = "";
            String query = "";

            if (this.txtCodigo.Value != "")
            {
                query = "SELECT * FROM estoque WHERE codigo = '" + this.txtCodigo.Value + "'";
            }

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                {
                    con.Open();

                }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }

                try
                {


                    dr = command.ExecuteReader();


                    // Mostra registros na tela
                    if (dr.Read())
                    {

                        this.txtid.Value = dr["id"].ToString();
                        this.txtCodigo.Value = dr["codigo"].ToString();
                        this.txtData.Text = dr["data"].ToString();
                        this.txtDescricao.Value = dr["descricao"].ToString();
                        this.txtUnidade.Value = dr["unidade"].ToString();
                        this.txtQtd.Value = dr["qtd_estq"].ToString();
                        this.txtMini.Value = dr["qtd_mini"].ToString();
                        this.txtClasse.Text = dr["classe"].ToString();
                        this.txtVencto.Text = dr["vencimento"].ToString();
                        this.txtFornecedor.ClearSelection();
                        this.txtFornecedor.Items.Insert(0, dr["fornecedor"].ToString());
                        this.txtidforne.Value = dr["fornecedor"].ToString();
                        this.txtRefere.Value = dr["referencia"].ToString();
                        this.txtSaldo.Value = dr["saldo"].ToString();
                        this.txtValor.Value = dr["valor"].ToString();
                        this.txtObs.Value = dr["obs"].ToString();
                        this.foto1.ImageUrl = dr["foto"].ToString();
                        this.lblBarra1.Text = "!0000000000" + dr["codigo"].ToString() + "!";


                    }

                    if (dr.HasRows)
                    {
                        //dr.Close();
                    }
                    else
                    {

                        this.lblmensagem1.Text = "<font color='#FF0000'>Regitro não Encontrado !!!</font>";
                        this.txtid.Value = "";
                        this.txtCodigo.Value = "";
                        this.txtData.Text = "";
                        this.txtDescricao.Value = "";
                        this.txtUnidade.Value = "";
                        this.txtQtd.Value = "";
                        this.txtMini.Value = "";
                        this.txtClasse.Text = "";
                        this.txtVencto.Text = "";
                        this.txtFornecedor.ClearSelection();
                        this.txtidforne.Value = "";
                        this.txtRefere.Value = "";
                        this.txtSaldo.Value = "";
                        this.txtValor.Value = "";
                        this.txtObs.Value = "";
                        this.foto1.ImageUrl = "";


                    }
                }
                catch
                {

                    this.lblmensagem1.Text = "<font color='#FF0000'>Regitro não Encontrado !!!</font>";
                    this.txtid.Value = "";
                    this.txtCodigo.Value = "";
                    this.txtData.Text = "";
                    this.txtDescricao.Value = "";
                    this.txtUnidade.Value = "";
                    this.txtQtd.Value = "";
                    this.txtMini.Value = "";
                    this.txtClasse.Text = "";
                    this.txtVencto.Text = "";
                    this.txtFornecedor.ClearSelection();
                    this.txtidforne.Value = "";
                    this.txtRefere.Value = "";
                    this.txtSaldo.Value = "";
                    this.txtValor.Value = "";
                    this.txtObs.Value = "";
                    this.foto1.ImageUrl = "";
                }

            }
        }

        protected void Inicio_Click(object sender, EventArgs e)
        {

            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            CarregaCombo();

            this.lblmensagem1.Text = "";
            String query = "";

            query = "SELECT * FROM estoque ORDER BY id ASC";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                {
                    con.Open();

                }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }



                dr = command.ExecuteReader();


                // Mostra registros na tela
                if (dr.Read())
                {

                    this.txtid.Value = dr["id"].ToString();
                    this.txtCodigo.Value = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtDescricao.Value = dr["descricao"].ToString();
                    this.txtUnidade.Value = dr["unidade"].ToString();
                    this.txtQtd.Value = dr["qtd_estq"].ToString();
                    this.txtMini.Value = dr["qtd_mini"].ToString();
                    this.txtClasse.Text = dr["classe"].ToString();
                    this.txtVencto.Text = dr["vencimento"].ToString();
                    this.txtFornecedor.ClearSelection();
                    this.txtFornecedor.Items.Insert(0, dr["fornecedor"].ToString());
                    this.txtidforne.Value = dr["fornecedor"].ToString();
                    this.txtRefere.Value = dr["referencia"].ToString();
                    this.txtSaldo.Value = dr["saldo"].ToString();
                    this.txtValor.Value = dr["valor"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
                    this.foto1.ImageUrl = dr["foto"].ToString();
                    this.lblBarra1.Text = "!0000000000" + dr["codigo"].ToString() + "!";

                }

                try
                {
                    //dr.Close();
                }
                catch
                {

                    this.lblmensagem1.Text = "Regitro não Encontrado !!! 2";

                }
            }

        }

        protected void Anterior_Click(object sender, EventArgs e)
        {
            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            CarregaCombo();

            int val_seek1;
            if (this.txtCodigo.Value == "")
            {
                val_seek1 = 1;
            }
            else
            {
                val_seek1 = Convert.ToInt32(this.txtid.Value) - 1;
            }
            this.lblmensagem1.Text = "";
            String query = "";
            query = "SELECT * FROM estoque  WHERE id = " + val_seek1 + "";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                {
                    con.Open();

                }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }



                dr = command.ExecuteReader();


                // Mostra registros na tela
                if (dr.Read())
                {

                    this.txtid.Value = dr["id"].ToString();
                    this.txtCodigo.Value = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtDescricao.Value = dr["descricao"].ToString();
                    this.txtUnidade.Value = dr["unidade"].ToString();
                    this.txtQtd.Value = dr["qtd_estq"].ToString();
                    this.txtMini.Value = dr["qtd_mini"].ToString();
                    this.txtClasse.Text = dr["classe"].ToString();
                    this.txtVencto.Text = dr["vencimento"].ToString();
                    this.txtFornecedor.ClearSelection();
                    this.txtFornecedor.Items.Insert(0, dr["fornecedor"].ToString());
                    this.txtidforne.Value = dr["fornecedor"].ToString();
                    this.txtRefere.Value = dr["referencia"].ToString();
                    this.txtSaldo.Value = dr["saldo"].ToString();
                    this.txtValor.Value = dr["valor"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
                    this.foto1.ImageUrl = dr["foto"].ToString();
                    this.lblBarra1.Text = "!0000000000" + dr["codigo"].ToString() + "!";

                }

                try
                {
                    //dr.Close();
                }
                catch
                {

                    this.lblmensagem1.Text = "Regitro não Encontrado !!! 2";

                }
            }

        }

        protected void Proximo_Click(object sender, EventArgs e)
        {
            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            CarregaCombo();

            int val_seek1;
            if (this.txtCodigo.Value == "")
            {
                val_seek1 = 1;
            }
            else
            {
                val_seek1 = Convert.ToInt32(this.txtid.Value) + 1;
            }
            this.lblmensagem1.Text = "";
            String query = "";
            query = "SELECT * FROM estoque  WHERE id = " + val_seek1 + "";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                {
                    con.Open();

                }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }



                dr = command.ExecuteReader();


                // Mostra registros na tela
                if (dr.Read())
                {

                    this.txtid.Value = dr["id"].ToString();
                    this.txtCodigo.Value = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtDescricao.Value = dr["descricao"].ToString();
                    this.txtUnidade.Value = dr["unidade"].ToString();
                    this.txtQtd.Value = dr["qtd_estq"].ToString();
                    this.txtMini.Value = dr["qtd_mini"].ToString();
                    this.txtClasse.Text = dr["classe"].ToString();
                    this.txtVencto.Text = dr["vencimento"].ToString();
                    this.txtFornecedor.ClearSelection();
                    this.txtFornecedor.Items.Insert(0, dr["fornecedor"].ToString());
                    this.txtidforne.Value = dr["fornecedor"].ToString();
                    this.txtRefere.Value = dr["referencia"].ToString();
                    this.txtSaldo.Value = dr["saldo"].ToString();
                    this.txtValor.Value = dr["valor"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
                    this.foto1.ImageUrl = dr["foto"].ToString();
                    this.lblBarra1.Text = "!0000000000" + dr["codigo"].ToString() + "!";

                }

                try
                {
                    //dr.Close();
                }
                catch
                {

                    this.lblmensagem1.Text = "Regitro não Encontrado !!! 2";

                }
            }

        }

        protected void Fim_Click(object sender, EventArgs e)
        {
            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            CarregaCombo();


            this.lblmensagem1.Text = "";
            String query = "";
            query = "SELECT * FROM estoque ORDER BY id DESC";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                {
                    con.Open();

                }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }



                dr = command.ExecuteReader();


                // Mostra registros na tela
                if (dr.Read())
                {

                    this.txtid.Value = dr["id"].ToString();
                    this.txtCodigo.Value = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtDescricao.Value = dr["descricao"].ToString();
                    this.txtUnidade.Value = dr["unidade"].ToString();
                    this.txtQtd.Value = dr["qtd_estq"].ToString();
                    this.txtMini.Value = dr["qtd_mini"].ToString();
                    this.txtClasse.Text = dr["classe"].ToString();
                    this.txtVencto.Text = dr["vencimento"].ToString();
                    this.txtFornecedor.ClearSelection();
                    this.txtFornecedor.Items.Insert(0, dr["fornecedor"].ToString());
                    this.txtidforne.Value = dr["fornecedor"].ToString();
                    this.txtRefere.Value = dr["referencia"].ToString();
                    this.txtSaldo.Value = dr["saldo"].ToString();
                    this.txtValor.Value = dr["valor"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
                    this.foto1.ImageUrl = dr["foto"].ToString();
                    this.lblBarra1.Text = "!0000000000" + dr["codigo"].ToString() + "!";

                }

                try
                {
                    //dr.Close();
                }
                catch
                {

                    this.lblmensagem1.Text = "Regitro não Encontrado !!! 2";

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.txtid.Value = "";
            this.txtCodigo.Value = "";
            this.txtData.Text = "";
            this.txtDescricao.Value = "";
            this.txtUnidade.Value = "";
            this.txtQtd.Value = "";
            this.txtMini.Value = "";
            this.txtClasse.Text = "";
            this.txtVencto.Text = "";
            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            this.txtidforne.Value = "";
            this.txtRefere.Value = "";
            this.txtSaldo.Value = "";
            this.txtValor.Value = "";
            this.txtObs.Value = "";
            this.foto1.ImageUrl = "";
            //this.txtCodigo.Focus();
            this.Incluir.Enabled = true;
            this.lblmensagem1.Text = "";
            this.lblmodulo1.Text = "";
            this.lblBarra1.Text = "";


            CarregaCombo();
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebSistem1.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }



        public void CarregaCombo()
        {

            String queryx = "";

            queryx = "SELECT * FROM fornecedor ORDER BY id";

            using (MySqlConnection conx = new MySqlConnection(strConx()))
            {
                MySqlCommand cmdx = new MySqlCommand(queryx, conx);
                MySqlDataReader drx;
                conx.Open();

                drx = cmdx.ExecuteReader();

                if (drx.HasRows)
                {
                    this.txtFornecedor.ClearSelection();
                    this.txtFornecedor.DataSource = drx;
                    this.txtFornecedor.DataTextField = "fornecedor";
                    this.txtFornecedor.DataValueField = "id";
                    this.txtFornecedor.DataBind();
                    this.txtFornecedor.Items.Insert(0, "-- Selecione o Fornecedor --");

                }
                drx.Close();
                //conx.Close();

            }
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {

            this.Incluir.Visible = true;
            this.Salvar.Visible = false;
            this.Excluir.Enabled = true;
            this.Alterar.Enabled = true;


            if (this.txtCodigo.Value != "")
            {

                String nome_3 = strNomeUser();
                if (nome_3 == null)
                {

                    nome_3 = "";
                    Response.Redirect("WebLogar1.aspx");
                    Response.End();

                }
                int novcodigo = 0;
                int acumul = 0;

                String query = "";
                query = "SELECT * FROM `estoque` ORDER BY  `codigo` DESC";

                using (MySqlConnection con = new MySqlConnection(strConx()))
                {
                    MySqlDataReader dr;
                    MySqlCommand command2 = con.CreateCommand();
                    command2.CommandText = query;

                    try
                    { con.Open(); }
                    catch
                    { }


                    try
                    {
                        dr = command2.ExecuteReader();
                        if (dr.Read())
                        {

                            string codigo = dr["codigo"].ToString();
                            acumul = Convert.ToInt32(codigo);

                            acumul += 1;
                            novcodigo = acumul;
                            this.txtCodigo.Value = novcodigo.ToString();
                        }
                    }
                    catch
                    { }
                }
                string codi = this.txtCodigo.Value;
                string data = this.txtData.Text;
                string descricao = this.txtDescricao.Value;
                int unidade = Convert.ToInt32(this.txtUnidade.Value);
                int qtd = Convert.ToInt32(this.txtQtd.Value);
                int min = Convert.ToInt32(this.txtMini.Value);
                string classe = this.txtClasse.Text;
                string vencimento = this.txtVencto.Text;
                string fornecedor = this.txtFornecedor.SelectedItem.ToString();
                string referencia = this.txtRefere.Value;
                string saldo = this.txtSaldo.Value;
                string valor = this.txtValor.Value;
                string obs = this.txtObs.Value;
                string log = nome_3 + " - " + DateTime.Now.ToString() + "- INCLUSAO ";


                using (MySqlConnection Conexao = new MySqlConnection(strConx()))
                {
                    MySqlCommand Query = new MySqlCommand();
                    MySqlCommand command = Conexao.CreateCommand();

                    Query.Connection = Conexao;
                    try
                    {

                        Conexao.Open();

                        //string de inclusão de dados no Mysql 
                        Query.CommandText = "INSERT INTO estoque(codigo,data,descricao,unidade,qtd_estq,qtd_mini,classe,vencimento,fornecedor,referencia,saldo,valor,obs,log)" +
                            "VALUES(@codigo, @data, @descricao, @unidade, @qtd, @min, @classe, @vencimento, @fornecedor, @referencia, @saldo, @valor, @obs, @log)";
                        Query.Parameters.AddWithValue("@codigo", novcodigo);
                        Query.Parameters.AddWithValue("@data", data);
                        Query.Parameters.AddWithValue("@descricao", descricao);
                        Query.Parameters.AddWithValue("@unidade", unidade);
                        Query.Parameters.AddWithValue("@qtd", qtd);
                        Query.Parameters.AddWithValue("@min", min);
                        Query.Parameters.AddWithValue("@classe", classe);
                        Query.Parameters.AddWithValue("@vencimento", vencimento);
                        Query.Parameters.AddWithValue("@fornecedor", fornecedor);
                        Query.Parameters.AddWithValue("@referencia", referencia);
                        Query.Parameters.AddWithValue("@saldo", saldo);
                        Query.Parameters.AddWithValue("@valor", valor);
                        Query.Parameters.AddWithValue("@obs", obs);
                        Query.Parameters.AddWithValue("@log", log);
                        Query.ExecuteNonQuery();
                        Query.Dispose();
                        this.lblmensagem1.Text = "<font color='#2E8B57'>Registro cadastrado com sucesso!!!</font>";
                        Conexao.Close();

                        this.Cancelar.Visible = false;
                        this.Button3.Visible = true;

                        this.Lista.Enabled = true;
                        this.Consulta.Enabled = true;
                        this.Inicio.Enabled = true;
                        this.Proximo.Enabled = true;
                        this.Anterior.Enabled = true;
                        this.Fim.Enabled = true;
                        this.Imprimir1.Enabled = true;
                        this.Salvar.Visible = false;
                        this.Incluir.Visible = true;

                        this.lblmensagem1.Text = "<font color='#2E8B57'>Registro cadastrado com sucesso!!!</font>";


                        this.txtCodigo.Value = codi;
                        this.txtData.Text = data;
                        this.txtDescricao.Value = descricao;
                        this.txtUnidade.Value = unidade.ToString();
                        this.txtQtd.Value = qtd.ToString();
                        this.txtMini.Value = min.ToString();
                        this.txtClasse.Text = classe;
                        this.txtVencto.Text = vencimento;
                        //this.txtFornecedor.SelectedItem.ToString();
                        this.txtFornecedor.Items.Insert(0, fornecedor);
                        this.txtRefere.Value = referencia;
                        this.txtSaldo.Value = saldo;
                        this.txtValor.Value = valor;
                        this.txtObs.Value = obs;
                        this.lblBarra1.Text = "!0000000000" + codi + "!";


                        //Response.Redirect("WebEstoque1.aspx?codigo=" + novcodigo);

                    }
                    catch
                    {
                        this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Registro ja cadastrado!!!</font>";
                        this.Cancelar.Visible = false;
                        this.Button3.Visible = true;

                        this.Lista.Enabled = true;
                        this.Consulta.Enabled = true;
                        this.Inicio.Enabled = true;
                        this.Proximo.Enabled = true;
                        this.Anterior.Enabled = true;
                        this.Fim.Enabled = true;
                        this.Imprimir1.Enabled = true;
                        this.Salvar.Visible = false;
                        this.Incluir.Visible = true;



                    }

                }
            }
            else
            {
                this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Não foi possivel Incluir";

                this.Cancelar.Visible = false;
                this.Button3.Visible = true;

                this.Lista.Enabled = true;
                this.Consulta.Enabled = true;
                this.Inicio.Enabled = true;
                this.Proximo.Enabled = true;
                this.Anterior.Enabled = true;
                this.Fim.Enabled = true;
                this.Imprimir1.Enabled = true;
                this.Salvar.Visible = false;
                this.Incluir.Visible = true;
                this.lblmodulo1.Text = "";


            }


        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar.Visible = false;
            this.Button3.Visible = true;

            this.Lista.Enabled = true;
            this.Consulta.Enabled = true;
            this.Inicio.Enabled = true;
            this.Proximo.Enabled = true;
            this.Anterior.Enabled = true;
            this.Fim.Enabled = true;
            this.Imprimir1.Enabled = true;
            this.Salvar.Visible = false;
            this.Incluir.Visible = true;
            this.Fotoprod1.Enabled = true;



            this.txtid.Value = "";
            this.txtCodigo.Value = "";
            this.txtData.Text = "";
            this.txtDescricao.Value = "";
            this.txtUnidade.Value = "";
            this.txtQtd.Value = "";
            this.txtMini.Value = "";
            this.txtClasse.Text = "";
            this.txtVencto.Text = "";
            this.txtFornecedor.ClearSelection();
            this.txtFornecedor.Items.Clear();
            this.txtidforne.Value = "";
            this.txtRefere.Value = "";
            this.txtSaldo.Value = "";
            this.txtValor.Value = "";
            this.txtObs.Value = "";
            this.foto1.ImageUrl = "";
            //this.txtCodigo.Focus();
            this.Incluir.Enabled = true;
            this.lblmensagem1.Text = "";
            this.lblmodulo1.Text = "";
            this.lblBarra1.Text = "";



            CarregaCombo();

        }

        protected void Excluir_Click1(object sender, EventArgs e)
        {

            if (this.txtdelete.Value == "SIM")
            {
                //this.lblmensagem1.Text = "Voce escolheu Deletar SIM";

                String nome_3 = strNomeUser();
                if (nome_3 == null)
                {

                    nome_3 = "";
                    Response.Redirect("WebLogar1.aspx");
                    Response.End();

                }


                if (this.txtCodigo.Value != "")
                {

                    // Salva Informacoes dos Registros Excluidos
                    int codigo = Convert.ToInt32(this.txtCodigo.Value);
                    string data = this.txtData.Text;
                    string descricao = this.txtDescricao.Value;
                    int unidade = Convert.ToInt32(this.txtUnidade.Value);
                    int qtd = Convert.ToInt32(this.txtQtd.Value);
                    int min = Convert.ToInt32(this.txtMini.Value);
                    string classe = this.txtClasse.Text;
                    string vencimento = this.txtVencto.Text;
                    string fornecedor = this.txtFornecedor.SelectedItem.ToString();
                    string referencia = this.txtRefere.Value;
                    decimal saldo = Convert.ToDecimal(this.txtSaldo.Value);
                    decimal valor = Convert.ToDecimal(this.txtValor.Value);
                    string obs = this.txtObs.Value;
                    string log = nome_3 + " - " + DateTime.Now.ToString() + "- Excluido ";
                    string nao_exclui = "";

                    using (MySqlConnection Conexao = new MySqlConnection(strConx()))
                    {
                        MySqlCommand Query = new MySqlCommand();
                        MySqlCommand command = Conexao.CreateCommand();

                        Query.Connection = Conexao;
                        try
                        {

                            Conexao.Open();

                            //string de inclusão de dados no Mysql 
                            Query.CommandText = "INSERT INTO estoque_excluidos(codigo,data,descricao,unidade,qtd_estq,qtd_mini,classe,vencimento,fornecedor,referencia,saldo,valor,obs,log)" +
                                "VALUES(@codigo, @data, @descricao, @unidade, @qtd, @min, @classe, @vencimento, @fornecedor, @referencia, @saldo, @valor, @obs, @log)";
                            Query.Parameters.AddWithValue("@codigo", codigo);
                            Query.Parameters.AddWithValue("@data", data);
                            Query.Parameters.AddWithValue("@descricao", descricao);
                            Query.Parameters.AddWithValue("@unidade", unidade);
                            Query.Parameters.AddWithValue("@qtd", qtd);
                            Query.Parameters.AddWithValue("@min", min);
                            Query.Parameters.AddWithValue("@classe", classe);
                            Query.Parameters.AddWithValue("@vencimento", vencimento);
                            Query.Parameters.AddWithValue("@fornecedor", fornecedor);
                            Query.Parameters.AddWithValue("@referencia", referencia);
                            Query.Parameters.AddWithValue("@saldo", saldo);
                            Query.Parameters.AddWithValue("@valor", valor);
                            Query.Parameters.AddWithValue("@obs", obs);
                            Query.Parameters.AddWithValue("@log", log);
                            Query.ExecuteNonQuery();
                            Query.Dispose();
                            Conexao.Close();
                        }
                        catch
                        {
                            this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Não foi possivel Exluir</font>";
                            nao_exclui = "NAO";

                        }
                    }
                    if (nao_exclui != "NAO")
                    {
                        int id2;
                        id2 = Convert.ToInt32(this.txtid.Value);
                        using (MySqlConnection conexao_d = new MySqlConnection(strConx()))
                        {
                            MySqlCommand query_d = new MySqlCommand();

                            MySqlCommand command_d = conexao_d.CreateCommand();

                            query_d.Connection = conexao_d;
                            string usr_1 = nome_3;
                            try
                            {

                                conexao_d.Open();

                                query_d.CommandText = "DELETE FROM estoque WHERE id = " + id2 + "";

                                query_d.ExecuteNonQuery();
                                query_d.Dispose();
                                this.lblmensagem1.Text = "<font color='#2E8B57'>Registro Exluido com Sucesso !!!!</font>";

                                this.txtid.Value = "";
                                this.txtCodigo.Value = "";
                                this.txtData.Text = "";
                                this.txtDescricao.Value = "";
                                this.txtUnidade.Value = "";
                                this.txtQtd.Value = "";
                                this.txtMini.Value = "";
                                this.txtClasse.Text = "";
                                this.txtVencto.Text = "";
                                this.txtFornecedor.ClearSelection();
                                this.txtFornecedor.Items.Clear();
                                this.txtidforne.Value = "";
                                this.txtRefere.Value = "";
                                this.txtSaldo.Value = "";
                                this.txtValor.Value = "";
                                this.txtObs.Value = "";
                                this.foto1.ImageUrl = "";

                                CarregaCombo();


                                using (MySqlConnection conexao_org = new MySqlConnection(strConx()))
                                {

                                    MySqlCommand query_org = new MySqlCommand();
                                    MySqlCommand command_org = conexao_org.CreateCommand();
                                    query_org.Connection = conexao_org;
                                    conexao_org.Open();
                                    query_org.CommandText = "ALTER TABLE `estoque` DROP `id`";
                                    query_org.ExecuteNonQuery();
                                    query_org.Dispose();
                                    //conexao_org.Close();
                                }
                                using (MySqlConnection conexao_org2 = new MySqlConnection(strConx()))
                                {
                                    MySqlCommand query_org2 = new MySqlCommand();
                                    MySqlCommand command_org2 = conexao_org2.CreateCommand();
                                    query_org2.Connection = conexao_org2;
                                    conexao_org2.Open();
                                    query_org2.CommandText = "ALTER TABLE `estoque` ORDER BY `codigo`";
                                    query_org2.ExecuteNonQuery();
                                    query_org2.Dispose();
                                    //conexao_org2.Close();
                                }
                                using (MySqlConnection conexao_org3 = new MySqlConnection(strConx()))
                                {
                                    MySqlCommand query_org3 = new MySqlCommand();
                                    MySqlCommand command_org3 = conexao_org3.CreateCommand();
                                    query_org3.Connection = conexao_org3;
                                    conexao_org3.Open();
                                    query_org3.CommandText = "ALTER TABLE `estoque` ADD `id` INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST";
                                    query_org3.ExecuteNonQuery();
                                    query_org3.Dispose();
                                    //conexao_org3.Close();
                                }

                            }
                            catch
                            {
                                this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Não foi possivel Exluir";
                            }

                            //conexao_d.Close();
                        }
                    }
                }
                else
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Não foi possivel Exluir";
                }




            }
            else
            {
                this.lblmensagem1.Text = "Operação Camcelada !!!";
            }



        }


    }
}