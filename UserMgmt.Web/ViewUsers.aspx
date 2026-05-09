<%@ Page Title="View Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="UserMgmt.Web.ViewUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registered Users</h2>

    <a href="NewUser.aspx" class="btn btn-primary">+ New User</a>
    <asp:Button ID="Button1" runat="server" Text="Refresh"
            OnClick="btnRefresh_Click" CausesValidation="false"
            CssClass="btn btn-secondary" />

    <br /><br />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false"
                  DataKeyNames="Id" OnRowCommand="gvUsers_RowCommand"
                  AllowPaging="true" PageSize="10" OnPageIndexChanging="gvUsers_PageIndexChanging"
                  Width="100%" CellPadding="6" BorderColor="#dddddd" BorderStyle="Solid" BorderWidth="1px" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged">

        <HeaderStyle BackColor="#4a90d9" ForeColor="White" Font-Bold="true" />
        <AlternatingRowStyle BackColor="#f9f9f9" />
        <SelectedRowStyle BackColor="#cce5ff" />

        <Columns>
            <asp:BoundField DataField="Id"    HeaderText="ID" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName"  HeaderText="Last Name" />
            <asp:BoundField DataField="Email"     HeaderText="Email" />
            <asp:BoundField DataField="Gender"    HeaderText="Gender" />
            <asp:BoundField DataField="DateOfBirth"  HeaderText="Date of Birth"  DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="CellPhone"    HeaderText="Cell" />
            <asp:BoundField DataField="MobilePhone"  HeaderText="Mobile" />
            <asp:BoundField DataField="Address"      HeaderText="Address" />
            <asp:BoundField DataField="Town"         HeaderText="Town" />
            <asp:BoundField DataField="Parish"       HeaderText="Parish" />
            <asp:BoundField DataField="CreatedAt"    HeaderText="Date Added" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary"
                                    CommandName="EditUser"
                                    CommandArgument='<%# Eval("Id") %>'
                                    Text="Edit" />
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger"
                                    CommandName="DeleteUser"
                                    CommandArgument='<%# Eval("Id") %>'
                                    Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this user? This cannot be undone.');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>