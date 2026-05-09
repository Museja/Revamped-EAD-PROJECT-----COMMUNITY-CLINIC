<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"CodeBehind="Registration.aspx.cs" Inherits="MOLLCommunityClinicWeb1.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create Account</h2>

<asp:Label ID="lblMessage" runat="server" CssClass="msg-error"></asp:Label>

<div class="form-group">
    <label>Full Name</label>
    <asp:TextBox ID="txtFullname" runat="server" />
</div>

<div class="form-group">
    <label>Email</label>
    <asp:TextBox ID="txtEmail" runat="server" />
</div>

<div class="form-group">
    <label>Password</label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
</div>

<div class="form-group">
    <label>Confirm Password</label>
    <asp:TextBox ID="txtConfirmpassword" runat="server" TextMode="Password" />
</div>

<div class="form-group">
    <label>Select Role</label>
    <div class="radio-group">
        <asp:RadioButton ID="radioPatient" runat="server" GroupName="Role" Text="Patient"
            AutoPostBack="true" OnCheckedChanged="Role_CheckedChanged" />

        <asp:RadioButton ID="radioAdmin" runat="server" GroupName="Role" Text="Admin"
            AutoPostBack="true" OnCheckedChanged="Role_CheckedChanged" />

        <asp:RadioButton ID="radioMedicalstaff" runat="server" GroupName="Role" Text="Medical Staff"
            AutoPostBack="true" OnCheckedChanged="Role_CheckedChanged" />
    </div>
</div>

<div class="form-group">
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false">
        <label>Admin ID</label>
        <asp:TextBox ID="txtAdminId" runat="server" />
    </asp:Panel>
</div>

<div class="form-group">
    <asp:Panel ID="pnlMedStaff" runat="server" Visible="false">
        <label>Staff ID</label>
        <asp:TextBox ID="txtMedStaff" runat="server" />
    </asp:Panel>
</div>

<asp:Button ID="btnRegister" runat="server"
    Text="Create Account"
    OnClick="btnRegister_Click"
    CssClass="btn-primary" />

</asp:Content>