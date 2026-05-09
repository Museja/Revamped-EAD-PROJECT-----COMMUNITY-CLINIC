<%@ Page Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="Logout.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center; margin-top:100px;">

        <h2 style="color:green;">
            You have successfully logged out
        </h2>

        <br /><br />

        <!-- Link back to login -->
        <asp:HyperLink ID="lnkLogin" runat="server"
            NavigateUrl="~/Login.aspx"
            Text="Go back to Login Page"
            CssClass="btn btn-primary"
            Style="padding:10px 20px; text-decoration:none; display:inline-block; margin-bottom:15px;" />

        <br /><br />

        <!-- Exit button -->
        <asp:Button ID="btnExit" runat="server"
            Text="Exit"
            CssClass="btn btn-danger"
            OnClick="btnExit_Click"
            Style="padding:10px 20px;" />

    </div>

</asp:Content>