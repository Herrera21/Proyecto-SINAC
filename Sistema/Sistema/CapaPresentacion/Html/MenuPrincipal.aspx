<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <link href="/CapaPresentacion/Css/MenuPrincipal.css" rel="stylesheet" />
    <script src="/Jquery/js/jquery.slides.js"></script>
    <script type="text/javascript" src="/CapaPresentacion/Js/MenuPrincipal.js"></script>

    <!--contenido-->               
     <div class="container">
            <div class="row" style="width:99.7%">
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <!-- Brand and toggle get grouped for better mobile display -->
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="#">INICIO</a>
                        </div>
                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                            <ul class="nav navbar-nav">
                                <li><a href="CAreaConserv.aspx">Administrar</a></li>
                                <%--<li class="dropdown">
                                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Áreas de Conservación<span class="caret"></span></a>
                                  <ul class="dropdown-menu">
                                    <li><a href="RMenuAreaConserv.aspx">Registrar</a></li>
                                    <li><a href="MMenuAreaConserv.aspx">Modificar</a></li>
                                  </ul>
                                </li>
                                <li class="dropdown">
                                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Brigadas<span class="caret"></span></a>
                                  <ul class="dropdown-menu">
                                    <li><a href="RMenuBrigada.aspx">Registrar</a></li>
                                    <li><a href="MMenuBrigada.aspx">Modificar</a></li>
                                  </ul>
                                </li>--%>
                                <li class="dropdown" id="userMenu">
                                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Usuarios<span class="caret"></span></a>
                                  <ul class="dropdown-menu">
                                    <li><a href="RMenuUsu.aspx">Registrar</a></li>
                                    <li><a href="MMenuUsu.aspx">Modificar</a></li>
                                  </ul>
                                </li>
                                <li class="dropdown">
                                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Bomberos Forestales<span class="caret"></span></a>
                                  <ul class="dropdown-menu">
                                    <li><a href="BombForest/RBomInfoPerson.aspx">Registrar Info. Personal</a></li>
                                    <li><a href="BombForest/MBomInfoPerson.aspx">Modificar Info. Personal</a></li>
                                    <li><a href="BombForest/REquipoProtPerso.aspx">Mantenimiento</a></li>
                                    
                                  </ul>
                                </li>

                                <%--<li class="dropdown">
                                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Polizas<span class="caret"></span></a>
                                  <ul class="dropdown-menu">
                                    
                                    <li><a href="RMenuPoliza.aspx">Registrar Poliza</a></li>
                                    <li><a href="MMenuPoliza.aspx">Modificar Poliza</a></li>
                                    <li><a href="MMenuPoliza.aspx">Asignar Polizas</a></li>
                                  </ul>
                                </li>--%>

                                <li><a href="Mantenimiento/CMenuPoliza.aspx">Mantenimientos</a></li>
                            </ul>
                            <form class="navbar-form navbar-right" role="search" runat="server">
                                <!--mensaje-->
                                <div id="mensajes" class="modal" data-backdrop="static" data-keyboard="false" style="display: none; ">
                                        <div class="modal-header">
                                          <h3>Mensaje</h3>
                                        </div>
                                        <div class="modal-body">
                                           <label id="labelMensaje" runat="server">¿Desea salir del sistema?</label>		        
                                        </div>
                                        <div class="modal-footer">
                                          <asp:Button ID="ButtonAceptar" runat="server" Text="Aceptar" class="btn" OnClick="ButtonAcepta"/>
                                          <a id="botonMensaje2" runat="server" href="#" class="btn" data-dismiss="modal">Cancelar</a>
                                        </div>
                                </div>

                                <asp:Button runat="server" class="btn btn-primary btn-block" Text="Cerrar sesión" OnClick="Button1_Click"/>
                            </form>
                        </div><!-- /.navbar-collapse -->
                    </div><!-- /.container-fluid -->
                </nav>
            </div>
        </div>
        <div class="container">
            <!-- Miga -->
            <div class="row" style="background-color:white; width:99.7%">
                <ol class="breadcrumb">
                    <li class="active">Menú Principal</li>
                    <!--<li><a href="#">Library</a></li>
                    <li><a href="#">Data</a></li>-->
                </ol>
            </div>
            <!-- Contenido -->
            <div class="row" style="background-color:white; width:99.7%">
                <div class="main">

                    <!-- Imagen Áreas -->
                    <div class="col-md-4" style="margin:0; padding:0;">
                        <h4>Áreas de Conservación</h4>
                    
                        <img src="/Imagenes/MapaAC.jpg" class="img-responsive, col-md-12" style="max-width: 100%; height: auto; background-color: white; margin:0; padding:0;"  />

                    </div>

                    <!-- Slideshow -->
                    <div class="slides col-md-5 ">
                        <div>
                            <img src="../../Imagenes/slide1.jpg" alt=""/>
                        </div>
                        <div>
                            <img src="../../Imagenes/slide2.jpg" alt=""/>
                        </div>
                        <div>
                            <img src="../../Imagenes/slide3.jpg" alt=""/>
                        </div>
                        <div>
                            <img src="../../Imagenes/slide4.jpg" alt=""/>
                        </div>
                         <div>
                            <img src="../../Imagenes/slide5.jpg" alt=""/>
                        </div>
                         <div>
                            <img src="../../Imagenes/slide6.jpg" alt=""/>
                        </div>

                    </div>
                
                </div>
            </div>
        </div>

        <script>
            if (Rol() != 0 && Rol() != 1)
            {
                ocultar("userMenu", true);
            }

            function Rol() {
                return <%=VariablesSeccionControl.Lee<byte>("userRol")%>;
            }
        </script>
</asp:Content>
