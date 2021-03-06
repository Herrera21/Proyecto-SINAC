﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="RBomInfoPerson.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.RBomInfoPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <script>
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
              <a id="botonMensaje1" runat="server" href="CBomberos.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>
     <div id="mensajes2" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
            <div class="modal-header">
              <h3>Error</h3>
            </div>
            <div class="modal-body">
               <label id="label1" runat="server">Esta cédula ya pertenece a un bombero registrado en el sistema</label>
            </div>
            <div class="modal-footer">
              <a id="A1" runat="server" href="RBomInfoPerson.aspx" class="btn">Cerrar</a>
            </div>
    </div>
    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active"><a href="CBomberos.aspx"> Bomberos forestales </a></li>
                <li class="active">Registrar información personal </li>                
            </ol>
        </div>

        <form id="form1" runat="server">

            <%--Modal identificacion--%>
            <div id="buscarId" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                        <div class="modal-header">
                        <a class="close" href="CBomberos.aspx">×</a>
                            <h3>Ingresar la identificación del bombero</h3>
                        </div>
                        <div class="modal-body">
                            <div class="form-group has-feedback" id="divVId">
                                <label id="labelArea" runat="server">Este campo no podrá ser modificado después</label>
                                <input type="text" id="verificarIdInput" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator8','ContentPlaceHolderContenido_RegularExpressionValidator14' ,'divVId','span1VId');" placeholder="Ingrese la identificación" maxlength="9" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="verificarIdInput" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="verificar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="La identificación debe tener un mínimo de 9 caracteres" ControlToValidate="verificarIdInput" ValidationExpression="^[0-9a-zA-Z ]{9,15}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True"  ValidationGroup="verificar"></asp:RegularExpressionValidator>
                                <span class="" aria-hidden="true" id="span1VId"></span>
                                
                            </div>
                            <div>
                            <input type="radio" name="iden" id="cedulaRB" onclick="validarId('ContentPlaceHolderContenido_verificarIdInput');" checked /> Cedula 
                            <input type="radio" name="iden" id="pasaporteRB" onclick="validarId('ContentPlaceHolderContenido_verificarIdInput');" /> Pasaporte 
                            <input type="radio" name="iden" id="residenciaRB" onclick="validarId('ContentPlaceHolderContenido_verificarIdInput');"/> Residencia 
                            </div>
                            
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="botonVerificarId" runat="server" Text="Ingresar" class="btn btn-primary " OnClick="ButtonVerificarId" ValidationGroup="verificar"/>
                        </div>
                     </div>


            <div class="row" style="background-color:white; width:99.7%">
                <!--formulario-->

                <h1 class="text-center login-title">Registrar información personal</h1><hr />

                <!--columna1-->
                <div class="col-md-6">
                    <div class="col-sm-6 col-md-8 col-md-offset-2">

                        <div class="form-group has-feedback has-success" id="divCedula">
                            <label class="control-label">Identificación</label>
                            <input type="text" class="form-control" name="identificacion" id="cedula" runat="server" 
                                    placeholder="Ingresar identificación" maxlength="9" readonly/>
                            
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Cedula"></span>
                        </div>

                        <div class="form-group has-feedback" id="divNombre">
                            <label class="control-label">Nombre</label>
                            <input type="text" id="nombre" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');" placeholder="Ingrese el nombre" maxlength="40" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Nombre"></span>
                        </div>
                        
                        <div class="form-group has-feedback" id="divApellido1">
                            <label class="control-label">Primer apellido</label>
                            <input type="text" id="p_Ape" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divApellido1','span1Apellido1');" placeholder="Ingrese el primer apellido" maxlength="20" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="p_Ape" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="p_Ape" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Apellido1"></span>
                        </div>
                       
                        <div class="form-group has-feedback" id="divApellido2">
                            <label class="control-label">Segundo apellido</label>
                            <input type="text" id="s_Ape" runat="server"  class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divApellido2','span1Apellido2');" placeholder="Ingrese el segundo apellido" maxlength="20" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="s_Ape" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="s_Ape" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Apellido2"></span>
                        </div>
                        
                        <%--<div class="form-group" id="divCedula">
                            <label class="control-label">Identificación</label>
                            <input type="text" class="form-control" name="identificacion" id="cedula" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator13','ContentPlaceHolderContenido_RegularExpressionValidator13' ,'divCedula','span1Cedula');"
                                    placeholder="Ingresar identificación" maxlength="9" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cedula" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Solo se permiten numeros. Minimo 9 números" ControlToValidate="cedula" ValidationExpression="^[0-9 ]{9,15}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Cedula"></span>
                        </div>--%>
                        <%--<div>
                            <input type="radio" name="iden" id="cedulaRB" onclick="validarId('ContentPlaceHolderContenido_cedula', 'ContentPlaceHolderContenido_RegularExpressionValidator13');" checked /> Cedula 
                            <input type="radio" name="iden" id="pasaporteRB" onclick="validarId('ContentPlaceHolderContenido_cedula', 'ContentPlaceHolderContenido_RegularExpressionValidator13');" /> Pasaporte 
                            <input type="radio" name="iden" id="residenciaRB" onclick="validarId('ContentPlaceHolderContenido_cedula', 'ContentPlaceHolderContenido_RegularExpressionValidator13');"/> Residencia 
                        </div>
                         <br />--%>
                         

                        
                       <%-- <div class="form-group has-feedback" id="divProvincia">
                            <label class="control-label">Provincia de residencia</label>
                            <input type="text" id="provincia" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divProvincia','span1Provincia');" placeholder="Ingrese la provincia de residencia" maxlength="40" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="provincia" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="provincia" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Provincia"></span>
                        </div>
                        
                        <div class="form-group has-feedback" id="divCanton">
                            <label class="control-label">Cantón de residencia</label>
                            <input type="text" id="canton" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator5','ContentPlaceHolderContenido_RegularExpressionValidator5' ,'divCanton','span1Canton');" placeholder="Ingrese el canton de residencia" maxlength="40" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="canton" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="canton" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Canton"></span>
                        </div>--%>

                        <div class="form-group" id="divPro">
                                <label id="label2" runat="server">Provincia</label>
                                <asp:DropDownList ID="Provincia" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Provincia_SelectedIndexChanged" onchange="validarComboBox('ContentPlaceHolderContenido_RequiredFieldValidatorPro','divPro','span1Pro');">
                                    <asp:listitem selected="selected" value="0">Seleccionar</asp:listitem>
                                </asp:DropDownList>
                             <asp:RequiredFieldValidator id="RequiredFieldValidatorPro" ControlToValidate="Provincia" ErrorMessage="Seleccione una provincia" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1Pro"></span>
                            </div>
                            <div class="form-group" id="divCanton">
                                <label>Canton</label>
                                <asp:DropDownList ID="Canton" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Canton_SelectedIndexChanged" onchange="validarComboBox('ContentPlaceHolderContenido_RequiredFieldValidatorCanton','divCanton','span1Canton');">
                                    <asp:listitem selected="selected" value="0">Seleccionar</asp:listitem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator id="RequiredFieldValidatorCanton" ControlToValidate="Provincia" ErrorMessage="Seleccione una provincia" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1Canton"></span>
                            </div>
                            <div class="form-group" id="divDis">
                                <label>Distrito</label>
                                <asp:DropDownList ID="Distrito" class="form-control" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_RequiredFieldValidatorDis','divDis','span1Dis');">
                                    <asp:listitem selected="selected" value="0">Seleccionar</asp:listitem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator id="RequiredFieldValidatorDis" ControlToValidate="Provincia" ErrorMessage="Seleccione una provincia" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1Dis"></span>
                            </div>

                        <div class="form-group has-feedback" id="divLugarResidencia">
                            <label class="control-label">Lugar de residencia</label>
                            <input type="text" id="lugarResid" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator6','ContentPlaceHolderContenido_RegularExpressionValidator6' ,'divLugarResidencia','span1LugarResidencia');" placeholder="Ingrese el lugar de residencia" maxlength="60" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="lugarResid" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="lugarResid" ValidationExpression="^[0-9A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1LugarResidencia"></span>
                        </div>
                        
                        <div class="form-group has-feedback" id="divNacionalidad">
                            <label class="control-label">Nacionalidad</label>
                            
                            <asp:DropDownList class="form-control" id="nacionalidad" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_Vnacionalidad','divNacionalidad','span1Nacionalidad');">
	                            <asp:listitem selected="selected" value="0">Seleccionar</asp:listitem>
	                            <asp:listitem>Costarricense</asp:listitem>
                                <asp:listitem>Extranjero</asp:listitem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="Vnacionalidad" ControlToValidate="nacionalidad" ErrorMessage="Seleccione una nacionalidad" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1Nacionalidad"></span>  
                        </div>
                        
                        <div class="form-group has-feedback" id="divFechaNacimiento">
                            <label class="control-label">Fecha de nacimiento</label>
                            <input type="text" class="form-control date fechaNac" id="fechaNac" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator7','ContentPlaceHolderContenido_RegularExpressionValidator7' ,'divFechaNacimiento','span1FechaNacimiento');" placeholder="Ingrese la fecha de nacimiento" maxlength="10" readonly/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="fechaNac" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Formato inválido" ControlToValidate="fechaNac" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1FechaNacimiento"></span>
                        </div>
                        
                        <div class="form-group has-feedback" id="divTelResid">
                            <label class="control-label">Teléfono de residencia</label>
                            <input type="text" id="telResid" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_CompareValidator1','ContentPlaceHolderContenido_RegularExpressionValidator8' ,'divTelResid','span1TelefonoResidencia');" placeholder="Ingrese el teléfono de residencia" maxlength="8" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="telCel" ControlToValidate="telResid" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Verificar. Los telefonos son iguales" Operator="NotEqual"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="El teléfono debe ser de 8 numeros" ControlToValidate="telResid" ValidationExpression="^[0-9 ]{8,9}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1TelefonoResidencia"></span>
                        </div>
                        
                        <div class="form-group has-feedback" id="divTelCel">
                            <label class="control-label">Teléfono celular</label>
                            <input type="text" id="telCel" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_CompareValidator2','ContentPlaceHolderContenido_RegularExpressionValidator9' ,'divTelCel','span1TelefonoCelular');" placeholder="Ingrese el teléfono celular" maxlength="8" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="telResid" ControlToValidate="telCel" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Verificar. Los telefonos son iguales" Operator="NotEqual"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="El teléfono debe ser de 8 numeros" ControlToValidate="telCel" ValidationExpression="^[0-9 ]{8,9}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1TelefonoCelular"></span>
                        </div>
                        

                        <div class="form-group has-feedback" id="divOcupacion">
                            <label class="control-label">Ocupación</label>
                            <input type="text" id="ocupacion" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator10','ContentPlaceHolderContenido_RegularExpressionValidator10' ,'divOcupacion','span1Ocupacion');" placeholder="Ingrese la ocupación" maxlength="30" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ocupacion" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="ocupacion" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Ocupacion"></span>
                        </div>
                         
                        <div class="form-group has-feedback" id="divCorreo">
                            <label class="control-label">Correo electrónico</label>
                            <input type="email" id="correo" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator11','ContentPlaceHolderContenido_RegularExpressionValidator11' ,'divCorreo','span1Correo');" placeholder="Ingrese el correo electrónico" maxlength="30" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="enviar" ControlToValidate="correo" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ValidationGroup="enviar" ErrorMessage="Correo electrónico inválido" ControlToValidate="correo" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="" aria-hidden="true" id="span1Correo"></span>
                        </div> 
                        <br />
                        
 
                        </div>
                    </div>

                    <!--columna 2-->

                    <div class="col-md-6">
                        <div class="col-sm-6 col-md-8 col-md-offset-2">

                            <div class="form-group">
                                <label>Subir la imagen del perfil</label>
                                <asp:FileUpload ID="FileUpload1" class="img" runat="server"/>
                            </div> 

                            <div class="form-group">
                                <label>Subir la imagen de la cédula</label>
                                <asp:FileUpload ID="FileUpload2" class="img" runat="server"/>
                            </div>

                            <hr />

                            <div class="form-group has-feedback" id="divTipoBom">
                            <label class="control-label">Tipo de bombero</label> 
                            <asp:DropDownList class="form-control" id="tipoBombero" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_RequiredFieldValidatorTipo','divTipoBom','span1TipoBom');">
	                            <asp:listitem selected="selected" value="0">Seleccionar</asp:listitem>
	                            <asp:listitem>Bombero funcionario</asp:listitem>
                                <asp:listitem>Bombero voluntario</asp:listitem>
                                <asp:listitem>Bombero Institucional</asp:listitem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="RequiredFieldValidatorTipo" ControlToValidate="tipoBombero" ErrorMessage="Seleccione un tipo de bombero" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1TipoBom"></span>
                            </div>

                            <div class="form-group has-feedback" id="divAniosBrig">
                                <label class="control-label">Años de servicio</label>
                                <input type="text" id="aniosBrig" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator12','ContentPlaceHolderContenido_RegularExpressionValidator12' ,'divAniosBrig','span1AniosBrigada');" placeholder="Ingrese los años en la brigada" maxlength="2" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="aniosBrig" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="aniosBrig" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                                <span class="" aria-hidden="true" id="span1AniosBrigada"></span>
                            </div>

                            <%--<div class="" id="divAzgPol">
                            <label class="control-label">Asignar Póliza</label>
                                <asp:DropDownList ID="poliza" class="form-control" runat="server" onblur="comboVal(this,'divAzgPol','span1AzgPol','span2AzgPol');">
                                    <asp:listitem value ="0"> seleccionar </asp:listitem>
                                </asp:DropDownList>
                                <span class="" aria-hidden="true" id="span1AzgPol" style="right: -30px;"></span>
                                <span class="help-block" id="span2AzgPol"></span>
                            </div>

                            <hr />

                            <div class="form-group">
                                <label>Asignar Capacitacion</label>
                                <select class="form-control" id="asignaCap">
                                    <option selected="selected">Seleccionar</option>
                                    <option>OTRAS</option>
                                </select>
                            </div>

                            <hr />--%>
                                    
                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" ValidationGroup="enviar" OnClick="Button1_Click"/>
                        </div>
                    </div>
            </div>
        </form>
        </div>
    <script>
        Configurafecha("+0m +0d -18y", ".fechaNac", "-65:-18");
    </script>
</asp:Content>
