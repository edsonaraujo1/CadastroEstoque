using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace iSysmp01
{
    public partial class GridUsuarios : System.Web.UI.Page
    {
        private string strConx()
        {
            return Application.Get("strConString").ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            String query = "";
            //String strcon = "SERVER=localhost; DATABASE=sistema; UID=root; PASSWORD=12345;";

            query = "SELECT login, nome_l, e_mail, data, conta FROM tt_ser_01";



            using (MySqlConnection con = new MySqlConnection(strConx()))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
                //con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cod_prod = "";
            if (Request.QueryString["codigo"] != "")
            {
                cod_prod = Request.QueryString["codigo"];
            }

            Response.Redirect("WebUsuarios.aspx?codigo=" + cod_prod);

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }


    }
}