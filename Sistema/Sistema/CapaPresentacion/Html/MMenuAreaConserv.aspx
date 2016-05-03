<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MMenuAreaConserv.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.MMenuAreaConserv1" %>
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
              <a id="botonMensaje1" runat="server" href="CAreaConserv.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="MenuPrincipal.aspx"> Menú Principal </a></li>
                <li>Áreas de conservación </li>
                <li> <a href="CAreaConserv.aspx">Consultas </a></li>
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
                          <div class="form-group has-feedback has-success" id="divNombre">
                            <label class="control-label">Nombre del Área de Conservación</label>
                            <input type="text" id="NAreaCons"  onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');" runat="server" class="form-control" placeholder="Ingrese el Área de Conservación" maxlength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="NAreaCons" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" 
                                Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="NAreaCons" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                              <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Nombre"></span>
                             
                          </div>
                          
                          <div class="form-group has-feedback has-success" id="divAbreviatura">
                            <label class="control-label">Abreviatura</label>
                            <input type="text" id="abrev" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divAbreviatura','span1Abrev');" class="form-control" placeholder="Ingrese la abreviatura" maxlength="8"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="abrev" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="abrev" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Abrev"></span>
                          
                          </div>
                          
                          <div class="form-group has-feedback has-success" id="divUbicacion">
                              <label class="control-label">Ubicación</label>
                              <asp:DropDownList ID="ubicacion" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_vUbicacion','divUbicacion','span1Ubicacion');" class="form-control" >
                                  <asp:listitem value ="0"> Seleccionar </asp:listitem>
                                  <asp:listitem value ="Alajuela"> Alajuela </asp:listitem>
                                  <asp:listitem value ="Cartago"> Cartago </asp:listitem>
                                  <asp:listitem value ="Guanacaste"> Guanacaste </asp:listitem>
                                  <asp:listitem value ="Heredia"> Heredia </asp:listitem>
                                  <asp:listitem value ="Puntarenas"> Puntarenas </asp:listitem>
                                  <asp:listitem value ="San José"> San José </asp:listitem>
                                  <asp:listitem value ="Limón"> Limón </asp:listitem>
                              </asp:DropDownList>
                              <asp:RequiredFieldValidator id="vUbicacion" ControlToValidate="ubicacion" ErrorMessage="Seleccione una ubicación" Display="Static" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True"/>
                              <span class="" aria-hidden="true" id="span1Ubicacion" ></span>
                              
                          </div>

                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" Enabled="true" OnClick="Button1_Click" OnClientClick="area()" />
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" OnClientClick="area()" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>