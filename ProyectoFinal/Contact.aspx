<%@ Page Title="Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ProyectoFinal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div style = "margin:5%">
	<asp:Literal ID ="divActividad" runat ="server" />
	</div>
	<asp:Button Text="Apúntate" ID='btnApuntarse' class='btn' runat='server' OnClick='btnApuntarse_Click'/>
	<asp:Label runat='server' class='col-md-6' ID="Apuntado"><b>¡Ya te has inscrito a esta actividad!</b></asp:Label>
</asp:Content>
