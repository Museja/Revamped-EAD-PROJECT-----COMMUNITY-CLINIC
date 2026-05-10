<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="PatientPortal.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.PatientPortal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Patient Portal</h2>

<asp:Label ID="lblMessages" runat="server" ForeColor="Green"></asp:Label>

<hr />

<!-- ================= PROFILE ================= -->
<h3>Profile</h3>

<asp:GridView ID="gvProfile" runat="server"
    CssClass="table table-bordered"
    AutoGenerateColumns="False"
    DataKeyNames="PatientID"
    OnRowEditing="gvProfile_RowEditing"
    OnRowUpdating="gvProfile_RowUpdating"
    OnRowCancelingEdit="gvProfile_RowCancelingEdit">

    <Columns>
        <asp:BoundField DataField="PatientID" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="Name" HeaderText="Full Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Phone" HeaderText="Phone" />
        <asp:BoundField DataField="Address" HeaderText="Address" />

        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>

<hr />

<!-- ================= APPOINTMENTS ================= -->
<h3>My Appointments</h3>

<asp:GridView ID="gvAppointments" runat="server"
    CssClass="table table-bordered"
    AutoGenerateColumns="True">
</asp:GridView>

<br />

Appointment ID:
<asp:TextBox ID="txtAppointmentId" runat="server" CssClass="form-control" /><br />

New Date:
<asp:TextBox ID="txtNewDate" runat="server" TextMode="Date" CssClass="form-control" /><br />

<asp:Button ID="btnBook" runat="server" Text="Book" CssClass="btn btn-success" OnClick="btnBook_Click" />
<asp:Button ID="btnReschedule" runat="server" Text="Reschedule" CssClass="btn btn-warning" OnClick="btnReschedule_Click" />
<asp:Button ID="btnCancelAppointment" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelAppointment_Click" />

<hr />

<!-- ================= MEDICAL HISTORY ================= -->
<h3>Medical History</h3>

<asp:GridView ID="gvHistory" runat="server"
    CssClass="table table-bordered"
    AutoGenerateColumns="True">
</asp:GridView>

<hr />

<asp:Button ID="btnLoad" runat="server" Text="Reload" CssClass="btn btn-info" OnClick="btnLoad_Click" />
<asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />

</asp:Content>