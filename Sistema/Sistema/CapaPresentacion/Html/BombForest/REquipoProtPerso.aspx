<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="REquipoProtPerso.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.REquipoProtPerso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!-- menu-->
    <ul class="nav nav-tabs">
      <li class="active"><a href="REquipoProtPerso.aspx">Equipo de protección personal</a></li>
      <li><a href="RCarne.aspx">Información del carné</a></li>
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
                <li class="active">Registrar equipo de protección personal </li>                
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar equipo de protección personal</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                          <div class="form-group">
                            <label>Equipo</label>
                            <input type="text" class="form-control" id="nombre" runat="server"
                                placeholder="Ingresar el nombre" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Cantidad entregada</label>
                            <input type="number" class="form-control" id="cantEntreg" runat="server"
                                   placeholder="Ingresar la cantidad entregada"/>
                          </div>
                          <div class="form-group">
                            <label>Ubicación</label>
                            <input type="text" class="form-control" id="ubic" runat="server" 
                                   placeholder="Ingresar la ubicación"/>
                          </div>
                          <div class="form-group">
                            <label>Fecha de Entrega</label>
                            <input type="text" class="form-control date" id="fechEntreg" runat="server" 
                                   placeholder="Ingresar la fecha de entrega"/>
                          </div>
                          <div class="form-group">
                            <label>Estado</label>
                            <select class="form-control" id="estado">
	                            <option selected="selected">Bueno</option>
	                            <option>Malo</option>
	                            <option>Regular</option>
                            </select>
                          </div>
                          <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
