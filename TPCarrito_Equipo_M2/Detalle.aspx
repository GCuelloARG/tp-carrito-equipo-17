<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPCarrito_Equipo_M2.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm">
                <h1>detalle con foto</h1>
                <img src="https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ=" class="rounded mx-auto d-block" alt="300">
            </div>
            <div class="col-sm">
                <h2>controles carrito</h2>
                <h3>Descripcion</h3>
                <p>breve explicacion traida desde base de datos</p>
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <asp:Button Text="-" id="btnDisminuye" CssClass="btn btn-outline-secondary" OnClick="btnDisminuye_Click" runat="server" />
                                </div>
                                <asp:TextBox ID="txtCantidad" CssClass="rounded" runat="server" Width="40">1</asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button Text="+" id="btnAumenta" cssclass="btn btn-outline-secondary" OnClick="btnAumenta_Click" runat="server" />
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <a href="Carrito.aspx?id=10" class="btn btn-primary">Agregar al carrito</a> <!-- aca falta id del articulo y poder pasar la cantidad hacia el carrito -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
