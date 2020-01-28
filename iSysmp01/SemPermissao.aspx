<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SemPermissao.aspx.cs" Inherits="iSysmp01.SemPermissao" %>
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

        .CaixaTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight: normal;
            color: #000000;
            border: 1px solid #000000;
            height: 24px;
            width: 92px;
            text-align: left;
        }
        .LabelTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight:normal;
            color: #004080;
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
            <table width="28%" height="152" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td>

<fieldset style="width: 456px; height: 224px; background-color: #FFF8DC;">
<legend><b><font color="#4B6C9E" face="Arial">Atenção - Segurança</font></b></legend>
    
    								<div align=center>

    <br />
    <asp:Label ID="Label1" runat="server" 
        style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: medium" 
        Text="ERRO: ACESSO NÃO PERMITIDO !!!!"></asp:Label>
    <br />
    * * *
    <asp:Label ID="lblusuario" runat="server"  
        style="font-weight: 700; font-style: italic; color: #546E96; font-family: Arial"></asp:Label>
    &nbsp;* * *<br />
    <span class="style5">Seu Computador não tem permissão,</span><br 
        class="style5" />
    <span class="style5">&nbsp;para uso neste horário, 
    <asp:Label ID="lblHora1" runat="server" style="font-weight: 700"></asp:Label>
    &nbsp;caso</span><br 
        class="style5" />
    <span class="style5">&nbsp;seja necessário entre em contato com o</span><br 
        class="style5" />
    <span class="style6">&nbsp;</span><span class="style5"><strong>ADMINISTRADOR</strong></span><span class="style4"><span 
                                            class="style5"> do Sistema.</span><br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Voltar" CssClass="Botao" 
        onclick="Button1_Click" />
    </span>


    </div>
</fieldset><br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

&nbsp;</td>
              </tr>
            </table>
</div>

    </body>


</asp:Content>
