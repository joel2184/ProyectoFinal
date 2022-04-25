<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ProyectoFinal.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="css/styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">



    <div class="about-section">
  <h1>SOBRE NOSOTROS</h1>
            <p class="text-justify">Volhelp es un portal de búsqueda de voluntariados en residencias. Esta idea surge para fomentar la actividad social y mejorar los valores como sociedad. Somos un grupo de cuatro estudiantes de un curso de .NET organizado por FundaEsplai. Esta web es el resultado del proyecto final.</p>

</div>

<div class="row">
  <div class="column">
    <div class="card">
      <img src="Images\joel.jpg" alt="Jane" style="width:100%">
      <div class="container">
        <h2>Joel Hurtado</h2>
        <p class="title">Programador</p>
        <p>Programador de aplicaciones
con implicación, aprendizaje
rápido y con capacidad para
trabajar en grupo.
Disponibilidad inmediata y
ganas de seguir formándome.</p>
            <ul class="social-icons" style="text-align:center">
              <li><a class="github" href="https://github.com/joel2184"><i class="fa fa-github"></i></a></li>
              <li><a class="linkedin" href="https://www.linkedin.com/in/joelhurtadocomino/"><i class="fa fa-linkedin"></i></a></li>   
            </ul>
      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
      <img src="Images\manuel.jpg" alt="Mike" style="width:100%">
      <div class="container">
        <h2>Manuel Arispe</h2>
        <p class="title">Programador</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.Some text that describes me lorem ipsum ipsum lorem.</p>
            <ul class="social-icons" style="text-align:center">
              <li><a class="github" href="https://github.com/jacks2121"><i class="fa fa-github"></i></a></li>
              <li><a class="linkedin" href="https://www.linkedin.com/in/manuel-arispe/"><i class="fa fa-linkedin"></i></a></li>   
            </ul>
      </div>
    </div>
  </div>

      <div class="column">
    <div class="card">
      <img src="Images\jose.jpg" alt="Mike" style="width:100%">
      <div class="container">
        <h2>Jose Luis López</h2>
        <p class="title">Programador</p>
        <p>Persona responsable con muchas ganas de aprender mucho más sobre este sector y coger experiencia en el mismo.</p>
            <ul class="social-icons" style="text-align:center">
              <li><a class="github" href="https://github.com/kesp34"><i class="fa fa-github"></i></a></li>
              <li><a class="linkedin" href="https://www.linkedin.com/in/joseluislopezlorenzo"><i class="fa fa-linkedin"></i></a></li>   
            </ul>
      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
      <img src="Images\gabriele.jpg" alt="GABRIELE" style="width:100%">
      <div class="container">
        <h2>Gabriele Nevini</h2>
        <p class="title">Programador</p>
        <p>Mi objetivo es formar parte de una empresa en la que pueda poner en práctica todos mis conocimientos, que me brinde la oportunidad de lograr objetivos
personales, y que me ofrezca la oportunidad de crecer en el área
laboral, personal e intelectual.</p>
            <ul class="social-icons" style="text-align:center;vertical-align: text-bottom">
              <li><a class="github" href="https://github.com/Gabrinev"><i class="fa fa-github"></i></a></li>
              <li><a class="linkedin" href="https://www.linkedin.com/in/gabriele-nevini/"><i class="fa fa-linkedin"></i></a></li>   
            </ul>
      </div>
    </div>
  </div>
</div>

</asp:Content>