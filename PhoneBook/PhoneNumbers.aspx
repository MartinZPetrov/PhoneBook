<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneNumbers.aspx.cs" Inherits="Phonebook.PhoneNumbers" %>

<!DOCTYPE html>
<%@ Import Namespace="Phonebook" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gv_PhoneNumbers" runat="server" HeaderStyle-CssClass="pn-header" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PhoneID" HeaderText="Phone ID" SortExpression="PhoneID" Visible="false" />
                    <asp:BoundField DataField="PNumber" HeaderText="Numbers" SortExpression="PNumber" />
                    <asp:BoundField DataField="PersonID" HeaderText="Person ID" SortExpression="PersonID" Visible="false" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <a href='<%# UrlConstants.EDITNUMBER + Eval("PhoneID")%>'>Edit</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_Delete" OnCommand="lbtn_Delete_Command" CommandArgument='<%# Eval("PhoneID") %>' runat="server">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btn_InsertNumber" runat="server" Text="Insert New Number" OnClick="btn_InsertNumber_Click" />
            <br />
            <br />
            <asp:Button ID="btn_BackToPhoneBook" runat="server" Text="Back to Phonebook" OnClick="btn_BackToPhoneBook_Click" />
        </div>
    </form>
</body>
</html>
