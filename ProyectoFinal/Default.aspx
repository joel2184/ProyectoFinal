<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <!-- Header-->
<!-- Slideshow container -->
<div class="slideshow-container">

  <!-- Full-width images with number and caption text -->
  <div class="mySlides">
    <div class="numbertext">1 / 3</div>
    <img src="https://t2.salir.ltmcdn.com/es/articles/1/3/7/las_mejores_residencias_de_ancianos_en_madrid_1731_orig.jpg" style="width:100%; height: 250px">
    
  </div>

  <div class="mySlides">
    <div class="numbertext">2 / 3</div>
    <img src="https://www.infoelder.com/oc-content/uploads/0/2/0/2473_thumbnail.jpg" style="width:100%; height: 250px">
  </div>

  <div class="mySlides">
    <div class="numbertext">3 / 3</div>
    <img src="https://emera-group.es/wp-content/uploads/2020/11/cabecera-Residencia-para-mayores-Sant-Genis-1536x551.jpg" style="width:100%; height: 250px">
  </div>

  <!-- Next and previous buttons -->
  <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
  <a class="next" onclick="plusSlides(1)">&#10095;</a>
</div>
<br>

<!-- The dots/circles -->
<div style="text-align:center">
  <span class="dot" onclick="currentSlide(1)"></span>
  <span class="dot" onclick="currentSlide(2)"></span>
  <span class="dot" onclick="currentSlide(3)"></span>
</div>

    <script>
        let slideIndex = 1;
        showSlides(slideIndex);

        // Next/previous controls
        function plusSlides(n) {
            showSlides(slideIndex += n);
        }

        // Thumbnail image controls
        function currentSlide(n) {
            showSlides(slideIndex = n);
        }

        function showSlides(n) {
            let i;
            let slides = document.getElementsByClassName("mySlides");
            let dots = document.getElementsByClassName("dot");
            if (n > slides.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
        }

    </script>

     <div class="container-post">

        <input type="radio" id="TODAS" name="categories" value="TODAS" checked>
        <input type="radio" id="OCIO" name="categories" value="OCIO">
        <input type="radio" id="PASEO" name="categories" value="PASEO">
        <input type="radio" id="ENTRETENIMIENTO" name="categories" value="ENTRETENIMIENTO">
        <input type="radio" id="EDUCATIVA" name="categories" value="EDUCATIVA">


        <div class="container-category">
            <label for="TODAS">TODAS ACTIVIDADES</label>
            <label for="OCIO">OCIO</label>
            <label for="PASEO">PASEO</label>
            <label for="ENTRETENIMIENTO">ENTRETENIMIENTO</label>
            <label for="EDUCATIVA">EDUCATIVA</label>
        </div>
         </div>

    <div class="posts">
  
    <asp:Literal ID = "divCards" runat = "server" />

</div>
        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Core theme JS-->
        <script src="js/scripts.js"></script>


</asp:Content>
