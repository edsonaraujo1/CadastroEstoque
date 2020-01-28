<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="iSysmp01.About" %>
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
        color: #000000;
        font-family: Verdana;
    }
    .style5
    {
        color: #003366;
        font-family: Verdana;
    }
    .style6
    {
        color: #0000FF;
        font-family: Verdana;
            font-size: small;
        }
    .style7
    {
        color: #009900;
        font-family: Verdana;
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
    
        .style9
        {
            font-size: small;
        }
        .style10
        {
            color: #003366;
            font-family: Verdana;
            font-size: small;
        }
        .style11
        {
            color: #000000;
            font-family: Verdana;
            font-size: small;
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
            <table height="152" border="0" cellpadding="0" cellspacing="0" style="width: 85%">
              <tr>
                <td>

    <fieldset style="width: 783px; height: 378px">
<legend align="left"><b><font color="#4B6C9E" face="Arial">Informações</font></b></legend>
<div style="aling:left; text-align: left; height: 343px;">

        
                Conteudo do Sistema.<br />
                &nbsp;
        &nbsp;

    &nbsp;<asp:Image ID="Image3" runat="server" 
        ImageUrl="~/imagens/aspnet.jpg" style="text-align: left" Height="72px" 
            Width="138px" />
        &nbsp;&nbsp;
        <asp:Image ID="Image4" runat="server" Height="57px" 
            ImageUrl="~/imagens/mysql-3-logo-primary.jpg" />
<br />

    Sistema Criado com tecnologia ASP.NET na linguagem C# com conexão a Banco de Dados MySQL e SQLServer Express.<br />
    <div style="text-align: center;">

        <asp:Label ID="Label1" runat="server" 
            style="font-weight: 700; font-family: Verdana; font-size: small" 
            Text="Usuário : "></asp:Label>

        <asp:Label ID="lblUsuario_adm" runat="server" 
            style="color: #0000FF; font-weight: 700; font-family: Verdana"></asp:Label>

        <asp:Label ID="Label2" runat="server" 
            style="font-weight: 700; font-family: Verdana; font-size: small" 
            Text=" logado: "></asp:Label>

    </div>

                <span class="style11"><strong>Programador: </strong></span><span class="style5">
        <span class="style9">Edson de Araujo</span><br class="style9" />
    </span><span class="style11"><strong>Programador:</strong></span><span 
        class="style10"> Vinicius Silva Agrellos</span><span class="style4"><strong><br 
            class="style9" />
        <span class="style9">Desenvolvido em </span> </strong><em><strong>
        <span class="style9">C#/JavaScript/MySQL/Ajax</span><br class="style9" />
    </strong></em><strong><span class="style9">Este Sistema e Protegido pela lei: de Copyrigtht(c) 
    2010-2013</span><br class="style9" />
        <br class="style9" />
        <span class="style9">Este programa esta licenciado para :&nbsp; XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX</span><br 
            class="style9" />
        <span class="style9">o seguinte CNPJ/CPF : XXX.XXX.XXXX/XX</span><br />
        <br />
        <span class="style9">Versão : 1.0<br />
                Criado em : </span> </strong> </span><strong><span class="style7">
        <span class="style9">27/08/2013 ás 10:23</span><br class="style9" />
        </span><span class="style11">Ultima Atualização em </span> <span class="style6">02/10/2013 às 
    17:24</span></strong>
    <br />
    <div style="align:left; width: 724px; text-align: right;">

        <asp:Button ID="Button1" runat="server" 
            style="text-align: center; font-weight: 700" Text="Sair" Width="70px" 
            CssClass="Botao" onclick="Button1_Click" />

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
