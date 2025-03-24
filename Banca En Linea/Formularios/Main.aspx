<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Banca_En_Linea._Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <section class="bg-light py-3 py-md-5 py-xl-8">

            <div class="container">

                <div class="row gy-4 gy-lg-0">
                    <div class="col-12 col-lg-4 col-xl-3">
                        <div class="row gy-4">
                            <div class="col-12">
                                <div class="card widget-card border-light shadow-sm">
                                    <div class="card-header text-bg-primary">Welcome, Username</div>
                                    <div class="card-body">
                                        <div class="text-center mb-3">
                                            <img src=<%= ResolveUrl("~/Images/logo.png") %> class="img-fluid rounded-circle" alt="Luna John">
                                        </div>
                                        <h5 class="text-center mb-1">Username</h5>
                                        <p class="text-center text-secondary mb-4">Cuenta personal</p>
                                        <ul class="list-group list-group-flush mb-4">
                                            <li class="list-group-item d-flex justify-content-between align-items-center">
                                                <h6 class="m-0">Cartera</h6>
                                                <span>$0.00 USD</span>
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
                                                    <span class="bii bi-geo-alt-fill me-2"></span>
                                                    Ubicación
                                                </h6>
                                                <span> </span>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-lg-8 col-xl-9">
                        <div class="card widget-card border-light shadow-sm">
                            <div class="card-body p-4">
                                <ul class="nav nav-tabs" id="profileTab" role="tablist">
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link active" id="overview-tab" data-bs-toggle="tab" data-bs-target="#overview-tab-pane" type="button" role="tab" aria-controls="overview-tab-pane" aria-selected="true">Información</button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile-tab-pane" type="button" role="tab" aria-controls="profile-tab-pane" aria-selected="false">Editar perfil</button>
                                    </li>
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link" id="password-tab" data-bs-toggle="tab" data-bs-target="#password-tab-pane" type="button" role="tab" aria-controls="password-tab-pane" aria-selected="false">Editar contraseña</button>
                                    </li>
                                </ul>
                                <div class="tab-content pt-4" id="profileTabContent">
                                    <div class="tab-pane fade show active" id="overview-tab-pane" role="tabpanel" aria-labelledby="overview-tab" tabindex="0">
                                        <h5 class="mb-3">Cuenta</h5>
                                        <div class="row g-0">
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Nombre</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Apellido</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Email</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Fecha de nacimiento</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Usuario</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">País</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                            <div class="col-5 col-md-3 bg-light border-bottom border-white border-3">
                                                <div class="p-2">Provincia</div>
                                            </div>
                                            <div class="col-7 col-md-9 bg-light border-start border-bottom border-white border-3">
                                                <div class="p-2"></div>
                                            </div>
                                           
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="profile-tab-pane" role="tabpanel" aria-labelledby="profile-tab" tabindex="0">
                                        <form action="#!" class="row gy-3 gy-xxl-4">
                                            <div class="col-12 col-md-6">
                                                <label for="inputFirstName" class="form-label">Email</label>
                                                <input type="text" class="form-control" id="inputFirstName">
                                                    </div>
                                            <div class="col-12 col-md-6">
                                                <label for="inputLastName" class="form-label">Usuario</label>
                                                <input type="text" class="form-control" id="inputLastName">
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <label for="inputEducation" class="form-label">País</label>
                                                <input type="text" class="form-control" id="inputEducation">
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <label for="inputSkills" class="form-label">Provincia</label>
                                                <input type="text" class="form-control" id="inputSkills">
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <label for="inputJob" class="form-label">Telefono</label>
                                                <input type="text" class="form-control" id="inputJob">
                                            </div>
                                            <div class="col-12">
                                                <button type="submit" class="btn btn-primary">Save Changes</button>
                                            </div>
                                        </form>
                                    </div>
                                    <div class="tab-pane fade" id="email-tab-pane" role="tabpanel" aria-labelledby="email-tab" tabindex="0">
                                        <form action="#!">
                                            <fieldset class="row gy-3 gy-md-0">
                                                <legend class="col-form-label col-12 col-md-3 col-xl-2">Email Alerts</legend>
                                                <div class="col-12 col-md-9 col-xl-10">
                                                    <div class="form-check">
                                                        <input class="form-check-input" type="checkbox" id="emailChange">
                                                        <label class="form-check-label" for="emailChange">
                                                            Email Changed
                                                        </label>
                                                    </div>
                                                    <div class="form-check">
                                                        <input class="form-check-input" type="checkbox" id="passwordChange">
                                                        <label class="form-check-label" for="passwordChange">
                                                            Password Changed
                                                        </label>
                                                    </div>
                                                    <div class="form-check">
                                                        <input class="form-check-input" type="checkbox" id="weeklyNewsletter">
                                                        <label class="form-check-label" for="weeklyNewsletter">
                                                            Weekly Newsletter
                                                        </label>
                                                    </div>
                                                    <div class="form-check">
                                                        <input class="form-check-input" type="checkbox" id="productPromotions">
                                                        <label class="form-check-label" for="productPromotions">
                                                            Product Promotions
                                                        </label>
                                                    </div>
                                                </div>
                                            </fieldset>
                                            <div class="row">
                                                <div class="col-12">
                                                    <button type="submit" class="btn btn-primary mt-4">Save Changes</button>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                    <div class="tab-pane fade" id="password-tab-pane" role="tabpanel" aria-labelledby="password-tab" tabindex="0">
                                        <form action="#!">
                                            <div class="row gy-3 gy-xxl-4">
                                                <div class="col-12">
                                                    <label for="currentPassword" class="form-label">Current Password</label>
                                                    <input type="password" class="form-control" id="currentPassword">
                                                </div>
                                                <div class="col-12">
                                                    <label for="newPassword" class="form-label">New Password</label>
                                                    <input type="password" class="form-control" id="newPassword">
                                                </div>
                                                <div class="col-12">
                                                    <label for="confirmPassword" class="form-label">Confirm Password</label>
                                                    <input type="password" class="form-control" id="confirmPassword">
                                                </div>
                                                <div class="col-12">
                                                    <button type="submit" class="btn btn-primary">Change Password</button>
                                                </div>
                                            </div>
                                        </form>
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
