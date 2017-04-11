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
    var swiper = new Swiper('.swiper-container', {
        pagination: '.swiper-pagination',
        slidesPerView: 3,
        paginationClickable: true,
        spaceBetween: 30,
        freeMode: true
    });
});