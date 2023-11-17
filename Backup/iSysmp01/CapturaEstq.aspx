<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CapturaEstq.aspx.cs" Inherits="iSysmp01.CapturaEstq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        #entrada
        {
            height: 188px;
            width: 660px;
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
               .LabelTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight:normal;
            color: #004080;
        }

        .style4
        {
            color: #000000;
        }
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

              <fieldset id="entrada">
              <legend><b><font color="#4B6C9E" face="Arial">Capturar Imagem</font></b></legend>

              <div align="center" class="LabelTexto">
                  <span class="style4">Criar Imagem para:</span>&nbsp;
                  <asp:Label ID="lblLabel1" runat="server" style="font-weight: 700" ></asp:Label>

                  <br />

                  <br />
                  Procurar o Arquivo:
                  <asp:FileUpload ID="FileUpload1" runat="server" />
                  
                  <br />
                  
                  <br />
                  <asp:Label ID="lblmsgerro" runat="server" 
                      style="color: #FF0000; font-weight: 700"></asp:Label>
                  
                  <br />
                  <br />
                  <asp:Button ID="Button2" runat="server" Text="Enviar" CssClass="Botao" 
                      onclick="Button2_Click" />

                  &nbsp;
                  <asp:Button ID="Button3" runat="server" CssClass="Botao" Text="Voltar" 
                      onclick="Button3_Click" />

                  </div>




              </fieldset>



&nbsp;</td>
              </tr>
            </table>
</div>

</body>


</asp:Content>
