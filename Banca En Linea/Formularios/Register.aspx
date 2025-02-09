<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Banca_En_Linea._Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="card" style="width: 40rem;">
            <h5 class="card-header">Crear cuenta</h5>
            <div class="card-body">
                <div class="col-md-4">
                    <label for="validationCustom01" class="form-label">Nombre</label>
                    <input type="text" class="form-control" id="txtNombre" required>
                    <div class="valid-feedback">
                    </div>
                    <div class="invalid-feedback">
                        Ponga su nombre
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="validationCustom02" class="form-label">Apellidos</label>
                    <input type="text" class="form-control" id="txtApellido" required>
                    <div class="invalid-feedback">
                        Ponga sus apellidos
                    </div>
                    <div class="valid-feedback">
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="validationCustom01" class="form-label">Correo electronico</label>
                    <input type="text" class="form-control" id="txtCorreo" required>
                    <div class="valid-feedback">
                    </div>
                    <div class="invalid-feedback">
                        Ponga un correo valido
                    </div>
                </div>
                <div class="col-md-4">
                    <label for="validationCustomUsername" class="form-label">Nombre de usuario</label>
                    <div class="input-group has-validation">
                        <span class="input-group-text" id="inputGroupPrepend">@</span>
                        <input type="text" class="form-control" id="txtUsername" aria-describedby="inputGroupPrepend" required>
                        <div class="invalid-feedback">
                            Elija un nombre de usuario
                        </div>
                    </div>
                </div>
                                <div class="col-md-4">
                    <label for="validationCustom01" class="form-label">Contraseña</label>
                    <input type="text" class="form-control" id="txtcontrasena" required>
                    <div class="valid-feedback">
                    </div>
                    <div class="invalid-feedback">
                        Ponga una contraseña valida
                    </div>
                </div>
                                <div class="col-md-4">
                    <label for="validationCustom01" class="form-label">Fecha de nacimiento</label>
                    <input type="text" class="form-control" id="txtNacimiento" required>
                    <div class="valid-feedback">
                    </div>
                    <div class="invalid-feedback">
                        Ponga una fecha valida
                    </div>
                </div>
                <div class="col-md-6">
                    <label for="validationCustom03" class="form-label">Pais</label>
                    <input type="text" class="form-control" id="txtPais" required>
                    <div class="invalid-feedback">
                        Escriba un pais valido
                    </div>
                </div>
                                <div class="col-md-6">
                    <label for="validationCustom03" class="form-label">Pais</label>
                    <input type="text" class="form-control" id="txtProvincia" required>
                    <div class="invalid-feedback">
                        Escriba una provincia valida
                    </div>
                </div>
                <div class="col-md-3">
                    <label for="validationCustom05" class="form-label">Teléfono</label>
                    <input type="text" class="form-control" id="txtTelefono" required>
                    <div class="invalid-feedback">
                        Ingrese un número de teléfono valido
                    </div>
                </div>
                <div class="col-12">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" value="" id="invalidCheck" required>
                        <label class="form-check-label" for="invalidCheck">
                            Aceptar términos y condiciones
                        </label>
                        <div class="invalid-feedback">
                            Debe aceptar los terminos y condiciones antes de registrarse
                        </div>
                    </div>
                </div>
                <div class="col-12">
                    <button class="btn btn-primary" id:"btnCrearCuenta" type="submit">Crear cuenta</button>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
