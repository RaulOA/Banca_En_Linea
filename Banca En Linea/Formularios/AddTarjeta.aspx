    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTarjeta.aspx.cs" Inherits="Banca_En_Linea._AddTarjeta" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <main>
        <div class="bg-light py-3 py-md-5">
            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-12 col-md-11 col-lg-8 col-xl-7 col-xxl-6">
                        <div class="bg-white p-4 p-md-5 rounded shadow-sm">
                            <div class="row">
                                <div class="col-12">
                                    <div class="text-center mb-4">
                                        <a href="#!">
                                            <img src=<%= ResolveUrl("~/Images/Easy_pay__1_-removebg.png") %> alt="BootstrapBrain Logo" width="200" height="200">
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <form action="#!">
                                <div class="row gy-3 gy-md-4">
                                    <div class="col-12">
                                        <label for="txtNombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                                        <div class="input-group">
                                            <span class="input-group-text">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-vcard" viewBox="0 0 16 16">
                                                    <path d="M5 8a2 2 0 1 0 0-4 2 2 0 0 0 0 4m4-2.5a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4a.5.5 0 0 1-.5-.5M9 8a.5.5 0 0 1 .5-.5h4a.5.5 0 0 1 0 1h-4A.5.5 0 0 1 9 8m1 2.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5" />
                                                    <path d="M2 2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2zM1 4a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H8.96c.026-.163.04-.33.04-.5C9 10.567 7.21 9 5 9c-2.086 0-3.8 1.398-3.984 3.181A1.006 1.006 0 0 1 1 12z" />
                                                </svg>
                                            </span>  
                                            <asp:TextBox type="text" id="txtNombre" class="form-control" placeholder="Nombre" runat="server" required/>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <label for="txtNumeroTarjeta" class="form-label">Número de tarjeta <span class="text-danger">*</span></label>
                                        <asp:TextBox type="text" id="txtNumeroTarjeta" class="form-control" runat="server" placeholder="1234 5678 9012 3456" required/>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="txtFechaVencimiento" class="form-label">Fecha de vencimiento <span class="text-danger">*</span></label>
                                        <asp:TextBox type="text" id="txtFechaVencimiento" class="form-control" runat="server" placeholder="MM/YY" required/>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="txtcvv" class="form-label">CVV<span class="text-danger">*</span></label>
                                        <asp:TextBox type="text" id="txtcvv" class="form-control" runat="server" placeholder="123" required/>
                                    </div>
                                    <div class="col-12">
                                        <div class="d-grid">
                                            <asp:button ID="BtnRegistro" runat="server" CssClass="btn btn-primary btn-lg" type="submit" text="Añadir tarjeta" onclick="BtnAddTarjeta_Click" />
                                        </div>
                                    </div>
                                    <div class="col-12">
                                         <div class="form-floating mb-3">
                                            <asp:Label ID="LblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </main>

</asp:Content>
