<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Banca_En_Linea._Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro</title>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="bg-light p-3 p-md-4 p-xl-5">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-12 col-xxl-11">
                            <div class="card border-light-subtle shadow-sm">
                                <div class="row g-0">
                                    <!-- Imagen -->
                                    <div class="col-12 col-md-6">
                                        <img class="img-fluid rounded-start w-100 h-100 object-fit-cover" loading="lazy"
                                            src="<%= ResolveUrl("~/Images/pexels-dana-tentis-118658-370799.jpg") %>"
                                            alt="Bienvenido a Easy Pay!" />
                                    </div>

                                    <!-- Formulario -->
                                    <div class="col-12 col-md-6 d-flex align-items-center justify-content-center">
                                        <div class="col-12 col-lg-11 col-xl-10">
                                            <div class="card-body p-3 p-md-4 p-xl-5">
                                                <div class="row gy-3 overflow-hidden">

                                                    <!-- Cédula -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtCedula" runat="server" TextMode="Number"></asp:TextBox>
                                                            <label for="TxtCedula" class="form-label">Cédula</label>
                                                        </div>
                                                    </div>

                                                    <!-- Nombre -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtNombre" runat="server"></asp:TextBox>
                                                            <label for="TxtNombre" class="form-label">Nombre</label>
                                                        </div>
                                                    </div>

                                                    <!-- Apellido -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtApellido" runat="server"></asp:TextBox>
                                                            <label for="TxtApellido" class="form-label">Apellido</label>
                                                        </div>
                                                    </div>

                                                    <!-- Usuario -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtUsuario" runat="server"></asp:TextBox>
                                                            <label for="TxtUsuario" class="form-label">Nombre de Usuario</label>
                                                        </div>
                                                    </div>

                                                    <!-- Contraseña -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtPass1" runat="server" TextMode="Password"></asp:TextBox>
                                                            <label for="TxtPass1" class="form-label">Contraseña</label>
                                                        </div>
                                                    </div>

                                                    <!-- Confirmar contraseña -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtPass2" runat="server" TextMode="Password"></asp:TextBox>
                                                            <label for="TxtPass2" class="form-label">Repita Contraseña</label>
                                                        </div>
                                                    </div>

                                                    <!-- Fecha de nacimiento -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtNacimiento" runat="server" TextMode="Date"></asp:TextBox>
                                                            <label for="TxtNacimiento" class="form-label">Fecha de Nacimiento</label>
                                                        </div>
                                                    </div>

                                                    <!-- Dirección -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtDireccion" runat="server"></asp:TextBox>
                                                            <label for="TxtDireccion" class="form-label">Dirección</label>
                                                        </div>
                                                    </div>

                                                    <!-- Teléfono -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtTelefono" runat="server" TextMode="Number"></asp:TextBox>
                                                            <label for="TxtTelefono" class="form-label">Teléfono</label>
                                                        </div>
                                                    </div>

                                                    <!-- Correo -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtCorreo" runat="server" TextMode="Email"></asp:TextBox>
                                                            <label for="TxtCorreo" class="form-label">Correo</label>
                                                        </div>
                                                    </div>

                                                    <!-- Pregunta de seguridad -->
                                                    <div class="col-12">
                                                        <div class="mb-3">
                                                            <label for="DdlPregunta" class="form-label">Pregunta de seguridad</label>
                                                            <asp:DropDownList ID="DdlPregunta" runat="server" CssClass="form-select" required>
                                                                <asp:ListItem Text="Selecciona una pregunta..." Value="" Selected="True" Disabled="True"></asp:ListItem>
                                                                <asp:ListItem Text="¿Cómo se llamaba tu primera mascota?" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="¿Cuál es el segundo nombre de tu madre/padre?" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="¿Cuál es tu libro favorito de la infancia?" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox CssClass="form-control" ID="TxtRespuesta" runat="server"></asp:TextBox>
                                                            <label for="TxtRespuesta" class="form-label">Respuesta</label>
                                                        </div>
                                                    </div>

                                                    <!-- Botón de registro -->
                                                    <div class="col-12">
                                                        <div class="d-grid">
                                                            <asp:Button ID="BtnRegistro" runat="server" CssClass="btn btn-dark btn-lg" Text="Registrarse" OnClick="BtnRegistro_Click" />
                                                        </div>
                                                    </div>

                                                    <!-- Mensaje de error -->
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:Label ID="LblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>

                                                <!-- Enlace de inicio de sesión -->
                                                <div class="row">
                                                    <div class="col-12">
                                                        <p class="mb-0 mt-5 text-secondary text-center">
                                                            ¿Ya estás registrado? <a href="#!" class="link-primary text-decoration-none">Ingresar</a>
                                                        </p>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- row g-0 -->
                            </div>
                            <!-- card -->
                        </div>
                        <!-- col-xxl-11 -->
                    </div>
                    <!-- row justify-content-center -->
                </div>
                <!-- container -->
            </section>

        </div>
    </form>
</body>
</html>
