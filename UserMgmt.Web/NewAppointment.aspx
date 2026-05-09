<%@ Page Title="New Appointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAppointment.aspx.cs" Inherits="UserMgmt.Web.NewAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>New Appointment</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

    <%-- Name --%>
    <div class="form-group">
        <asp:Label runat="server" Text="First Name *" />
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server"
            ControlToValidate="txtFirstName"
            ErrorMessage="First Name is required."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Last Name *" />
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvLastName" runat="server"
            ControlToValidate="txtLastName"
            ErrorMessage="Last Name is required."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Email --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Email *" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
            ControlToValidate="txtEmail"
            ErrorMessage="Email is required."
            ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="revEmail" runat="server"
            ControlToValidate="txtEmail"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ErrorMessage="Enter a valid email address."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Gender --%>
    <div class="form-group">
        <span class="field-label">Gender *</span>
        <asp:RadioButtonList ID="rblGender" runat="server"
                             RepeatDirection="Horizontal"
                             RepeatLayout="Flow"
                             CssClass="radio-inline-group">
            <asp:ListItem Text="Male" Value="Male" />
            <asp:ListItem Text="Female" Value="Female" />
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfvGender" runat="server"
            ControlToValidate="rblGender"
            ErrorMessage="Please select a gender."
            ForeColor="Red" Display="Dynamic"
            InitialValue="" />
    </div>

    <%-- New Patient --%>
    <div class="form-group">
        <span class="field-label">Returning Patient? *</span>
        <asp:RadioButtonList ID="rblNewPatient" runat="server" RepeatDirection="Horizontal"
                             RepeatLayout="Flow" CssClass="radio-inline-group">
            <asp:ListItem Text="Yes" Value="Yes" />
            <asp:ListItem Text="No" Value="No" />
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfvNewPatient" runat="server"
            ControlToValidate="rblNewPatient"
            ErrorMessage="Please indicate if this is a returning patient."
            ForeColor="Red" Display="Dynamic"
            InitialValue="" />
    </div>

    <%-- Phone --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Cell Phone" />
        <asp:TextBox ID="txtCell" runat="server" CssClass="form-control" placeholder="e.g. 8761234567" MaxLength="10" />
        <asp:RegularExpressionValidator ID="revCell" runat="server"
            ControlToValidate="txtCell"
            ValidationExpression="^\d{10}$"
            ErrorMessage="Cell number must be exactly 10 digits."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Mobile Phone" />
        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="e.g. 8761234567" MaxLength="10" />
        <asp:RegularExpressionValidator ID="revMobile" runat="server"
            ControlToValidate="txtMobile"
            ValidationExpression="^\d{10}$"
            ErrorMessage="Mobile number must be exactly 10 digits."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Address --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Address *" />
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
            ControlToValidate="txtAddress"
            ErrorMessage="Address is required."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Town *" />
        <asp:TextBox ID="txtTown" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvTown" runat="server"
            ControlToValidate="txtTown"
            ErrorMessage="Town is required."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Parish --%>
    <div class="form-group">
        
        <asp:Label runat="server" Text="Parish *" />
        <asp:DropDownList ID="ddlParish" runat="server" CssClass="form-control">
            <asp:ListItem Text="Select a Parish" Value="" />
            <asp:ListItem Text="Clarendon" Value="Clarendon" />
            <asp:ListItem Text="Hanover" Value="Hanover" />
            <asp:ListItem Text="Kingston" Value="Kingston" />
            <asp:ListItem Text="Manchester" Value="Manchester" />
            <asp:ListItem Text="Portland" Value="Portland" />
            <asp:ListItem Text="Saint Andrew" Value="Saint Andrew" />
            <asp:ListItem Text="Saint Ann" Value="Saint Ann" />
            <asp:ListItem Text="Saint Catherine" Value="Saint Catherine" />
            <asp:ListItem Text="Saint Elizabeth" Value="Saint Elizabeth" />
            <asp:ListItem Text="Saint James" Value="Saint James" />
            <asp:ListItem Text="Saint Mary" Value="Saint Mary" />
            <asp:ListItem Text="Saint Thomas" Value="Saint Thomas" />
            <asp:ListItem Text="Trelawny" Value="Trelawny" />
            <asp:ListItem Text="Westmoreland" Value="Westmoreland" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvParish" runat="server"
            ControlToValidate="ddlParish"
            InitialValue=""
            ErrorMessage="Please select a parish."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Appointment Type --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Appointment Type *" />
        <asp:DropDownList ID="ddlApptType" runat="server" CssClass="form-control">
            <asp:ListItem Text="-- Select Appointment Type --" Value="" />
            <asp:ListItem Text="General Consultation" Value="General Consultation" />
            <asp:ListItem Text="Follow-up" Value="Follow-up" />
            <asp:ListItem Text="Lab Work" Value="Lab Work" />
            <asp:ListItem Text="Specialist Referral" Value="Specialist Referral" />
            <asp:ListItem Text="Routine Check-up" Value="Routine Check-up" />
            <asp:ListItem Text="Emergency" Value="Emergency" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvApptType" runat="server"
            ControlToValidate="ddlApptType"
            InitialValue=""
            ErrorMessage="Please select an appointment type."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Doctor --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Doctor *" />
        <asp:DropDownList ID="ddlDocName" runat="server" CssClass="form-control">
            <asp:ListItem Text="-- Select Doctor --" Value="" />
            <asp:ListItem Text="Dr. Brown  —  General Practice" Value="Dr. Brown  —  General Practice" />
            <asp:ListItem Text="Dr. Clarke  —  Cardiology" Value="Dr. Clarke  —  Cardiology" />
            <asp:ListItem Text="Dr. Davis  —  Paediatrics" Value="Dr. Davis  —  Paediatrics" />
            <asp:ListItem Text="Dr. Miller  —  Orthopaedics" Value="Dr. Miller  —  Orthopaedics" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvDocName" runat="server"
            ControlToValidate="ddlDocName"
            InitialValue=""
            ErrorMessage="Please select a doctor."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Appointment Date --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Appointment Date *" />
        <asp:TextBox ID="txtApptDate" runat="server" CssClass="form-control" TextMode="Date" />
        <asp:RequiredFieldValidator ID="rfvApptDate" runat="server"
            ControlToValidate="txtApptDate"
            ErrorMessage="Appointment date is required."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Appointment Time --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Appointment Time *" />
        <asp:DropDownList ID="ddlTime" runat="server" CssClass="form-control">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTime" runat="server"
            ControlToValidate="ddlTime"
            InitialValue=""
            ErrorMessage="Please select an appointment time."
            ForeColor="Red" Display="Dynamic" />
    </div>

    <%-- Notes --%>
    <div class="form-group">
        <asp:Label runat="server" Text="Notes (optional)" />
        <asp:TextBox ID="txtNotes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
    </div>

    <%-- Buttons --%>
    <div class="form-group">
    <asp:Button ID="btnSave" runat="server" Text="Create Appointment"
                OnClick="btnSave_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnClear" runat="server" Text="Clear"
                OnClick="btnClear_Click" CausesValidation="false"
                CssClass="btn btn-secondary" />
    <a href="ViewAppointments.aspx" class="btn btn-secondary">View Appointments →</a>
</div>

</asp:Content>