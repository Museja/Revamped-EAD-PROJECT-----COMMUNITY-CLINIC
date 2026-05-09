<%@ Page Title="Staff Login" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffLogin.aspx.cs"
    Inherits="MOLLCommunityClinicWeb1.StaffLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Staff Login</h2>

    <asp:Label ID="lblMessage" runat="server"></asp:Label>

    <div class="form-group">
        <label>Email Address</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Password</label>
        <asp:TextBox ID="txtPassword"
            runat="server"
            TextMode="Password">
        </asp:TextBox>
    </div>

    <div class="form-group">

        <label>Select Role</label>

        <div class="radio-group">

            <asp:RadioButton ID="radioAdmin"
                runat="server"
                GroupName="Role"
                Text="Admin" />

            <asp:RadioButton ID="radioMedicalStaff"
                runat="server"
                GroupName="Role"
                Text="Medical Staff" />

        </div>

    </div>

    <asp:Button ID="btnLogin"
        runat="server"
        Text="Login"
        CssClass="btn-primary"
        OnClick="btnLogin_Click" />

</asp:Content>