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
                                  <div class="form-group">
                                    <label for="ejemplo_email_1">Nombre</label>
                                    <input type="text" class="form-control" id="nombre" runat="server"/>
                                  </div>
                                    <!-- cargar de info person -->
                                  <div class="form-group">
                                    <label for="ejemplo_email_1">Primer apellido</label>
                                    <input type="text" class="form-control" id="p_Ape" runat="server"/>
                                  </div>
                                    <!-- cargar de info person -->
                                  <div class="form-group">
                                    <label for="ejemplo_email_1">Segundo apellido</label>
                                    <input type="text" class="form-control" id="s_Ape" runat="server"/>
                                  </div>
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Año del carné</label>
                                    <input type="number" class="form-control" id="anioCarne" runat="server" 
                                           placeholder="Ingresar el año el Carné"/>
                                  </div>
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Emisión del carné</label>
                                    <input type="text" class="form-control" id="emiCarne" runat="server" 
                                           placeholder="ingrese la emisión del carné"/>
                                  </div>
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Fecha de vencimiento</label>
                                    <input type="text" class="form-control date" id="FechaVencim" runat="server" 
                                           placeholder="ingresar la fecha de vencimiento"/>
                                  </div>
                                    <!-- cargar de info medica -->
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Tipo de sangre del bombero</label>
                                    <input type="text" class="form-control" id="tipoSangre" runat="server"/>
                                  </div>
                                    <!-- cargar de info person -->
                                  <div class="form-group">
                                    <label for="ejemplo_password_1">Fecha de nacimiento de bombero</label>
                                    <input type="text" class="form-control date" id="fechaNacim" runat="server"/>
                                  </div>
                                  <div class="form-group">
                                    <label>Imagen de perfil</label>
                                    <img  class="form-control" ID="Image1" style="width: 300px; height: auto;" runat="server"/>
                                  </div> 
                                   <hr />
                                  <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" class="btn btn-lg btn-primary btn-block" />
                            </div>
                </form>
            </div>
        </div>
</asp:Content>
