<%@ Page Title="Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ProyectoFinal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div style = "margin:5%">
		

 
	<asp:Literal ID ="divActividad" runat ="server" />
			
	<asp:Button Text="Apúntate" ID='btnApuntarse' class='btn2' runat='server' OnClick='btnApuntarse_Click'/>

	<asp:Button Text="Cancelar voluntariado" ID='btnCancelar' class='btn2' runat='server' OnClick='btnCancelar_Click'/>
	<asp:Label runat='server' class='col-md-6' ID="Apuntado"><b>¡Ya te has inscrito a esta actividad!</b></asp:Label>
</div>
</asp:Content>
