<%@ Page Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="Inventorylist.aspx.cs"
Inherits="MOLLCommunityClinicWeb1.Inventorylist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inventory List</h2>

    <asp:Label ID="lblMessage"
        runat="server"
        ForeColor="Red">
    </asp:Label>

    <br /><br />

    <!-- SEARCH SECTION -->
    Search Inventory:

    <asp:TextBox ID="txtSearch"
        runat="server"
        CssClass="form-control">
    </asp:TextBox>

    <br />

    <asp:Button ID="btnSearch"
        runat="server"
        Text="Search"
        CssClass="btn btn-primary"
        OnClick="btnSearch_Click" />

    <asp:Button ID="btnRefresh"
        runat="server"
        Text="Refresh"
        CssClass="btn btn-info"
        Style="margin-left:10px;"
        OnClick="btnRefresh_Click" />

    <br /><br />

    <!-- GRIDVIEW -->
    <asp:GridView ID="gvInventory"
        runat="server"
        CssClass="table table-bordered table-striped"
        AutoGenerateColumns="False">

        <Columns>

            <asp:BoundField DataField="Id"
                HeaderText="ID" />

            <asp:BoundField DataField="Item"
                HeaderText="Item Name" />

            <asp:BoundField DataField="DateAdded"
                HeaderText="Date Added"
                DataFormatString="{0:yyyy-MM-dd}" />

            <asp:BoundField DataField="Quantity"
                HeaderText="Quantity" />

            <asp:BoundField DataField="Description"
                HeaderText="Description" />

            <asp:BoundField DataField="Price"
                HeaderText="Price"
                DataFormatString="{0:C}" />

            <asp:BoundField DataField="Expiration"
                HeaderText="Expiration"
                DataFormatString="{0:yyyy-MM-dd}" />

            <asp:BoundField DataField="Category"
                HeaderText="Category" />

            <asp:BoundField DataField="Unit"
                HeaderText="Unit" />

            <asp:BoundField DataField="BatchNumber"
                HeaderText="Batch Number" />

            <asp:BoundField DataField="Manufacturer"
                HeaderText="Manufacturer" />

            <asp:BoundField DataField="Supplier"
                HeaderText="Supplier" />

            <asp:BoundField DataField="Status"
                HeaderText="Status" />

            <asp:BoundField DataField="Notes"
                HeaderText="Notes" />

        </Columns>

    </asp:GridView>

    <br />

    <!-- ACTION BUTTONS -->
    <asp:Button ID="btnBack"
        runat="server"
        Text="Back"
        CssClass="btn btn-secondary"
        OnClick="btnBack_Click" />

    <asp:Button ID="btnExit"
        runat="server"
        Text="Exit"
        CssClass="btn btn-danger"
        Style="margin-left:10px;"
        OnClick="btnExit_Click" />

</asp:Content>