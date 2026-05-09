<%@ Page Language="C#" 
MasterPageFile="~/Site.Master"
AutoEventWireup="true" 
CodeBehind="Appointments.aspx.cs" 
Inherits="MOLLCommunityClinicWeb1.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

    <h2>📅 Book Appointment</h2>

    <asp:Label ID="lblMessage" runat="server" CssClass="msg-success"></asp:Label>

    <hr />

    <!-- PATIENT ID -->
    <div class="form-group">
        <label>Patient ID</label>
        <asp:TextBox ID="txtPatientId" runat="server" />
        <asp:RequiredFieldValidator 
            ControlToValidate="txtPatientId"
            runat="server"
            ErrorMessage="Patient ID required"
            ForeColor="Red" />
    </div>

    <!-- DATE -->
    <div class="form-group">
        <label>Appointment Date</label>
        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" />
        <asp:RequiredFieldValidator 
            ControlToValidate="txtDate"
            runat="server"
            ErrorMessage="Date required"
            ForeColor="Red" />
    </div>

    <!-- REASON -->
    <div class="form-group">
        <label>Reason</label>
        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="4" />
        <asp:RequiredFieldValidator 
            ControlToValidate="txtReason"
            runat="server"
            ErrorMessage="Reason required"
            ForeColor="Red" />
    </div>

    <!-- STATUS -->
    <div class="form-group">
        <label>Status</label>
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Text="Pending" Value="Pending" Selected="True" />
            <asp:ListItem Text="Confirmed" Value="Confirmed" />
            <asp:ListItem Text="Cancelled" Value="Cancelled" />
        </asp:DropDownList>
    </div>

    <!-- BUTTON -->
    <asp:Button ID="btnSubmit" runat="server"
        Text="Book Appointment"
        CssClass="btn btn-primary"
        OnClick="btnSubmit_Click" />

</div>

</asp:Content>