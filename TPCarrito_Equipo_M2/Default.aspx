<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_Equipo_M2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView runat="server" ID="dgvArticulos" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoria" DataField="Cat" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:ImageField HeaderText="Imagen" DataImageUrlField="Imagen" />

        </Columns>
    </asp:GridView>

</asp:Content>
