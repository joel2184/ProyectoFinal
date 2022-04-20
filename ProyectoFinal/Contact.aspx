<%@ Page Title="Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ProyectoFinal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
		<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

<div style = "margin:5%">
		

 
	<asp:Literal ID ="divActividad" runat ="server" />
			
	<asp:Button Text="Apúntate" ID='btnApuntarse' class='btn2' runat='server' OnClick='btnApuntarse_Click'/>

	<asp:Button Text="Cancelar voluntariado" ID='btnCancelar' class='btn2' runat='server' OnClick='btnCancelar_Click'/>
	<asp:Label runat='server' class='col-md-6' ID="Apuntado"><b>¡Ya te has inscrito a esta actividad!</b></asp:Label>
</div>
</asp:Content>
