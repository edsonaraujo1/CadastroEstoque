<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="iSysmp01.User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="setTimeout('window.location.reload(true)',30000)" 
    style="background-color: #4B6C9E">
    <form id="form1" runat="server">
    <div style="width: 125px; text-align: center; height: 30px;">
    <font color="#CCCCCC" size="2" face="Arial">
        <asp:Label ID="lbluser_online" runat="server"></asp:Label>
     </font>
    </div>
    </form>
</body>
</html>
