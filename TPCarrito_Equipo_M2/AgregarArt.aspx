<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AgregarArt.aspx.cs" Inherits="TPCarrito_Equipo_M2.AgregarArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtCod" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCod" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" TextMode="Number" ID="txtPrecio" CssClass="form-control" />
            </div>
        </div>
        <div class="col-4">
            <div class="mb-3">
                <img src="https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ=" class="img-thumbnail" alt="300">
                <div class="row">

                <div class="col-4">
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Agregar Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagen" TextMode="Url" placeholder="Url imagen" CssClass="form-control" />
                    </div>
                </div>
                    <div class="col-4"></div>
                <div class="col-4">
                    <div class="mb-3">
                        <br />
                        <asp:Button Text="Agregar Imagen" ID="btnAgregarImagen" OnClick="btnAgregarImagen_Click" runat="server" />
                    </div>
                </div>


                </div>
                
            </div>
        </div>

    </div>
</asp:Content>
