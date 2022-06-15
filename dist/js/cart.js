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

    $('.mobile-search-icon').click(function(){
        $('.mobile-search-wrapper').toggleClass('search-inpt-toggle');
    })

    var $links = $('.image-ch').click(function () {
        $(this).addClass('clicked');
    });

    $(".image-ch").hover(
        function(){
            let mainImg = $(this).parent().parent().parent().prev().children().children().children();
            var bg = $(this).children().css('background-image');
            bg = bg.replace('url(','').replace(')','').replace(/\"/gi, "");
            $(this).siblings().removeClass("dot-active");
            $(this).toggleClass("dot-active");
            mainImg.attr('src',bg);
        },
        function(){
                        if($links.is(".clicked")){  
               $links.removeClass("clicked");            
            }else{
                $(this).removeClass("dot-active");
                $(this).siblings().first().addClass("dot-active")
                let mainImg = $(this).parent().parent().parent().prev().children().children().children();
                var bg = $(".image-ch").first().children().css('background-image');
                bg = bg.replace('url(','').replace(')','').replace(/\"/gi, "");
                mainImg.attr('src',bg);
            }
        }
    )

    $(".image-ch").click(function() {
        let mainImg = $(this).parent().parent().parent().prev().children().children().children();
        var bg = $(this).children().css('background-image');
        bg = bg.replace('url(','').replace(')','').replace(/\"/gi, "");
        $(this).siblings().removeClass("dot-active");
        $(this).addClass("dot-active");
        mainImg.attr('src',bg);
    });

    

    $(window).click(function() {
        $(".serach-result_search-isvisible").removeClass("serach-result_search-isvisible");
        $(".search-result_angle-rotate").removeClass("search-result_angle-rotate");
      });
      

    $(".open-sort").click(function(e){
        e.stopPropagation();
        $(this).toggleClass("search-result_angle-rotate");
        $(this).next().toggleClass("serach-result_search-isvisible");
    })

    $(".sort-item").click(function(e){
        e.preventDefault();
        $(".active-sort").removeClass("active-sort");
        $(this).children().next().addClass("active-sort");
    })

    $(".sort-radio").click(function(e){
        e.preventDefault();
        $('.sort-radio').children('i').removeClass('active');
        $(this).children('i').addClass('active');
    })

    
    $(".search-color").click(function(){
        $(this).children().children().children("i").toggleClass("search-inpt-toggle");
    })

    $(".cart-header_title").click(function(e){
        e.preventDefault();
        $(".search-result_pro_overlay").addClass("active");
        $(".search-result_pro_panel").addClass("search-menu-bar-vis");
        $(".search-result_pro").css("pointer-events","initial");
        
    })

    $(".search-result_pro_overlay").click(function(){
        $(".search-result_pro_overlay").removeClass("active");
        $(".search-result_pro_panel").removeClass("search-menu-bar-vis");
        $(".search-result_pro").css("pointer-events","none");
    })

    $(".cancel-search-filter").click(function(){
        $(".search-result_pro_overlay").removeClass("active");
        $(".search-result_pro_panel").removeClass("search-menu-bar-vis");
        $(".search-result_pro").css("pointer-events","none");
    })


    var distance = $('.navbar').offset().top; 

$(window).scroll(function () {
     
     if ($(window).scrollTop() >= distance) {
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