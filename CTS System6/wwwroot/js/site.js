// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var Public_DValue = 1;
var Public_CValue = 1;
var Public_QValue = 1;

//Delivery Scale Rating
$(".rating-D-stars").hover(function () {
    $(".rating-D-stars").addClass("fa-regular").removeClass("fa-solid");
    $(this).addClass("fa-solid").removeClass("fa-regular");
    $(this).prevAll(".rating-D-stars").addClass("fa-solid").removeClass("fa-regular");
});

$(".rating-D-stars").click(function () {
    var DValue = $(this).attr("data-value");
    $("#DSVal").val(DValue);
    Public_DValue = DValue;
});

$(".DScale-Span").mouseleave(function () {
    let starsinside = document.getElementsByClassName("rating-D-stars");
    for (let i = 0; i < starsinside.length; i++) {
        var currentStar = $(starsinside[i]).attr("data-value");
        if (currentStar <= Public_DValue) {

            $(starsinside[i]).addClass("fa-solid").removeClass("fa-regular");
        }
        else {
            $(starsinside[i]).addClass("fa-regular").removeClass("fa-solid");
        }
    }
});

//Communication Scale Rating
$(".rating-C-stars").hover(function () {
    $(".rating-C-stars").addClass("fa-regular").removeClass("fa-solid");
    $(this).addClass("fa-solid").removeClass("fa-regular");
    $(this).prevAll(".rating-C-stars").addClass("fa-solid").removeClass("fa-regular");
});

$(".rating-C-stars").click(function () {
    var CValue = $(this).attr("data-value");
    $("#CSVal").val(CValue);
    Public_CValue = CValue;
});

$(".CScale-Span").mouseleave(function () {
    let starsinside = document.getElementsByClassName("rating-C-stars");
    for (let i = 0; i < starsinside.length; i++) {
        var currentStar = $(starsinside[i]).attr("data-value");
        if (currentStar <= Public_CValue) {

            $(starsinside[i]).addClass("fa-solid").removeClass("fa-regular");
        }
        else {
            $(starsinside[i]).addClass("fa-regular").removeClass("fa-solid");
        }
    }
});

//Quality Scale Rating
$(".rating-Q-stars").hover(function () {
    $(".rating-Q-stars").addClass("fa-regular").removeClass("fa-solid");
    $(this).addClass("fa-solid").removeClass("fa-regular");
    $(this).prevAll(".rating-Q-stars").addClass("fa-solid").removeClass("fa-regular");
});

$(".rating-Q-stars").click(function () {
    var QValue = $(this).attr("data-value");
    $("#QSVal").val(QValue);
    Public_QValue = QValue;
});

$(".QScale-Span").mouseleave(function () {
    let starsinside = document.getElementsByClassName("rating-Q-stars");
    for (let i = 0; i < starsinside.length; i++) {
        var currentStar = $(starsinside[i]).attr("data-value");
        if (currentStar <= Public_QValue) {
            $(starsinside[i]).addClass("fa-solid").removeClass("fa-regular");
        }
        else {
            $(starsinside[i]).addClass("fa-regular").removeClass("fa-solid");
        }
    }
});

function ViewProfile(id) {
    window.location.href = "/ViewUserProfile/Index?userId=" + id;
    //console.log("sucsses");
    //$.ajax({
    //    type:"GET",
    //    url: "/ViewUserProfile/Index",
    //    data: { "userId": id }
    //    });
};