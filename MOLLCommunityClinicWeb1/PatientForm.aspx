<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="PatientForm.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.PatientForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Patient Data Form</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

    <br /><br />

    <div>

        Full Name:<br />
        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" /><br /><br />

        Email Address:<br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" /><br /><br />

        Date of Birth:<br />
        <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="form-control" /><br /><br />

        Age:<br />
        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" /><br /><br />

        Gender:<br />
        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <br />

        Phone:<br />
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" /><br /><br />

        Address:<br />
        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" /><br /><br />

        Allergies:<br />
        <asp:TextBox ID="txtAllergies" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" /><br /><br />

        Medications:<br />
        <asp:TextBox ID="txtMedications" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" /><br /><br />

        Medical History:<br />
        <asp:TextBox ID="txtHistory" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" /><br /><br />

        <!-- BUTTONS -->

        <asp:Button ID="btnSave" runat="server"
            Text="Save"
            OnClick="btnSave_Click"
            CssClass="btn btn-primary" />

        <asp:Button ID="btnClear" runat="server"
            Text="Clear"
            OnClick="btnClear_Click"
            CssClass="btn btn-secondary"
            Style="margin-left:10px;" />

        <asp:Button ID="btnBack" runat="server"
            Text="Back"
            OnClick="btnBack_Click"
            CssClass="btn btn-info"
            Style="margin-left:10px;" />

        <asp:Button ID="btnExit" runat="server"
            Text="Exit"
            OnClick="btnExit_Click"
            CssClass="btn btn-danger"
            Style="margin-left:10px;" />

    </div>

</asp:Content>
