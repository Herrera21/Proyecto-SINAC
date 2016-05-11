<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="InfPersDetallado.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.BombForest.InfPersDetallado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!-- menu-->
    <ul class="nav nav-tabs">
      <li class="active"><a href="InfPersDetallado.aspx">Información detallada</a></li>
      <li><a href="CEquipoProtPerso.aspx">Equipo de protección personal</a></li>
      <li><a href="RCarne.aspx">Información del carné</a></li>
      <li><a href="CCapacitacion.aspx">Capacitaciones</a></li>
      <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Experiencia de campo<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="CActivPrevenc.aspx">Actividades de Prevención</a></li>
              <li><a href="CIncendForest.aspx">Participación en incencios forestales</a></li>
          </ul>
      </li>
      <li class="dropdown">
          <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información médica<span class="caret"></span></a>
          <ul class="dropdown-menu">
              <li><a href="CBomPoliza.aspx">Pólizas</li>
              <li><a href="CBomBenef.aspx">Beneficiarios</a></li>
              <li><a href="CContactosEmergencia.aspx">Contactos de Emergencia</a></li>
              <li><a href="RReseniaMedica.aspx">Reseña médica</a></li>
          </ul>
      </li>
      <li><a href="../MenuPrincipal.aspx">Salir</a></li>
    </ul>

    <h1 class="text-center login-title">Bombero Forestal información detallada</h1><hr />


</asp:Content>
