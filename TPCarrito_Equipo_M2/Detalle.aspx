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
                    <asp:Label ID="lblDescripcion" runat="server" />
                </p>
                <br />
                <h6>
                    <asp:Label ID="lblMarca" runat="server" /></h6>
                <div>
                    <label>$  </label>
                    <asp:Label ID="lblPrecio" runat="server" />
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col">

                            <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                <asp:Button Text="-" ID="btnDisminuye" CssClass="btn btn-success" OnClick="btnDisminuye_Click" runat="server" />
                                <h5>
                                    <asp:TextBox ID="txtCantidad" runat="server" Width="44">1</asp:TextBox></h5>
                                <asp:Button Text="+" ID="btnAumenta" CssClass="btn btn-success" OnClick="btnAumenta_Click" runat="server" />
                            </div>


                        </div>
                    </div>
                    <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-success" Text="Agregar al Carrito" OnClick="btnAgregarCarrito_Click" CommandArgument='<%#Eval("IdArtciulo") %>' />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
