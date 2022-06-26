$(document).ready(function(){
  $('.slider-for').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: true,
    Infinity: false,
    asNavFor: '.slider-nav',
    prevArrow: $('.prev'),
    nextArrow: $('.next'),
  });
  $('.slider-nav').slick({
    slidesToShow: 3,
    dots:true,
    Infinity: false,
    slidesToScroll: 1,
    asNavFor: '.slider-for',
    centerMode: true,
    focusOnSelect: true,
    Infinity:false
  });
})

  