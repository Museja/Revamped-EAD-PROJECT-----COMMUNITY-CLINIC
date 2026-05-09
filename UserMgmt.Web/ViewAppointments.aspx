<%@ Page Title="View Appointments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointments.aspx.cs" Inherits="UserMgmt.Web.ViewAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Appointments</h2>

    <a href="NewAppointment.aspx" class="btn btn-primary">+ New Appointment</a>
    <asp:Button ID="Button1" runat="server" Text="Refresh"
            OnClick="btnRefresh_Click" CausesValidation="false"
            CssClass="btn btn-secondary" />

    <br /><br />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

    <asp:GridView ID="gvAppts" runat="server" AutoGenerateColumns="false"
                  DataKeyNames="Id" OnRowCommand="gvAppts_RowCommand"
                  AllowPaging="true" PageSize="10" OnPageIndexChanging="gvAppts_PageIndexChanging"
                  Width="100%" CellPadding="6" BorderColor="#dddddd" BorderStyle="Solid" BorderWidth="1px">

        <HeaderStyle BackColor="#4a90d9" ForeColor="White" Font-Bold="true" />
        <AlternatingRowStyle BackColor="#f9f9f9" />
        <SelectedRowStyle BackColor="#cce5ff" />

        <Columns>
            <asp:BoundField DataField="Id"   HeaderText="ID" />
            <asp:BoundField DataField="FirstName"       HeaderText="First Name" />
            <asp:BoundField DataField="LastName"        HeaderText="Last Name" />
            <asp:BoundField DataField="Email"           HeaderText="Email" />
            <asp:BoundField DataField="Gender"          HeaderText="Gender" />
            <asp:BoundField DataField="CellPhone"       HeaderText="Cell" />
            <asp:BoundField DataField="MobilePhone"     HeaderText="Mobile" />
            <asp:BoundField DataField="Parish"          HeaderText="Parish" />
            <asp:BoundField DataField="IsNewPatient"    HeaderText="New Patient?" />
            <asp:BoundField DataField="AppointmentType" HeaderText="Type" />
            <asp:BoundField DataField="AppointmentDate" HeaderText="Date"   DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="AppointmentTime" HeaderText="Time" />
            <asp:BoundField DataField="DoctorName"      HeaderText="Doctor" />
            <asp:BoundField DataField="Notes"           HeaderText="Notes" />
            <asp:BoundField DataField="CreatedAt"       HeaderText="Date Added" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary"
                        CommandName="EditAppt"
                        CommandArgument='<%# Eval("Id") %>'
                        Text="Edit" />
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger"
                                    CommandName="DeleteAppt"
                                    CommandArgument='<%# Eval("Id") %>'
                                    Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this appointment? This cannot be undone.');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>