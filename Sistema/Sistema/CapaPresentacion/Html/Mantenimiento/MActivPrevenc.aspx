<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MActivPrevenc.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.Mantenimiento.MActivPrevenc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
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
              <a id="botonMensaje1" runat="server" href="CActivPrevenc.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Mantenimientos</li>
                <li class="active"><a href="CActivPrevenc.aspx"> Actividades de prevención </a></li>
                <li class="active">Modificar</li>                
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Modificar Actividad de Prevención</h1>
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
                          <div class="form-group">
                            <label>Nombre de la actividad</label>
                            <input type="text" class="form-control" id="NombreActiv" runat="server"
                                placeholder="Ingrese el nombre de la actividad" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Fecha de la actividad</label>
                            <input type="text" class="form-control date" id="fechaActiv" runat="server"
                                   placeholder="Ingrese la fecha de la actividad"/>
                          </div>
                          <%--<div class="form-group">
                            <label>Total de horas participadas</label>
                            <input type="number" class="form-control" id="TotHorasPart" runat="server"
                                   placeholder="Ingrese el total de horas participadas"/>
                          </div>--%>
                          <div class="form-group">
                            <label>Lugar donde se realizó la actividad</label>
                            <input type="text" class="form-control" id="LugarActiv" runat="server" 
                                   placeholder="Ingrese el lugar donde se realizó la actividad"/>
                          </div>
                          <div class="form-group">
                                <label class="control-label" >Observaciones</label>
                                <textarea name="observaciones" id="observaciones" runat="server" class="form-control"></textarea>
                            </div>
                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" Enabled="true" OnClick="Button1_Click" OnClientClick="" />
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" OnClientClick="" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
