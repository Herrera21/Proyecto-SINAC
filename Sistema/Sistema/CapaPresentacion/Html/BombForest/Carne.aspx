<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="Carne.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.Carne" %>
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
              <a id="botonMensaje1" runat="server" href="../MenuPrincipal.aspx" class="btn">Cerrar</a>
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
                    <li class="active">Reseña médica </li>
                </ol>
            </div>

            <div class="row" style="background-color:white; width:99.7%">


                <form id="form1" runat="server">
                    <!-- menu-->
                    <ul class="nav nav-tabs">
                        <%--<li><a href="RBomInfoPerson.aspx">Información Personal</a></li>--%>
                        <li><a href="CEquipoProtPerso.aspx">Equipo de protección personal</a></li>
                        <li><a href="Carne.aspx">Información del carné</a></li>
                        <%--<li><a href="RCapacitación.aspx">Capacitaciones</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Experiencia de campo<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="RActivPrevenc.aspx">Actividades de Prevención</a></li>
                                <li><a href="RIncendForest.aspx">Participación en incencios forestales</a></li>
                            </ul>
                        </li>--%>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="RBomPoliza.aspx">Pólizas</li>
                                <li><a href="RBomBenef.aspx">Beneficiarios</a></li>
                                <li><a href="CContactosEmergencia.aspx">Contactos de Emergencia</a></li>
                                <li class="active"><a href="ReseniaMedica.aspx">Reseña médica</a></li>
                            </ul>
                        </li>
                        <li><a href="../MenuPrincipal.aspx">Salir</a></li>
                    </ul>

                    <%--formulario--%>

                </form>
            </div>
        </div>
</asp:Content>
