<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebSend1.aspx.cs" Inherits="iSysmp01.WebSend1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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

       .auto-style1
       {
           text-align: right;
       }
       #TextArea1
       {
           height: 238px;
           width: 408px;
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


    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

 <div align="center">
            <br />
            <table height="152" border="0" cellpadding="0" cellspacing="0" style="width: 557px">
              <tr>
                <td>

    <fieldset style="width: 558px; height: 394px">
<legend align="left"><b><font color="#4B6C9E" face="Arial">Enviar Mensagem</font></b></legend>
<div style="aling:left; text-align: center; height: 371px;">

        
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="Usuário.:" CssClass="LabelTexto"></asp:Label>
                        </td>
                        <td style="text-align: left"><asp:ComboBox ID="txtUsuarios" runat="server" Width="250px" Height="25px" onfocus="this.className='anormal'"  
                        onblur="this.className='normal'"></asp:ComboBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                <asp:Label ID="Label2" runat="server" Text="Mensagem.:" CssClass="LabelTexto"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                </table>

        
&nbsp;<textarea id="TextArea1" onfocus="this.className='anormal'"  
                        onblur="this.className='normal'" class="CaixaTexto"></textarea>
                <br />
    <br />
    <div style="text-align: center;">

        <asp:Button ID="Button2" runat="server" Text="Enviar" CssClass="Botao" Width="70px" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button1" runat="server" 
            style="text-align: center; font-weight: 700" Text="Sair" Width="70px" 
            onclick="Button1_Click" CssClass="Botao" />

    </div>

</div>
</fieldset> 

<br />

&nbsp;</td>
              </tr>
            </table>
</div>

</body>

</asp:Content>
