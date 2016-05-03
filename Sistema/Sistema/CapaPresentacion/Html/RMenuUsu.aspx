<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RMenuUsu.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.RMenuUsu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <script>
        function returnIDcontrasenia()
        {
            return "<%=contrasenia.ClientID%>";
        }
        function returnIDconfContrasenia()
        {
            return "<%=confContrasenia.ClientID%>";
        }
        function idBoton() {
            return "<%=Button1.ClientID%>";
        }
        function idCedula() {
            return "<%=cedula.ClientID%>";
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
              <a id="botonMensaje1" runat="server" href="MenuPrincipal.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Usuarios </li>
                <li class="active">Registrar </li>
            </ol>
        </div>

           <form id="form1" runat="server">
            <div class="row" style="background-color:white; width:99.7%">
                
                <!--formulario-->

                <h1 class="text-center login-title">Registrar usuario</h1><hr />

                <!--columna1-->
                <div class="col-md-6">
                    <div class="col-sm-6 col-md-8 col-md-offset-2">
                        <div class="form-group" id="divUsuario">
                            <label>Usuario</label>
                            <input type="text" class="form-control" id="usuario" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divUsuario','span1Usuario');" runat="server" maxlength="20" placeholder="Ingrese el usuario que desea" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="usuario" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="4 a 15 caracteres. Solo se permiten numeros y letras" ControlToValidate="usuario" ValidationExpression="^[A-Za-z0-9_-]{4,15}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Usuario"></span>
                        </div>
                        <div class="form-group" id="divCedula">
                            <label>Identificacion</label>
                            <input type="text" class="form-control" name="identificacion" id="cedula" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator6','ContentPlaceHolderContenido_RegularExpressionValidator6' ,'divCedula','span1Cedula');" runat="server" onblur="usuar(); identificacionVal(this,'cedulaRB','pasaporteRB','residenciaRB',idCedula(),'divCedula','span1Cedula','span2Cedula'); usuarios(idBoton());" maxlength="9"
                                    placeholder="Ingresar identificacion" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cedula" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="cedula" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Cedula"></span>
                        </div>
                        <div>
                            <input type="radio" name="iden" id="cedulaRB" onchange="identificacionV();" checked /> Cedula 
                            <input type="radio" name="iden" id="pasaporteRB"  /> Pasaporte 
                            <input type="radio" name="iden" id="residenciaRB" /> Residencia 
                        </div>
                         <br />


                        <div class="form-group" id="divNombre">
                            <label>Nombre</label>
                            <input type="text" class="form-control" id="nombre" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divNombre','span1Nombre');" maxlength="20" 
                                    placeholder="Ingrese su nombre" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                        </div>
                        <div class="form-group" id="divApellido1">
                            <label>Primer apellido</label>
                            <input type="text" class="form-control" id="apellido1" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divApellido1','span1Apellido1');"  maxlength="15" 
                                    placeholder="Ingrese sus apellidos" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="apellido1" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="apellido1" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Apellido1"></span>
                        </div>

                        <div class="form-group" id="divApellido2">
                            <label>Segundo apellido</label>
                            <input type="text" class="form-control" id="apellido2" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divApellido2','span1Apellido2');"  maxlength="15" 
                                    placeholder="Ingrese sus apellidos" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="apellido2" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="apellido2" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Apellido2"></span>
                        </div>

                        <div class="form-group" id="divEmail">
                            <label>Correo electronico</label>
                            <input type="text" class="form-control" id="email" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator5','ContentPlaceHolderContenido_RegularExpressionValidator5' ,'divEmail','span1Email');" maxlength="40" 
                                    placeholder="Ingrese su correo electrónico" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="email" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Correo electrónico inválido" ControlToValidate="email" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Email"></span>
                        </div>
                    </div>
                </div>

                    <!--columna 2-->

                    <div class="col-md-6">
                        <div class="col-sm-6 col-md-8 col-md-offset-2">
                            
                          <div class="" id="divAreaCons">
                            <label class="control-label">Área de Conservación</label>
                                <asp:DropDownList ID="AreaCons" class="form-control" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_vAreaConservacion','ContentPlaceHolderContenido_vAreaConservacion' ,'divAreaCons','span1AreaCons');">
                                    <asp:listitem value ="0"> seleccionar </asp:listitem>
                                </asp:DropDownList>
                              <asp:RequiredFieldValidator id="vAreaConservacion" ControlToValidate="areaCons" ErrorMessage="Seleccione un área de conservación" Display="Static" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True"/>
                                <span class="" aria-hidden="true" id="span1AreaCons" style="right: -30px;"></span>
                          </div>
                          <div>
                             <label for="ejemplo_password_1">Rol</label>
                            <asp:RadioButtonList ID="radioButtonFuncion" runat="server"
                                    RepeatDirection="Vertical" RepeatLayout="Table">
                                    <asp:ListItem Text="  TIC" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="  Coordinador Nacional" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="  Coordinador Regional" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="  Otras Instituciones" Selected="True" Value="3"></asp:ListItem>
                                    <%--<asp:ListItem Text="  Visitante" Selected="True" Value="4"></asp:ListItem>--%>
                            </asp:RadioButtonList>
                          </div>

                            <hr />

                          <div class="form-group" id="divContrasenia">
                            <label for="ejemplo_password_1">Contraseña</label>
                            <input type="password" class="form-control" id="contrasenia" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_RequiredFieldValidator8','ContentPlaceHolderContenido_RequiredFieldValidator8' ,'divContrasenia','span1Contrasenia');" maxlength="15"
                                   placeholder="Ingrese la contraseña" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="contrasenia" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <span class="" aria-hidden="true" id="span1Contrasenia"></span>
                          </div>
                           <div class="form-group" id="divContrasenia2">
                            <label for="ejemplo_password_1">Confirmar contraseña</label>
                            <input type="password" class="form-control" id="confContrasenia" runat="server" onblur="usuar();" onchange="validar('ContentPlaceHolderContenido_CompareValidator1','ContentPlaceHolderContenido_CompareValidator1' ,'divContrasenia2','span1Contrasenia2');" maxlength="15"
                                   placeholder="Ingrese la contraseña nuevamente" />
                                                          
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="confContrasenia" ControlToValidate="contrasenia" CssClass="alert-danger" ErrorMessage="Las contraseñas no coinciden" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
                              <span class="" aria-hidden="true" id="span1Contrasenia2"></span>
                          </div>

                           
                                    
                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" OnClientClick="usuar()"/>
                        </div>
                    </div>
            </div>
        </form>
        </div>
</asp:Content>
