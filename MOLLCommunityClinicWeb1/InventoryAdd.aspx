<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="InventoryAdd.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.InventoryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inventory Add Form</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

    <br /><br />

    Item:
    <asp:TextBox ID="txtItem" runat="server" CssClass="form-control" /><br />

    Date Added:
    <asp:TextBox ID="txtDateAdded" runat="server" TextMode="Date" CssClass="form-control" /><br />

    Quantity:
    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" /><br />

    Description:
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" /><br />

    Price:
    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" /><br />

    Expiration:
    <asp:TextBox ID="txtExpiration" runat="server" TextMode="Date" CssClass="form-control" /><br />

    Category:
    <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" /><br />

    Unit:
    <asp:TextBox ID="txtUnit" runat="server" CssClass="form-control" /><br />

    Batch Number:
    <asp:TextBox ID="txtBatchNumber" runat="server" CssClass="form-control" /><br />

    Manufacturer:
    <asp:TextBox ID="txtManufacturer" runat="server" CssClass="form-control" /><br />

    Supplier:
    <asp:TextBox ID="txtSupplier" runat="server" CssClass="form-control" /><br />

    Status:
    <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" /><br />

    Notes:
    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" /><br />

    <!-- BUTTONS -->

    <asp:Button ID="btnSave" runat="server"
        Text="Save"
        CssClass="btn btn-primary"
        OnClick="btnSave_Click" />

    <asp:Button ID="btnUpdate" runat="server"
        Text="Update"
        CssClass="btn btn-info"
        Style="margin-left:10px;"
        OnClick="btnUpdate_Click" />

    <asp:Button ID="btnClear" runat="server"
        Text="Clear"
        CssClass="btn btn-secondary"
        Style="margin-left:10px;"
        OnClick="btnClear_Click" />

    <asp:Button ID="btnBack" runat="server"
        Text="Back"
        CssClass="btn btn-warning"
        Style="margin-left:10px;"
        OnClick="btnBack_Click" />

    <asp:Button ID="btnExit" runat="server"
        Text="Exit"
        CssClass="btn btn-danger"
        Style="margin-left:10px;"
        OnClick="btnExit_Click" />

</asp:Content>
