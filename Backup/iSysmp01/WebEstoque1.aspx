<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebEstoque1.aspx.cs" Inherits="iSysmp01.WebEstoque1" %>

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
        .style4
        {
            height: 18px;
        }
        .style5
        {
            height: 18px;
            width: 52px;
        }
        .style6
        {
            width: 52px;
        }
        .style17
        {
            height: 18px;
            width: 90px;
        }
        .style18
        {
            width: 90px;
        }
        .style19
        {
            height: 18px;
            width: 83px;
        }
        .style20
        {
            width: 83px;
        }
        .style21
        {
            height: 18px;
            width: 85px;
        }
        .style22
        {
            width: 85px;
        }
        .style23
        {
            height: 18px;
            width: 80px;
        }
        .style24
        {
            width: 80px;
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
        }
        .LabelTexto
        {
            font-family: Verdana;
            font-size: 13px;
            font-weight:normal;
            color: #004080;
        }

        .style25
        {
            width: 93%;
        }

        .style26
        {
            text-align: left;
            width: 432px;
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

        .style27
        {
            width: 442px;
        }
        .style28
        {
            width: 183px;
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

    
   <body OnLoad="loadImages();">
        <!--#include file="wait.asp"-->
        <%Response.Flush(); //envia conteúdo para o browser%>

        <div align="center">
            <br />
            <table width="28%" height="152" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>



                        <fieldset id="entrada">
                            <legend align="left"><b><font color="#4B6C9E" face="Arial">Cadastro de Estoque</font></b></legend>


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
                                            cellpadding="0" cellspacing="0" style="width: 105%">
                                            <tr>
                                                <th height="242" valign="top" scope="col">
                                                    <table width="91%" height="234" border="0"
                                                        cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <th valign="top" scope="col" class="style25">
                                                                <table border="0"
                                                                    cellpadding="0" cellspacing="4" style="height: 353px; width: 99%;">
                                                                    <tr>
                                                                        <th width="18%" scope="col">
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Codigo.:</font></div>
                                                                        </th>
                                                                        <th width="82%" scope="col" class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial" class="LabelTexto">
                  <input name="txtCodigo" type="text" class="CaixaTexto" id="txtCodigo" size="10" 
                        runat="server" onfocus="this.className='anormal'"  
                        onblur="this.className='normal'" tabindex="1" enableviewstate="True" maxlength="11">
                      <font size="2" face="Arial" class="LabelTexto">*</font>
                  <input name="txtid" type="hidden" id="txtid" size="10" runat="server">
                  <input name="txtdelete" type="hidden" id="txtdelete" size="1" runat="server">


 
 Data.:               <asp:TextBox ID="txtData" runat="server" class="CaixaTexto"
                      onfocus="this.className='anormal'" onblur="this.className='normal'" 
                        Width="97px" TabIndex="2" onkeyup="formataData(this,event);" 
                        ReadOnly="True" MaxLength="10"></asp:TextBox>
                      <asp:Image ID="Imagecale1" runat="server" ImageUrl="~/imagens/calendario.gif" />
                      <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                      
                      PopupButtonID="Imagecale1" TargetControlID="txtData">
                      </asp:CalendarExtender>

                      


                    </font>

                                                                            </div>
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Descri&ccedil;&atilde;o.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial">
                  <input name="txtDescricao" type="text" class="CaixaTexto" id="txtDescricao" 
                        runat="server" size="50" style="width: 403px" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="3" enableviewstate="True"></font><font size="2" face="Arial" class="LabelTexto">*</font>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Unidade.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial" class="LabelTexto">
                  <input name="txtUnidade" type="text" class="CaixaTexto" id="txtUnidade" size="9"  
                        runat="server" onfocus="this.className='anormal'"  
                        onblur="this.className='normal'" tabindex="4" 
                        onkeyup="formataInteiro(this,event);" enableviewstate="True" maxlength="11">
Qtd.Estoq.:<input name="txtQtd" type="text" class="CaixaTexto" id="txtQtd" size="9" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="5" onkeyup="formataInteiro(this,event);" maxlength="11">
Qtd.Min.: 
<input name="txtMini" type="text" class="CaixaTexto" id="txtMini" size="9" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="6" onkeyup="formataInteiro(this,event);" maxlength="11">
</font>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Classe.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">

                                                                                <asp:DropDownList ID="txtClasse" name="txtClasse" class="CaixaTexto" runat="server" onfocus="this.className='anormal'"
                                                                                    onblur="this.className='normal'" TabIndex="7" maxlength="20">
                                                                                    <asp:ListItem></asp:ListItem>
                                                                                    <asp:ListItem>CLASSE A</asp:ListItem>
                                                                                    <asp:ListItem>CLASSE B</asp:ListItem>
                                                                                    <asp:ListItem>CLASSE C</asp:ListItem>
                                                                                    <asp:ListItem>CLASSE D</asp:ListItem>
                                                                                    <asp:ListItem>CLASSE E</asp:ListItem>
                                                                                    <asp:ListItem>CLASSE F</asp:ListItem>

                                                                                </asp:DropDownList>


                                                                                <font size="2" face="Arial" class="LabelTexto">
Vencimento.: 
</font>
                                                                                <asp:TextBox ID="txtVencto" runat="server" class="CaixaTexto"
                                                                                    onfocus="this.className='anormal'" onblur="this.className='normal'"
                                                                                    Width="97px" TabIndex="8" onkeyup="formataData(this,event);" MaxLength="10"></asp:TextBox>
                                                                                <asp:Image ID="Imagecale2" runat="server" ImageUrl="~/imagens/calendario.gif" />
                                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                                                                    PopupButtonID="Imagecale2" TargetControlID="txtVencto">
                                                                                </asp:CalendarExtender>




                                                                                </font>
                   
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Fornecedor.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial">
                      <asp:ComboBox ID="txtFornecedor" name="txtFornecedor" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="9" Width="385px" Height="22px">
                      </asp:ComboBox>
                      <input name="txtidforne" type="hidden" id="txtidforne" size="10" runat="server">
                  </font>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Refer&ecirc;ncia.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial">
                  <input name="txtRefere" type="text" class="CaixaTexto" id="txtRefere" 
                        style="width: 413px" size="50" runat="server" 
                        onfocus="this.className='anormal'"  onblur="this.className='normal'" 
                        tabindex="10" maxlength="50" >
                  </font>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Saldo.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial" class="LabelTexto">
                  <input name="txtSaldo" type="text" class="CaixaTexto" id="txtSaldo" size="20" runat="server" style="text-align:right;"  onfocus="this.className='anormal'"  onblur="this.className='normal'" onkeyup="formataValor(this,event);" tabindex="11" maxlength="12">
Valor.: 
<input name="txtValor" type="text" class="CaixaTexto" id="txtValor" size="20" runat="server" style="text-align:right;"  onfocus="this.className='anormal'"  onblur="this.className='normal'" onkeyup="formataValor(this,event);" tabindex="12" maxlength="12">
</font>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div align="right"><font size="2" face="Arial" class="LabelTexto">Observa&ccedil;&otilde;es.:</font></div>
                                                                        </td>
                                                                        <td class="style26">
                                                                            <div align="left" class="style26">
                                                                                <font size="2" face="Arial">
                  <textarea name="txtObs" class="CaixaTexto" id="txtObs" style="height: 94px; width: 425px;"  runat="server"  onfocus="this.className='anormal'"  onblur="this.className='normal'" tabindex="13"></textarea>
                  </font>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </th>
                                                            <th width="21%" valign="top" scope="col">
                                                                <table border="0"
                                                                    align="center" cellpadding="0" cellspacing="3"
                                                                    style="height: 134px; width: 65%;">
                                                                    <tr>
                                                                        <th height="101" scope="col">
                                                                            <asp:Image ID="foto1" runat="server" Height="116px" Width="110px"
                                                                                BorderStyle="None" />
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="center">
                                                                                <asp:Button ID="Fotoprod1" runat="server" OnClick="Fotoprod1_Click" Text="Imagem"
                                                                                    Style="width: 70px; height: 24px;" class="Botao" Enabled="False" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <asp:Label ID="lblBarra1" runat="server" Style="font-family: EAN-13; font-size: 30pt" ForeColor="Black"></asp:Label>
                                                                <br />
                                                            </th>
                                                        </tr>
                                                    </table>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table border="0" align="center" cellpadding="0" cellspacing="3"
                                                        style="height: 71px; width: 99%">
                                                        <tr>
                                                            <th scope="col" class="style5"></th>
                                                            <th scope="col" class="style17">
                                                                <asp:Button ID="Imprimir1" runat="server" OnClick="Imprimir1_Click" Text="Imprimir"
                                                                    Style="width: 70px; height: 24px;" class="Botao" Enabled="False" /></th>
                                                            <th scope="col" class="style19">
                                                                <asp:Button ID="Lista" runat="server" OnClick="Lista_Click" Text="Lista" Style="width: 70px; height: 24px;" class="Botao" /></th>
                                                            <th scope="col" class="style21">
                                                                <asp:Button ID="Excluir" runat="server" OnClientClick="confirm_delete();" Text="Excluir"
                                                                    Style="width: 70px; height: 24px;" class="Botao1" Enabled="False"
                                                                    OnClick="Excluir_Click1" /></th>
                                                            <th scope="col" class="style23">
                                                                <asp:Button ID="Alterar" runat="server" OnClick="Alterar_Click" Text="Alterar"
                                                                    Style="width: 70px; height: 24px;" class="Botao" Enabled="False" /></th>
                                                            <th scope="col" class="style23">
                                                                <asp:Button ID="Incluir" runat="server" OnClick="Incluir_Click" Text="Incluir"
                                                                    Style="width: 70px; height: 24px;" class="Botao" Enabled="False" />


                                                                <asp:Button ID="Salvar" runat="server" Text="Salvar"
                                                                    Style="width: 70px; height: 24px;" class="Botao" OnClick="Salvar_Click"
                                                                    Visible="False" />


                                                            </th>
                                                            <th scope="col" class="style19">
                                                                <asp:Button ID="Consulta" runat="server" OnClick="Consulta_Click" Text="Consulta" Style="width: 70px; height: 24px;" class="Botao" /></th>
                                                            <th scope="col" class="style4"></th>
                                                        </tr>
                                                        <tr>
                                                            <td class="style6">
                                                                <div align="center"></div>
                                                            </td>
                                                            <td class="style18">
                                                                <div align="center">
                                                                    <asp:Button ID="Inicio" runat="server" OnClick="Inicio_Click" Text="<<" Style="width: 35px; height: 24px;" class="Botao" />
                                                                    <asp:Button ID="Anterior" runat="server" OnClick="Anterior_Click" Text="<" Style="width: 35px; height: 24px;" class="Botao" />
                                                                </div>
                                                            </td>
                                                            <td class="style20">
                                                                <div align="center">
                                                                    <asp:Button ID="Proximo" runat="server" OnClick="Proximo_Click" Text=">" Style="width: 35px; height: 24px;" class="Botao" />
                                                                    <asp:Button ID="Fim" runat="server" OnClick="Fim_Click" Text=">>"
                                                                        Style="width: 35px;" class="Botao" />
                                                                </div>
                                                            </td>
                                                            <td class="style22">
                                                                <div align="center">
                                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="........" Style="width: 70px; height: 24px;" class="Botao" />
                                                                </div>
                                                            </td>
                                                            <td class="style24">
                                                                <div align="center">
                                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="........" Style="width: 70px; height: 24px;" class="Botao" />
                                                                </div>
                                                            </td>
                                                            <td class="style24">
                                                                <div align="center">
                                                                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Limpar"
                                                                        Style="width: 70px;" class="Botao" />

                                                                    <asp:Button ID="Cancelar" runat="server" Text="Cancelar"
                                                                        OnClick="Cancelar_Click" Style="width: 70px; height: 24px;" class="Botao"
                                                                        Visible="False" />
                                                                </div>
                                                            </td>
                                                            <td class="style20">
                                                                <div align="center">
                                                                    <asp:Button ID="Sair" runat="server" OnClick="Sair_Click" Text="Sair" Style="width: 70px; height: 24px;" class="Botao" />
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div align="center"></div>
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
                        <br />

                        &nbsp;</td>
                </tr>
            </table>
        </div>

    </body>

</asp:Content>
