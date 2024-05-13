<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_Equipo_M2.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoria" DataField="Cat" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:ImageField HeaderText="Imagen" DataImageUrlFormatString="Imagen" />
            <asp:CommandField ShowSelectButton="true" SelectText="Agregar" HeaderText="Agregar a carrito"/>
        </Columns>
    </asp:GridView>-->


    <div class="row">
        <asp:Repeater ID="repArticulo" runat="server">
            <ItemTemplate>
                <div class="col 4">

                    <div class="card" style="width: 18rem;">
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
                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar al Carrito" />
                        </div>
                    </div>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
