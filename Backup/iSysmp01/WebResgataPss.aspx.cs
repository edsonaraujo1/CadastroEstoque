using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iSysmp01
{
    public partial class WebResgataPss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                imgCaptcha.ImageUrl = "Captcha.aspx";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (CheckCaptcha())
                litMessage.Text = "Código correto";
            else
                litMessage.Text = "<font color='#FF0000'>Código errado</font>";
        }

        public bool CheckCaptcha()
        {
            string strCaptcha = txtCaptcha.Text;
            if (Session["CaptchaImageText"].ToString() == strCaptcha)
                return true;
            else
                return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebLogar1.aspx");
            Response.End();
        }
    }
}