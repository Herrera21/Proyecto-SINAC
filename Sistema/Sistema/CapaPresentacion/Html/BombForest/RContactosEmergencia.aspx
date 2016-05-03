<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RContactosEmergencia.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RContactosEmergencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!-- menu-->
    <ul class="nav nav-tabs">
      <li><a href="REquipoProtPerso.aspx">Equipo de protección personal</a></li>
      <li><a href="RCarne.aspx">Información del carné</a></li>
      <li class="dropdown active">
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
              <a id="botonMensaje1" runat="server" href="MenuPrincipal.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Bomberos Forestales</li>
                <li class="active">Información médica</li>
                <li class="active">Registrar contacto de emergencia </li>                
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar contacto de emergencia</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                          <div class="form-group">
                            <label>Nombre</label>
                            <input type="text" class="form-control" id="nombre" runat="server"
                                placeholder="Ingrese el nombre" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Primer apellido</label>
                            <input type="text" class="form-control" id="p_Ape" runat="server"
                                   placeholder="Ingrese el primer apellido"/>
                          </div>
                          <div class="form-group">
                            <label>Segundo apellido</label>
                            <input type="text" class="form-control" id="s_Ape" runat="server"
                                   placeholder="Ingrese el segundo apellido"/>
                          </div>
                          <div class="form-group">
                            <label>Cédula</label>
                            <input type="text" class="form-control" id="cedula" runat="server" 
                                   placeholder="Ingrese la cédula"/>
                          </div>
                          <div class="form-group">
                            <label>Parentesco</label>
                            <input type="text" class="form-control" id="parent" runat="server" 
                                   placeholder="Ingrese el segundo apellido"/>
                          </div>
                          <div class="form-group">
                            <label>Teléfono celular</label>
                            <input type="text" class="form-control" id="telCel" runat="server"
                                placeholder="Ingresar el teléfono celular"/>
                          </div>
                          <div class="form-group">
                            <label>Teléfono casa</label>
                            <input type="text" class="form-control" id="telCasa" runat="server"
                                   placeholder="Ingresar el teléfono de casa"/>
                          </div>
                          <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
