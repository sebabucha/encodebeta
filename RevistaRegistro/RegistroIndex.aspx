<%@ Page Title="Suscripcion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroIndex.aspx.cs" Inherits="RevistaRegistro.RegistroIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <h3>¿Queres recibir suscripciones mensuales de nuestra revista?</h3>
    <h6>¡Registrate solamente rellenando los datos solicitados!</h6>


    <div class="panel-body">
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Tipo de Documento" runat="server" />
                    <asp:DropDownList ID="dllTipoDocBuscar" runat="server" CssClass="form-control input-sm">
                        <asp:ListItem Text="Documento Nacional Identidad(DNI)" />
                        <asp:ListItem Text="Pasaporte" />
                        <asp:ListItem Text="Otro" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Numero de Documento" runat="server" />
                    <asp:TextBox runat="server" Enable="true" CssClass="form-control input-sm" placeholder="Numero de Documento" ID="txtNumDocBuscar" />
                </div>
            </div>
            <div class="col-md-2 col-md-offset-8">

                <div class="form-group">
                    <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-info" Width="100px" runat="server" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>

        <hr />


        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    
                    <asp:TextBox runat="server" ID="txtIdSuscriptor" Visible="false" TextMode="Number"></asp:TextBox> &nbsp;</div>
            </div>            
        </div>




        
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox runat="server" Enable="true" CssClass="form-control input-sm" placeholder="Nombre" ID="txtNombre" />
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Apellido" runat="server" />
                    <asp:TextBox runat="server" Enable="true" CssClass="form-control input-sm" placeholder="Apellido" ID="txtApellido" />
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Tipo de Documento" runat="server" />
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control input-sm">
                        <asp:ListItem Text="Documento Nacional Identidad(DNI)" />
                        <asp:ListItem Text="CUIL/CUIT" />
                        <asp:ListItem Text="Otro" />
                        <asp:ListItem Text="Razon Social" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Numero de Documento" runat="server" />
                    <asp:TextBox runat="server" Enable="true" CssClass="form-control input-sm" placeholder="Numero de Documento" ID="txtNumeroDocumento" />
                </div>
            </div>
        </div>  
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Direccion" runat="server" />
                    <asp:TextBox runat="server" Enable="true" CssClass="form-control input-sm" placeholder="Direccion" ID="txtDireccion" />
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Telefono" runat="server" />
                    <asp:TextBox runat="server" Enable="true" TextMode="Phone" CssClass="form-control input-sm" placeholder="Telefono" ID="txtTelefono" />
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Email" runat="server" />
                    <asp:TextBox runat="server" Enable="true" TextMode="Email" CssClass="form-control input-sm" placeholder="ejemplo@ejemplo.com" ID="txtEmail" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="form-group">
                    <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-success" Width="100px" Text="Nuevo" OnClick="btnNuevo_Click" />
                    <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-secundary" Width="100px" runat="server" OnClick="btnModificar_Click" />
                </div>
            </div>

        </div>








        <hr />
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Usuario" runat="server" />
                    <asp:TextBox runat="server" Enable="true" CssClass="form-control input-sm" placeholder="Usuario" ID="txtUsuario" />
                </div>
            </div>
            <div class="col-md-4 col-md-offset-1">
                <div class="form-group">
                    <asp:Label Text="Contraseña" runat="server" />
                    <asp:TextBox runat="server" Enable="true" TextMode="Phone" CssClass="form-control input-sm" placeholder="Contraseña" ID="txtContraseña"/>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="form-group">
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-success" Width="100px" Text="Aceptar" OnClick="btnAceptar_Click" />
                     <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secundary" Width="100px" runat="server" />
                </div>
            </div>

        </div>



    </div>

</asp:Content>


