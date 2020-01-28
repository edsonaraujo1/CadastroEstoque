<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridFornecedor.aspx.cs" Inherits="iSysmp01.GridFornecedor" %>
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
               .LabelTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight:normal;
            color: #004080;
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

  <fieldset style="width:740px; flex-align:center;">
      <legend align="left"><b><font color="#4B6C9E" face="Arial">Lista Fornecedor</font></b></legend>
      <asp:Label ID="lblMesagem1" runat="server" style="color: #FF0000; font-weight: 700; font-family: Arial; font-size: small" ></asp:Label>
      <br />

  
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
          Style="text-align: left" Width="713px"
          OnPageIndexChanging="GridView1_PageIndexChanging" BorderStyle="None" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          <Columns>
              <asp:HyperLinkField DataNavigateUrlFields="codigo"
                  DataNavigateUrlFormatString="WebFornecedor1.aspx?codigo={0}"
                  DataTextField="codigo" HeaderText="Codigo" />
              <asp:BoundField DataField="left(fornecedor,30)" HeaderText="Fornecedor" />
              <asp:BoundField DataField="data" HeaderText="Data" />
              <asp:BoundField DataField="fone" HeaderText="Fone" />
              <asp:BoundField DataField="celular" HeaderText="Celular" />
          </Columns>
          <EditRowStyle BackColor="#999999" />
          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#E9E7E2" />
          <SortedAscendingHeaderStyle BackColor="#506C8C" />
          <SortedDescendingCellStyle BackColor="#FFFDF8" />
          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
      </asp:GridView>
<br />
<div style="width: 689px; text-align: right">
    <asp:Button ID="Button1" runat="server" Text="Voltar" CssClass="Botao" OnClick="Button1_Click" Height="25px" Width="70px" />
</div>

       &nbsp;</fieldset><br />
&nbsp;</td>
              </tr>
            </table>
</div>


</body>

</asp:Content>
