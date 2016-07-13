<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Phonebook.aspx.cs" Inherits="Phonebook.Phonebook" %>

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
            <asp:Repeater ID="rptPhonebookTabel" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr class="pb-header">
                            <th scope="col">
                                <asp:LinkButton ID="lnkreq_id" runat="server" ForeColor="white" OnClick="lnkreq_id_click">ID</asp:LinkButton></th>
                            <th scope="col">
                                <asp:LinkButton ID="lnkreq_name" runat="server" ForeColor="white" OnClick="lnkreq_name_click">Name</asp:LinkButton></th>
                            <th scope="col">
                                <asp:LinkButton ID="lnkreq_address" runat="server" ForeColor="white" OnClick="lnkreq_address_click">Address</asp:LinkButton></th>
                            <th scope="col">Phone</th>
                            <th scope="col">Edit</th>
                            <th scope="col">Delete</th>
                        </tr>
                </HeaderTemplate>
                <AlternatingItemTemplate>
                    <tr class="pb-altRow">
                        <td><%# Eval("PersonID") %></td>
                        <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                        <td><%# Eval("Address") %></td>
                        <td><a href='<%# UrlConstants.PHONENUMBERSID + Eval("PersonID") %>'>Phone</a></td>
                        <td><a href='<%# UrlConstants.EDITPERSON +  Eval("PersonID") %>'>Edit</a></td>
                        <td>
                            <asp:LinkButton ID="lbtn_Delete" runat="server" OnCommand="lbtn_Delete_Command" CommandArgument='<%# Eval("PersonID") %>'>Delete</asp:LinkButton></td>
                    </tr>
                </AlternatingItemTemplate>
                <ItemTemplate>
                    <tr class="pb-row">
                        <td><%# Eval("PersonID") %></td>
                        <td><%# Eval("FirstName") %> <%# Eval("LastName") %></td>
                        <td><%# Eval("Address") %></td>
                        <td><a href='<%# UrlConstants.PHONENUMBERSID + Eval("PersonID") %>'>Phone</a></td>
                        <td><a href='<%# UrlConstants.EDITPERSON +  Eval("PersonID") %>'>Edit</a></td>
                        <td>
                            <asp:LinkButton ID="lbtn_Delete" runat="server" OnCommand="lbtn_Delete_Command" CommandArgument='<%# Eval("PersonID") %>'>Delete</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
               
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <asp:Button ID="btnSearch" runat="server" Text="Search " OnClick="btnSearch_Click" />
            <asp:TextBox ID="tb_SearchText" runat="server" />
            <br />
            <br />
            <asp:Button ID="btn_InsertNewPerson" runat="server" Text="Insert New Person" OnClick="btn_InsertNewPerson_Click" />
        </div>
    </form>
</body>
</html>
