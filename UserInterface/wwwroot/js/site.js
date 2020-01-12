window.onscroll = function () { scrollLoader() };

function scrollLoader() {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
    var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    var scrolled = (winScroll / height) * 100;
    document.getElementById("windowBar").style.width = scrolled + "%";
}

function navbarScroll() {
    if ($(document).scrollTop() > 20) {
        $(".ebs-navbar").css('background', '#3b4368');
        $(".ebs-menu").css('color', 'white');
        $(".ebs-title").css('color', 'white');
    } if ($(document).scrollTop() < 20) {
        $(".ebs-navbar").css('background', 'none');
        $(".ebs-menu").css('color', '#343A40');
        $(".ebs-title").css('color', '#343A40');
    }
}

$(window).load(function () { $(".se-pre-con").fadeOut("slow"); });
$(window).scroll(function () { navbarScroll(); });

scrollLoader();
navbarScroll();

$(".ebs-menu").click(function () {
    $(".ebs-menu-body").animate({
        "right":"0"
    });
    $(".ebs-menu-target").addClass("animated");
    $(".ebs-menu-target").addClass("fadeInRight");
});

$(".ebs-menu-close").click(function () {
    $(".ebs-menu-body").animate({
        "right": "-100%"
    });
    $(".ebs-menu-target").removeClass("animated");
    $(".ebs-menu-target").removeClass("fadeInRight");
});