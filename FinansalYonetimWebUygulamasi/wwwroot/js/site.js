document.addEventListener('DOMContentLoaded', function () {


    let slideIndex = 0;
    let slideInterval;

    function showSlides() {

        let slides = document.querySelectorAll('.slide');
        let dots = document.querySelectorAll('.nav-dot');

        for (let i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }

        slideIndex++;
        if (slideIndex > slides.length) {
            slideIndex = 1;
        }

        for (let i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }

        slides[slideIndex - 1].style.display = "block";
        dots[slideIndex - 1].className += " active";

    }

    function startSlideShow() {
        showSlides();
        slideInterval = setInterval(showSlides, 3000); // Change image every 3 seconds
    }

    function stopSlideShow() {
        clearInterval(slideInterval);
    }

    window.currentSlide = function (n) {
        console.log("currentSlide called with index: ", n);
        slideIndex = n - 1;
        stopSlideShow(); // Stop the existing slideshow
        showSlides(); // Show the selected slide
        slideInterval = setInterval(showSlides, 3000); // Restart the slideshow
    };

    startSlideShow();

    window.toggleMenu = function () {
        console.log("toggleMenu called");
        let nav = document.querySelector('.navbar-nav');
        nav.classList.toggle('show');
    };
});
