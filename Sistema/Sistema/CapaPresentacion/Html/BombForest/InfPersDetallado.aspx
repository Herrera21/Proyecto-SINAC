<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="InfPersDetallado.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.InfPersDetallado1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
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
                    <li class="active">Reseña médica </li>
                </ol>
            </div>

             <div class="row" style="background-color:white; width:99.7%">

                 <form id="form1" runat="server" >
                        <!-- menu-->
                        <ul class="nav nav-tabs">
                        <li class="active"><a href="InfPersDetallado.aspx">Información Personal</a></li>
                        <li><a href="CEquipoProtPerso.aspx">Equipo de protección personal</a></li>
                        <li><a href="Carne.aspx">Información del carné</a></li>
                        <li><a href="CCapacit.aspx">Capacitaciones</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Experiencia de campo<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="CActivPrev.aspx">Actividades de Prevención</a></li>
                                <li><a href="CIncendForest.aspx">Participación en incencios forestales</a></li>
                            </ul>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="CPoliza.aspx">Pólizas</a></li>
                                <li><a href="CContactosEmergencia.aspx">Contactos de Emergencia</a></li>
                                <li><a href="ReseniaMedica.aspx">Reseña médica</a></li>
                            </ul>
                        </li>
                        <li><a href="CBomberos.aspx">Salir</a></li>
                    </ul>

             <!--formulario-->

            <h1 class="text-center login-title">Bombero Forestal información detallada</h1><hr />

            <!--columna1-->
            <div class="col-md-6">
                <div class="col-sm-6 col-md-8 col-md-offset-2">

                        <div class="form-group has-feedback has-success" id="divNombre">
                            <label class="control-label">Nombre</label>
                            <input type="text" id="nombre" runat="server" class="form-control" readonly/>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divApellido1">
                            <label class="control-label">Primer apellido</label>
                            <input type="text" id="p_Ape" runat="server" class="form-control" readonly/>
                        </div>
                       
                        <div class="form-group has-feedback has-success" id="divApellido2">
                            <label class="control-label">Segundo apellido</label>
                            <input type="text" id="s_Ape" runat="server"  class="form-control" readonly/>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divCedula">
                            <label class="control-label">Identificación</label>
                            <input type="text" class="form-control" name="identificacion" id="cedula" runat="server" readonly/>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divProvincia">
                            <label class="control-label">Provincia de residencia</label>
                            <input type="text" id="provincia" runat="server" class="form-control" readonly/>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divCanton">
                            <label class="control-label">Cantón de residencia</label>
                            <input type="text" id="canton" runat="server" class="form-control" readonly/>
                        </div>
                        

                         <div class="form-group has-feedback has-success" id="divLugarResidencia">
                            <label class="control-label">Lugar de residencia</label>
                            <input type="text" id="lugarResid" runat="server" class="form-control" readonly/>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divNacionalidad">
                            <label class="control-label">Nacionalidad</label>
                            <input type="text" class="form-control date fechaNac" id="nacionalidad" runat="server" readonly/>
                         </div>

                         <div class="form-group has-feedback has-success" id="divFechaNacimiento">
                            <label class="control-label">Fecha de nacimiento</label>
                            <input type="text" class="form-control date fechaNac" id="fechaNac" runat="server" readonly/>
                         </div>
                        
                         <div class="form-group has-feedback has-success" id="divTelResid">
                            <label class="control-label">Teléfono de residencia</label>
                            <input type="text" id="telResid" runat="server" class="form-control" readonly/>
                        </div>
                        
                        <div class="form-group has-feedback has-success" id="divTelCel">
                            <label class="control-label">Teléfono celular</label>
                            <input type="text" id="telCel" runat="server" class="form-control" readonly/>
                        </div>
                        

                        <div class="form-group has-feedback has-success" id="divOcupacion">
                            <label class="control-label">Ocupación</label>
                            <input type="text" id="ocupacion" runat="server" class="form-control" readonly/>
                        </div>
                         
                        <div class="form-group has-feedback has-success" id="divCorreo">
                            <label class="control-label">Correo electrónico</label>
                            <input type="email" id="correo" runat="server" class="form-control" readonly/>
                        </div> 
                        <br />
                        
 
                        </div>
                    </div>

                    <!--columna 2-->

                    <div class="col-md-6">
                        <div class="col-sm-6 col-md-8 col-md-offset-2">

                            <div class="form-group">
                                <label>Imagen del perfil</label>
                                <img  class="form-control" ID="Image1" style="width: 300px; height: auto;" runat="server"/>
                            </div> 

                            <div class="form-group">
                                <label>Imagen de la cédula</label>
                                <img  class="form-control" ID="Image2" style="width: 300px; height: auto;" runat="server"/>
                            </div>

                            <hr />

                            <div class="form-group has-feedback has-success" id="divTipoBom">
                                <label class="control-label">Tipo de bombero</label> 
                                <input type="text" id="tipoBombero" runat="server" class="form-control" readonly/>
                            </div>

                            <div class="form-group has-feedback has-success" id="divAniosBrig">
                                <label class="control-label">Años de servicio</label>
                                <input type="text" id="aniosBrig" runat="server" class="form-control" readonly/>
                            </div>
                        </div>
                    </div>
                 </form>
            </div>
     </div>
</asp:Content>
