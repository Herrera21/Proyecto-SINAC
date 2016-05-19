<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RContactosEmergencia.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RContactosEmergencia" %>
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
              <a id="botonMensaje1" runat="server" href="CContactosEmergencia.aspx" class="btn">Cerrar</a>
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
                    <li><a href="CContactosEmergencia.aspx">Contactos de emergencia </a></li>
                    <li class="active">Registrar </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar contacto de emergencia</h1>
                    <div class="account-wall">
                        <form id="form2" class="form-signin" runat="server">
                          <div class="form-group" id="divNombre">
                            <label>Nombre</label>
                            <input type="text" class="form-control" id="nombre" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');"
                                placeholder="Ingrese el nombre" />
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                          </div>
                          <div class="form-group" id="divP_Ape">
                            <label>Primer apellido</label>
                            <input type="text" class="form-control" id="p_Ape" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divP_Ape','span1P_Ape');"
                                   placeholder="Ingrese el primer apellido"/>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="p_Ape" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="p_Ape" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1P_Ape"></span>
                          </div>
                          <div class="form-group" id="divS_Ape">
                            <label>Segundo apellido</label>
                            <input type="text" class="form-control" id="s_Ape" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divS_Ape','span1S_Ape');"
                                   placeholder="Ingrese el segundo apellido"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  runat="server" ControlToValidate="s_Ape" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="s_Ape" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1S_Ape"></span>
                          </div>
                          <div class="form-group" id="divCedula">
                            <label>Identificación</label>
                            <input type="text" class="form-control" id="cedula" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divCedula','span1Cedula');"
                                   placeholder="Ingrese la identificación" maxlength="9"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server" ControlToValidate="cedula" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Debe tener un minimo de 9 digitos" ControlToValidate="cedula" ValidationExpression="^[A-Za-z0-9 ]{9,15}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Cedula"></span>
                          </div>
                             <div>
                            <input type="radio" name="iden" id="cedulaRB" onclick="validarId('ContentPlaceHolderContenido_cedula');" checked /> Cedula 
                            <input type="radio" name="iden" id="pasaporteRB" onclick="validarId('ContentPlaceHolderContenido_cedula');" /> Pasaporte 
                            <input type="radio" name="iden" id="residenciaRB" onclick="validarId('ContentPlaceHolderContenido_cedula');"/> Residencia 
                        </div>
                         <br />
                          <div class="form-group" id="divParent">
                            <label>Parentesco</label>
                            <input type="text" class="form-control" id="parent" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator5','ContentPlaceHolderContenido_RegularExpressionValidator5' ,'divParent','span1Parent');"
                                   placeholder="Ingrese el segundo apellido"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  runat="server" ControlToValidate="parent" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="parent" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Parent"></span>
                          </div>
                          <div class="form-group" id="divTelCel">
                            <label>Teléfono celular</label>
                            <input type="text" class="form-control" id="telCel" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_CompareValidator1','ContentPlaceHolderContenido_RegularExpressionValidator6' ,'divTelCel','span1TelCel');"
                                placeholder="Ingresar el teléfono celular" maxlength="8"/>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="telCasa" ControlToValidate="telCel" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Verificar. Los telefonos son iguales" Operator="NotEqual" ValidationGroup="enviar"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="El teléfono debe ser de 8 numeros" ControlToValidate="telCel" ValidationExpression="^[0-9 ]{8,9}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1TelCel"></span>
                          </div>
                          <div class="form-group" id="divTelCasa">
                            <label>Teléfono de residencia</label>
                            <input type="text" class="form-control" id="telCasa" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_CompareValidator2','ContentPlaceHolderContenido_RegularExpressionValidator7' ,'divTelCasa','span1TelCasa');"
                                   placeholder="Ingresar el teléfono de casa" maxlength="8"/>
                              <asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Verificar. Los telefonos son iguales" Operator="NotEqual" ValidationGroup="enviar" ControlToCompare="telCel" ControlToValidate="telCasa"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="El teléfono debe ser de 8 numeros" ControlToValidate="telCasa" ValidationExpression="^[0-9 ]{8,9}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1TelCasa"></span>
                          </div>
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Guardar" ValidationGroup="enviar" OnClick="Button1_Click"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
