<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPCarrito_Equipo_M2.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm">
                <h1>
                    <asp:Label ID="lblNombre" runat="server" /></h1>


                <asp:Repeater ID="repImagenes" runat="server">
                    <ItemTemplate>
                        <img src="<%#Eval("UrlImagen") %>" class="d-block w-100" alt="">
                    </ItemTemplate>
                </asp:Repeater>



            </div>
            <div class="col-sm">
                <h2>Descripcion</h2>
                <p>
                    <asp:Label ID="lblDescripcion" runat="server" /></p>
                <br />
                <h6>
                    <asp:Label ID="lblMarca" runat="server" /></h6>
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <asp:Button Text="-" ID="btnDisminuye" CssClass="btn btn-outline-secondary" OnClick="btnDisminuye_Click" runat="server" />
                                </div>
                                <asp:TextBox ID="txtCantidad" CssClass="rounded" runat="server" Width="40">1</asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button Text="+" ID="btnAumenta" CssClass="btn btn-outline-secondary" OnClick="btnAumenta_Click" runat="server" />

                                </div>
                            </div>
                            <div>
                                <label>$  </label>
                                <asp:Label ID="lblPrecio" runat="server" />
                            </div>
                        </div>
                    </div>
                    <a href="Carrito.aspx?id=10" class="btn btn-primary">Agregar al carrito</a>
                    <!-- aca falta id del articulo y poder pasar la cantidad hacia el carrito -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
