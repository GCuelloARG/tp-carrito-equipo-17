<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_Equipo_M2.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <asp:Repeater ID="repArticulo" runat="server" >
            <ItemTemplate>
                <div class="col 4">

                    <div class="card" style="width:18rem">
                        <img src="<%#((Dominio.Imagen)Eval("Imagen")).UrlImagen%>" class="card-img-top">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item"><%#Eval("Marca") %></li>
                            <li class="list-group-item"><%#Eval("Precio") %></li>
                        </ul>
                        <div class="card-body">
                            <a href="Detalle.aspx?id=<%#Eval("id")%>">Detalles</a>
                        </div>
                        <div class="card-body">    
                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar al Carrito" OnClick="btnAgregar_Click" CommandArgument=<%#Eval("Id")%>/>               
                        </div>
                    </div>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
