<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MCapacitación.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.MCapacitación" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <script>
        function idBoton() {
            return "<%=Button1.ClientID%>";
        }
    </script>
    <!--mensaje-->
    <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>		        
            </div>
            <div class="modal-footer">
              <a id="botonMensaje1" runat="server" href="CCapacitación.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Mantenimientos</li>
                <li class="active"><a href="CCapacitación.aspx"> Capacitaciones </a> </li>
                <li class="active">Modificar </li>
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Modificar Capacitación</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                        <!--alert-->
                        <div id="alert" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                                <div class="modal-header">
                                  <h3>Alerta</h3>
                                </div>
                                <div class="modal-body">
                                   <label id="labelAlert" runat="server"></label>		        
                                </div>
                                <div class="modal-footer">
                                  <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" class="btn" OnClick="ButtonAcepta"/>
                                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" class="btn" OnClick="ButtonCancela"/>
                                </div>
                        </div>
                          <!--formulario-->
                         <div class="form-group">
                            <label>Nombre de la capacitación</label>
                            <input type="text" class="form-control" id="nombreCap" runat="server"
                                placeholder="Ingrese el nombre de la capacitación" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Lugar donde recibió la capacitación</label>
                            <input type="text" class="form-control" id="lugarCap" runat="server"
                                   placeholder="Ingrese el lugar donde recibió la capacitación"/>
                          </div>
                          <div class="form-group">
                            <label>Fecha de emisión</label>
                            <input type="text" class="form-control date" id="fechaEmiCap" runat="server" 
                                   placeholder="Ingrese la fecha de emisión"/>
                          </div>
                          <div class="form-group">
                            <label>Fecha de caducidad</label>
                            <input type="text" class="form-control date" id="fechaCad" runat="server" 
                                   placeholder="Ingrese la fecha de caducidad"/>
                          </div>
                          <div class="form-group">
                            <label>Institución</label>
                            <input type="text" class="form-control" id="institut" runat="server" 
                                   placeholder="Ingrese la institución donde recibió la capacitación"/>
                          </div>
                          <div class="form-group">
                            <label>Cantidad de horas</label>
                            <input type="text" class="form-control" id="cantHoras" runat="server" 
                                   placeholder="Ingrese la cantidad de horas de la capacitación"/>
                          </div>
                          <%--<div class="form-group">
                            <label>Capacitación aprobada</label>
                            <select class="form-control" id="capacAprob">
	                            <option selected="selected">Aprobado</option>
	                            <option>Reprobado</option>
                            </select>
                          </div>--%>

                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" Enabled="true" OnClick="Button1_Click" OnClientClick="area()" />
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" OnClientClick="area()" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
