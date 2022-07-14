$(document).ready(function () {

    $(document).on("click", ".priceSort", function (e) {
        e.preventDefault()

        let url = $(this).attr("href")
        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $(".product-list").html(data);
        })
    })
    $(document).on("click", ".addToBasket", function (e) {
        e.preventDefault()

        let url = $("#basketform").attr("action")
        let colorId = $("#colorId").val();
        url = url + "?colorId=" + colorId
        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $("#shop-cart").html(data);
        })
        sleep(1000).then(() => ProCountSee());
        sleep(1000).then(() => ProCountMobSee());
    })

    $(document).on("change","select.qwerty",function(){
        var count = $(this).children("option:selected").val();
        let url = $(this).parent().parent().attr("action")
        console.log(url)
        url = url + "&count=" + count
        fetch(url).then(response => {

            fetch("ShoppingCart/UpdateHeaderCart").then(response => {
                return response.text();
            }).then(data => {
                $("#shop-cart").html(data);
            })

            return response.text();
        }).then(data => {
            $("#shopcart").html(data);
        })
    });

    $(document).on("click", ".delete-pro-l", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $("#shop-cart").html(data);
        })
        sleep(1000).then(() => ProCountSee());
        sleep(1000).then(() => ProCountMobSee());
    });

    $(document).on("click", ".delete-pro", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(response => {

            fetch("ShoppingCart/UpdateHeaderCart").then(response => {
                return response.text();
            }).then(data => {
                $("#shop-cart").html(data);
            })

            fetch("ProductDetail/GetBasketCount").then(response => {
                return response.text();
            }).then(data => {
                $("#proCountUp").html(data);
            })

            fetch("ProductDetail/GetBasketCountMob").then(response => {
                return response.text();
            }).then(data => {
                $(".mob-pro-count").html(data);
            })

            return response.text();
        }).then(data => {
            $("#shopcart").html(data);
        })
    });

    $('.input-search').keyup(function () {
        let val = $(this).val().trim();
        if (val.length > 1) {
            $.ajax({
                type: "GET",
                url: "/ProductDetail/SearchPartial?query=" + val,
                success: function (response) {
                    $('.prod-search-list').html("");
                    $('.prod-search-list').html(response);
                }
            })
        }
        else {
            $('.prod-search-list').html("");
        }
    })

    $(document).on("click", ".close-cart", function (e) {
        e.preventDefault();
        $("#shop-cart").css("transform", "translateX(600px)");
        $(".cart-backdrop").removeClass("is-visible");
        $('body').removeClass("body-over-hid");
    })
    $(".cart-open").click(function(e){
        e.preventDefault();
        $("#shop-cart").css("transform","translateX(0)");
        $(".cart-backdrop").addClass("is-visible");
        $('body').addClass("body-over-hid")
    });

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
        function () {
            let mainImg = $(this).parent().parent().parent().prev().children().children().children();
            var bg = $(this).children().children('img').attr('src')
            $(this).siblings().removeClass("dot-active");
            $(this).toggleClass("dot-active");
            mainImg.attr('src', bg);
        },
        function () {
            if ($links.is(".clicked")) {
                $links.removeClass("clicked");
            } else {
                $(this).removeClass("dot-active");
                $(this).siblings().first().addClass("dot-active")
                let mainImg = $(this).parent().parent().parent().prev().children().children().children();
                var bg = $(this).parent().children().first().children().children().attr('src')
                mainImg.attr('src', bg);
            }
        }
    )

    $(".image-ch").click(function () {
        let mainImg = $(this).parent().parent().parent().prev().children().children().children();
        var bg = $(this).children().children().attr('src');
        $(this).siblings().removeClass("dot-active");
        $(this).addClass("dot-active");
        mainImg.attr('src', bg);
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
        $(".active-sort").removeClass("active-sort");
        $(this).children().next().addClass("active-sort");
    })

    $(".sort-radio").click(function(e){
        e.preventDefault();
        $('.sort-radio').children('i').removeClass('active');
        $('.sort-radio').children('input').prop('checked', false);
        $(this).children('i').addClass('active');
        $(this).children('input').prop('checked', true);
    })

    
    $(".search-color").click(function (e) {
        e.preventDefault();
        $('.check-color-s').removeClass('search-inpt-toggle');
        $('.col-inp').prop('checked', false);
        $(this).children().children().children("i").addClass('search-inpt-toggle');
        $(this).children('input').prop('checked', true);
        
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

    $("#RecoverPassword").click(function(){
        $("#CustomerLoginForm").addClass("hide");
        $("#RecoverPasswordForm").removeClass("hide");
    })

    $("#HideRecoverPasswordLink").click(function(){
        $("#CustomerLoginForm").removeClass("hide");
        $("#RecoverPasswordForm").addClass("hide");
    })

    $("#RecoverPasswordAccountPage").click(function(){
        $(".account-content_main").addClass("hide");
        $("#RecoverPasswordFormAccount").removeClass("hide");
    })

    $("#HideRecoverPasswordLinkAccount").click(function(){
        $(".account-content_main").removeClass("hide");
        $("#RecoverPasswordFormAccount").addClass("hide");
    })

    $("#EditAdressShow").click(function(){
        $("#acount-main-info").addClass("hide");
        $("#EditAdress").removeClass("hide");

    })

    $("#hideEditAdress").click(function(){
        $("#acount-main-info").removeClass("hide");
        $("#EditAdress").addClass("hide");
    })

    $("#AcDetails").click(function(){
        $(".account-content_main").removeClass("hide");
        $("#orderHis").addClass("hide");
        $(this).parent().addClass("is-active");
        $(this).parent().siblings().removeClass("is-active");
    })

    $('.pro-quanty').click(function(){
        $('.quant-rot').toggleClass('rotate-180');
    })

    var distance = $('.navbar').offset().top; 

$(window).scroll(function () {
     
     if ($(window).scrollTop() >= 200) {
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

function UpdateCart() {
    var form = $("#refCart");
    var url = form.attr("action");
    fetch(url).then(response => {
		return response.text();
	}).then(data => {
        $("#shop-cart").html(data);
	})
}

function ProCountSee() {
    var form = $("#countRef");
    var url = form.attr("action");
    fetch(url).then(response => {
        return response.text();
    }).then(data => {
        $("#proCountUp").html(data);
    })
}
function ProCountMobSee() {
    var form = $("#countRefMob");
    var url = form.attr("action");
    fetch(url).then(response => {
        return response.text();
    }).then(data => {
        $(".mob-pro-count").html(data);
    })
}
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}
