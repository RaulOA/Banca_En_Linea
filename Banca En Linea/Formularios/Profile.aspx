<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Banca_En_Linea._Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <script src="https://unpkg.com/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css" />

    <main>
        <section class="bg-light py-3 py-md-5 py-xl-8">

            <div class="container">
                <div class="row gy-4 gy-lg-0">
                    <div class="col-12 col-lg-4 col-xl-3">
                        <div class="row gy-4">
                            <div class="col-12">
                                <div class="card widget-card border-light shadow-sm">
                                    <div class="card-header text-bg-primary">Welcome,<asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario"></asp:Label></div>
                                    <div class="card-body">
                                        <div class="text-center mb-3">
                                            <asp:Image ID="imgFoto" runat="server" Width="100px" Height="100px"/>
                                        </div>
                                        <asp:Label ID="lblNombreCompleto" runat="server" Text="Nombre"></asp:Label>
                                        <asp:Label ID="lblNumeroCuenta" runat="server" Text="Cuenta"></asp:Label>
                                        <ul class="list-group list-group-flush mb-4">
                                            <li class="list-group-item d-flex justify-content-between align-items-center">
                                                <h6 class="m-0">Cartera</h6>
                                                <asp:Label ID="lblSaldo" runat="server" Text="Saldo"></asp:Label>
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
                                                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
                                                </h6>
                                                <span></span>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-lg-8 col-xl-9">
                        <div class="card widget-card border-light shadow-sm">
                            <div class="card-body p-4">
                                <div class="tab-content pt-4" id="profileTabContent">
                                    <div class="tab-pane fade show active" id="overview-tab-pane" role="tabpanel">
                                        <div class="container-fluid">
                                            <div class="row gy-4">
                                                <!-- Transferencias -->
                                                <div class="col-12 col-sm-6">
                                                    <div class="card widget-card border-light shadow-sm">
                                                        <div class="card-body p-4 d-flex justify-content-between align-items-center">
                                                            <div>
                                                                <h5 class="card-title mb-3">Transferencias</h5>
                                                                <h4 class="card-subtitle text-body-secondary m-0">$0</h4>
                                                            </div>
                                                            <div class="bg-info text-white rounded-circle p-3 d-flex align-items-center justify-content-center">
                                                                <i class="bi bi-truck fs-4"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Cartera -->
                                                <div class="col-12 col-sm-6">
                                                    <div class="card widget-card border-light shadow-sm">
                                                        <div class="card-body p-4 d-flex justify-content-between align-items-center">
                                                            <div>
                                                                <h5 class="card-title mb-3">Cartera</h5>
                                                                <h4 class="card-subtitle text-body-secondary m-0">$0</h4>
                                                            </div>
                                                            <div class="bg-info text-white rounded-circle p-3 d-flex align-items-center justify-content-center">
                                                                <i class="bi bi-currency-dollar fs-4"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Payment Overview -->
                                            <div class="col-12 col-sm-10 col-md-7 col-lg-6 col-xl-5 col-xxl-4">
                                                <div class="card widget-card border-light shadow-sm">
                                                    <div class="card-body p-4">
                                                        <h5 class="card-title mb-4">Resumen de pagos</h5>
                                                        <div class="row gy-3">
                                                            <!-- Template de Pago -->
                                                            <div class="col-12">
                                                                <div class="d-flex align-items-center justify-content-between">
                                                                    <div class="d-flex align-items-center">
                                                                        <div class="fs-5 bg-primary-subtle text-primary rounded-2 p-2 me-3">
                                                                            <i class="bi bi-paypal"></i>
                                                                        </div>
                                                                        <div>
                                                                            <h6 class="m-0">PayPal</h6>
                                                                            <p class="text-secondary m-0 fs-7">Funds Received</p>
                                                                        </div>
                                                                    </div>
                                                                    <h6 class="text-end">$0</h6>
                                                                </div>
                                                            </div>

                                                            <div class="col-12">
                                                                <div class="d-flex align-items-center justify-content-between">
                                                                    <div class="d-flex align-items-center">
                                                                        <div class="fs-5 bg-primary-subtle text-primary rounded-2 p-2 me-3">
                                                                            <i class="bi bi-stripe"></i>
                                                                        </div>
                                                                        <div>
                                                                            <h6 class="m-0">Stripe</h6>
                                                                            <p class="text-secondary m-0 fs-7">Invoice Paid</p>
                                                                        </div>
                                                                    </div>
                                                                    <h6 class="text-end">$0</h6>
                                                                </div>
                                                            </div>

                                                            <div class="col-12">
                                                                <div class="d-flex align-items-center justify-content-between">
                                                                    <div class="d-flex align-items-center">
                                                                        <div class="fs-5 bg-primary-subtle text-primary rounded-2 p-2 me-3">
                                                                            <i class="bi bi-credit-card-fill"></i>
                                                                        </div>
                                                                        <div>
                                                                            <h6 class="m-0">Credit Card</h6>
                                                                            <p class="text-secondary m-0 fs-7">Top Up</p>
                                                                        </div>
                                                                    </div>
                                                                    <h6 class="text-end">$0</h6>
                                                                </div>
                                                            </div>

                                                            <div class="col-12">
                                                                <div class="d-flex align-items-center justify-content-between">
                                                                    <div class="d-flex align-items-center">
                                                                        <div class="fs-5 bg-primary-subtle text-primary rounded-2 p-2 me-3">
                                                                            <i class="bi bi-bank2"></i>
                                                                        </div>
                                                                        <div>
                                                                            <h6 class="m-0">Bank</h6>
                                                                            <p class="text-secondary m-0 fs-7">Check Deposited</p>
                                                                        </div>
                                                                    </div>
                                                                    <h6 class="text-end">$0</h6>
                                                                </div>
                                                            </div>

                                                            <div class="col-12">
                                                                <div class="d-flex align-items-center justify-content-between">
                                                                    <div class="d-flex align-items-center">
                                                                        <div class="fs-5 bg-primary-subtle text-primary rounded-2 p-2 me-3">
                                                                            <i class="bi bi-wallet-fill"></i>
                                                                        </div>
                                                                        <div>
                                                                            <h6 class="m-0">Wallet</h6>
                                                                            <p class="text-secondary m-0 fs-7">Bill Payment</p>
                                                                        </div>
                                                                    </div>
                                                                    <h6 class="text-end">$0</h6>
                                                                </div>
                                                            </div>

                                                            <div class="col-12">
                                                                <div class="d-flex align-items-center justify-content-between">
                                                                    <div class="d-flex align-items-center">
                                                                        <div class="fs-5 bg-primary-subtle text-primary rounded-2 p-2 me-3">
                                                                            <i class="bi bi-arrow-up-left-circle-fill"></i>
                                                                        </div>
                                                                        <div>
                                                                            <h6 class="m-0">Refund</h6>
                                                                            <p class="text-secondary m-0 fs-7">Case Closed</p>
                                                                        </div>
                                                                    </div>
                                                                    <h6 class="text-end">$0</h6>
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
    </main>

</asp:Content>
