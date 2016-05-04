<%@ Page Title="" Language="C#" MasterPageFile="~/CapaPresentacion/Html/PaginaEstandar.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Sistema.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <!--mensaje-->
    <div id="mensajes" class="modal" style="display: none; " >
            <div class="modal-header">
              <a class="close" data-dismiss="modal">×</a>
              <h3>Mensaje</h3>
            </div>
            <div class="modal-body">
               <label id="labelMensaje" runat="server"></label>			        
            </div>
            <div class="modal-footer">
              <a href="#" class="btn" data-dismiss="modal" visible="true">Cerrar</a>
            </div>
    </div>

    <!--contenido-->
        <div class="container">
            <div class="row" style="background-color:white; width:99.7%">
                <div class="col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">ENTRAR AL SISTEMA</h1>
                    <div class="account-wall">
                        <form id="form1" class="form-signin" runat="server">
                            <input type="text" class="form-control" id="usuario" runat="server"
                                   placeholder ="Usuario" autofocus="autofocus"
                                   required="required"/>
                            <input type="password" class="form-control" id="pass" runat="server"
                                   placeholder ="Contraseña" autofocus="autofocus"
                                   required="required"/>
                            <asp:Button ID="Button1" runat="server" Text="Entrar" class="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" />
                            <a href="#">¿Olvidaste la Contraseña?</a>
                        </form>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
