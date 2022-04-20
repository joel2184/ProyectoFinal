<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResiPannel.aspx.cs" Inherits="ProyectoFinal.ResiPannel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <asp:Label ID="lblTitle" runat="server" Text="Label" CssClass="h1"></asp:Label>



    <br />
    <asp:Button ID="btnActForm" class="btn btn-primary btn-sm" runat="server" Text="CREAR NUEVA ACTIVIDAD" OnClick="btnActForm_Click" />
    <asp:Button ID="btnVoluList" class="btn btn-primary btn-sm" runat="server" Text="LISTA VOLUNTARIOS APUNTADOS" OnClick="btnVoluList_Click" />


    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <div runat="server" class="form-floating" id="divNewAct">
                    <asp:Label ID="Label9" runat="server" Text="DNI: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtDni" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Nombre: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNomV" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Telefono: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTelV" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Email: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtEmailV" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Horario: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="dlHor" runat="server">
                        <asp:ListItem>mañanas</asp:ListItem>
                        <asp:ListItem>tardes</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="Contraseña: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPassV" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div runat="server" class="form-floating" id="divSeeVol">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="modal fade" id="loginModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">INICIAR SESSIÓN</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="form-floating">
                        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtMail" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br>
                    <div class="form-floating">
                        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br>
                    <div class="checkbox mb-1">
                        <label>
                            <input type="checkbox" runat="server" name="rememberme" id="rememberme">
                            Recordarme
                        </label>
                    </div>

                    <br>
                    <div>
                        ¿Notienes cuenta? <a href="#signUpModal">Crear una</a>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnLogIn" runat="server" CssClass="btn btn-secondary" Text="INICIAR SESIÓN" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


