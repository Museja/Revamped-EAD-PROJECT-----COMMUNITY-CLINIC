<%@ Page Title="Staff Dashboard"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="StaffDashboard.aspx.cs"
    Inherits="MOLLCommunityClinicWeb1.StaffDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>
    Welcome,
    <asp:Label ID="lblName" runat="server"></asp:Label>
</h2>

<hr />

<!-- ================= MENU ================= -->
<div class="menu-container">

    <h3>📊 Dashboard Menu</h3>

    <!-- INVENTORY SECTION -->
    <h4>📦 Inventory Management</h4>

    <asp:HyperLink ID="lnkInventoryManage"
        runat="server"
        NavigateUrl="~/InventoryManagement.aspx">
        ➤ Manage Inventory (Add / Edit / Delete)
    </asp:HyperLink>

    <br />

    <asp:HyperLink ID="lnkInventoryAdd"
        runat="server"
        NavigateUrl="~/InventoryAdd.aspx">
        ➤ Add Inventory Item
    </asp:HyperLink>

    <br />

    <asp:HyperLink ID="lnkInventoryList"
        runat="server"
        NavigateUrl="~/InventoryList.aspx">
        ➤ View Inventory List
    </asp:HyperLink>

    <hr />

    <!-- PATIENT SECTION -->
    <h4>🧑‍⚕️ Patient Management</h4>

    <asp:HyperLink ID="lnkUserManagement"
        runat="server"
        NavigateUrl="~/UserManagement.aspx">
        ➤ Manage Patients (Edit / Delete)
    </asp:HyperLink>

    <br />

    <asp:HyperLink ID="lnkPatientList"
        runat="server"
        NavigateUrl="~/PatientList.aspx">
        ➤ View Patient List
    </asp:HyperLink>

    <hr />

    <!-- APPOINTMENTS -->
    <h4>📅 Appointments</h4>

    <asp:HyperLink ID="lnkAppointments"
        runat="server"
        NavigateUrl="~/AppointmentsList.aspx">
        ➤ View Appointments
    </asp:HyperLink>

    <hr />

    <!-- LOGOUT -->
    <asp:Button ID="btnLogout"
        runat="server"
        Text="Logout"
        CssClass="btn btn-danger"
        OnClick="btnLogout_Click" />

</div>

</asp:Content>