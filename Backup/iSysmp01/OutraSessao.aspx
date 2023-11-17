<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutraSessao.aspx.cs" Inherits="iSysmp01.OutraSessao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .Botao {
            font-family: Verdana;
            font-size: 11px;
            font-weight: bold;
            color: #004080;
            background-color: #DAD7CF;
            width: 70px;
            height: 24px;
        }

        .style4
        {
            width: 325px;
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

<script language='JavaScript'><!--
    document.onkeydown = keyCatcher;
    function keyCatcher() {
        var e = event.srcElement.tagName;

        if (event.keyCode == 8 && e != 'INPUT' && e != 'TEXTAREA') {
            event.cancelBubble = true;
            event.returnValue = false;
        }
    }
								//-->
								</script>
	
								<script language=JavaScript>
								<!--								    begin
								    var sHors = '00';
								    var sMins = '60';
								    var sSecs = 60;
								    function getSecs() {
								        sSecs--;
								        if (sSecs < 0)
								        { sSecs = 59; sMins--; if (sMins <= 9) sMins = '0' + sMins; }
								        if (sMins == '0-1')
								        { sMins = 5; sHors--; if (sHors <= 9) sHors = '0' + sHors; }
								        if (sSecs <= 9) sSecs = '0' + sSecs;
								        if (sHors == '0-1') {
								            sHors = '00'; sMins = '00'; sSecs = '00';
								            clock1.innerHTML = sHors + '<font color=#000000>:</font>' + sMins + '<font color=#000000>:</font>' + sSecs;
								        }
								        else {
								            clock1.innerHTML = sHors + '<font color=#000000>:</font>' + sMins + '<font color=#000000>:</font>' + sSecs;
								            setTimeout('getSecs()', 1000);
								        }
								    }
								//-->
								</script>


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

<fieldset style="width: 380px; background-color: #FFF8DC;">
<legend><b><font color="#4B6C9E" face="Arial">ATENÇÃO</font></b></legend>

	
								<div align=center>
								
								<table align=center border='0' bgcolor='#FFF8DC'>
								<tr>
								<td align=center class="style4">
								     <font face=arial><font color = #FF0000><b>> > > A T E N Ç Ã O < < <</b><br></font>
									                 <b>*** Usuário já Conectado !!! ***<br>
									                          Seu nome de usuário <br>
										      
                                     <asp:Label ID="lblnome_33" runat="server" style="color: #1E90FF"></asp:Label>
                                     <br>
											  &nbsp;&nbsp;ja esta em uso em outro terminal&nbsp;&nbsp;<br>
                                              &nbsp;&nbsp;isso pode interferir no uso do Sistema&nbsp;&nbsp;<br>
											  &nbsp;&nbsp;efetue o logof, ou aguarde fim da sessão
                                     &nbsp;&nbsp;											  
<div align='center'> 
	<b><font color=#ff0000 size=3 face=arial><span id='clock1'></span><script>	                                                                      setTimeout('getSecs()', 1000);</script></font></b><br>
	</div>
											  
								<table border='0' cellspacing='3' style="width: 200px">
                                  <tr>
                                    <td><div align='center'>
                                        <asp:Button ID="Button1" runat="server" Height="25px" onclick="Button1_Click" 
                                            Text="Entrar" Width="70px" CssClass="Botao" />
                                        </div></td>
                                    <td><div align='center'>
                                        <asp:Button ID="Button2" runat="server" Height="25px" onclick="Button2_Click" 
                                            Text="Sair" Width="70px" CssClass="Botao" />
                                        </div></td>
                                  </tr>
                                </table>
								</td>
								</tr>
								</table>
								</div>

</fieldset>
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
