<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebLogar1.aspx.cs" Inherits="iSysmp01.WebLogar1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        a {
            text-decoration: none;
        }

        a:hover {
                border-bottom: none;
        }

        .menu:hover {
            background-color: #666666;
        }

        .menu2:hover {
            background-color: #FFFFCC;
        }

        .Botao 
        {
            font-family: Verdana;
            font-size: 11px;
            font-weight: bold;
            color: #004080;
            background-color: #DAD7CF;
            width: 70px;
            height: 24px;
        }
        .Botao1 
        {
            font-family: Verdana;
            font-size: 11px;
            font-weight: bold;
            color:Red;
            background-color: #DAD7CF;
            width: 70px;
            height: 24px;
        }
        .CaixaTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight: normal;
            color: #000000;
            border: 1px solid #000000;
            height: 24px;
        }
        .LabelTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight:normal;
            color: #004080;
        }

    .style4
    {
        height: 41px;
    }
    .normal
    {
        font-family: Verdana;
        font-size: 13px;
        font-weight: normal;
        border: 1px solid #000000;
        height: 24px;

        background-color: White;
    }
    .anormal
    {
        font-family: Verdana;
        font-size: 13px;
        font-weight: normal;
        border: 1px solid #000000;
        height: 24px;

        background-color: #EAEBFF;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Response.Buffer = true; // a página será carregado no buffer%>
<script language="JavaScript" type="text/JavaScript">
    function loadImages() {
        if (document.getElementById) {  // DOM3 = IE5, NS6
            document.getElementById('hidepage').style.visibility = 'hidden';
        }
        else {
            if (document.layers) {  // Netscape 4
                document.hidepage.visibility = 'hidden';
            }
            else {  // IE 4
                document.all.hidepage.style.visibility = 'hidden';
            }
        }
    }
</script>


<body OnLoad="loadImages();">
<!--#include file="wait.asp"-->
<%Response.Flush(); //envia conteúdo para o browser%>

        <div align="center">
                    <p>&nbsp;</p>
                    <table width="28%" height="152" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td>

                      <fieldset id="entrada" style="background-color: #FFF8DC;">
                      <legend><b><font color="#4B6C9E" face="Arial">Entrada no Sistema</font></b></legend>
                          <asp:Label ID="lblmensage1" runat="server" 
                              style="color: #FF0000; font-family: Arial; font-size: small" ></asp:Label>
                      <br>
        <form name="form" method="post" action="login.html">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="29%" class="style4"><div align="right" class="LabelTexto"><font face="Arial">Usu&aacute;rio</font>:</div></td>
            <td width="71%" class="style4"><input type="text" name="txtnome3" id="txtnome3" 
                    runat="server" onfocus="this.className='anormal'"  onblur="this.className='normal'" class="CaixaTexto" ></td>
          </tr>
          <tr>
            <td height="25"><div align="right" class="LabelTexto"><font face="Arial">Senha</font>:</div></td>
            <td><input type="password" name="txtpass03" id="txtpass03" runat="server" 
                    onfocus="this.className='anormal'"  onblur="this.className='normal'" class="CaixaTexto"></td>
          </tr>
          <tr>
            <td height="19"><div align="right"></div></td>
            <td>
              <div align="left"><font color="#4B6C9E" size="1" face="Arial"><a href="WebResgataPss.aspx">N&atilde;o consegue acessar sua conta?</a></font> </div></td></tr>
        </table>
        <div align="center"></div>
        <table width="99%" height="42" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td><div align="center">
              &nbsp;<asp:Button ID="Entrar" runat="server" onclick="Entrar_Click" 
                    Text="Entrar" CssClass="Botao" />
            </div></td>
          </tr>
        </table>

        </form>



              
                      </fieldset>



        &nbsp;</td>
                      </tr>
                    </table>
        </div>

</body>


</asp:Content>
