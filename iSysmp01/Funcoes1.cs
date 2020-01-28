using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace iSysmp01
{
    public class Funcoes1
    {
        public string progr_user(string for_user, string user_log, string strCom)
        {

            //string strCom = ("Persist Security Info=False;server=192.168.1.61;database=sistema;uid=sindificios;server=192.168.1.61;database=sistema;uid=sindificios;pwd=@12XLSIN_!?");
 
            // ******  Inicio da Busca do Programa
            using (MySqlConnection connection5 = new MySqlConnection(strCom))
            {
                MySqlCommand cmd5;
                MySqlDataReader dr5;
                connection5.Open();
                string sim_i = "";

                try
                {
                    cmd5 = connection5.CreateCommand();
                    cmd5.CommandText = "SELECT * FROM tt_ser_01 WHERE login = '" + user_log + "'";
                    dr5 = cmd5.ExecuteReader();

                    if (dr5.Read())
                    {
                        int i = 0;
                        string progr_1 = dr5["programas"].ToString();
                        string busca = progr_1;
                        string[] camp_bus = busca.Split(',');
                        string busca_nova = String.Join(";", camp_bus);
                        int numero_linha = camp_bus.Length;

                        for (i = 0; i < numero_linha; i++)
                        {
                            if (for_user == camp_bus[i])
                            {
                                sim_i = "FAZ";
                            }
                        }

                        if (sim_i == "FAZ")
                        {
                            sim_i = "SIM_FAZ";
                        }
                        else
                        {
                            sim_i = "NAO_FAZ";
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                return sim_i;
            }
            //connection5.Close();

        }
        public string verificadiasemana(string user_log, string strCom)
        {

            //string strCom = strCon8.ToString(); // Application.Get("strConString").ToString();
            //string strCom = ("Persist Security Info=False;server=192.168.1.61;database=sistema;uid=sindificios;server=192.168.1.61;database=sistema;uid=sindificios;pwd=@12XLSIN_!?");
            //string strCom = ("Persist Security Info=False;server=192.168.1.61;database=sistema;uid=sindificios;server=192.168.1.61;database=sistema;uid=sindificios;pwd=@12XLSIN_!?");
            //string strCom = ("Persist Security Info=False;server=localhost;database=sistema;uid=root;server=localhost;database=sistema;uid=root;pwd=12345");

            // ******  Inicio da Busca do Programa
            using (MySqlConnection connection6 = new MySqlConnection(strCom))
            {
                MySqlCommand cmd6;
                MySqlDataReader dr6;
                connection6.Open();
                string semanadia_i = "";
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string semana_w = culture.TextInfo.ToTitleCase(dtfi.GetDayName(DateTime.Now.DayOfWeek));
                string sema_w2 = semana_w.Substring(0, 3);

                try
                {
                    cmd6 = connection6.CreateCommand();
                    cmd6.CommandText = "SELECT * FROM tt_ser_01 WHERE login = '" + user_log + "'";
                    dr6 = cmd6.ExecuteReader();

                    if (dr6.Read())
                    {
                        int i = 0;
                        string progr_1 = dr6["semana"].ToString();
                        string busca = progr_1;
                        string[] camp_bus = busca.Split(',');
                        string busca_nova = String.Join(";", camp_bus);
                        int numero_linha = camp_bus.Length;

                        for (i = 0; i < numero_linha; i++)
                        {
                            if (sema_w2.ToUpper() == camp_bus[i])
                            {
                                semanadia_i = "FAZ";
                            }
                        }

                        if (semanadia_i == "FAZ")
                        {
                            semanadia_i = "SIM_FAZ";
                        }
                        else
                        {
                            semanadia_i = "NAO_FAZ";
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }

                return semanadia_i;
            }
            //connection5.Close();

        }
        public string permisbotoes(string usuario1, string tabela1, string strCom)
        {

            string paramentro1 = "";
            //string strCom = ("Persist Security Info=False;server=192.168.1.61;database=sistema;uid=sindificios;server=192.168.1.61;database=sistema;uid=sindificios;pwd=@12XLSIN_!?");

            // ******  Inicio da Busca do Programa
            using (MySqlConnection connection6 = new MySqlConnection(strCom))
            {
                MySqlCommand cmd6;
                MySqlDataReader dr6;
                connection6.Open();
                try
                {
                    cmd6 = connection6.CreateCommand();
                    cmd6.CommandText = "SELECT * FROM permissoes WHERE login = '" + usuario1 + "' AND tabela = '" + tabela1.ToUpper() + "'";
                    dr6 = cmd6.ExecuteReader();

                    if (dr6.Read())
                    {
                        string per_1 = dr6["incluir"].ToString();
                        string per_2 = dr6["alterar"].ToString();
                        string per_3 = dr6["excluir"].ToString();
                        string per_4 = dr6["imprimir"].ToString();
                    }


                }
                catch (Exception)
                {
                    throw;
                }
                //connection6.Close();

                return paramentro1;
            }
        }

    }
}