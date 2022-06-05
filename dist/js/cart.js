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
});

$(window).on("load", function(){
    $(".laodPage").fadeOut("slow");
});