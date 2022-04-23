<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ResiPannel.aspx.cs" Inherits="ProyectoFinal.ResiPannel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="css/styles.css">


    <asp:Label ID="lblTitle" runat="server" Text="Label" CssClass="h1"></asp:Label>



    <br />
    <br />
    <asp:Button ID="btnActForm" class="btn btn-primary btn-sm" runat="server" Text="CREAR NUEVA ACTIVIDAD" OnClick="btnActForm_Click" />
    <asp:Button ID="btnVoluList" class="btn btn-primary btn-sm" runat="server" Text="LISTA VOLUNTARIOS APUNTADOS" OnClick="btnVoluList_Click" />
    <asp:Button ID="btnActiList" class="btn btn-primary btn-sm" runat="server" Text="TUS ACTIVIDADES" OnClick="btnActiList_Click" />



    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <div runat="server" class="form-group" id="divNewAct">
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="Título: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNom" class="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Tipo: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddTipo" runat="server" class="form-control">
                        <asp:ListItem>Ocio</asp:ListItem>
                        <asp:ListItem>Taller</asp:ListItem>
                        <asp:ListItem>Paseo</asp:ListItem>
                        <asp:ListItem>Cine</asp:ListItem>
                        <asp:ListItem>Educativa</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Horario: "></asp:Label>
                    <br />
                    <input type="time" runat="server" class="form-control" id="txtHor">
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Fecha: "></asp:Label>
                    <br />
                    <input type="date" runat="server" class="form-control" id="txtFecha">
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Descripción: "></asp:Label>
                    <br />
                    <textarea class="form-control" runat="server" id="txtDesc" rows="3"></textarea>

                    <asp:Button ID="btnSubmit" class="btn2" runat="server" Text="CREAR" OnClick="btnSubmit_Click" />

                </div>

                <div runat="server" class="form-floating" id="divListVol">
                    <br />
          

                    <asp:ListView runat="server" ID="TableListView" 
                          ItemPlaceholderID="itemPlaceHolder"
                        OnItemDataBound="TableListView_ItemDataBound">
                <LayoutTemplate>
                    <table id="ListViewTable" class="table table-bordered">
                        <thead>
                            <tr>
                                <th scope="col">Actividad</th>
                                <th scope="col">Voluntario</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" id="itemPlaceHolder">
                            </asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>                                
                        <td runat="server" id="nombreActividad"></td>
                        <td runat="server" id="nombreVoluntario"></td>
                    </tr>
                </ItemTemplate>           
                        </asp:ListView>
                </div>

                 <div runat="server" class="form-floating" id="divListAct">
                    <br />
                    <asp:ListBox ID="lbActi" runat="server" class="list-group"></asp:ListBox>
                     <br />
                    <asp:Button ID="btnRemove" class="btn btn-primary btn-sm" runat="server" Text="ELIMINAR" OnClick="btnRemoveActi_Click" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>



