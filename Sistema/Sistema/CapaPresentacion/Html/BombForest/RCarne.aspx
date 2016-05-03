<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RCarne.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RCarne" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!-- menu-->
    <ul class="nav nav-tabs">
      <li><a href="REquipoProtPerso.aspx">Equipo de protección personal</a></li>
      <li class="active"><a href="RCarne.aspx">Información del carné</a></li>
      <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="RContactosEmergencia.aspx">Contactos de Emergencia</a></li>
              <li><a href="RReseniaMedica.aspx">Reseña médica</a></li>
          </ul>
      </li>
      <li><a href="RBomBenef.aspx">Beneficiarios</a></li>
      <li><a href="../MenuPrincipal.aspx">Salir</a></li>
    </ul>

    <!--mensaje-->
    <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>		        
            </div>
            <div class="modal-footer">
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Bomberos Forestales</li>
                <li class="active">Registrar carné </li>                
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar carné</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                            <!-- cargar de info person -->
                          <div class="form-group">
                            <label for="ejemplo_email_1">Nombre</label>
                            <input type="text" class="form-control" id="nombre" runat="server"
                                placeholder="Ingresar el nombre" required autofocus/>
                          </div>
                            <!-- cargar de info person -->
                          <div class="form-group">
                            <label for="ejemplo_email_1">Primer apellido</label>
                            <input type="text" class="form-control" id="p_Ape" runat="server"
                                   placeholder="Ingresar el Primer apellido"/>
                          </div>
                            <!-- cargar de info person -->
                          <div class="form-group">
                            <label for="ejemplo_email_1">Segundo apellido</label>
                            <input type="text" class="form-control" id="a_Ape" runat="server"
                                   placeholder="Ingresar el Segundo apellido"/>
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
                            <input type="text" class="form-control" id="tipoSangre" runat="server" 
                                   placeholder="ingrese el tipo de sangre"/>
                          </div>
                            <!-- cargar de info person -->
                          <div class="form-group">
                            <label for="ejemplo_password_1">Fecha de nacimiento de bombero</label>
                            <input type="text" class="form-control date" id="fechaNacim" runat="server" 
                                   placeholder="ingrese la fecha de nacimiento"/>
                          </div>
                          <div class="form-group">
                            <label for="ejemplo_password_1">Imagen del carné</label>
                            <input type="text" class="form-control" id="Password3" runat="server" 
                                   placeholder="ingrese la contraseña"/>
                          </div>
                          <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
