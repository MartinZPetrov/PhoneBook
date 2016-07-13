<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertNumber.aspx.cs" Inherits="Phonebook.InsertNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_Number" runat="server" Text="Phone Number:" />
            &nbsp;<asp:TextBox ID="tb_PhoneNmb" runat="server" />
            <br />
            <br />
            <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
        </div>
    </form>
</body>
</html>
