using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Diagnostics;

namespace iSysmp01
{
    public partial class RelEstoque : System.Web.UI.Page
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

            String Form_user = "RelEstoque";

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

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebSistem3.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            string file = @"C:\Windows\Temp\Documento.pdf";
            string faz = "cabe";

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, new FileStream(file, FileMode.Create));

            float x, y;
            x = 0;
            y = 0;

            document.Open();

            string html = "" +
            "<div style='height: 25px; text-align: center; width: 1119px;'>" +
            "&nbsp;<span style='font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: 20px'><b>Relátório de Estoque</b></span><br />" +
            "<br />" +
            "</div>" +
            "<table style='width:100;' border='1'>" +
            "<tr>" +
            "<td style='width: 10px; text-align: center; font-size: small; background-color: #CCCCCC;'><b>codigo</b></td>" +
            "<td style='width: 15px; text-align: center; font-size: small; background-color: #CCCCCC;'><b>Vencto</b></td>" +
            "<td style='width: 991px; text-align: left; font-size: small; background-color: #CCCCCC;'><b>Descrição&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>" +
            "<td style='width: 50px; text-align: center; font-size: small; background-color: #CCCCCC;'><b>Qtd</b></td>" +
            "<td style='width: 50px; text-align: center; font-size: small; background-color: #CCCCCC;'><b>Qtd min</b></td>" +
            "<td style='width: 30px; text-align: center; font-size: small; background-color: #CCCCCC;'><b>Situação</b></td>" +
            "</tr>";

            String query = "";
            query = "SELECT * FROM estoque ORDER BY id DESC";

            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                MySqlDataReader dr;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = query;

                try
                { con.Open(); }
                catch
                { }

                dr = command.ExecuteReader();

                // Mostra registros na tela
                while (dr.Read())
                {

                    html += "<tr>" +
                            "    <td style='width: 55px; text-align: center; font-size: small;'>" + dr["codigo"].ToString() + "</td>" +
                            "    <td style='width: 59px; text-align: center; font-size: small; '>" + dr["vencimento"].ToString() + "</td>" +
                            "    <td style='width: 89px; text-align: left; font-size: small;'>" + dr["descricao"].ToString() + "</td>" +
                            "    <td style='width: 113px; text-align: right; font-size: small;'>" + dr["qtd_estq"].ToString() + "</td>" +
                            "    <td style='width: 151px; text-align: right; font-size: small;'>" + dr["qtd_mini"].ToString() + "</td>" +
                            "    <td style='width: 216px; text-align: center; font-size: small;'>Ativo</td>" +
                            "</tr>";

                }

                try
                { }
                catch
                { }
            }


            html += "</table>";


            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                document.Add(E);

            document.Close();

            Process.Start(file);



        }
    }
}