/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

//show van phong cac mien
$(function () {
    $(".item-miem").bind("click", function () {
        $(".item-miem").each(function () {
            $(this).removeClass("selected");
        });
        $(".mien").each(function () {
            $(this).hide();
        });
        var id = $(this).attr("id");
        $("#div" + id).show();
        $(this).addClass("selected");
    });
});
//hien active thanh cong cu va padding-top130
$(function () {
    $(".trace").bind("click", function () {
        $(".trace").each(function () {
            $(this).removeClass("active-Content");
        });
        $(this).addClass("active-Content");


        if ($(this).attr('id').toString() === "ctt") {
            $("#chuongtrinhtour").addClass("pd-top100");
        } else if ($(this).attr('id').toString() === "ctiettour") {
            $("#chitiettour").addClass("pd-top100");
        } else if ($(this).attr('id').toString() === "ly") {
            $("#luuy").addClass("pd-top100");
        } else if ($(this).attr('id').toString() === "phkh") {
            $("#phanhoikhachhang").addClass("pd-top100");
        } else {
            $("#lienhe").addClass("pd-top100");
        }

    });
});
window.onscroll = function () {
    myFunction();
    showActiveThanhDieuHuong();
};
//thanh dieu huong di chuyen theo khi cuon
function myFunction() {
    var navbar = document.getElementById("nav-top");
    var sticky = navbar.offsetTop;
    var usernav = document.getElementById("user-nav");
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky-content");
        usernav.classList.add("black-color");
    } else {
        navbar.classList.remove("sticky-content");
        usernav.classList.remove("black-color");
    }
}


function offset(el) {
    var rect = el.getBoundingClientRect(),
        scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
        scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    return { top: rect.top + scrollTop, left: rect.left + scrollLeft }
}
//doi mau khi cuon toi noi dung
function showActiveThanhDieuHuong() {
    var LuuYBar = document.getElementById("ly");
    var LuuYContent = document.getElementById("luuy");
    var cttBar = document.getElementById("ctt");
    var cttContent = document.getElementById("chuongtrinhtour");
    var chittBar = document.getElementById("ctiettour");
    var chittContent = document.getElementById("chitiettour");
    var phkhBar = document.getElementById("phkh");
    var phkhContent = document.getElementById("phanhoikhachhang");
    var lheBar = document.getElementById("lhe");
    var lheContent = document.getElementById("lienhe");
    var navbar = document.getElementById("nav-top");
    var luuy = offset(LuuYContent);
    var nav = offset(navbar);
    if (nav.top <= offset(chittContent).top) {
        cttBar.classList.add("active-Content");
    } else {
        cttBar.classList.remove("active-Content");
        $("#chuongtrinhtour").removeClass("pd-top100");
    }
    if (nav.top <= luuy.top && nav.top >= offset(chittContent).top) {
        chittBar.classList.add("active-Content");
    } else {
        chittBar.classList.remove("active-Content");
        $("#chitiettour").removeClass("pd-top100");
    }
    if (nav.top >= luuy.top && nav.top <= offset(phkhContent).top) {
        LuuYBar.classList.add("active-Content");
    } else {
        LuuYBar.classList.remove("active-Content");
        $("#luuy").removeClass("pd-top100");
    }
    if (nav.top >= offset(phkhContent).top && nav.top <= offset(lheContent).top) {
        phkhBar.classList.add("active-Content");
    } else {
        phkhBar.classList.remove("active-Content");
        $("#phanhoikhachhang").removeClass("pd-top100");

    }
    if (nav.top >= offset(lheContent).top) {
        lheBar.classList.add("active-Content");
    } else {
        lheBar.classList.remove("active-Content");
        $("#lienhe").removeClass("pd-top100");
    }




}
// hien tab chi tiet tour
$(function () {
    $(".t").bind("click", function () {
        $(".t").each(function () {
            $(this).removeClass("selected");
        });
        $(".tabContent").each(function () {
            $(this).hide();
        });
        var id = $(this).attr("id");
        $("#t" + id).show();
        $(this).addClass("selected");
    });
}
);
//dem so nguoi tra loi 
window.onload = function () {
    CountTraLoi();
};

function CountTraLoi() {
    var nguoihoi = document.querySelectorAll('.nguoihoi').length;
    var nguoitraloi = document.querySelectorAll('.nguoitraloi').length;
    //console.log(nguoihoi + nguoitraloi);
    document.getElementById("count-ykien").innerHTML = "Ý KIẾN KHÁCH HÀNG " + "(" + (nguoihoi + nguoitraloi) + ")";
}