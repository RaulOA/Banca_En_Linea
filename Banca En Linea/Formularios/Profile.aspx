<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Banca_En_Linea._Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <script src="https://unpkg.com/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://unpkg.com/bootstrap@5.3.3/dist/css/bootstrap.min.css" />

    <main class="bg-light py-4">
        <div class="container mt-4">
            <div class="row">
                <!-- Columna izquierda - Datos del cliente -->
                <div class="col-md-4">
                    <div class="card mb-4">
                        <div class="card-header bg-primary text-white">
                            <h5 class="mb-0">Perfil del Cliente</h5>
                        </div>
                        <div class="card-body">
                            <div class="text-center mb-3">
                                <asp:Image ID="imgFoto" runat="server" CssClass="img-thumbnail rounded-circle" Width="120" />
                            </div>

                            <div class="mb-3">
                                <h6 class="font-weight-bold">Nombre:</h6>
                                <asp:Label ID="lblNombreCompleto" runat="server" CssClass="form-control-plaintext" />
                            </div>

                            <div class="mb-3">
                                <h6 class="font-weight-bold">Usuario:</h6>
                                <asp:Label ID="lblNombreUsuario" runat="server" CssClass="form-control-plaintext" />
                            </div>

                            <div class="mb-3">
                                <h6 class="font-weight-bold">Cuenta:</h6>
                                <asp:Label ID="lblNumeroCuenta" runat="server" CssClass="form-control-plaintext" />
                            </div>

                            <div class="mb-3">
                                <h6 class="font-weight-bold">Saldo Actual:</h6>
                                <asp:Label ID="lblSaldo" runat="server" CssClass="form-control-plaintext font-weight-bold text-success" />
                            </div>

                            <div class="mb-3">
                                <h6 class="font-weight-bold">Dirección:</h6>
                                <asp:Label ID="lblDireccion" runat="server" CssClass="form-control-plaintext" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Columna derecha - Transacciones -->
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header bg-primary text-white">
                            <h5 class="mb-0">Últimas Transacciones</h5>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <!-- AQUÍ VA EL GRIDVIEW -->
                                <asp:GridView ID="gvTransacciones" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-sm" GridLines="None"
                                    EmptyDataText="No hay transacciones recientes">
                                    <Columns>
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha"
                                            DataFormatString="{0:dd/MM/yyyy HH:mm}" ItemStyle-Width="120px" />

                                        <asp:BoundField DataField="TipoMovimiento" HeaderText="Tipo de Movimiento"
                                            ItemStyle-Width="180px" />

                                        <asp:TemplateField HeaderText="Monto" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <span class='<%# Convert.ToDecimal(Eval("Monto")) >= 0 ? "text-success" : "text-danger" %>'>
                                                    <%# string.Format("{0:C}", Eval("Monto")) %>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <!-- FIN DEL GRIDVIEW -->
                            </div>

                            <!-- Resumen de transacciones (opcional, puedes mantenerlo o eliminarlo) -->
                            <div class="mt-4 p-3 bg-light rounded">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h6>Total Ingresos: <span class="text-success">
                                            <asp:Label ID="lblTotalIngresos" runat="server" Text="$0.00" />
                                        </span></h6>
                                    </div>
                                    <div class="col-md-6">
                                        <h6>Total Egresos: <span class="text-danger">
                                            <asp:Label ID="lblTotalEgresos" runat="server" Text="$0.00" />
                                        </span></h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
