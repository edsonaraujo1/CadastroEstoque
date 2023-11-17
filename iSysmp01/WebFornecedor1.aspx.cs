using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
//using Correios.Net;

namespace iSysmp01
{
    public partial class WebFornecedor1 : System.Web.UI.Page
    {
        // Principal
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

            string tabelaper = "fornecedor";
            String Form_user = "WebFornecedor";

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
                using (MySqlConnection connection = new MySqlConnection(strConx()))
                {
                    MySqlCommand cmd;
                    MySqlDataReader dr;
                    connection.Open();
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "SELECT * FROM permissoes WHERE login = '" + nome_3 + "' AND tabela = '" + tabelaper.ToUpper() + "'";
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            per_1 = dr["incluir"].ToString();
                            per_2 = dr["alterar"].ToString();
                            per_3 = dr["excluir"].ToString();
                            per_4 = dr["imprimir"].ToString();
                        }

                        if (this.lblmodulo1.Text != "Inclusão")
                        {
                            // Abilita para uso os Bottoes
                            if (per_1 == "SIM") { this.Incluir.Enabled = true; }
                            if (per_2 == "SIM") { this.Alterar.Enabled = true; }
                            if (per_3 == "SIM") { this.Excluir.Enabled = true; }
                            if (per_4 == "SIM") { this.Imprimir1.Enabled = true; }

                        }
                    }
                    catch { }
                }
                // Fim da Verificacao dos botoes

            }

            if (!Page.IsPostBack)
            {

                // Consulta para voltar a mesma tela vindo de outra Pagina
                if (Request.QueryString["codigo"] != null)
                {
                    int cod_ret = 0;
                    cod_ret = Convert.ToInt32(Request.QueryString["codigo"]);

                    String query = "";
                    query = "SELECT * FROM fornecedor WHERE codigo = " + cod_ret + "";

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
                                this.TxtCodigo.Text = dr["codigo"].ToString();
                                this.txtData.Text = dr["data"].ToString();
                                this.txtNome.Value = dr["fornecedor"].ToString();
                                this.txtTel.Text = dr["fone"].ToString();
                                this.txtCel.Text = dr["celular"].ToString();
                                this.txtEmail.Text = dr["e_mail"].ToString();
                                this.txtEnd.Value = dr["endereco"].ToString();
                                this.txtNumero.Value = dr["numero"].ToString();
                                this.txtCep.Value = dr["cep"].ToString();
                                this.txtBairro.Text = dr["bairro"].ToString();
                                this.txtCidade.Value = dr["cidade"].ToString();
                                this.txtUf.Text = dr["estado"].ToString();
                                this.txtObs.Value = dr["obs"].ToString();
                            }
                        }
                        catch { }
                    }
                }
                else
                { }

            }
        }


        protected void Sair_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebSistem1.aspx");
        }

        protected void Consulta_Click(object sender, EventArgs e)
        {
            this.lblmensagem1.Text = "";
            String query = "";

            if (this.TxtCodigo.Text != "")
            {
                query = "SELECT * FROM fornecedor WHERE codigo = " + Convert.ToInt32(this.TxtCodigo.Text) + "";
            }

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                { con.Open(); }
                catch { this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>"; }

                try
                {
                    dr = command.ExecuteReader();

                    // Mostra registros na tela
                    if (dr.Read())
                    {
                        this.txtid.Value = dr["id"].ToString();
                        this.TxtCodigo.Text = dr["codigo"].ToString();
                        this.txtData.Text = dr["data"].ToString();
                        this.txtNome.Value = dr["fornecedor"].ToString();
                        this.txtTel.Text = dr["fone"].ToString();
                        this.txtCel.Text = dr["celular"].ToString();
                        this.txtEmail.Text = dr["e_mail"].ToString();
                        this.txtEnd.Value = dr["endereco"].ToString();
                        this.txtNumero.Value = dr["numero"].ToString();
                        this.txtCep.Value = dr["cep"].ToString();
                        this.txtCidade.Value = dr["cidade"].ToString();
                        this.txtBairro.Text = dr["bairro"].ToString();
                        this.txtUf.Text = dr["estado"].ToString();
                        this.txtObs.Value = dr["obs"].ToString();
                    }

                    if (dr.HasRows)
                    {
                        //dr.Close();
                    }
                    else
                    {
                        limpar_campo();
                        this.lblmensagem1.Text = "<font color='#FF0000'>Regitro não Encontrado !!!</font>";

                    }
                }
                catch
                {
                    limpar_campo();
                    this.lblmensagem1.Text = "<font color='#FF0000'>Regitro não Encontrado !!!</font>";
                }

            }

        }

        public void limpar_campo()
        {
            // Limpa os Campos para Inclusao
            this.txtid.Value = "";
            this.lblmensagem1.Text = "";
            this.TxtCodigo.Text = "";
            this.txtData.Text = "";
            this.txtNome.Value = "";
            this.txtTel.Text = "";
            this.txtCel.Text = "";
            this.txtEmail.Text = "";
            this.txtEnd.Value = "";
            this.txtNumero.Value = "";
            this.txtCep.Value = "";
            this.txtCep.Value = "";
            this.txtCidade.Value = "";
            this.txtBairro.Text = "";
            this.txtUf.Text = "";
            this.txtObs.Value = "";
            this.txtUf.SelectedValue = "";
            this.lblmodulo1.Text = "";

        }

        protected void Imprimir1_Click(object sender, EventArgs e)
        {

        }

        protected void Lista_Click(object sender, EventArgs e)
        {
            Response.Redirect("GridFornecedor.aspx?codigo=" + this.txtid.Value);
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


                if (this.TxtCodigo.Text != "")
                {

                    // Salva Informacoes dos Registros Excluidos
                    int codigo = Convert.ToInt32(this.TxtCodigo.Text);
                    string data = this.txtData.Text;
                    string nome = this.txtNome.Value;
                    string telefone = this.txtTel.Text;
                    string celular = this.txtCel.Text;
                    string email = this.txtEmail.Text;
                    string endereco = this.txtEnd.Value;
                    string numero = this.txtNumero.Value;
                    string cep = this.txtCep.Value;
                    string cidade = this.txtCidade.Value;
                    string bairro = this.txtBairro.Text;
                    string uf = this.txtUf.Text;
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
                            Query.CommandText = "INSERT INTO fornecedor_excluidos(codigo,  data,  fornecedor,  fone,  celular,  e_mail,  endereco,  numero,  cep,  cidade,  bairro,  estado,  obs,  log)" +
                                                                         "VALUES(@codigo, @data, @fornecedor, @fone, @celular, @e_mail, @endereco, @numero, @cep, @cidade, @bairro, @estado, @obs, @log)";
                            Query.Parameters.AddWithValue("@codigo", codigo);
                            Query.Parameters.AddWithValue("@data", data);
                            Query.Parameters.AddWithValue("@fornecedor", nome);
                            Query.Parameters.AddWithValue("@fone", telefone);
                            Query.Parameters.AddWithValue("@celular", celular);
                            Query.Parameters.AddWithValue("@e_mail", email);
                            Query.Parameters.AddWithValue("@endereco", endereco);
                            Query.Parameters.AddWithValue("@numero", numero);
                            Query.Parameters.AddWithValue("@cep", cep);
                            Query.Parameters.AddWithValue("@cidade", cidade);
                            Query.Parameters.AddWithValue("@bairro", bairro);
                            Query.Parameters.AddWithValue("@estado", uf);
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

                                query_d.CommandText = "DELETE FROM fornecedor WHERE id = " + id2 + "";

                                query_d.ExecuteNonQuery();
                                query_d.Dispose();

                                limpar_campo();
                                this.lblmensagem1.Text = "<font color='#2E8B57'>Registro Exluido com Sucesso !!!!</font>";


                                using (MySqlConnection conexao_org = new MySqlConnection(strConx()))
                                {

                                    MySqlCommand query_org = new MySqlCommand();
                                    MySqlCommand command_org = conexao_org.CreateCommand();
                                    query_org.Connection = conexao_org;
                                    conexao_org.Open();
                                    query_org.CommandText = "ALTER TABLE `fornecedor` DROP `id`";
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
                                    query_org2.CommandText = "ALTER TABLE `fornecedor` ORDER BY `codigo`";
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
                                    query_org3.CommandText = "ALTER TABLE `fornecedor` ADD `id` INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY FIRST";
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


                    // fim do ´código


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

        protected void Alterar_Click(object sender, EventArgs e)
        {

            if (this.TxtCodigo.Text != "")
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

                        int id = Convert.ToInt32(this.txtid.Value);
                        int codigo = Convert.ToInt32(this.TxtCodigo.Text);
                        string data = this.txtData.Text;
                        string nome = this.txtNome.Value;
                        string telefone = this.txtTel.Text;
                        string celular = this.txtCel.Text;
                        string email = this.txtEmail.Text;
                        string endereco = this.txtEnd.Value;
                        string numero = this.txtNumero.Value;
                        string cep = this.txtCep.Value;
                        string cidade = this.txtCidade.Value;
                        string bairro = this.txtBairro.Text;
                        string uf = this.txtUf.Text;
                        string obs = this.txtObs.Value;
                        string log = nome_3 + " - " + DateTime.Now.ToString() + "- ALTERACAO ";

                        //string sal = saldo.ToString().Replace(",", ".");
                        //string val = valor.ToString().Replace(",", ".");


                        Conexao.Open();

                        //string de inclusão de dados no Mysql 
                        Query.CommandText = "UPDATE `fornecedor` SET `data` = '" + data + "', `fornecedor` = '" + nome + "', `fone` = '" + telefone + "', `celular` = '" + celular + "', `endereco` = '" + endereco + "', `numero` = '" + numero + "', `cep` = '" + cep + "', `e_mail` = '" + email + "', `cidade` = '" + cidade + "', `bairro` = '" + bairro + "', `estado` = '" + uf + "', `obs` = '" + obs + "', `log` = '" + log + "'  WHERE `id` = " + id + "";
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
            // Desabilita Botoes para Inclusao
            this.Imprimir1.Enabled = false;
            this.Lista.Enabled = false;
            this.Excluir.Enabled = false;
            this.Alterar.Enabled = false;
            this.txtConsulta.Enabled = false;
            this.Inicio.Enabled = false;
            this.Anterior.Enabled = false;
            this.Proximo.Enabled = false;
            this.Fim.Enabled = false;
            this.Button1.Enabled = false;
            this.Button2.Enabled = false;
            this.ImageButton1.Enabled = true;

            this.Limpar.Visible = false;
            this.Cancelar.Visible = true;
            this.Salvar.Visible = true;
            this.Incluir.Visible = false;

            this.TxtCodigo.ReadOnly = true;



            limpar_campo();

            int novcodigo = 0;

            String query = "";
            query = "SELECT * FROM `fornecedor` ORDER BY  `codigo` DESC";

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
                        this.TxtCodigo.Text = novcodigo.ToString();
                    }
                }
                catch
                { }
            }

            this.txtData.Text = DateTime.Now.ToString("d");
            this.lblmodulo1.Text = "Inclusão";

        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            // Salvar Informacoes no Banco
            if (this.TxtCodigo.Text != "")
            {

                if (ValidarEmail(this.txtEmail.Text) == false)
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Email com formato incorreto!</font>";
                }
                else
                {

                    this.lblmensagem1.Text = "";

                    String nome_3 = strNomeUser();
                    if (nome_3 == null)
                    {

                        nome_3 = "";
                        Response.Redirect("WebLogar1.aspx");
                        Response.End();

                    }
                    int novcodigo = 0;

                    String query = "";
                    query = "SELECT * FROM `fornecedor` ORDER BY  `codigo` DESC";

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
                                this.TxtCodigo.Text = novcodigo.ToString();
                            }
                        }
                        catch
                        { }
                    }

                    string data = this.txtData.Text;
                    string nome = this.txtNome.Value;
                    string telefone = this.txtTel.Text;
                    string celular = this.txtCel.Text;
                    string email = this.txtEmail.Text;
                    string endereco = this.txtEnd.Value;
                    string numero = this.txtNumero.Value;
                    string cep = this.txtCep.Value;
                    string cidade = this.txtCidade.Value;
                    string bairro = this.txtBairro.Text;
                    string uf = this.txtUf.Text;
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
                            Query.CommandText = "INSERT INTO fornecedor(codigo,data,fornecedor,fone,celular,e_mail,endereco,numero,cep,cidade,bairro,estado,obs,log)" +
                                "VALUES(@codigo, @data, @fornecedor, @fone, @celular, @e_mail, @endereco, @numero, @cep, @cidade, @bairro, @estado, @obs, @log)";
                            Query.Parameters.AddWithValue("@codigo", novcodigo);
                            Query.Parameters.AddWithValue("@data", data);
                            Query.Parameters.AddWithValue("@fornecedor", nome);
                            Query.Parameters.AddWithValue("@fone", telefone);
                            Query.Parameters.AddWithValue("@celular", celular);
                            Query.Parameters.AddWithValue("@e_mail", email);
                            Query.Parameters.AddWithValue("@endereco", endereco);
                            Query.Parameters.AddWithValue("@numero", numero);
                            Query.Parameters.AddWithValue("@cep", cep);
                            Query.Parameters.AddWithValue("@cidade", cidade);
                            Query.Parameters.AddWithValue("@bairro", bairro);
                            Query.Parameters.AddWithValue("@estado", uf);
                            Query.Parameters.AddWithValue("@obs", obs);
                            Query.Parameters.AddWithValue("@log", log);
                            Query.ExecuteNonQuery();
                            Query.Dispose();
                            this.lblmensagem1.Text = "<font color='#2E8B57'>Registro cadastrado com sucesso!!!</font>";
                            Conexao.Close();

                            this.Imprimir1.Enabled = true;
                            this.Lista.Enabled = true;
                            this.Excluir.Enabled = true;
                            this.Alterar.Enabled = true;
                            this.txtConsulta.Enabled = true;
                            this.Inicio.Enabled = true;
                            this.Anterior.Enabled = true;
                            this.Proximo.Enabled = true;
                            this.Fim.Enabled = true;
                            this.Button1.Enabled = true;
                            this.Button2.Enabled = true;

                            this.Limpar.Visible = true;
                            this.Cancelar.Visible = false;
                            this.lblmodulo1.Text = "";


                            this.Salvar.Visible = false;
                            this.Incluir.Visible = true;
                            this.lblmensagem1.Text = "<font color='#2E8B57'>Registro cadastrado com sucesso!!!</font>";

                            // Mostra na Tela as Informacoes Incluidas
                            this.TxtCodigo.Text = novcodigo.ToString();
                            this.txtData.Text = data;
                            this.txtNome.Value = nome;
                            this.txtTel.Text = telefone;
                            this.txtCel.Text = celular;
                            this.txtEmail.Text = email;
                            this.txtEnd.Value = endereco;
                            this.txtNumero.Value = numero;
                            this.txtCep.Value = cep;
                            this.txtCidade.Value = cidade;
                            this.txtBairro.Text = bairro;
                            this.txtUf.Text = uf;
                            this.txtObs.Value = obs;


                        }
                        catch
                        {
                            this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Registro ja cadastrado!!!</font>";
                            this.Imprimir1.Enabled = true;
                            this.Lista.Enabled = true;
                            this.Excluir.Enabled = true;
                            this.Alterar.Enabled = true;
                            this.txtConsulta.Enabled = true;
                            this.Inicio.Enabled = true;
                            this.Anterior.Enabled = true;
                            this.Proximo.Enabled = true;
                            this.Fim.Enabled = true;
                            this.Button1.Enabled = true;
                            this.Button2.Enabled = true;

                            this.Limpar.Visible = true;
                            this.Cancelar.Visible = false;


                            this.Salvar.Visible = false;
                            this.Incluir.Visible = true;
                            this.lblmodulo1.Text = "";

                        }

                    }
                }
            }
            else
            {
                this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Não foi possivel Incluir";

                this.Imprimir1.Enabled = true;
                this.Lista.Enabled = true;
                this.Excluir.Enabled = true;
                this.Alterar.Enabled = true;
                this.txtConsulta.Enabled = true;
                this.Inicio.Enabled = true;
                this.Anterior.Enabled = true;
                this.Proximo.Enabled = true;
                this.Fim.Enabled = true;
                this.Button1.Enabled = true;
                this.Button2.Enabled = true;

                this.Limpar.Visible = true;
                this.Cancelar.Visible = false;


                this.Salvar.Visible = false;
                this.Incluir.Visible = true;
                this.lblmodulo1.Text = "";

                this.TxtCodigo.ReadOnly = false;

            }


        }

        protected void Inicio_Click(object sender, EventArgs e)
        {

            this.lblmensagem1.Text = "";
            String query = "";

            query = "SELECT * FROM fornecedor ORDER BY id ASC";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                { con.Open(); }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }

                dr = command.ExecuteReader();

                // Mostra registros na tela
                if (dr.Read())
                {
                    this.txtid.Value = dr["id"].ToString();
                    this.TxtCodigo.Text = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtNome.Value = dr["fornecedor"].ToString();
                    this.txtTel.Text = dr["fone"].ToString();
                    this.txtCel.Text = dr["celular"].ToString();
                    this.txtEmail.Text = dr["e_mail"].ToString();
                    this.txtEnd.Value = dr["endereco"].ToString();
                    this.txtNumero.Value = dr["numero"].ToString();
                    this.txtCep.Value = dr["cep"].ToString();
                    this.txtBairro.Text = dr["bairro"].ToString();
                    this.txtCidade.Value = dr["cidade"].ToString();
                    this.txtUf.Text = dr["estado"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
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

            int val_seek1;
            if (this.TxtCodigo.Text == "")
            {
                val_seek1 = 1;
            }
            else
            {
                val_seek1 = Convert.ToInt32(this.txtid.Value) - 1;
            }
            this.lblmensagem1.Text = "";
            String query = "";
            query = "SELECT * FROM fornecedor  WHERE id = " + val_seek1 + " ORDER BY id ASC";

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
                    this.TxtCodigo.Text = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtNome.Value = dr["fornecedor"].ToString();
                    this.txtTel.Text = dr["fone"].ToString();
                    this.txtCel.Text = dr["celular"].ToString();
                    this.txtEmail.Text = dr["e_mail"].ToString();
                    this.txtEnd.Value = dr["endereco"].ToString();
                    this.txtNumero.Value = dr["numero"].ToString();
                    this.txtCep.Value = dr["cep"].ToString();
                    this.txtBairro.Text = dr["bairro"].ToString();
                    this.txtCidade.Value = dr["cidade"].ToString();
                    this.txtUf.Text = dr["estado"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
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
            int val_seek1;
            if (this.TxtCodigo.Text == "")
            {
                val_seek1 = 1;
            }
            else
            {
                val_seek1 = Convert.ToInt32(this.txtid.Value) + 1;
            }
            this.lblmensagem1.Text = "";
            String query = "";
            query = "SELECT * FROM fornecedor  WHERE id = " + val_seek1 + " ORDER BY id DESC";

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
                    this.TxtCodigo.Text = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtNome.Value = dr["fornecedor"].ToString();
                    this.txtTel.Text = dr["fone"].ToString();
                    this.txtCel.Text = dr["celular"].ToString();
                    this.txtEmail.Text = dr["e_mail"].ToString();
                    this.txtEnd.Value = dr["endereco"].ToString();
                    this.txtNumero.Value = dr["numero"].ToString();
                    this.txtCep.Value = dr["cep"].ToString();
                    this.txtBairro.Text = dr["bairro"].ToString();
                    this.txtCidade.Value = dr["cidade"].ToString();
                    this.txtUf.Text = dr["estado"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
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
            this.lblmensagem1.Text = "";
            String query = "";

            query = "SELECT * FROM fornecedor ORDER BY id DESC";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                { con.Open(); }
                catch
                {
                    this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: Problemas na Conexão !!!</font>";
                }

                dr = command.ExecuteReader();

                // Mostra registros na tela
                if (dr.Read())
                {
                    this.txtid.Value = dr["id"].ToString();
                    this.TxtCodigo.Text = dr["codigo"].ToString();
                    this.txtData.Text = dr["data"].ToString();
                    this.txtNome.Value = dr["fornecedor"].ToString();
                    this.txtTel.Text = dr["fone"].ToString();
                    this.txtCel.Text = dr["celular"].ToString();
                    this.txtEmail.Text = dr["e_mail"].ToString();
                    this.txtEnd.Value = dr["endereco"].ToString();
                    this.txtNumero.Value = dr["numero"].ToString();
                    this.txtCep.Value = dr["cep"].ToString();
                    this.txtBairro.Text = dr["bairro"].ToString();
                    this.txtCidade.Value = dr["cidade"].ToString();
                    this.txtUf.Text = dr["estado"].ToString();
                    this.txtObs.Value = dr["obs"].ToString();
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

        protected void Limpar_Click(object sender, EventArgs e)
        {
            limpar_campo();
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {

            this.Imprimir1.Enabled = true;
            this.Lista.Enabled = true;
            this.Excluir.Enabled = true;
            this.Alterar.Enabled = true;
            this.txtConsulta.Enabled = true;
            this.Inicio.Enabled = true;
            this.Anterior.Enabled = true;
            this.Proximo.Enabled = true;
            this.Fim.Enabled = true;
            this.Button1.Enabled = true;
            this.Button2.Enabled = true;
            this.ImageButton1.Enabled = false;

            this.Limpar.Visible = true;
            this.Cancelar.Visible = false;

            this.Salvar.Visible = false;
            this.Incluir.Visible = true;

            this.TxtCodigo.ReadOnly = false;


            limpar_campo();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                // Busca o CEP nos Correios pela API
                //Address address = BuscaCep.GetAddress(this.txtCep.Value);
                //this.txtEnd.Value = address.Street;
                //this.txtBairro.Text = address.District;
                //this.txtCidade.Value = address.City;
                //this.txtUf.Text = address.State;
                //this.lblmensagem1.Text = "";
            }
            catch
            {
                this.lblmensagem1.Text = "<font color='#FF0000'>ERRO: CEP Informado e Incorreto !!!</font>";
            }
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


    }
}