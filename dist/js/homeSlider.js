$(document).ready(function(){
  $('.autoplay').slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    autoplay: false,
    autoplaySpeed: 2000,
    dots: true,
    dotsClass: "my-dots",
    prevArrow: $('.prev'),
    nextArrow: $('.next'),
    infinite:false
  });
})




  