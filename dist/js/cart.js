$(document).ready(function(){
    $(".cart-open").click(function(e){
        e.preventDefault();
        $("#shop-cart").css("transform","translateX(0)");
        $(".cart-backdrop").addClass("is-visible");
        $('body').css('overflow','hidden')
    });
    $("#close-cart").click(function(e){
        e.preventDefault();
        $("#shop-cart").css("transform","translateX(600px)");
        $(".cart-backdrop").removeClass("is-visible");
        $('body').css('overflow','auto')
    })

    $('#mobile-menu-open-close').click(function(){
        $('.open-m, .close-m').toggleClass('d-none');
        $('.open-drower-parent').toggleClass('mobile_isVisible');
        $('body').toggleClass('boy-overflow-hid');

    })

    $('.open_expand').click(function(){
        $(this).parent().next().addClass('mobile-expand-visible');
        $('.mobile-menu_secondary').toggleClass('d-none');
    })

    $('.close-expand').click(function(){
        $(this).parent().parent().parent().removeClass("mobile-expand-visible");
        $('.mobile-menu_secondary').toggleClass('d-none');
    })

    $('.rotate').click(function(){
        $(this).toggleClass('plus-minus-rotate-closed')
        $(this).toggleClass('plus-minus-rotate-open');
    })

    $(".image-ch").click(function(e) {
        e.preventDefault();
        let mainImg = $(this).parent().parent().parent().prev().children().children().children();
        var bg = $(this).children().css('background-image');
        bg = bg.replace('url(','').replace(')','').replace(/\"/gi, "");
        $(this).siblings().removeClass("dot-active");
        $(this).addClass("dot-active");
        mainImg.attr('src',bg);
    });


    var distance = $('.navbar').offset().top; 

$(window).scroll(function () {
     
     if ($(window).scrollTop() >= 110) {
         $('.navbar').addClass("sticky-navbar");
         $('.mobile-navbar').addClass("sticky-mobile-navbar");
     } else {
         $('.navbar').removeClass("sticky-navbar");
         $('.mobile-navbar').removeClass("sticky-mobile-navbar");
     }
 });

});
$(window).on("load", function(){
    $(".loadingPage").fadeOut("slow");
    $('.loadingPage').toggleClass('boy-overflow-hid');
        });