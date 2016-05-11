<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RCapacitación.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RCapacitación" %>
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
                <li class="active">Registrar </li>
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Registrar capacitación</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                          <div class="form-group" id="divNombre">
                            <label>Nombre de la capacitación</label>
                            <input type="text" class="form-control" id="nombreCap" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');"
                                placeholder="Ingrese el nombre de la capacitación" maxlength="20" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="nombreCap" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombreCap" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                          </div>
                          <div class="form-group" id="divLugarCap">
                            <label>Lugar donde se recibió la capacitación</label>
                            <input type="text" class="form-control" id="lugarCap" runat="server"  onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divLugarCap','span1LugarCap');"
                                   placeholder="Ingrese el lugar donde recibió la capacitación" maxlength="50"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="lugarCap" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="lugarCap" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1LugarCap"></span>
                          </div>
                          <div class="form-group" id="divFechaEmiCap">
                            <label>Fecha de emisión</label>
                            <input type="text" class="form-control date fechaEmi" id="fechaEmiCap" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divFechaEmiCap','span1FechaEmiCap');"
                                   placeholder="Ingrese la fecha de emisión" maxlength="10"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fechaEmiCap" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Formato inválido" ControlToValidate="fechaEmiCap" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1FechaEmiCap"></span>
                          </div>
                          <div class="form-group" id="divFechaCad">
                            <label>Fecha de caducidad</label>
                            <input type="text" class="form-control date fechaCad" id="fechaCad" runat="server"  onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divFechaCad','span1FechaCad');"
                                   placeholder="Ingrese la fecha de caducidad" maxlength="10"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="fechaCad" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Formato inválido" ControlToValidate="fechaCad" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1FechaCad"></span>
                          </div>
                          <div class="form-group" id="divInstitut">
                            <label>Institución</label>
                            <input type="text" class="form-control" id="institut" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator5','ContentPlaceHolderContenido_RegularExpressionValidator5' ,'divInstitut','span1Institut');"
                                   placeholder="Ingrese la institución donde recibió la capacitación" maxlength="20"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  runat="server" ControlToValidate="institut" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="institut" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Institut"></span>
                          </div>
                          <div class="form-group" id="divCantHoras">
                            <label>Cantidad de horas</label>
                            <input type="text" class="form-control" id="cantHoras" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator6','ContentPlaceHolderContenido_RegularExpressionValidator6' ,'divCantHoras','span1CantHoras');"
                                   placeholder="Ingrese la cantidad de horas de la capacitación" maxlength="4"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="cantHoras" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="cantHoras" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                             <span class="" aria-hidden="true" id="span1CantHoras"></span>
                          </div>
                          <%--<div class="form-group">
                            <label>Capacitación aprobada</label>
                            <select class="form-control" id="capacAprob">
	                            <option selected="selected">Aprobado</option>
	                            <option>Reprobado</option>
                            </select>
                          </div>--%>
                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" ValidationGroup="enviar"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    <script>
        Configurafecha("+0m +0d +0y", ".fechaEmi", "-65:+0");
        Configurafecha("+0m +0d +15y", ".fechaCad", "-15:+15");
    </script>
</asp:Content>
