function ValidarData(campo, valor) {
  var date = valor;
 
  // data zerada considera valida
  if (date == "__/__/__" || date == "") {
      return true;
   }
  // cria uma expressão regular para validar a entrada de data
  var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[0-9]{2}");
  var ardt = new Array;
   ardt = date.split("/");
 
  // essa var será usada para arrumar datas incompletas
  var currentDate = new Date();
 
  // preenche mês atual
  if (jQuery.trim(ardt[1]) == "__") {
       ardt[1] = "" + (currentDate.getMonth() + 1);
      if (ardt[1].length == 1)
           ardt[1] = "0" + ardt[1];
 
   }
 
  // preenche ano atual
  if (jQuery.trim(ardt[2]) == "__") {
       ardt[2] = "" + (currentDate.getFullYear() - 2000);
   }
 
  // remonta
   date = ardt[0] + "/" + ardt[1] + "/" + ardt[2];
 
  //  manda de volta
   campo.value = date;
 
   erro = false;
 
  // se não passou pela expressão regular, já cai fora
  if (date.search(ExpReg) == -1) {
       erro = true;
   } // ardt[0] = dia | ardt[1] = mês | ardt[2] = ano
  else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
       erro = true;
  else if (ardt[1] == 2) {
      if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
           erro = true;
      if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
           erro = true;
   }
 
  // deu erro? mostra mensagem e retorna false
  if (erro) {
       alert("\"" + valor + "\" não é uma data válida!");
       campo.focus();
       campo.value = "";
      return false;
   }
 
  // chegou até aqui, OK
  return true;
}