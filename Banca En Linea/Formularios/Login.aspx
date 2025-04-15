<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Banca_En_Linea._Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/utilities/bsb-ls/bsb-ls.css" />
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/utilities/bsb-sep/bsb-sep.css" />
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/utilities/font-size/font-size.css" />
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/utilities/margin/margin.css" />
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/utilities/padding/padding.css" />
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
                                    <div class="col-12 col-md-6">
                                        <img src="<%= ResolveUrl("~/Images/pexels-dana-tentis-118658-370799.jpg") %>" alt="Welcome back you've been missed!" class="img-fluid rounded-start w-100 h-100 object-fit-cover" loading="lazy" />
                                    </div>
                                    <div class="col-12 col-md-6 d-flex align-items-center justify-content-center">
                                        <div class="col-12 col-lg-11 col-xl-10">
                                            <div class="card-body p-3 p-md-4 p-xl-5">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="mb-5">
                                                            <div class="text-center mb-4">
                                                                <img src="<%= ResolveUrl("~/Images/logo.png") %>" alt="" width="200" height="120" />
                                                            </div>
                                                            <h4 class="text-center">Por favor ingresa tus datos de sesión:</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row gy-3 overflow-hidden">
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" required></asp:TextBox>
                                                            <label for="email" class="form-label">Correo Electronico</label>
                                                        </div>
                                                    </div>
                                                    <div class="col-12">
                                                        <div class="form-floating mb-3" runat="server">
                                                            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" required></asp:TextBox>
                                                            <label for="password" class="form-label" runat="server">Contraseña</label>
                                                        </div>
                                                    </div>
                                                    <div class="col-12" runat="server">
                                                        <div class="d-grid" runat="server">
                                                            <asp:Button class="btn btn-dark btn-lg" ID="ButtonLogin" type="submit" runat="server" OnClick="BtnLogin_Click" Text="Iniciar Sesión " />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row" runat="server">
                                                    <div class="col-12" runat="server">
                                                        <div class="form-floating mb-3" runat="server">
                                                            <asp:Label ID="LblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                                        </div>

                                                        <!-- Enlace de inicio de sesión -->
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <p class="mb-0 mt-5 text-secondary text-center">
                                                                    ¿No tienes cuenta? <a href="/Formularios/Register.aspx" class="link-primary text-decoration-none">Registrarse</a>
                                                                </p>
                                                            </div>
                                                        </div>

                                                    </div>
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

        </div>
    </form>
</body>
</html>
