<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUsuarios.aspx.cs" Inherits="iSysmp01.WebUsuarios" %>

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
        
        #entrada
        {
            width: 733px;
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

        .normal
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight: normal;
            border: 1px solid #000000;
            height: 24px;
            width: auto;

            background-color: White;
        }
        .anormal
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight: normal;
            border: 1px solid #000000;
            height: 24px;
            width: auto;

            background-color: #EAEBFF;
        }


        #TextArea1 {
            width: 462px;
            height: 107px;
        }


        #txtMaquina {
            width: 163px;
        }


        .auto-style2 {
            width: 17%;
        }


        .auto-style3 {
            width: 82%;
        }


        .auto-style11 {
            width: 154px;
        }
        .auto-style14 {
            width: 177px;
            text-align: left;
        }


        .auto-style13 {
            width: 44px;
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


<script type="text/javascript">
    function confirm_delete() {
        debugger;
        if (confirm("Tem certeza que deseja EXCLUIR o Registro. ?") == true) {
            document.getElementById('ContentPlaceHolder1_txtdelete').value = "SIM";
            Form1.submit();
        }
        else
            document.getElementById('ContentPlaceHolder1_txtdelete').value = "NAO";
    }

  </script>
<br />


                     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"
                      EnableScriptGlobalization="true" EnableScriptLocalization="true">
                      </asp:ToolkitScriptManager>




<div align="center">
            <br />
            <table width="28%" height="152" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td>

 

<fieldset id="entrada">
              <legend align="left"><b><font color="#4B6C9E" face="Arial">Cadastro de Usuários</font></b></legend>


<table height="308" border="0" cellpadding="0" cellspacing="0" style="width: 98%">
  <tr>
    <th height="32" scope="col" style="text-align: left">
      
      <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
      <tr>
          <td class="style27">
              <asp:Label ID="lblmensagem1" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
          </td>
          <td style="text-align: center" class="style28">
              <asp:Label ID="lblmodulo1" runat="server" 
                  Style="font-family: Arial; font-size: small; color: #0000CC;"></asp:Label>
          </td>
      </tr>
      </table>
        
      </th>
  </tr>
  <tr>
    <th height="155" valign="top" scope="col">
        <table height="304" border="0" 
            cellpadding="0" cellspacing="0" style="width: 95%">
      <tr><td >
                <table border="0" 
                    cellpadding="0" cellspacing="4" style="height: 353px; width: 98%;">
              <tr>
                <th scope="col" ><div align="right"><font size="2" face="Arial" class="LabelTexto">Login.:</font></div></th>
                <th scope="col" ><div align="left" >
                  <font size="2" face="Arial" class="LabelTexto">
                  <asp:TextBox ID="txtlogin" runat="server" CssClass="CaixaTexto" Height="24px" Width="92px" onfocus="this.className='anormal'" onblur="this.className='normal'" MaxLength="35" TabIndex="1"></asp:TextBox>
                      <input type="hidden" id="txtid" name="txtid" runat="server"/>
                    &nbsp;Senha.:<asp:TextBox ID="txtsenha" runat="server" CssClass="CaixaTexto" Height="24px" Width="93px" onfocus="this.className='anormal'" onblur="this.className='normal'" MaxLength="300" TabIndex="2"></asp:TextBox>
&nbsp;Data.:               <asp:TextBox ID="txtData" runat="server" class="CaixaTexto"
                      onfocus="this.className='anormal'" onblur="this.className='normal'" 
                        Width="97px" TabIndex="3" onkeyup="formataData(this,event);" 
                        ReadOnly="True" MaxLength="10"></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                      
                      PopupButtonID="Imagecale1" TargetControlID="txtData">
                      </asp:CalendarExtender>

                      


                      <asp:Image ID="Imagecale1" runat="server" ImageUrl="~/imagens/calendario.gif" />

                      


                    </font>
                    
                    </div></th>
              </tr>
              <tr>
                <td class="auto-style2"><div align="right"><font size="2" face="Arial" class="LabelTexto">Nome.:</font></div></td>
                <td class="auto-style3"><div align="left" class="style26">
                  <font size="2" face="Arial">
                  <input name="txtDescricao" type="text" class="CaixaTexto" id="txtNome" 
                        runat="server" size="50" style="width: 413px" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="4" enableviewstate="True" maxlength="45">
                  </font></div></td>
              </tr>
              <tr>
                <td class="auto-style2"><div align="right"><font size="2" face="Arial" class="LabelTexto">Maquina.:</font></div></td>
                <td class="auto-style3" ><div align="left">
                  <table cellpadding="0" cellspacing="0" style="width:100%;">
                        <tr>
                            <td class="auto-style11">
                  <font size="2" face="Arial" class="LabelTexto">
                  <input name="txtUnidade" type="text" class="CaixaTexto" id="txtMaquina" size="9"  
                        runat="server" onfocus="this.className='anormal'"  
                        onblur="this.className='normal'" tabindex="5" 
                        enableviewstate="True"></font></td>
                            <td class="LabelTexto" align="right">Conta.:</td>
                            <td valign="top">
                  <font size="2" face="Arial" class="LabelTexto">
                                <asp:ComboBox ID="txtConta" name="txtConta" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="6" Width="150px" Height="22px" MaxLength="20">
                      </asp:ComboBox>
                           </font></td>
                        </tr>
                    </table>
                    </div></td>
              </tr>
              <tr>
                <td class="auto-style2"><div align="right"><font size="2" face="Arial" class="LabelTexto">Programas Permitidos.:</font></div></td>
                <td class="auto-style3" ><div align="left" >
                  <font size="2" face="Arial" class="LabelTexto">
                  <textarea name="txtprogramas" type="text" class="CaixaTexto" id="txtPrograma" size="20" 
                        runat="server" onfocus="this.className='anormal'"  
                        onblur="this.className='normal'" tabindex="7" style="Width:407px; Height:122px;" cols="20" rows="1"></textarea>&nbsp;



                    
</font>
                   
</div></td>
              </tr>
              <tr>
                <td class="auto-style2"><div align="right"></div></td>
                <td class="auto-style3"><div align="left" class="style26">
                    <font size="2" face="Arial">
                    <asp:Table ID="Table1" runat="server" Height="25px" Width="180px" CssClass="LabelTexto">
                        <asp:TableRow ID="TableRow1" runat="server">
                            <asp:TableCell ID="TableCell1" runat="server">Inicio</asp:TableCell>
                            <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
                            <asp:TableCell ID="TableCell3" runat="server">Fim</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                  </font></div></td>
              </tr>
              <tr>
                <td class="auto-style2"><div align="right"><font size="2" face="Arial" class="LabelTexto">Horarios.:</font></div></td>
                <td class="auto-style3"><div align="left" class="LabelTexto">
                   
                      <table cellpadding="0" cellspacing="0" style="width:100%;">
                            <tr>
                                <td class="auto-style14">
                   
                      <input name="txthora1" type="text" class="CaixaTexto" id="txtHora1" size="20" runat="server" style="Width:64px"  onfocus="this.className='anormal'"  onblur="this.className='normal'" onkeyup="formataHora(this,event);" maxlength="5" tabindex="8" > às
                  <input name="txtHora2" type="text" class="CaixaTexto" id="txtHora2" size="20" runat="server" style="Width:65px"  onfocus="this.className='anormal'"  onblur="this.className='normal'" onkeyup="formataHora(this,event);" tabindex="9" maxlength="5" ></td>
                                <td class="auto-style13">Tipo.:</td>
                                <td style="text-align: left" valign="top"> 
                        <asp:ComboBox ID="txtTipo" name="txtConta" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="10" Width="150px" Height="22px" MaxLength="50">
                      </asp:ComboBox>


                                                </td>
                            </tr>
                      </table>


                                                </div></td>
              </tr>
              <tr>
                <td class="auto-style2"><div align="right"><font size="2" face="Arial" class="LabelTexto">Semanas.:</font></div></td>
                <td class="auto-style3"><div align="left">
                  <input name="txtSemana" type="text" class="CaixaTexto" id="txtSemana" size="120" runat="server" style="text-align:left; Width:246px"  onfocus="this.className='anormal'"  onblur="this.className='normal'" maxlength="100" tabindex="11" ></div></td>
              </tr>
              <tr>
                <td valign="top" class="auto-style2"><div align="right"><font size="2" face="Arial" class="LabelTexto">E-Mail.:</font></div></td>
                <td class="auto-style3"><div align="left">
                  <font size="2" face="Arial">
                  <input name="txtEmail" type="text" class="CaixaTexto" id="txtEmail" 
                        runat="server" size="50" style="width: 413px" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="12" enableviewstate="True" maxlength="200">

                  </font></div></td>
                  
              </tr>
                    

            </table>

          </td>
        <th height="242" valign="top" scope="col">
                <asp:Image ID="txtfoto1" runat="server" Height="104px" Width="92px" />
                <br />
                <asp:Button ID="Fotoprod1" runat="server" class="Botao" Enabled="False" OnClick="Fotoprod1_Click1" Text="Imagem" Height="24px" />

        </th>
      </tr>
          
    </table><br />
        <table border="0" align="center" cellpadding="0" cellspacing="3" 
                style="height: 71px; width: 536px">
          <tr>
            <th scope="col" class="style5"></th>
            <th scope="col" class="style17">
            <asp:Button ID="Imprimir1" runat="server" onclick="Imprimir1_Click" Text="Tabelas" 
                    style="width: 70px; height: 24px;" class="Botao" /></th>
            <th scope="col" class="style19">
            <asp:Button ID="Lista" runat="server" onclick="Lista_Click" Text="Lista" style="width: 70px; height: 24px;" class="Botao" /></th>
            <th scope="col" class="style21">
            <asp:Button ID="Excluir" runat="server" onClientClick="confirm_delete();" Text="Excluir" 
                    style="width: 70px; height: 24px;" class="Botao1" Enabled="False" 
                    onclick="Excluir_Click1" /></th>
            <th scope="col" class="style23">
            <asp:Button ID="Alterar" runat="server" onclick="Alterar_Click" Text="Alterar" 
                    style="width: 70px; height: 24px;" class="Botao" Enabled="False" /></th>
            <th scope="col" class="style23">
            <asp:Button ID="Incluir" runat="server" onclick="Incluir_Click" Text="Incluir" 
                    style="width: 70px; height: 24px;" class="Botao" Enabled="False" />
                    
                    
                <asp:Button ID="Salvar" runat="server"  Text="Salvar" 
                    style="width: 70px; height: 24px;" class="Botao" onclick="Salvar_Click" 
                    Visible="False" />
                    
                    
                    </th>
            <th scope="col" class="style19">
            <asp:Button ID="Consulta" runat="server" onclick="Consulta_Click" Text="Consulta" style="width: 70px; height: 24px;" class="Botao" /></th>
            <th scope="col" class="style4"></th>
          </tr>
          <tr>
            <td class="style6"><div align="center"></div></td>
            <td class="style18"><div align="center">
              <asp:Button ID="Inicio" runat="server" onclick="Inicio_Click" Text="<<" style="width: 35px; height: 24px;" class="Botao" />
              <asp:Button ID="Anterior" runat="server" onclick="Anterior_Click" Text="<" style="width: 35px; height: 24px;" class="Botao" /></th>
            </div></td>
            <td class="style20"><div align="center">
              <asp:Button ID="Proximo" runat="server" onclick="Proximo_Click" Text=">" style="width: 35px; height: 24px;" class="Botao" />
              <asp:Button ID="Fim" runat="server" onclick="Fim_Click" Text=">>" 
                    style="width: 35px; " class="Botao" />
            </div></td>
            <td class="style22"><div align="center">
              <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="........" style="width: 70px; height: 24px;" class="Botao" />
            </div></td>
            <td class="style24"><div align="center">
              <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="........" style="width: 70px; height: 24px;" class="Botao" />
            </div></td>
            <td class="style24"><div align="center">
              <asp:Button ID="Limpar" runat="server" onclick="Limpar_Click" Text="Limpar" 
                    style="width: 70px; " class="Botao" />

                <asp:Button ID="Cancelar" runat="server" Text="Cancelar" 
                    onclick="Cancelar_Click" style="width: 70px; height: 24px;" class="Botao" 
                    Visible="False" />
            </div></td>
            <td class="style20"><div align="center">
              <asp:Button ID="Sair" runat="server" onclick="Sair_Click" Text="Sair" style="width: 70px; height: 24px;" class="Botao" />
            </div></td>
            <td><div align="center"></div></td>
          </tr>
        </table></th>
  </tr>
</table>


</fieldset>
<br />

&nbsp;</tr>
              </tr>
            </table>
</div>


</body>


</asp:Content>
