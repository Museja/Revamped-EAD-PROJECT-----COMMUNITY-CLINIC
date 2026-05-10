<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="InventoryManagement.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.InventoryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Inventory Management</h2>

<asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

<hr />

<!-- SEARCH -->
Search Item:
<asp:TextBox ID="txtSearch" runat="server" />
<asp:Button ID="btnSearch" runat="server"
    Text="Search"
    OnClick="btnSearch_Click" />

<hr />

<!-- GRID VIEW -->
<asp:GridView ID="gvInventory" runat="server"
    AutoGenerateColumns="False"
    CssClass="table table-bordered"
    OnSelectedIndexChanged="gvInventory_SelectedIndexChanged"
    DataKeyNames="Id">

    <Columns>

        <asp:BoundField DataField="Id" HeaderText="ID" />
        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="Category" HeaderText="Category" />

        <asp:CommandField ShowSelectButton="True" SelectText="Edit" />

    </Columns>

</asp:GridView>

<hr />

<!-- EDIT SECTION -->
<h3>Edit Inventory Item</h3>

ID:
<asp:TextBox ID="txtId" runat="server" ReadOnly="true" /><br />

Item Name:
<asp:TextBox ID="txtItemName" runat="server" /><br />

Quantity:
<asp:TextBox ID="txtQuantity" runat="server" /><br />

Category:
<asp:TextBox ID="txtCategory" runat="server" /><br />

<br />

<asp:Button ID="btnUpdate" runat="server"
    Text="Update"
    CssClass="btn btn-primary"
    OnClick="btnUpdate_Click" />

<asp:Button ID="btnDelete" runat="server"
    Text="Delete"
    CssClass="btn btn-danger"
    OnClick="btnDelete_Click" />

    <asp:Button ID="btnBack" runat="server"
    Text="Back"
    CssClass="btn btn-secondary"
    OnClick="btnBack_Click"
    Style="margin-left:10px;" />

</asp:Content>