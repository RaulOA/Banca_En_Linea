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
                                <!-- Navegación de pestañas -->
                                <ul class="nav nav-tabs" id="profileTab" role="tablist">
                                    <!-- Pestaña de Cuentas -->
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link active" id="Cuentatab" data-bs-toggle="tab" data-bs-target="#CuentaOverTabpane" type="button" role="tab" aria-controls="CuentaOverTabpane" aria-selected="true" runat="server">
                                            Cuentas
                                        </button>
                                    </li>
                                    <!-- Pestaña de Tarjetas -->
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="TarjetaTab" data-bs-toggle="tab" data-bs-target="#TarjetaOverTabpane" type="button" role="tab" aria-controls="TarjetaOverTabpane" aria-selected="false" runat="server">
                                            Tarjetas
                                        </button>
                                    </li>
                                    <!-- Pestaña de Perfil -->
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="overviewtab" data-bs-toggle="tab" data-bs-target="#overviewtabpane" type="button" role="tab" aria-controls="overviewtabpane" aria-selected="false" runat="server">
                                            Perfil
                                        </button>
                                    </li>
                                    <!-- Pestaña de Editar Perfil -->
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="profiletab" data-bs-toggle="tab" data-bs-target="#profiletabpane" type="button" role="tab" aria-controls="profiletabpane" aria-selected="false" runat="server">
                                            Editar perfil
                                        </button>
                                    </li>
                                    <!-- Pestaña de Editar Contraseña -->
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="passwordtab" data-bs-toggle="tab" data-bs-target="#passwordtabpane" type="button" role="tab" aria-controls="passwordtabpane" aria-selected="false" runat="server">
                                            Editar contraseña
                                        </button>
                                    </li>
                                </ul>

                                <!-- Contenido de pestañas -->
                                <div class="tab-content pt-4" id="profileTabContent">
                                    <!-- Pestaña de Cuentas: se muestra dinámicamente según la cantidad de cuentas -->
                                    <div class="tab-pane fade show active" id="CuentaOverTabpane" role="tabpanel" aria-labelledby="Cuentatab" tabindex="0">
                                        <h5 class="mb-3">Cuentas</h5>
                                        <div class="row g-4">
                                            <asp:Repeater ID="rptCuentas" runat="server">
                                                <ItemTemplate>
                                                    <div class="col-sm-12 col-md-4">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title">Cuenta <%# Container.ItemIndex + 1 %></h5>
                                                                <p class="card-text">
                                                                    Número de Cuenta: <%# Eval("NumeroCuenta") %><br />
                                                                    Moneda: <%# Eval("Moneda") %><br />
                                                                    Saldo: <%# Eval("Saldo", "{0:C}") %>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>

                                    <!-- Pestaña de Tarjetas: se muestra dinámicamente según la cantidad de tarjetas -->
                                    <div class="tab-pane fade" id="TarjetaOverTabpane" role="tabpanel" aria-labelledby="TarjetaTab" tabindex="0">
                                        <h5 class="mb-3">Tarjetas</h5>
                                        <div class="row g-4">
                                            <asp:Repeater ID="rptTarjetas" runat="server">
                                                <ItemTemplate>
                                                    <div class="col-sm-12 col-md-4">
                                                        <div class="card">
                                                            <div class="card-body">
                                                                <h5 class="card-title">Tarjeta <%# Container.ItemIndex + 1 %></h5>
                                                                <p class="card-text">
                                                                    Número de Tarjeta: <%# Eval("NumeroTarjeta") %><br />
                                                                    Fecha de Vencimiento: <%# Eval("FechaVencimiento") %>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>

                                    <!-- Pestaña de Perfil -->
                                    <div class="tab-pane fade" id="overviewtabpane" role="tabpanel" aria-labelledby="overviewtab" tabindex="0">
                                        <h5 class="mb-3">Perfil</h5>
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
                                    <div class="tab-pane fade" id="profiletabpane" role="tabpanel" aria-labelledby="profiletab" tabindex="0">
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
                                            <asp:Label ID="lblMensaje" runat="server" CssClass="alert" />
                                        </div>
                                    </div>

                                    <!-- Pestaña de Editar Contraseña -->
                                    <div class="tab-pane fade" id="passwordtabpane" role="tabpanel" aria-labelledby="passwordtab" tabindex="0">
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
                                </div><!-- Fin tab-content -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>