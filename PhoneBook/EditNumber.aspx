<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditNumber.aspx.cs" Inherits="Phonebook.EditNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_PhoneNumber" runat="server" Text="Phone Number:" />
            &nbsp;
           
            <asp:TextBox ID="tb_PhoneNumber" runat="server" />
            <br />
            <br />
            <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" />
            <asp:Button ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click" />
        </div>
    </form>
</body>
</html>
