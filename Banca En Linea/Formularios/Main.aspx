<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Banca_En_Linea.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

    <main>
        <section class="bg-light py-3 py-md-5 py-xl-8">
            <div class="container">
                <div class="row gy-4 gy-lg-0">
                    <!-- Columna izquierda - Perfil -->
                    <div class="col-12 col-lg-4 col-xl-3">
                        <div class="row gy-4">
                            <div class="col-12">
                                <div class="card widget-card border-light shadow-sm">
                                    <div class="card-header text-bg-primary" id="cardHeader" runat="server">Welcome, Username</div>
                                    <div class="card-body">
                                        <div class="text-center mb-3">
                                            <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid rounded-circle" ImageUrl='<%# ResolveUrl("~/Images/logo.png") %>' AlternateText="Foto de perfil" />
                                        </div>
                                        <h5 class="text-center mb-1" id="usernameLabel" runat="server">Username</h5>
                                        <p class="text-center text-secondary mb-4">Cuenta personal</p>
                                        <ul class="list-group list-group-flush mb-4">
                                            <li class="list-group-item d-flex justify-content-between align-items-center">
                                                <h6 class="m-0">Cartera</h6>
                                                <span>$0.00 USD</span>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="card widget-card border-light shadow-sm">
                                    <div class="card-header text-bg-primary">About Me</div>
                                    <div class="card-body">
                                        <ul class="list-group list-group-flush mb-0">
                                            <li class="list-group-item">
                                                <h6 class="mb-1">
                                                    <span class="bi bi-geo-alt-fill me-2"></span>
                                                    Ubicación
                                                </h6>
                                                <span></span>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Columna derecha - Contenido -->
                    <div class="col-12 col-lg-8 col-xl-9">
                        <div class="card widget-card border-light shadow-sm">
                            <div class="card-body p-4">
                                <ul class="nav nav-tabs" id="profileTab" role="tablist">
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link active" id="overview-tab" data-bs-toggle="tab" data-bs-target="#overview-tab-pane" type="button" role="tab" aria-controls="overview-tab-pane" aria-selected="true" runat="server">Información</button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile-tab-pane" type="button" role="tab" aria-controls="profile-tab-pane" aria-selected="false" runat="server">Editar perfil</button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="password-tab" data-bs-toggle="tab" data-bs-target="#password-tab-pane" type="button" role="tab" aria-controls="password-tab-pane" aria-selected="false" runat="server">Editar contraseña</button>
                                    </li>
                                </ul>

                                <div class="tab-content pt-4" id="profileTabContent">
                                    <!-- Pestaña de Información -->
                                    <div class="tab-pane fade show active" id="overview-tab-pane" role="tabpanel" aria-labelledby="overview-tab" tabindex="0">
                                        <h5 class="mb-3">Cuenta</h5>
                                        <div class="row g-0">
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Nombre Completo</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"><asp:Label ID="lblNombreCompleto" runat="server" /></div>
                                            </div>
                                            
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Email</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"><asp:Label ID="lblEmail" runat="server" /></div>
                                            </div>
                                            
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Fecha de nacimiento</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"><asp:Label ID="lblFechaNacimiento" runat="server" /></div>
                                            </div>
                                            
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Usuario</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"><asp:Label ID="lblUsuario" runat="server" /></div>
                                            </div>
                                            
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Dirección</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"><asp:Label ID="lblDireccion" runat="server" /></div>
                                            </div>
                                            
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Teléfono</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"><asp:Label ID="lblTelefono" runat="server" /></div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Pestaña de Editar Perfil -->
                                    <div class="tab-pane fade" id="profile-tab-pane" role="tabpanel" aria-labelledby="profile-tab" tabindex="0">
                                        <div class="row gy-3 gy-xxl-4">
                                            <div class="col-12 col-md-6">
                                                <label class="form-label">Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <label class="form-label">Usuario</label>
                                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <label class="form-label">Dirección</label>
                                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <label class="form-label">Teléfono</label>
                                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12">
                                                <asp:Button ID="btnGuardarPerfil" runat="server" Text="Guardar Cambios" 
                                                    CssClass="btn btn-primary" OnClick="btnGuardarPerfil_Click" />
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Pestaña de Editar Contraseña -->
                                    <div class="tab-pane fade" id="password-tab-pane" role="tabpanel" aria-labelledby="password-tab" tabindex="0">
                                        <div class="row gy-3 gy-xxl-4">
                                            <div class="col-12">
                                                <label class="form-label">Contraseña Actual</label>
                                                <asp:TextBox ID="txtContrasenaActual" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12">
                                                <label class="form-label">Nueva Contraseña</label>
                                                <asp:TextBox ID="txtNuevaContrasena" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12">
                                                <label class="form-label">Confirmar Contraseña</label>
                                                <asp:TextBox ID="txtConfirmarContrasena" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-12">
                                                <asp:Button ID="btnCambiarContrasena" runat="server" Text="Cambiar Contraseña" 
                                                    CssClass="btn btn-primary" OnClick="btnCambiarContrasena_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>