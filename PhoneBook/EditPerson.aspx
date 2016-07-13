<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPerson.aspx.cs" Inherits="Phonebook.EditPerson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_firstName" runat="server" Text="First name: "></asp:Label>
            &nbsp;
            <asp:TextBox ID="tb_firstName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbl_lastName" runat="server" Text="Last name: "></asp:Label>
            &nbsp;
            <asp:TextBox ID="tb_lastName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbl_Address" runat="server" Text="Adress: " />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_Address" runat="server" />
            <br />
            <br />
            <asp:Button ID="btn_Update" runat="server" Text="Update changes" OnClick="btn_Update_Click" />
            <asp:Button ID="btn_BackToPhoneBook" runat="server" Text="Back to Phonebook" OnClick="btn_BackToPhoneBook_Click" />
        </div>
    </form>
</body>
</html>
