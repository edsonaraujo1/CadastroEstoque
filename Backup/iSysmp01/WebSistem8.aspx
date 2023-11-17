<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebSistem8.aspx.cs" Inherits="iSysmp01.WebSistem8" %>
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
            height: 82px;
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


<div style="left; width:928px; text-align: left;">
<asp:Label ID="lblmensage1" runat="server" style="text-align: left" ></asp:Label>
</div>
<br />
<table width="78%" border="0" cellspacing="0" cellpadding="0" style="height: 410px">
              <tr valign="top">
                <th width="48%" height="264" scope="col">
<table border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgcolor="#3A4F63"><table width="260" border="0" cellpadding="0" cellspacing="2" style="height: 183px">
      <tr>
        <th width="240" height="20"><div align="left"><font color="#FFFFFF" size="2" face="Verdana, Arial, Helvetica, sans-serif">&nbsp;&nbsp;Operador</font></div></th>
      </tr>
      <tr>
        <td height="150" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
           <tr class="menu2">
            <td width="9%" height="25"><div align="center"><img src="imagens/arrows.gif" 
                    width="8" height="8"></div></td>
            <td width="91%"><div align="left"><font size="2" face="Arial"><a href="About.aspx"><font color="#465C71" size="2" face="Arial">Informação do Sistema</font></a> </div></td>
          </tr>
          <tr class="menu2">
            <td height="25"><div align="center"><img src="imagens/arrows.gif" width="8" height="8"></div></td>
            <td><div align="left"><font size="2" face="Arial"><a href="#"><font color="#465C71" size="2" face="Arial">Configuração do Servidor</font></a> </div></td>
          </tr>
          <tr class="menu2">
            <td height="25"><div align="center"><img src="imagens/arrows.gif" width="8" height="8"></div></td>
            <td><div align="left"><font size="2" face="Arial"><a href="#"><font color="#465C71" size="2" face="Arial">Configuração do Sistema</font></a> </div></td>
          </tr>
          <tr class="menu2">
            <td height="25"><div align="center"><img src="imagens/arrows.gif" width="8" height="8"></div></td>
            <td><div align="left"><font size="2" face="Arial"><a href="WebUsuarios.aspx"><font color="#465C71" size="2" face="Arial">Cadastro de Usuarios</font></a></div></td>
          </tr>
          <tr class="menu2">
            <td height="25"><div align="center"><img src="imagens/arrows.gif" width="8" height="8"></div></td>
            <td><div align="left"><font size="2" face="Arial"><a href="WebSend1.aspx"><font color="#465C71" size="2" face="Arial">Enviar Menssagens</font></a> </div></td>
          </tr>
          <tr class="menu2">
            <td height="25"><div align="center"><img src="imagens/arrows.gif" width="8" height="8"></div></td>
            <td><div align="left"><font size="2" face="Arial"><a href="#"><font color="#465C71" size="2" face="Arial">Reindex(Organizar)</font></a> </div></td>
          </tr>
          <tr class="menu2">
            <td height="25"><div align="center"><img src="imagens/arrows.gif" width="8" height="8"></div></td>
            <td><div align="left"><font size="2" face="Arial"><a href="#"><font color="#465C71" size="2" face="Arial">Cronometro</font></a></div></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>


&nbsp;</th>
                <th width="44%" scope="col">&nbsp;</th>
                <th width="4%" scope="col">&nbsp;</th>
                <th width="4%" scope="col">&nbsp;</th>
              </tr>
              <tr>
                <td class="style4"></td>
                <td class="style4"></td>
                <td class="style4"></td>
                <td class="style4"></td>
              </tr>
            </table>
            <br />


&nbsp;

</body>


</asp:Content>
