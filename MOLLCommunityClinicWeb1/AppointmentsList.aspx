<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentsList.aspx.cs" Inherits="MOLLCommunityClinicWeb1.AppointmentsList" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Appointments List</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>All Appointments</h2>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br /><br />

        <asp:GridView ID="gvAppointments" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            OnRowDeleting="gvAppointments_RowDeleting"
            CssClass="table">

            <Columns>

                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />

                <asp:BoundField DataField="PatientId" HeaderText="Patient ID" />

                <asp:BoundField DataField="AppointmentDate" HeaderText="Date"
                    DataFormatString="{0:yyyy-MM-dd}" />

                <asp:BoundField DataField="Reason" HeaderText="Reason" />

                <asp:BoundField DataField="Status" HeaderText="Status" />

                <asp:CommandField ShowDeleteButton="True" />

            </Columns>

        </asp:GridView>

    </form>
</body>
</html>