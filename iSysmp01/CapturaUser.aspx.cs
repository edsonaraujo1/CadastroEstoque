using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace iSysmp01
{
    public partial class CapturaUser : System.Web.UI.Page
    {
        private string strConx()
        {
            return Application.Get("strConString").ToString();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // *** Inicio da rotina de verificação

            String strSessao3 = (string)Session["usuarSessa"];
            String strSenha3 = (string)Session["senhrSessa"];
            String nome_3 = strSessao3;
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
                string nodo_Form = "CapturaUser";   // <<< **** Não esquecer de colocar o nome do Form **** >>>
                // *****************************************************************************************

                Funcoes1 busca_pro = new Funcoes1();
                string busca_pro1 = busca_pro.progr_user(nodo_Form, nome_3, strConx());

                if (busca_pro1 == "NAO_FAZ")
                {
                    Response.Redirect("Acessedenied.aspx");
                    Response.End();
                }

            }
            // *** fim da rotina de verificação


            if (Request.QueryString["produto"] != "")
            {

                this.lblLabel1.Text = Request.QueryString["produto"];
                this.lblmsgerro.Text = "";
                string cod_prod = "";
                int cod_info = 0;
                cod_prod = Request.QueryString["codigo"];
                cod_info = Convert.ToInt32(Request.QueryString["inf"]);

            }
            else
            {
                Button2.Enabled = false;

                this.lblmsgerro.Text = "Menhum Usuario Encontrado !!!";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int cod_prod = 0;
            cod_prod = Convert.ToInt32(Request.QueryString["inf"]);

            try
            {

                if (FileUpload1.HasFile)
                {
                    // BLOQUEIA A TRANSFERÊNCIA DE ARQUIVOS MAIOR QUE 2MB
                    if (FileUpload1.PostedFile.ContentLength < 2097152)
                    {
                        Boolean fileOK = false;
                        //String path = Server.MapPath("fotos/");
                        string path = "fotosUser/";
                        if (FileUpload1.HasFile)
                        {
                            String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

                            for (int i = 0; i < allowedExtensions.Length; i++)
                            {
                                if (fileExtension == allowedExtensions[i])
                                {
                                    fileOK = true;
                                }
                            }
                        }

                        if (fileOK)
                        {
                            try
                            {
                                //FileUpload1.SaveAs(@"~/fotos/" + FileUpload1.FileName);

                                this.FileUpload1.SaveAs(Server.MapPath(path + FileUpload1.FileName));

                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "init", "<script>alert('Arquivo Enviado !!!.');</script>");
                                this.lblmsgerro.Text = "Arquivo Enviado !!!";

                                //Atualiza dados da foto no Banco

                                String strSessao3 = (string)Session["usuarSessa"];
                                String nome_3 = strSessao3;

                                //string CONFIG = ("Persist Security Info=False;server=localhost;database=sistema;uid=root;server=localhost;database=sistema;uid=root;pwd=12345");
                                using (MySqlConnection conexao = new MySqlConnection(strConx()))
                                {
                                    MySqlCommand query = new MySqlCommand();

                                    MySqlCommand command = conexao.CreateCommand();

                                    query.Connection = conexao;
                                    string tipo1a = "";
                                    string log1 = "";
                                    tipo1a = "INCLUIR FOTO";
                                    string usr_1 = nome_3;
                                    log1 = nome_3 + " - " + tipo1a + " - " + DateTime.Now.ToString();
                                    try
                                    {

                                        conexao.Open();

                                        query.CommandText = "UPDATE tt_ser_01 SET foto ='" + path + FileUpload1.FileName + "', log = '" + log1 + "' WHERE id = " + cod_prod + "";

                                        query.ExecuteNonQuery();
                                        query.Dispose();

                                    }
                                    catch
                                    {
                                        this.lblmsgerro.Text = "Não foi atualizado nome da Imagem !!!";
                                    }
                                }
                                //conexao.Close();




                                // Fim da Atualizacao de foto no Banco
                            }
                            catch (Exception ex)
                            {
                                // MENSAGEM INFORMATIVA PARA O USUÁRIO
                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "init", "<script>alert('" + ex.Message + ".');</script>");
                                this.lblmsgerro.Text = ex.Message;

                            }
                        }
                        else
                        {
                            // MENSAGEM INFORMATIVA PARA O USUÁRIO
                            string msg = "Só poderá carregar imagens neste campo.";
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "init", "<script>alert('" + msg + ".');</script>");
                            this.lblmsgerro.Text = msg.ToString();

                        }

                    }
                    else
                    {
                        // MENSAGEM INFORMATIVA PARA O USUÁRIO
                        string msg = "Limite máximo para a imagem é de 2MB.";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "init", "<script>alert('" + msg + ".');</script>");
                        this.lblmsgerro.Text = msg.ToString();

                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //string cod_prod = "";
            string cod_info = "";
            //cod_prod = Request.QueryString["codigo"];
            cod_info = Request.QueryString["produto"];

            Response.Redirect("WebUsuarios.aspx?codigo=" + cod_info);

        }
    }
}