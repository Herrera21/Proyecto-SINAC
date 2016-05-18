<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="Carne.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.Carne" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!--mensaje-->
    <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>		        
            </div>
            <div class="modal-footer">
              <a id="botonMensaje1" runat="server" href="../MenuPrincipal.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->               
     <div class="container">
             <!-- Miga -->
            <div class="row" style="background-color:white; width:99.7%">
                <ol class="breadcrumb">
                    <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                    <li><a href="../CAreaConserv.aspx">Áreas de conservación </a></li>
                    <li><a href="../CBrigadas.aspx">Brigada </a></li>
                    <li><a href="../BombForest/CBomberos.aspx">Bomberos </a></li>
                    <li class="active">Información detallada </li>
                    <li class="active">Reseña médica </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">


                <form id="form1" runat="server">
                    <!-- menu-->
                    <ul class="nav nav-tabs">
                        <%--<li><a href="RBomInfoPerson.aspx">Información Personal</a></li>--%>
                        <li><a href="CEquipoProtPerso.aspx">Equipo de protección personal</a></li>
                        <li class="active"><a href="Carne.aspx">Información del carné</a></li>
                        <li><a href="CCapacit.aspx">Capacitaciones</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Experiencia de campo<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="CActivPrev.aspx">Actividades de Prevención</a></li>
                                <li><a href="CIncendForest.aspx">Participación en incencios forestales</a></li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="CPoliza.aspx">Pólizas</li>
                                <%--<li><a href="RBomBenef.aspx">Beneficiarios</a></li>--%>
                                <li><a href="CContactosEmergencia.aspx">Contactos de Emergencia</a></li>
                                <li><a href="ReseniaMedica.aspx">Reseña médica</a></li>
                            </ul>
                        </li>
                        <li><a href="CBomberos.aspx">Salir</a></li>
                    </ul>

                    <%--formulario--%>

                    <h1 class="text-center login-title">Carné</h1>

                        <div class="col-sm-6 col-md-4 col-md-offset-4">
                             <!-- cargar de info person -->
                                  <div class="form-group" id="divNombre">
                                    <label for="ejemplo_email_1">Nombre</label>
                                    <input type="text" class="form-control" id="nombre" runat="server" readonly/>
                                    
                          
                                  </div>
                                    <!-- cargar de info person -->
                                  <div class="form-group">
                                    <label for="ejemplo_email_1">Primer apellido</label>
                                    <input type="text" class="form-control" id="p_Ape" runat="server" readonly/>
                                  </div>
                                    <!-- cargar de info person -->
                                  <div class="form-group">
                                    <label for="ejemplo_email_1">Segundo apellido</label>
                                    <input type="text" class="form-control" id="s_Ape" runat="server" readonly/>
                                  </div>
                                  <div class="form-group" id="divAnioCarne">
                                    <label for="ejemplo_password_1">Año del carné</label>
                                    <input type="number" class="form-control" id="anioCarne" runat="server" placeholder="Ingresar el año el carné" maxlength="4" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator12','ContentPlaceHolderContenido_RegularExpressionValidator12' ,'divAnioCarne','span1AnioCarne');" />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="anioCarne" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="anioCarne" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                                    <span class="" aria-hidden="true" id="span1AnioCarne"></span>
                                  </div>
                                  <div class="form-group" id="divFechaEmi">
                                    <label for="ejemplo_password_1">Emisión del carné</label>
                                    <input type="text" class="form-control date fechaEmi" id="emiCarne" runat="server" 
                                           placeholder="Ingrese la emisión del carné" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator7','ContentPlaceHolderContenido_RegularExpressionValidator7' ,'divFechaEmi','span1FechaEmi');" readonly/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="emiCarne" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Formato inválido" ControlToValidate="emiCarne" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                                    <span class="" aria-hidden="true" id="span1FechaEmi"></span>
                                  </div>
                                  <div class="form-group" id="divFechaVen">
                                    <label for="ejemplo_password_1">Fecha de vencimiento</label>
                                    <input type="text" class="form-control date fechaVen" id="FechaVencim" runat="server" 
                                           placeholder="Ingrese la fecha de vencimiento" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divFechaVen','span1FechaVen');" readonly/>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FechaVencim" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Formato inválido" ControlToValidate="FechaVencim" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                                    <span class="" aria-hidden="true" id="span1FechaVen"></span>
                                  </div>
                                    <!-- cargar de info medica -->
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Tipo de sangre del bombero</label>
                                    <input type="text" class="form-control" id="tipoSangre" runat="server" readonly/>
                                  </div>
                                    <!-- cargar de info person -->
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Fecha de nacimiento de bombero</label>
                                    <input type="text" class="form-control date" id="fechaNacim" runat="server" readonly/>
                                  </div>
                                  <div class="form-group">
                                    <label>Imagen de perfil</label>
                                    <img  class="form-control" ID="Image1" style="width: 300px; height: auto;" runat="server"/>
                                  </div> 
                                   <hr />
                                  <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" class="btn btn-lg btn-primary btn-block" ValidationGroup="enviar"/>
                            <br /><br />
                            </div>
                </form>
            </div>
        </div>
    <script>
        Configurafecha("+0m +0d +0y", ".fechaEmi", "-65:+0");
        Configurafecha("+0m +0d +20y", ".fechaVen", "+1:+20");
    </script>
</asp:Content>
