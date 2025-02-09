<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Banca_En_Linea._Principal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="d-flex justify-content-center align-items-center vh-100">

        <div class="container text-center">
            <section aria-labelledby="aspnetTitle">
                <h1 id="aspnetTitle">Bienvenido a Easy Pay</h1>
            </section>
            <div class="card text-center mb-3 mx-auto" style="width: 18rem;">
                <div class="card-body">
                    <img src="..." class="rounded mb-3" alt="...">
                    <div class="d-grid gap-2 col-6 mx-auto">
                        <button class="btnInicioSesion" type="button">Iniciar Sesión</button>
                        <button class="btnRegistrarse" type="button">Registrarse</button>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
