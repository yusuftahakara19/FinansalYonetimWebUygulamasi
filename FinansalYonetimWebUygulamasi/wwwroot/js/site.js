document.addEventListener('DOMContentLoaded', function () {
    let slideIndex = 0;
    let slideInterval;

    function showSlides() {
        let slides = document.querySelectorAll('.slide');
        let dots = document.querySelectorAll('.nav-dot');

        slides.forEach((slide) => {
            slide.style.display = 'none';
        });

        slideIndex++;
        if (slideIndex > slides.length) {
            slideIndex = 1;
        }

        dots.forEach((dot) => {
            dot.classList.remove('active');
        });

        slides[slideIndex - 1].style.display = 'block';
        dots[slideIndex - 1].classList.add('active');
    }

    function startSlideShow() {
        showSlides();
        slideInterval = setInterval(showSlides, 3000); // Change image every 3 seconds
    }

    function stopSlideShow() {
        clearInterval(slideInterval);
    }

    window.currentSlide = function (n) {
        slideIndex = n - 1;
        stopSlideShow(); // Stop the existing slideshow
        showSlides(); // Show the selected slide
        slideInterval = setInterval(showSlides, 3000); // Restart the slideshow
    };

    startSlideShow();

    window.toggleMenu = function () {
        let nav = document.querySelector('.navbar-nav');
        nav.classList.toggle('show');
    };
});

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('.navbar-toggler').addEventListener('click', function () {
        let nav = document.querySelector('.navbar-nav');
        nav.classList.toggle('show');
    });
});


