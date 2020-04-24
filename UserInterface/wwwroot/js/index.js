
/// Автозаполнение прогресса скролла страницы
function scrollLoader() {
    var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
    var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    var scrolled = (winScroll / height) * 100;
    document.getElementById("windowBar").style.width = scrolled + "%";
}

/// Исчезнование и появление навбара при скролле
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

/// Показывает прогресс скролла страницы
window.onscroll = function () {
    scrollLoader()
};

/// Предзагрузка страницы
$(window).load(function () {
    $(".se-pre-con").fadeOut("slow");
});

/// Вызов функции при скролле
$(window).scroll(function () {
    navbarScroll();
});

/// Открыть меню
$(".ebs-menu").click(function () {
    $(".ebs-menu-body").animate({ "right":"0" });
    $(".ebs-menu-target").addClass("animated");
    $(".ebs-menu-target").addClass("fadeInRight");
});

/// Закрыть меню
$(".ebs-menu-close").click(function () {
    $(".ebs-menu-body").animate({ "right": "-100%" });
    $(".ebs-menu-target").removeClass("animated");
    $(".ebs-menu-target").removeClass("fadeInRight");
});

/// Сокращение названия файла в форме
$(".custom-file-input").on("change", function () {
    var filename = $(this).val().split("\\").pop();
    $(this).next(".custom-file-label").html(filename);
});

/// Блокировка возможности добавления фотки
$("#RemoveImage").change(function () {
    if (this.checked) {
        $("#Image").attr("disabled", "true");
    } else {
        $("#Image").removeAttr("disabled");
    }
});

scrollLoader();
navbarScroll();

$("#sm-search-button").click(function () {
    $(".ebs-search").slideToggle();
});