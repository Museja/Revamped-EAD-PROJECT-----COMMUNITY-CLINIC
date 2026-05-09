<%@ Page Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="Success.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center; margin-top:80px;">

        <h2 style="color:green;">
            You have successfully registered
        </h2>

        <br />

        <asp:Button ID="btnNext" runat="server"
            Text="Next"
            CssClass="btn btn-primary"
            OnClick="btnNext_Click"
            Style="margin-right:10px; padding:10px 20px;" />

        <asp:Button ID="btnExit" runat="server"
            Text="Exit"
            CssClass="btn btn-danger"
            OnClick="btnExit_Click"
            Style="padding:10px 20px;" />

    </div>

</asp:Content>