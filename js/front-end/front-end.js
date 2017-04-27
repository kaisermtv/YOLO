$(document).ready(function () {
    $('.bar').off('click').on('click', function (e) {
        e.preventDefault();
        $(this).parent().addClass('active');
        if ($('#menu-wraper').hasClass('active')) {
            $('#menu-wraper').removeClass('active');
        } else {
            $('#menu-wraper').addClass('active');
        }

    });
    $('.login-m a').off('click').on('click', function (e) {
        e.preventDefault();
        if ($('#loggin-wraper').hasClass('active')) {
            $('#loggin-wraper').removeClass('active');
        } else {
            $('#loggin-wraper').addClass('active');
        }

    });
    $('.register-m a.register-rv').off('click').on('click', function (e) {
        e.preventDefault();
        if ($('#register-wraper').hasClass('active')) {
            $('#register-wraper').removeClass('active');
        } else {
            $('#register-wraper').addClass('active');
        }

    });
    $('.overlay').off('click').on('click', function (e) {
        e.preventDefault();
        $('#loggin-wraper,#register-wraper').removeClass('active');
    });
    var wH = $(window).width();
    var slidesPerView = 5;
    if (wH <= 1200 && wH >= 768) {
        slidesPerView = 4;
    } else if (wH <= 768 && wH >= 641) {
        slidesPerView = 3;
    } else if (wH <= 641 && wH >= 425) {
        slidesPerView = 2;
    } else if (wH <= 425) {
        slidesPerView = 1;
    }
    var swiper = new Swiper('.swiper-container', {
        pagination: '.swiper-pagination',
        slidesPerView: slidesPerView,
        paginationClickable: true,
        spaceBetween: 25,
        freeMode: true,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        //loop: true,
        autoplay: 5000
    });
    var swiper2 = new Swiper('.tab-slide-m', {
        //pagination: '.swiper-pagination',
        paginationClickable: true,
        spaceBetween: 0,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        loop: true,
        onClick: function (swiper, event) {
            if ($(swiper.clickedSlide).data('href')) {
                window.location.href = $(swiper.clickedSlide).data('href');
            }
        }
    });

    $(window).scroll(function () {
        var scrollTop = $(window).scrollTop();
        if (scrollTop >= 100) {
            $('#menu-wraper,.main-header .search-w').addClass('fixed');
        } else {
            $('#menu-wraper,.main-header .search-w').removeClass('fixed');
        }
    });
});