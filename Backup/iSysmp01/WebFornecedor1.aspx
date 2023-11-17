<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFornecedor1.aspx.cs" Inherits="iSysmp01.WebFornecedor1" %>

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


        .LabelTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight:normal;
            color: #004080;
        }

         .CaixaTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight: normal;
            color: #000000;
            border: 1px solid #000000;
            height: 24px;
            
        }
         .Botao 
        {
            font-family: Verdana;
            font-size: 11px;
            font-weight: bold;
            color: #004080;
            background-color: #DAD7CF;
            height: 24px;
            width: 70px;
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

 
  
        #txtCidade {
            width: 127px;
        }

 
  
        </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


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
 
                      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"
                      EnableScriptGlobalization="true" EnableScriptLocalization="true">
                      </asp:ToolkitScriptManager>

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
        <table height="152" border="0" cellpadding="0" cellspacing="0" style="width: 73%">
            <tr>
                <td>
                    <fieldset id="entrada">
                        <legend align="left"><b><font color="#4B6C9E" face="Arial">Cadastro de Fornecedor</font></b></legend>
                        <table height="308" border="0" cellpadding="0" cellspacing="0" style="width: 85%">
                            <tr>
                                <th height="32" scope="col" style="text-align: left">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td class="style27">
                                                <asp:Label ID="lblmensagem1" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
                                            </td>
                                            <td style="text-align: right" class="style28">
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
            cellpadding="0" cellspacing="0" style="width: 638px">
                                        <tr>
                                            <th height="242" valign="top" scope="col">
                                                <table height="234" border="0" 
                cellpadding="0" cellspacing="0" style="width: 605px">
                                                    <tr>
                                                        <th valign="top" scope="col" class="style25">
                                                            <table border="0" 
                    cellpadding="0" cellspacing="4" style="height: 353px; width: 575px">
                                                                <tr>
                                                                    <th scope="col" class="LabelTexto" style="text-align: right">
                                                                        Codigo.:</th>
                                                                    <th width="82" scope="col">
                                                                        <div align="left" style="width: 421px" >
                                                                            
                                                                           <asp:TextBox ID="TxtCodigo" runat="server" CssClass="CaixaTexto" Width="92px" onfocus="this.className='anormal'" onblur="this.className='normal'" MaxLength="11" TabIndex="1"></asp:TextBox>
                                                                            <input type="hidden" name="txtid" id="txtid" runat="server" />
                                                                            <input name="txtdelete" type="hidden" id="txtdelete" runat="server">
<font size="2" face="Arial" class="LabelTexto">&nbsp;
 
 Data.:               
 </font>              <asp:TextBox ID="txtData" runat="server" class="CaixaTexto"
                      onfocus="this.className='anormal'" onblur="this.className='normal'" 
                      Width="97px" TabIndex="2" onkeyup="formataData(this,event);" 
                      ReadOnly="True" CssClass="CaixaTexto" MaxLength="10"></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                      PopupButtonID="Imagecale1" TargetControlID="txtData">
                      </asp:CalendarExtender>
                      <asp:Image ID="Imagecale1" runat="server" ImageUrl="~/imagens/calendario.gif" />
                                                                            </font>
                                                                        </div>
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="right" class="LabelTexto">
                                                                            Nome<font size="2" face="Arial" class="LabelTexto">.:</font></div>
                                                                    </td>
                                                                    <td   >
                                                                        <div align="left"   >
                                                                            <font size="2" face="Arial">
                                                                            <input name="txtNome" type="text" class="CaixaTexto" id="txtNome" 
                        runat="server" size="50" style="width: 413px" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="3" enableviewstate="True" maxlength="50"> </font>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="right">
                                                                          <font size="2" face="Arial" class="LabelTexto">  Tel.:</font></div>
                                                                    </td>
                                                                    <td  >
                                                                        <div align="left" >
                                                                            
                                                                                  <asp:TextBox ID="txtTel" runat="server" onfocus="this.className='anormal'"  onblur="this.className='normal'" CssClass="CaixaTexto" MaxLength="30" onkeyup="formataTelefone(this,event);" TabIndex="4"></asp:TextBox>
                                                                   &nbsp;&nbsp;<font size="2" face="Arial" class="LabelTexto">
                                                                           Cel.:</font>
                                                                            &nbsp;<asp:TextBox ID="txtCel" runat="server" onfocus="this.className='anormal'"  onblur="this.className='normal'" CssClass="CaixaTexto" MaxLength="30" onkeyup="formataTelefone(this,event);" TabIndex="5"></asp:TextBox>
                                                                            &nbsp; 
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="right">
                                                                            <font size="2" face="Arial" class="LabelTexto">email.:</font></div>
                                                                    </td>
                                                                    <td   >
                                                                        <div align="left"   >
                                                                            
                                                                            <asp:TextBox ID="txtEmail" runat="server" Width="302px" onfocus="this.className='anormal'"  onblur="this.className='normal'" CssClass="CaixaTexto" MaxLength="80" TabIndex="6"></asp:TextBox>
                                                                            
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="right" class="LabelTexto">
                                                                            Endereço<font size="2" face="Arial" class="LabelTexto">.:</font></div>
                                                                    </td>
                                                                    <td   >
                                                                        <div align="left"   >
                                                                            <font size="2" face="Arial">
                                                                            <input name="endereco" type="text" class="CaixaTexto" id="txtEnd" 
                        style="width: 413px" size="50" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="7" maxlength="80" ></font></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="right" class="LabelTexto">
                                                                            <font size="2" face="Arial" class="LabelTexto">Número.:</font></div>
                                                                    </td>
                                                                    <td style="text-align: left"   >
                                                                            <font size="2" face="Arial" class="LabelTexto">
                                                                            <input name="numero" type="text" class="CaixaTexto" id="txtNumero" size="20" runat="server" style="text-align:left; width: 128px;"  onfocus="this.className='anormal'"  onblur="this.className='normal'" tabindex="8" maxlength="40">
                                                                            CEP.:<input type="text" name="cep" class="CaixaTexto" id="txtCep" size="20" runat="server" style="text-align:left; width: 102px;"  onfocus="this.className='anormal'"  onblur="this.className='normal'" onkeyup="formataCEP(this,event);" tabindex="9" maxlength="9">
                                                                            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Height="20px" ImageUrl="~/imagens/lupa.jpg" Width="22px" />

                                                                            </font></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" class="LabelTexto">
                                                                        Cidade.:</td>
                                                                    <td class="auto-style3">
                                                                        <div align="left"   >
                                                                            
                                                                            <input name="cidade" type="text" class="CaixaTexto" id="txtCidade" runat="server"  onfocus="this.className='anormal'"  onblur="this.className='normal'" tabindex="10" maxlength="40">
                                              <font size="2" face="Arial" class="LabelTexto">Bairro.:</font>
                                                                            <asp:TextBox ID="txtBairro" name="txtBairro" runat="server" CssClass="CaixaTexto" onfocus="this.className='anormal'"  onblur="this.className='normal'" MaxLength="20" TabIndex="11" Width="140px"></asp:TextBox>
&nbsp;<font size="2" face="Arial" class="LabelTexto">UF.:</font><asp:DropDownList ID="txtUf" runat="server" Height="25px" Width="49px" CssClass="CaixaTexto" TabIndex="12">
                                                                                <asp:ListItem></asp:ListItem>
            <asp:ListItem>SP</asp:ListItem>
            <asp:ListItem>AC</asp:ListItem>
            <asp:ListItem>AL</asp:ListItem>
            <asp:ListItem>AM</asp:ListItem>
            <asp:ListItem>AP</asp:ListItem>
            <asp:ListItem>BA</asp:ListItem>
            <asp:ListItem>CE</asp:ListItem>
            <asp:ListItem>DF</asp:ListItem>
            <asp:ListItem>ES</asp:ListItem>
            <asp:ListItem>GO</asp:ListItem>
            <asp:ListItem>MA</asp:ListItem>
            <asp:ListItem>MG</asp:ListItem>
            <asp:ListItem>MS</asp:ListItem>
            <asp:ListItem>MT</asp:ListItem>
            <asp:ListItem>PA</asp:ListItem>
            <asp:ListItem>PB</asp:ListItem>
            <asp:ListItem>PE</asp:ListItem>
            <asp:ListItem>PI</asp:ListItem>
            <asp:ListItem>PR</asp:ListItem>
            <asp:ListItem>RN</asp:ListItem>
            <asp:ListItem>RO</asp:ListItem>
            <asp:ListItem>RR</asp:ListItem>
            <asp:ListItem>RJ</asp:ListItem>
            <asp:ListItem>RS</asp:ListItem>
            <asp:ListItem>SC</asp:ListItem>
            <asp:ListItem>SE</asp:ListItem>
            <asp:ListItem>TO</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        </font>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <div align="right">
                                                                            <font size="2" face="Arial" class="LabelTexto">Observa&ccedil;&otilde;es.:          </td>
                                                                    <td   >
                                                                        <div align="left"   >
                                                                            <font size="2" face="Arial">
                                                                            <textarea name="txtObs" class="CaixaTexto" id="txtObs" style="height: 94px; width: 449px;"  runat="server"  onfocus="this.className='anormal'"  onblur="this.className='normal'" tabindex="13" rows="1"></textarea> </font>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </th>
                                                        <th valign="top" scope="col" class="auto-style1">
                                                            &nbsp;</th>
                                                    </tr>
                                                </table>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table border="0" align="center" cellpadding="0" cellspacing="3" 
                style="height: 71px; width: 531px">
                                                    <tr>
                                                        <th scope="col" class="style5"></th>
                                                        <th scope="col" class="style17">
                                                            <asp:Button ID="Imprimir1" runat="server" onclick="Imprimir1_Click" Text="Imprimir" 
                    style="width: 70px; height: 24px;" class="Botao" Enabled="False" />
                                                        </th>
                                                        <th scope="col" class="style19">
                                                            <asp:Button ID="Lista" runat="server" onclick="Lista_Click" Text="Lista" style="width: 70px; height: 24px;" class="Botao" />
                                                        </th>
                                                        <th scope="col" class="style21">
                                                            <asp:Button ID="Excluir" runat="server" onClientClick="confirm_delete();" Text="Excluir" 
                    style="width: 70px; height: 24px;" class="Botao1" Enabled="False" 
                    onclick="Excluir_Click1" />
                                                        </th>
                                                        <th scope="col" class="style23">
                                                            <asp:Button ID="Alterar" runat="server" onclick="Alterar_Click" Text="Alterar" 
                    style="width: 70px; height: 24px;" class="Botao" Enabled="False" />
                                                        </th>
                                                        <th scope="col" class="auto-style2">
                                                            <asp:Button ID="Incluir" runat="server" onclick="Incluir_Click" Text="Incluir" 
                    style="width: 70px; height: 24px;" class="Botao" Enabled="False" />
                                                            <asp:Button ID="Salvar" runat="server"  Text="Salvar" 
                    style="width: 70px; height: 24px;" class="Botao" onclick="Salvar_Click" 
                    Visible="False" Height="24px" />
                                                        </th>
                                                        <th scope="col" class="auto-style4">
                                                            <asp:Button ID="txtConsulta" runat="server" onclick="Consulta_Click" Text="Consulta" class="Botao" Height="24px" />
                                                        </th>
                                                        <th scope="col" class="style4"></th>
                                                    </tr>
                                                    <tr>
                                                        <td class="style6">
                                                            <div align="center">
                                                            </div>
                                                        </td>
                                                        <td class="style18">
                                                            <div align="center">
                                                                <asp:Button ID="Inicio" runat="server" onclick="Inicio_Click" Text="<<" style="width: 35px; " class="Botao" Height="24px" />
                                                                <asp:Button ID="Anterior" runat="server" onclick="Anterior_Click" Text="<" style="width: 35px; height: 24px;" class="Botao" />
                                                                </th>
                                                            </div>
                                                        </td>
                                                        <td class="style20">
                                                            <div align="center">
                                                                <asp:Button ID="Proximo" runat="server" onclick="Proximo_Click" Text=">" style="width: 35px; height: 24px;" class="Botao" />
                                                                <asp:Button ID="Fim" runat="server" onclick="Fim_Click" Text=">>" 
                    style="width: 35px; " class="Botao" Height="24px" />
                                                            </div>
                                                        </td>
                                                        <td class="style22">
                                                            <div align="center">
                                                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="........" style="width: 70px; " class="Botao" Height="24px" />
                                                            </div>
                                                        </td>
                                                        <td class="style24">
                                                            <div align="center">
                                                                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="........" style="width: 70px; height: 24px;" class="Botao" Height="24px" />
                                                            </div>
                                                        </td>
                                                        <td class="auto-style2">
                                                            <div align="center">
                                                                <asp:Button ID="Limpar" runat="server" onclick="Limpar_Click" Text="Limpar" 
                    style="width: 70px; height: 21px;" class="Botao" Height="24px" />
                                                                <asp:Button ID="Cancelar" runat="server" Text="Cancelar" 
                    onclick="Cancelar_Click" style="width: 70px; height: 24px;" class="Botao" 
                    Visible="False" Height="24px" />
                                                            </div>
                                                        </td>
                                                        <td class="auto-style4">
                                                            <div align="center">
                                                                <asp:Button ID="Sair" runat="server" onclick="Sair_Click" Text="Sair" style="width: 70px; height: 24px;" class="Botao" Height="24px" />
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div align="center">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </th>
                            </tr>
                        </table>
                    </fieldset>
                    <br />&nbsp;</td>
            </tr>
        </table>
    </div>


</body>


</asp:Content>
