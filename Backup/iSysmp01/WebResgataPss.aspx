<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebResgataPss.aspx.cs" Inherits="iSysmp01.WebResgataPss" %>
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

        .style4
        {
            font-family: Arial;
            font-size: large;
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

        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: medium;
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
            <br />
            <table height="152" border="0" cellpadding="0" cellspacing="0" 
                style="width: 49%">
              <tr>
                <td>

<fieldset style="width: 449px; height: 438px; background-color: #FFF8DC;">
<legend><b><font color="#4B6C9E" face="Arial">Atenção - Recuperar Senha</font></b></legend>
    
    								<div align=center style="height: 359px">

    <br />
    <asp:Label ID="Label1" runat="server" 
        style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: medium" 
        Text="A T E Ç Ã O"></asp:Label>
    <br />
                                        <span class="style4">
                                        <span 
                                            class="style5"> Para recuperação de sua senha digite seu e-mail<br />
                                        cadastrado no Sistema, você recebera um e-mail<br />
                                        com seu nome de usuário e uma senha provisoria.<br />
                                        Caso não tenha um e-mail cadastrado entre em<br />
                                        contato com o <strong>ADMINISTRADOR</strong> do Sistema.<br />
                                        OBRIGADO.<br />
                                        </span><br />

                                        <div style="text-align: left">
                                            <asp:Label ID="Label2" runat="server" Text="Digite seu E-mail cadastrado:" 
                                                
                                                style="font-family: Arial, Helvetica, sans-serif; font-size: small; font-weight: 700; color: #000000;"></asp:Label>
                                        <asp:TextBox ID="TextBox1" runat="server" Height="29px" Width="436px"></asp:TextBox>
                                        </div>
                                        <br />
    
    
                                        <div style="width: 264px; text-align: center">
	                                 <asp:Image ID="imgCaptcha" runat="server"/><br />
                                         <asp:TextBox ID="txtCaptcha" runat="server"/><br /><br />
	                                 <asp:Button ID="btnSubmit" runat="server" onclick="Submit_Click" 
                                         Text="Enviar" CssClass="Botao"/>&nbsp;
                                        <span class="style4">
                                    <asp:Button ID="Button1" runat="server" Text="Voltar" CssClass="Botao" 
                                        onclick="Button1_Click" />
    </span>


                                            <br />
	                                 <asp:Literal ID="litMessage" runat="server" />
                                    </div>

                                    <br />
                                        <br />
                                        <br />
    </span>


    </div>
</fieldset><br />
    <br />

&nbsp;</td>
              </tr>
            </table>
</div>


</body>


</asp:Content>
