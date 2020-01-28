using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace iSysmp01
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupera Sessao
            String strLocal1 = Application.Get("ambiente").ToString();
            String strSessao3 = (string)Session["usuarSessa"];
            String nome_3 = strSessao3;
            if (nome_3 == null)
            {
                nome_3 = "";
                //lbluseronline.Text = "off-line";

            }
            else
            {
                //lbluseronline.Text = "1 Usuario(s) on-line";
            }

            this.lbllocal1.Text = strLocal1.ToString();

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            int dia = DateTime.Now.Day;
            int ano = DateTime.Now.Year;
            string dia_1 = "";
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(DateTime.Now.DayOfWeek));
            string data = diasemana + ", " + dia + " de " + mes + " de " + ano;
            int hora = Convert.ToInt16(System.DateTime.Now.Hour);

            if (hora < 12)
            {
                dia_1 = "Bom Dia ";
            }
            else if (hora >= 18)
            {
                dia_1 = "Boa Noite ";
            }
            else
            {
                dia_1 = "Boa Tarde ";
            }

            this.lblsauda3.Text = dia_1 + " Seja Bem vindo, " + nome_3.ToUpper() + " hoje e " + data;


        }
    }
}
