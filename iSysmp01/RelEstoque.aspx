<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RelEstoque.aspx.cs" Inherits="iSysmp01.RelEstoque" %>
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
            <table border="0" cellpadding="0" cellspacing="0" style="width: 557px; height: 185px;">
              <tr>
                <td>

    <fieldset style="width: 482px; height: 201px">
<legend align="left"><b><font color="#4B6C9E" face="Arial">Relatório de Estoque</font></b></legend>
<div style="aling:left; text-align: center; height: 166px; width: 408px;">

        
                <br />
                <table style="width:79%;">
                    <tr>
                        <td class="auto-style1" style="width: 186px; text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Iniciar em.:" CssClass="LabelTexto"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="CaixaTexto" MaxLength="11" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 186px;">
                <asp:Label ID="Label2" runat="server" Text="Terminar em.:" CssClass="LabelTexto"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="CaixaTexto" MaxLength="11" TabIndex="2"></asp:TextBox>
                        </td>
                    </tr>
                </table>

        
&nbsp;
                <br />
    <br />
    <div style="text-align: center;">

        <asp:Button ID="Button2" runat="server" Text="Imprimir" CssClass="Botao" Width="70px" OnClick="Button2_Click" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button1" runat="server" 
            style="text-align: center; font-weight: 700" Text="Sair" Width="70px" onclick="Button1_Click" CssClass="Botao" />

    </div>

</div>
</fieldset> 
                    <br />
                    <br />
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
