<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPerson.aspx.cs" Inherits="Phonebook.InsertPerson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_FirstName" runat="server" Text="First Name" />
            &nbsp;
       
            <asp:TextBox ID="tb_FirstName" runat="server" />
            <br />
            <br />
            <asp:Label ID="lbl_LastName" runat="server" Text="Last Name" />
            &nbsp;
       
            <asp:TextBox ID="tb_LastName" runat="server" />
            <br />
            <br />
            <asp:Label ID="lbl_Address" runat="server" Text="Address" />
            &nbsp &nbsp; &nbsp;
       
            <asp:TextBox ID="tb_Address" runat="server" />
            <br />
            <br />
            <asp:Button ID="btn_SavePerson" runat="server" Text="Save" OnClick="btn_SavePerson_Click" />
            <asp:Button ID="btn_back" runat="server" Text="Back to Phonebook" OnClick="btn_back_Click" />
        </div>
    </form>
</body>
</html>
