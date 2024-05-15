<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPCarrito_Equipo_M2.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!--<asp:Table CssClass="table" ID="TableCarrito" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
            <asp:TableHeaderCell>Descripcion</asp:TableHeaderCell>
            <asp:TableHeaderCell>Marca</asp:TableHeaderCell>
            <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
            <asp:TableHeaderCell>Imagen</asp:TableHeaderCell>
            <asp:TableHeaderCell>Cantidad</asp:TableHeaderCell>
        </asp:TableHeaderRow>
            
    </asp:Table>-->
    <div class="row">
        <asp:Repeater ID="repCarrito" runat="server">
            <ItemTemplate>
                <div class="card mb-3" style="max-width: 1000px;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%#((Dominio.Imagen)Eval("Imagen")).UrlImagen %>" class="img-fluid rounded-start" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <p class="card-text"><small class="text-body-secondary"><%#Eval("Marca") %></small></p>
                                <p class="card-text"><small class="text-body-secondary"><%#Eval("Precio") %></small></p>

                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">

                                    <asp:Button ID="btnDescontar" runat="server" CssClass="btn btn-success" Text=" - " OnClick="btnDescontar_Click" CommandArgument='<%#Eval("Id") %>'/>
                                    <div style="display: block; text-align: center; margin: auto;">
                                        <asp:Label ID="lblContadir" runat="server" CssClass="text-body-secondary" Width="44"><%#Eval("Cantidad") %></asp:Label>
                                    </div>
                                    <asp:Button ID="btnAumentar" runat="server" CssClass="btn btn-success" Text=" + " OnClick="btnAumentar_Click" CommandArgument='<%#Eval("Id")%>' />

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div>
            <hr />
            <figure class="text-center">
                <blockquote class="blockquote">                       
                    <asp:Label ID="lblTotal" runat="server" CssClass="H2">Total: $</asp:Label>
                </blockquote>
            </figure>
        </div>
    </div>

</asp:Content>
