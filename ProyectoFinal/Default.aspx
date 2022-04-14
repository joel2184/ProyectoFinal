<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <!-- Header-->
<!-- Slideshow container -->
<div class="slideshow-container">

  <!-- Full-width images with number and caption text -->
  <div class="mySlides">
    <div class="numbertext">1 / 3</div>
    <img src="https://cdn.pixabay.com/photo/2021/08/25/20/42/field-6574455_960_720.jpg" style="width:100%; height: 250px">
    <div class="text">Caption Text</div>
  </div>

  <div class="mySlides">
    <div class="numbertext">2 / 3</div>
    <img src="https://cdn.pixabay.com/photo/2013/07/18/20/26/sea-164989_960_720.jpg" style="width:100%; height: 250px">
    <div class="text">Caption Two</div>
  </div>

  <div class="mySlides">
    <div class="numbertext">3 / 3</div>
    <img src="https://cdn.pixabay.com/photo/2018/08/24/23/33/field-3629120_960_720.jpg" style="width:100%; height: 250px">
    <div class="text">Caption Three</div>
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
        <div class="post" data-category="OCIO">
            <a href="#" class="news-card__card-link"></a>
            <img src="https://images.pexels.com/photos/127513/pexels-photo-127513.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" alt="" class="news-card__image">
            <div class="news-card__text-wrapper">
                <h2 class="news-card__title">Nombre Actividad</h2>
                <div class="news-card__post-date">Jan 29, 2018</div>
                <div class="news-card__details-wrapper">
                    <h6>Ubicación</h6>
                    <h6>Tipo de actividad</h6>
                    <h6>Número de plazas</h6>
                    <p class="news-card__excerpt">Lorem ipsum dolor sit amet consectetur adipisicing elit. Est pariatur nemo tempore repellat? Ullam sed officia iure architecto deserunt distinctio, pariatur&hellip;</p>
                    <a href="#" class="news-card__read-more">Read more <i class="fas fa-long-arrow-alt-right"></i></a>
                </div>
            </div>
        </div>

        <div class="post" data-category="OCIO">
            <a href="#" class="news-card__card-link"></a>
            <img src="https://images.pexels.com/photos/631954/pexels-photo-631954.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" alt="" class="news-card__image">
            <div class="news-card__text-wrapper">
                <h2 class="news-card__title">Amazing Second Title that is Quite Long</h2>
                <div class="news-card__post-date">Jan 29, 2018</div>
                <div class="news-card__details-wrapper">
                    <p class="news-card__excerpt">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ullam obcaecati ex natus nulla rem sequi laborum quod fugit&hellip;</p>
                    <a href="#" class="news-card__read-more">Read more <i class="fas fa-long-arrow-alt-right"></i></a>
                </div>
            </div>
        </div>

        <div class="post" data-category="PASEO">
            <a href="#" class="news-card__card-link"></a>
            <img src="https://images.pexels.com/photos/247599/pexels-photo-247599.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260" alt="" class="news-card__image">
            <div class="news-card__text-wrapper">
                <h2 class="news-card__title">Amazing Title</h2>
                <div class="news-card__post-date">Jan 29, 2018</div>
                <div class="news-card__details-wrapper">
                    <p class="news-card__excerpt">Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis beatae&hellip;</p>
                    <a href="#" class="news-card__read-more">Read more <i class="fas fa-long-arrow-alt-right"></i></a>
                </div>
            </div>
        </div>

        <div class="post" data-category="PASEO">
            <a href="#" class="news-card__card-link"></a>
            <img src="https://images.pexels.com/photos/248486/pexels-photo-248486.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" alt="" class="news-card__image">
            <div class="news-card__text-wrapper">
                <h2 class="news-card__title">Amazing Forth Title that is Quite Long</h2>
                <div class="news-card__post-date">Jan 29, 2018</div>
                <div class="news-card__details-wrapper">
                    <p class="news-card__excerpt">Lorem ipsum dolor sit amet!</p>
                    <a href="#" class="news-card__read-more">Read more <i class="fas fa-long-arrow-alt-right"></i></a>
                </div>
            </div>
        </div>

        <div class="post" data-category="OCIO">
            <a href="#" class="news-card__card-link"></a>
            <img src="https://images.pexels.com/photos/206660/pexels-photo-206660.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" alt="" class="news-card__image">
            <div class="news-card__text-wrapper">
                <h2 class="news-card__title">Amazing Fifth Title</h2>
                <div class="news-card__post-date">Jan 29, 2018</div>
                <div class="news-card__details-wrapper">
                    <p class="news-card__excerpt">Lorem ipsum dolor sit amet consectetur adipisicing elit. Est pariatur nemo tempore repellat? Ullam sed officia iure architecto deserunt distinctio&hellip;</p>
                    <a href="#" class="news-card__read-more">Read more <i class="fas fa-long-arrow-alt-right"></i></a>
                </div>
            </div>
        </div>

        <div class="post" data-category="ENTRETENIMIENTO">
            <a href="#" class="news-card__card-link"></a>
            <img src="https://images.pexels.com/photos/210243/pexels-photo-210243.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" alt="" class="news-card__image">
            <div class="news-card__text-wrapper">
                <h2 class="news-card__title">Amazing 6<sup>th</sup> Title</h2>
                <div class="news-card__post-date">Jan 29, 2018</div>
                <div class="news-card__details-wrapper">
                    <p class="news-card__excerpt">Lorem ipsum dolor sit amet consectetur adipisicing elit. Est pariatur nemo tempore repellat? Ullam sed officia.</p>
                    <a href="#" class="news-card__read-more">Read more <i class="fas fa-long-arrow-alt-right"></i></a>
                </div>
            </div>
        </div>

    </div>
        <!-- Footer-->
        <footer class="py-5 bg-dark">
            <div class="container"><p class="m-0 text-center text-white">Copyright &copy; Your Website 2022</p></div>
        </footer>
        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Core theme JS-->
        <script src="js/scripts.js"></script>


</asp:Content>
