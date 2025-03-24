<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Banca_En_Linea.Formularios.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Easy pay</title>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/bs-brain@2.0.4/components/heroes/hero-5/assets/css/hero-5.css" />
</head>
<body>
    <!-- Hero 5 - Bootstrap Brain Component -->
    <section class="bsb-hero-5 px-3 bsb-overlay" style="background-image: url('<%= ResolveUrl("~/Images/pexels-dana-tentis-118658-370799.jpg") %>');">
        <div class="container">
            <div class="row justify-content-md-center align-items-center">
                <div class="col-12 col-md-11 col-lg-9 col-xl-8 col-xxl-7">
                    <h2 class="display-1 text-white text-center fw-bold mb-4">Easy pay</h2>
                    <p class="lead text-white text-center mb-5 d-flex justify-content-sm-center">
                        <span class="col-12 col-sm-10 col-md-8 col-xxl-7">Plataforma de pagos con seguridad avanzada y facilidad de uso. Gestiona tus transacciones con confianza y sin complicaciones.</span>
                    </p>
                    <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                        <button type="button" class="btn bsb-btn-2xl btn-outline-light">Registrarse</button>
                        <button type="button" class="btn bsb-btn-2xl btn-outline-light">Iniciar Sesión</button>

                    </div>
                </div>
            </div>
        </div>
    </section>
</body>
</html>
