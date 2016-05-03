<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RActivPrevenc.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RActivPrevenc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!-- menu-->
    <ul class="nav nav-tabs">
      <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Pólizas<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="RBomPoliza.aspx">Registrar</li>
              <li><a href="RBomBenef.aspx">Modificar</a></li>
              <li><a href="RContactosEmergencia.aspx">Asignar</a></li>
          </ul>
      </li>
      <li class="dropdown ">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Capacitaciones<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="RCapacitación.aspx">Registrar</li>
              <li><a href="RBomBenef.aspx">Modificar</a></li>
              <li><a href="RContactosEmergencia.aspx">Asignar</a></li>
          </ul>
      </li>
      <li class="dropdown active">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Actividades de prevención<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="RActivPrevenc.aspx">Registrar</li>
              <li><a href="RBomBenef.aspx">Modificar</a></li>
              <li><a href="RContactosEmergencia.aspx">Asignar</a></li>
          </ul>
      </li>
      <li class="dropdown ">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Participación en incendios forestales<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="RIncendForest.aspx">Registrar</li>
              <li><a href="RBomBenef.aspx">Modificar</a></li>
              <li><a href="RContactosEmergencia.aspx">Asignar</a></li>
          </ul>
      </li>             
      <li><a href="../MenuPrincipal.aspx">Salir</a></li>
    </ul>

    <!--mensaje-->
    <div id="mensajes" class="modal" style="display: none; ">
            <div class="modal-header">
              <a class="close" data-dismiss="modal">×</a>
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
                <li class="active">Mantenimientos</li>
                <li class="active">Actividades de prevención</li>
                <li class="active">Registrar</li>                
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar Actividad de Prevención</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                          <div class="form-group">
                            <label>Tipo de actividad</label>
                            <input type="text" class="form-control" id="tipoActiv" runat="server"
                                placeholder="Ingrese el tipo de actividad" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Fecha de la actividad</label>
                            <input type="text" class="form-control date" id="fechaActiv" runat="server"
                                   placeholder="Ingrese la fecha de la actividad"/>
                          </div>
                          <div class="form-group">
                            <label>Total de horas participadas</label>
                            <input type="number" class="form-control" id="TotHorasPart" runat="server"
                                   placeholder="Ingrese el total de horas participadas"/>
                          </div>
                          <div class="form-group">
                            <label>Lugar donde se realizó la actividad</label>
                            <input type="text" class="form-control" id="LugarActiv" runat="server" 
                                   placeholder="Ingrese el lugar donde se realizó la actividad"/>
                          </div>
                          <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
