﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Banca_En_Linea._Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                                    <div class="col-12 col-md-6">
                                        <img class="img-fluid rounded-start w-100 h-100 object-fit-cover" loading="lazy" src="./assets/img/logo-img-1.webp" alt="Welcome back you've been missed!">
                                    </div>
                                    <div class="col-12 col-md-6 d-flex align-items-center justify-content-center">
                                        <div class="col-12 col-lg-11 col-xl-10">
                                            <div class="card-body p-3 p-md-4 p-xl-5">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="mb-5">
                                                            <div class="text-center mb-4">
                                                                <a href="#!">
                                                                    <img src="./assets/img/bsb-logo.svg" alt="BootstrapBrain Logo" width="175" height="57">
                                                                </a>
                                                            </div>
                                                            <h2 class="h4 text-center">Registration</h2>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="d-flex gap-3 flex-column">
                                                            <a href="#!" class="btn btn-lg btn-outline-dark">
                                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-google" viewBox="0 0 16 16">
                                                                    <path d="M15.545 6.558a9.42 9.42 0 0 1 .139 1.626c0 2.434-.87 4.492-2.384 5.885h.002C11.978 15.292 10.158 16 8 16A8 8 0 1 1 8 0a7.689 7.689 0 0 1 5.352 2.082l-2.284 2.284A4.347 4.347 0 0 0 8 3.166c-2.087 0-3.86 1.408-4.492 3.304a4.792 4.792 0 0 0 0 3.063h.003c.635 1.893 2.405 3.301 4.492 3.301 1.078 0 2.004-.276 2.722-.764h-.003a3.702 3.702 0 0 0 1.599-2.431H8v-3.08h7.545z" />
                                                                </svg>
                                                                <span class="ms-2 fs-6">Log in with Google</span>
                                                            </a>
                                                        </div>
                                                        <p class="text-center mt-4 mb-5">Or enter your details to register</p>
                                                    </div>
                                                </div>
                                                <form action="#!">
                                                    <div class="row gy-3 overflow-hidden">
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="firstName" id="firstName" placeholder="First Name" required>
                                                                <label for="firstName" class="form-label">Nombre</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="lastName" id="lastName" placeholder="First Name" required>
                                                                <label for="lastName" class="form-label">Apellidos</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="email" class="form-control" name="email" id="email" placeholder="name@example.com" required>
                                                                <label for="email" class="form-label">Email</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="lastName" id="Nacimiento" placeholder="First Name" required>
                                                                <label for="lastName" class="form-label">Fecha de nacimiento</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="lastName" id="Usuario" placeholder="First Name" required>
                                                                <label for="lastName" class="form-label">Nombre de usuario</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="password" class="form-control" name="password" id="txtpass" value="" placeholder="Password" required>
                                                                <label for="password" class="form-label">Contraseña</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="password" class="form-control" name="password" id="txtcomfpass" value="" placeholder="Password" required>
                                                                <label for="password" class="form-label">Confirmar contraseña</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="lastName" id="Pais" placeholder="First Name" required>
                                                                <label for="lastName" class="form-label">País</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="lastName" id="provincia" placeholder="First Name" required>
                                                                <label for="lastName" class="form-label">Provincia</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="mb-3">
                                                                <label for="inputState" class="form-label">Pregunta de seguridad</label>
                                                                <select id="inputState" class="form-select" name="pregunta" required>
                                                                    <option selected disabled>Selecciona una pregunta...</option>
                                                                    <option>¿Cómo se llamaba tu primera mascota?</option>
                                                                    <option>¿Cuál es el segundo nombre de tu madre/padre?</option>
                                                                    <option>¿Cuál es tu libro favorito de la infancia?</option>
                                                                </select>
                                                            </div>
                                                            <div class="form-floating mb-3">
                                                                <input type="text" class="form-control" name="respuesta" id="respuesta" placeholder="Tu respuesta" required>
                                                                <label for="respuesta">Respuesta</label>
                                                            </div>
                                                        </div>

                                                        <div class="col-12">
                                                            <div class="form-check">
                                                                <input class="form-check-input" type="checkbox" value="" name="iAgree" id="iAgree" required>
                                                                <label class="form-check-label text-secondary" for="iAgree">
                                                                    I agree to the <a href="#!" class="link-primary text-decoration-none">terms and conditions</a>
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <div class="col-12">
                                                            <div class="d-grid">
                                                                <button class="btn btn-dark btn-lg" type="submit">Sign up</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </form>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <p class="mb-0 mt-5 text-secondary text-center">Already have an account? <a href="#!" class="link-primary text-decoration-none">Sign in</a></p>
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
