<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="UserManagement.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>User Management (Patients)</h2>

<asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

<hr />

<!-- SEARCH -->
Search Patient:
<asp:TextBox ID="txtSearch" runat="server" />
<asp:Button ID="btnSearch" runat="server"
    Text="Search"
    OnClick="btnSearch_Click" />

<hr />

<!-- RESULTS -->
<asp:GridView ID="gvPatients" runat="server"
    AutoGenerateColumns="False"
    CssClass="table table-bordered"
    OnSelectedIndexChanged="gvPatients_SelectedIndexChanged"
    DataKeyNames="PatientID">

    <Columns>

        <asp:BoundField DataField="PatientID" HeaderText="ID" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" />
        <asp:BoundField DataField="Address" HeaderText="Address" />

        <asp:CommandField ShowSelectButton="True" SelectText="Edit" />

    </Columns>

</asp:GridView>

<hr />

<!-- EDIT SECTION -->
<h3>Edit Patient</h3>

Patient ID:
<asp:TextBox ID="txtId" runat="server" ReadOnly="true" /><br />

Name:
<asp:TextBox ID="txtName" runat="server" /><br />

Email:
<asp:TextBox ID="txtEmail" runat="server" /><br />

Phone:
<asp:TextBox ID="txtPhone" runat="server" /><br />

Address:
<asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" /><br />

<br />

<asp:Button ID="btnUpdate" runat="server"
    Text="Update"
    CssClass="btn btn-primary"
    OnClick="btnUpdate_Click" />

<asp:Button ID="btnDelete" runat="server"
    Text="Delete"
    CssClass="btn btn-danger"
    OnClick="btnDelete_Click" />

</asp:Content>