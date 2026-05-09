<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MOLLCommunityClinicWeb1.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Contact MOLL Community Clinic</h2>

    <p>
        We are here to help you. Please send us your message and our team will respond as soon as possible.
    </p>

    <hr />

    <h4>Clinic Information</h4>
    <p>
        📍 Address: 15 Health Avenue, Kingston 10, Jamaica<br />
        📞 Phone: +1 (876) 555-2189<br />
        📧 Email: support@mollclinic.com
    </p>

    <hr />

    <h4>Send Us a Message</h4>

    <div class="form-group">
        <label>Your Name</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Your Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Message</label>
        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" />
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit Request"
        CssClass="btn btn-primary"
        OnClick="btnSubmit_Click" />

    <br /><br />

    <asp:Label ID="lblStatus" runat="server" ForeColor="Green"></asp:Label>

</asp:Content>