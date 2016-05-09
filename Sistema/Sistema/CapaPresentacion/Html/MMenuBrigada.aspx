<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MMenuBrigada.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.MMenuBrigada1" %>
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
              <a id="botonMensaje1" runat="server" href="CBrigadas.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="MenuPrincipal.aspx"> Menú Principal </a></li>
                <li><a href="CAreaConserv.aspx">Áreas de Conservación </a></li>
                <li>Brigadas </li>
                <li><a href="CBrigadas.aspx">Consultas </a></li>
                <li class="active">Modificar </li>
            </ol>
        </div>

            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Modificar Brigada</h1>
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
                                <label class="control-label" >Nombre de la Brigada</label>
                                <input type="text" id="brigada" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');" placeholder="Ingrese el nombre de la brigada" maxlength="30" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="brigada" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="brigada" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                                <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Nombre"></span> 
                          </div>

                           
                          <div class="form-group has-feedback has-success" id="divAreaCons">
                            <label class="control-label">Área de Conservación</label>
                                <asp:DropDownList ID="areaCons" class="form-control" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_vAreaConservacion','divAreaCons','span1AreaCons');">
                                    <asp:listitem value ="0"> Seleccionar </asp:listitem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator id="vAreaConservacion" ControlToValidate="areaCons" ErrorMessage="Seleccione un área de conservación" Display="Static" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True"/>
                                <span class="" aria-hidden="true" id="span1AreaCons"></span>
                          </div>
                            

                          <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" OnClientClick="briga()" />
                          <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" OnClientClick="briga()" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
