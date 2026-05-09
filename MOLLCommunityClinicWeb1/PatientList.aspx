<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="PatientList.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.PatientList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Patient List</h2>

<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

<br /><br />

<!-- SEARCH BAR -->
Search Patient:
<asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" />

<br />

<asp:Button ID="btnSearch" runat="server"
    Text="Search"
    CssClass="btn btn-primary"
    OnClick="btnSearch_Click" />

<asp:Button ID="btnRefresh" runat="server"
    Text="Refresh"
    CssClass="btn btn-info"
    OnClick="btnRefresh_Click"
    Style="margin-left:10px;" />

<br /><br />

<!-- GRID VIEW -->
<asp:GridView ID="gvPatients" runat="server"
    CssClass="table table-bordered"
    AutoGenerateColumns="False">

    <Columns>

        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="Name" HeaderText="Full Name" />
        <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
        <asp:BoundField DataField="Age" HeaderText="Age" />
        <asp:BoundField DataField="Gender" HeaderText="Gender" />
        <asp:BoundField DataField="Phone" HeaderText="Phone" />
        <asp:BoundField DataField="Address" HeaderText="Address" />
        <asp:BoundField DataField="Allergies" HeaderText="Allergies" />
        <asp:BoundField DataField="MedicalHistory" HeaderText="Medical History" />
        <asp:BoundField DataField="Medications" HeaderText="Medications" />
        <asp:BoundField DataField="Email" HeaderText="Email" />

    </Columns>

</asp:GridView>

<br />

<!-- ACTION BUTTONS -->

<asp:Button ID="btnBack" runat="server"
    Text="Back"
    CssClass="btn btn-secondary"
    OnClick="btnBack_Click" />

<asp:Button ID="btnExit" runat="server"
    Text="Exit"
    CssClass="btn btn-danger"
    OnClick="btnExit_Click"
    Style="margin-left:10px;" />

</asp:Content>