<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MBomInfoPerson.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.MBomInfoPerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">

    <script>
        function modalIMG(num) {
            if(num){
                $('#FInputModal1').modal('show');
            }else{
                $('#FInputModal2').modal('show');
            }
        } 

        function previewFile1() {
            var preview = document.querySelector('#<%=Image1.ClientID %>');
            var file = document.querySelector('#<%=FileUpload1.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }

        function previewFile2() {
            var preview = document.querySelector('#<%=Image2.ClientID %>');
            var file = document.querySelector('#<%=FileUpload2.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
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
              <a id="botonMensaje1" runat="server" href="CBomberos.aspx" class="btn">Cerrar</a>
              <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
            </div>
    </div>
    <!--contenido-->
    <div class="container">

        <!-- Miga -->
        <div class="row" style="background-color:white; width:99.7%">
            <ol class="breadcrumb">
                <li><a href="../MenuPrincipal.aspx"> Menú Principal </a></li>
                <li class="active">Bomberos Forestales</li>
                <li class="active">Modificar información personal </li>                
            </ol>
        </div>

        <form id="form1" runat="server">
            <div class="row" style="background-color:white; width:99.7%">
                <!--fileInput-->
                <div id="FInputModal1" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                        <div class="modal-header">
                          <h3>Mensaje</h3>
                        </div>
                        <div class="modal-body">
                          <asp:FileUpload ID="FileUpload1" class="img" runat="server"   
                                onchange="previewFile1()" /> 
                        </div>
                        <div class="modal-footer">
                          <a id="A2" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
                        </div>
                </div>
                <!--fileInput-->
                <div id="FInputModal2" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                        <div class="modal-header">
                          <h3>Mensaje</h3>
                        </div>
                        <div class="modal-body">
                          <asp:FileUpload ID="FileUpload2" class="img" runat="server" onchange="previewFile2()"/> 
                        </div>
                        <div class="modal-footer">
                          <a id="A1" runat="server" href="#" class="btn" data-dismiss="modal">Cerrar</a>
                        </div>
                </div>
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

                <h1 class="text-center login-title">Modificar información personal</h1><hr />

                <!--columna1-->
                <div class="col-md-6">
                    <div class="col-sm-6 col-md-8 col-md-offset-2">

                        <div class="form-group has-feedback has-success" id="divNombre">
                            <label class="control-label">Nombre</label>
                            <input type="text" id="nombre" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator1','ContentPlaceHolderContenido_RegularExpressionValidator1' ,'divNombre','span1Nombre');" placeholder="Ingrese el nombre" maxlength="40" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="nombre" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="nombre" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Nombre"></span>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divApellido1">
                            <label class="control-label">Primer apellido</label>
                            <input type="text" id="p_Ape" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator2','ContentPlaceHolderContenido_RegularExpressionValidator2' ,'divApellido1','span1Apellido1');" placeholder="Ingrese el primer apellido" maxlength="20" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="p_Ape" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="p_Ape" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Apellido1"></span>
                        </div>
                       
                        <div class="form-group has-feedback has-success" id="divApellido2">
                            <label class="control-label">Segundo apellido</label>
                            <input type="text" id="s_Ape" runat="server"  class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator3','ContentPlaceHolderContenido_RegularExpressionValidator3' ,'divApellido2','span1Apellido2');" placeholder="Ingrese el segundo apellido" maxlength="20" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="s_Ape" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="s_Ape" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Apellido2"></span>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divCedula">
                            <label class="control-label">Identificación</label>
                            <input type="text" class="form-control" name="identificacion" id="cedula" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator13','ContentPlaceHolderContenido_RegularExpressionValidator13' ,'divCedula','span1Cedula');"
                                    placeholder="Ingresar identificación" maxlength="9" readonly/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cedula" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Solo se permiten numeros. Minimo 9 números" ControlToValidate="cedula" ValidationExpression="^[0-9 ]{9,15}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Cedula"></span>
                        </div>
                        <div>
                            <input type="radio" name="iden" id="cedulaRB"  checked /> Cedula 
                            <input type="radio" name="iden" id="pasaporteRB"  /> Pasaporte 
                            <input type="radio" name="iden" id="residenciaRB" /> Residencia 
                        </div>
                         <br />

                        
                        <div class="form-group has-feedback has-success" id="divProvincia">
                            <label class="control-label">Provincia de residencia</label>
                            <input type="text" id="provincia" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator4','ContentPlaceHolderContenido_RegularExpressionValidator4' ,'divProvincia','span1Provincia');" placeholder="Ingrese la provincia de residencia" maxlength="40" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="provincia" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="provincia" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Provincia"></span>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divCanton">
                            <label class="control-label">Cantón de residencia</label>
                            <input type="text" id="canton" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator5','ContentPlaceHolderContenido_RegularExpressionValidator5' ,'divCanton','span1Canton');" placeholder="Ingrese el canton de residencia" maxlength="40" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="canton" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="canton" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Canton"></span>
                        </div>
                        

                         <div class="form-group has-feedback has-success" id="divLugarResidencia">
                            <label class="control-label">Lugar de residencia</label>
                            <input type="text" id="lugarResid" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator6','ContentPlaceHolderContenido_RegularExpressionValidator6' ,'divLugarResidencia','span1LugarResidencia');" placeholder="Ingrese el lugar de residencia" maxlength="60" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="lugarResid" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="lugarResid" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1LugarResidencia"></span>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divNacionalidad">
                            <label class="control-label">Nacionalidad</label>
                            
                            <select class="form-control" id="nacionalidad" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_Vnacionalidad','divNacionalidad','span1Nacionalidad');">
	                            <option selected="selected" value="0">Seleccionar</option>
	                            <option>Costarricense</option>
                                <option>Extranjero</option>
                            </select>
                            <asp:RequiredFieldValidator id="Vnacionalidad" ControlToValidate="nacionalidad" ErrorMessage="Seleccione una nacionalidad" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="" aria-hidden="true" id="span1Nacionalidad"></span>  
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divFechaNacimiento">
                            <label class="control-label">Fecha de nacimiento</label>
                            <input type="text" class="form-control date fechaNac" id="fechaNac" runat="server" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator7','ContentPlaceHolderContenido_RegularExpressionValidator7' ,'divFechaNacimiento','span1FechaNacimiento');" placeholder="Ingrese la fecha de nacimiento" maxlength="10" readonly/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="fechaNac" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Formato inválido" ControlToValidate="fechaNac" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1FechaNacimiento"></span>
                            </div>
                        
                         <div class="form-group has-feedback has-success" id="divTelResid">
                            <label class="control-label">Teléfono de residencia</label>
                            <input type="text" id="telResid" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator8','ContentPlaceHolderContenido_RegularExpressionValidator8' ,'divTelResid','span1TelefonoResidencia');" placeholder="Ingrese el teléfono de residencia" maxlength="8" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="telCel" ControlToValidate="telResid" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Verificar. Los telefonos son iguales" Operator="NotEqual"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="El teléfono debe ser de 8 numeros" ControlToValidate="telResid" ValidationExpression="^[0-9 ]{8,9}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1TelefonoResidencia"></span>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divTelCel">
                            <label class="control-label">Teléfono celular</label>
                            <input type="text" id="telCel" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator9','ContentPlaceHolderContenido_RegularExpressionValidator9' ,'divTelCel','span1TelefonoCelular');" placeholder="Ingrese el teléfono celular" maxlength="8" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="telResid" ControlToValidate="telCel" CssClass="alert-danger" Display="Dynamic" ErrorMessage="Verificar. Los telefonos son iguales" Operator="NotEqual"></asp:CompareValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="El teléfono debe ser de 8 numeros" ControlToValidate="telCel" ValidationExpression="^[0-9 ]{8,9}$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1TelefonoCelular"></span>
                        </div>
                        

                        <div class="form-group has-feedback has-success" id="divOcupacion">
                            <label class="control-label">Ocupación</label>
                            <input type="text" id="ocupacion" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator10','ContentPlaceHolderContenido_RegularExpressionValidator10' ,'divOcupacion','span1Ocupacion');" placeholder="Ingrese la ocupación" maxlength="30" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ocupacion" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Solo se permiten letras" ControlToValidate="ocupacion" ValidationExpression="^[A-Za-zñÑáéíóúÁÉÍÓÚ ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Ocupacion"></span>
                        </div>
                         
                        <div class="form-group has-feedback has-success" id="divCorreo">
                            <label class="control-label">Correo electrónico</label>
                            <input type="email" id="correo" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator11','ContentPlaceHolderContenido_RegularExpressionValidator11' ,'divCorreo','span1Correo');" placeholder="Ingrese el correo electrónico" maxlength="30" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="enviar" ControlToValidate="correo" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ValidationGroup="enviar" ErrorMessage="Correo electrónico inválido" ControlToValidate="correo" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" SkinID="divNombre"></asp:RegularExpressionValidator>
                            <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1Correo"></span>
                        </div> 
                        <br />
                        
 
                        </div>
                    </div>

                    <!--columna 2-->

                    <div class="col-md-6">
                        <div class="col-sm-6 col-md-8 col-md-offset-2">

                            <div class="form-group">
                                <label>Subir la imagen del perfil</label>
                                <img  class="form-control" ID="Image1" style="width: 300px; height: auto;" runat="server" onClick="modalIMG(true);"/>
                            </div> 

                            <div class="form-group">
                                <label>Subir la imagen de la cédula</label>
                                <img  class="form-control" ID="Image2" style="width: 300px; height: auto;" runat="server" onClick="modalIMG(false);"/>
                            </div>

                            <hr />

                            <div class="form-group has-feedback has-success" id="divTipoBom">
                            <label class="control-label">Tipo de bombero</label> 
                            <select class="form-control" id="tipoBombero" runat="server" onchange="validarComboBox('ContentPlaceHolderContenido_RequiredFieldValidatorTipo','divTipoBom','span1TipoBom');">
	                            <option selected="selected" value="0">Seleccionar</option>
	                            <option>Bombero funcionario</option>
                                <option>Bombero voluntario</option>
                                <option>Bombero Institucional</option>
                            </select>
                            <asp:RequiredFieldValidator id="RequiredFieldValidatorTipo" ControlToValidate="tipoBombero" ErrorMessage="Seleccione un tipo de bombero" Display="Dynamic" InitialValue="0" runat="server" CssClass="alert-danger" SetFocusOnError="True" ValidationGroup="enviar"/>
                            <span class="form-group has-feedback has-success" aria-hidden="true" id="span1TipoBom"></span>
                            </div>

                        <div class="form-group has-feedback has-success" id="divAniosBrig">
                                <label class="control-label">Años de servicio</label>
                                <input type="text" id="aniosBrig" runat="server" class="form-control" onchange="validarInputText('ContentPlaceHolderContenido_RequiredFieldValidator12','ContentPlaceHolderContenido_RegularExpressionValidator12' ,'divAniosBrig','span1AniosBrigada');" placeholder="Ingrese los años en la brigada" maxlength="2" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="aniosBrig" CssClass="alert-danger" Display="Dynamic" ErrorMessage="No se permiten campos vacíos" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" SetFocusOnError="True" ValidationGroup="enviar"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Solo se permiten numeros" ControlToValidate="aniosBrig" ValidationExpression="^[0-9 ]+$" CssClass="alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationGroup="enviar"></asp:RegularExpressionValidator>
                                <span class="glyphicon form-control-feedback icon-checkmark" aria-hidden="true" id="span1AniosBrigada"></span>
                            </div>

                            <%--<div class="form-group">
                                <label>Asignar Poliza</label>
                                <select class="form-control" id="poliza">
                                    <option selected="selected">Seleccionar</option>
	                                <option>INS</option>
                                    <option>OTRAS</option>
                                </select>
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
                                    
                            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Guardar" ValidationGroup="enviar" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Inactivar" OnClick="Button2_Click" />
                        </div>
                    </div>
            </div>
        </form>
        </div>
    <script>
        Configurafecha("+0m +0d -18y", ".fechaNac", "-65:-18");
    </script>
</asp:Content>
