<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="AcercaDe.aspx.cs" Inherits="Sistema.CapaPresentacion.Html.AcercaDe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <div class="container">
        <div class="row" style="background-color:white; width:99.7%">
                <ol class="breadcrumb">
                    <li><a href="MenuPrincipal.aspx"> Menú Principal </a></li>
                    <li class="active">Acerca de </li>
                </ol>
            </div>
        <div class="row" style="background-color:white; width:99.7%">
            <div class="col-sm-6 col-md-12">
            <h1 class="text-center login-title">Acerca del sistema</h1>
            <div class="panel panel-default">
              <div class="panel-body">
                  <p class="text-justify">El Sistema de Expediente Digital de Bomberos Forestales 
                      fue elaborado por estudiantes de la Universidad Nacional, con el propósito 
                      de brindar una ayuda a la sociedad, y así también para el desarrollo profesional 
                      de los estudiantes. </p>
                 <b>Desarrollado por:</b>
                  <p>Santiago Sánchez Madrigal<br/>Alejandro Herrera Fernández<br/>Oscar Jiménez Obando<br />Adrián López Jiménez<br />William Méndez Barquero</p>
              </div>
            </div>
            </div>
                    
            
        </div>

    </div>
</asp:Content>
