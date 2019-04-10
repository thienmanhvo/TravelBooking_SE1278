
$(function () {
    $('#dangnhap').on('keypress', function (e) {
        if (e.which == 13) {
            e.preventDefault();
            var userName = $('#usernameLogin').val();
            var pass = $('#PasswordLogin').val();
            if (userName.length == 0 || pass == 0) {
                $("#message").show().text("Hãy nhập username và password.");
                return;
            }

            $.ajax({
                url: '/User/Login',
                type: 'POST',
                data: {
                    userName: userName,
                    password: pass,

                },
                //dataType: "json",
                success: function (result) {
                    if (result.status == true) {
                        if (window.location.href.search("/Tour/Details/") != -1 || window.location.href.search("/Booking/Index/") != -1 ) {
                            window.location.reload();
                        } else {
                            $("#message").hide();
                            $("#dangnhap").modal("hide");
                            setTimeout(function () {
                                $("#nav-Login").html(result.NavLoginSuccess);
                                $("#content-login").html(result.ContentLoginSuccess);
                            }, 500);
                        }
                    } else {
                        $("#message").show().text("Tên tài khoản hoặc mật khẩu không đúng.");
                    }

                },
                error: function () {
                    alert('Error loading profile data');
                }
            })
        }
    });
});

$(function () {
    $('body').on('click', '#btn-dangnhap', function (e) {

        e.preventDefault();
        var userName = $('#usernameLogin').val();
        var pass = $('#PasswordLogin').val();
        //$("#message").show().text("Logging in...");
        if (userName.length == 0 || pass == 0) {
            $("#message").show().text("Hãy nhập username và password.");
            return;
        }
        $.ajax({
            url: '/User/Login',
            type: 'POST',
            data: {
                userName: userName,
                password: pass,
            },
            //dataType: "json",
            success: function (result) {

                if (result.status == true) {
                    if (window.location.href.search("/Tour/Details/") != -1 || window.location.href.search("/Booking/Index/") != -1 ) {
                        window.location.reload();
                    } else {
                        $("#message").hide();
                        $("#dangnhap").modal("hide");
                        setTimeout(function () {
                            $("#nav-Login").html(result.NavLoginSuccess);
                            $("#content-login").html(result.ContentLoginSuccess);
                        }, 500);
                    }
                } else {
                    $("#message").show().text("Tên tài khoản hoặc mật khẩu không đúng.");
                }

            },
            error: function () {
                alert('Error loading profile data');
            }
        })
    });
});
$(function () {
    $('body').on('click', '#dangxuat', function (e) {
        e.preventDefault();
        //var userName = $('#usernameLogin').val();
        //var pass = $('#PasswordLogin').val();

        $.ajax({
            url: '/User/Logout',
            type: 'POST',
            data: {

            },
            //dataType: "json",
            success: function (result) {
                if (result.status == true) {
                    //$('#profile-img').attr('src', data.imageString);
                    //$('#profile-full-name').html(data.fullname);
                    if (window.location.href.search("/Tour/Details/") != -1 || window.location.href.search("/Booking/Index/") != -1 || window.location.href.search("/Booking/Details?username") != -1 || window.location.href.search("/Booking/DisplayPassenger/") ) {
                        window.location.reload();
                    } else {
                        $("#nav-Login").html(result.NavLogout);
                        $("#content-login").html(result.ContentLogout);
                        alert("success");
                    }                 
                } else {
                    alert('Error loading profile data');
                }
            },
            error: function () {
                alert('Error loading profile data');
            }
        })

    });
});

var ck_email = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
var ck_password = /^[A-Za-z0-9!@#$%^&8()_]{6,20}$/;
var ck_name = /[A-Za-z0-9 ]{1,20}$/;
var ck_username = /[A-Za-z0-9 ]{6,20}$/;
function validateRes(e) {
    var username = document.getElementById("usernameRegister").value;
    var password = document.getElementById("PasswordRegister").value;
    var rePassword = document.getElementById("RePasswordRegister").value;
    var ho = document.getElementById("lastName").value;
    var ten = document.getElementById("firstName").value;
    var count = 0;
    if (username === null || username === "" || password === null || password === "" || ho === null || ho === "" || ten === null || ten === "" || rePassword === null || rePassword === "") {
        //			document.write("Không được để trống");
        $("#outputBlank").show().text("Tên tài khoản , Mật khẩu, Họ và Tên không được để trống.");
        count++;
        return false;
    } else {
        $("#outputBlank").hide()
        if (!ck_username.test(username)) {
            $("#outputUsername").show().text("Username từ 6 đến 20 ký tự");
            count++;
            return false;
        } else {
            $("#outputUsername").hide();
        }
        if (!ck_password.test(password)) {
            $("#outputPass").show().text("Password phải từ 6 đến 20 ký tự");
            count++;
            return false;
        } else {
            $("#outputPass").hide();
        }
        if (rePassword !== password) {
            $("#outputPassRe").show().text("Mật khẩu và Mật khẩu nhập lại không khớp");
            count++;
            return false;
        } else {
            $("#outputPassRe").hide();
        }
        //			fname.value.length==0


        if (!ck_name.test(ten)) {
            $("#outputLastName").show().text("Họ không được chứa ký tự đặc biệt");
            count++;
            return false;
        } else {
            $("#outputLastName").hide();
        }
        if (!ck_name.test(ho)) {
            $("#outputName").show().text("Tên không được chứa ký tự đặc biệt");
            count++;
            return false;
        } else {
            $("#outputName").hide();
        }
    }
    if (count > 0) {
        $("#outputFailed").show().text("Tạo tài khoản thất bại");
    } else {
        $("#outputFailed").hide();
        return true;
    }
}