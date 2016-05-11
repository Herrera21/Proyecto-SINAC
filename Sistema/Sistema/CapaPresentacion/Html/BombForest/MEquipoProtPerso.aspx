﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MEquipoProtPerso.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.MEquipoProtPerso" %>
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
              <a id="botonMensaje1" runat="server" href="CEquipoProtPerso.aspx" class="btn">Cerrar</a>
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
                    <li><a href="../CBomberos.aspx">Bomberos </a></li>
                    <li class="active">Información detallada </li>
                    <li class="active">Equipo de protección personal </li>
                    <li class="active">Modificar </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Modificar Área de Conservación</h1>
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
                            <label>Equipo</label>
                            <input type="text" class="form-control" id="nombre" runat="server"
                                placeholder="Ingresar el nombre" required autofocus/>
                          </div>
                          <div class="form-group">
                            <label>Cantidad entregada</label>
                            <input type="text" class="form-control" id="cantEntre" runat="server" 
                                   placeholder="Ingresar la cantidad entregada"/>
                          </div>
                          <div class="form-group">
                            <label>Fecha de Entrega</label>
                            <input type="text" class="form-control date" id="fechEntreg" runat="server" 
                                   placeholder="Ingresar la fecha de entrega"/>
                          </div>
                          <div class="form-group">
                            <label>Estado</label>
                            <asp:DropDownList ID="estado" class="form-control" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_vAreaConservacion','divAreaCons','span1AreaCons');">
                                <asp:listitem value ="0"> Seleccionar </asp:listitem>
                                <asp:listitem value ="Bueno"> Bueno </asp:listitem>
                                <asp:listitem value ="Malo"> Malo </asp:listitem>
                                <asp:listitem value ="Regular"> Regular </asp:listitem>
                            </asp:DropDownList>
                          </div>
                          <div class="form-group">
                                <label class="control-label" >Observaciones</label>
                                <textarea name="observaciones" id="observaciones" runat="server" class="form-control"></textarea>
                          </div>

                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" Enabled="true" OnClick="Button1_Click" OnClientClick="area()" />
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" OnClientClick="area()" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>