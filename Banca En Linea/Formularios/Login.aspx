<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Banca_En_Linea._Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="d-flex justify-content-center align-items-center vh-100">

        <div class="container text-center">
            <section aria-labelledby="aspnetTitle">
                <h1 id="aspnetTitle">Bienvenido a Easy Pay</h1>
            </section>
            <div class="card text-center mb-3 mx-auto" style="width: 18rem;">
                <h5 class="card-header">Iniciar sesión</h5>
                <div class="card-body">
                    <img src="..." class="rounded mb-3" alt="...">
                    <div class="form-floating mb-3">
                        <input type="email" class="form-control" id="txtUsuario" placeholder="Usuario o Correo">
                        <label for="floatingInput">Usuario o Correo</label>
                    </div>
                    <div class="form-floating">
                        <input type="password" class="form-control" id="txtContrasena" placeholder="Contraseña">
                        <label for="floatingPassword">Contraseña</label>
                    </div>
                    <div class="d-grid gap-2 col-6 mx-auto">
                        <button class="btnlogin" type="button">Iniciar Sesión</button>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
