<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPCarrito_Equipo_M2.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Table CssClass="table" ID="TableCarrito" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
            <asp:TableHeaderCell>Descripcion</asp:TableHeaderCell>
            <asp:TableHeaderCell>Marca</asp:TableHeaderCell>
            <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
            <asp:TableHeaderCell>Imagen</asp:TableHeaderCell>
            <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
        </asp:TableHeaderRow>
            
    </asp:Table>

</asp:Content>
