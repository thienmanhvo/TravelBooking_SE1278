
var status = 0;
var usernameGlobal;
$(function () {
    $('body').on('click', '#btnSubmit', function (e) {
        e.preventDefault();
        var listPass = new Array();
        var Adult = parseInt($('#adult').val());
        var Kid = parseInt($('#children').val());
        var Baby = parseInt($('#baby').val());
        var TotalMoney = parseFloat($('#TotalPrice').val());
        var DateCreate = new Date();
        var Note = $('#note').val();
        var Phone = $('#mobilephone').val();
        var Address = $('#address').val();
        var Name = $('#contact_name').val();
        var TourID = $('#tourID').text();
        var Birthday = $('#birthday').val();
        var Email = $('#email').val();

        var username = $(this).attr('data-username');
        if (Name.length == 0) {
            alert("Xin quý khách hãy nhập thông tin chính xác.");
            document.getElementById("contact_name").focus();
            return;
        }
        else if (Phone.length == 0) {
            alert("Xin quý khách hãy nhập thông tin chính xác.");
            document.getElementById("mobilephone").focus();
            return;
        }
        else if (Email.length == 0) {
            alert("Xin quý khách hãy nhập thông tin chính xác.");
            document.getElementById("email").focus();
            return;
        } else {
            var Booking = {
                TotalMoney: TotalMoney,
                DateCreate: DateCreate,
                Username: username,
                NumOfKid: Kid,
                NumOfAdult: Adult,
                NumOfBaby: Baby,
                Note: Note,
                Phone: Phone,
                Address: Address,
                Name: Name,
                TourID: TourID,
                Birthday: Birthday,
                Email: Email
            };
            for (var i = 0; i < Adult; i++) {
                var name = "[" + i + "]" + "fullnameAdult";
                var gender = "[" + i + "]" + "genderAdult";
                var dob = "dobAdult+" + i;
                var type = "adult+" + i;
                var mess = 'messageDOBAdult+' + i;
                if (document.getElementById(name).value.length == 0) {
                    alert("Xin quý khách hãy nhập thông tin chính xác.");
                    document.getElementById(name).focus();
                    return;
                } else {
                    if (document.getElementById(dob).value.length == 0) {
                        alert("Xin quý khách hãy nhập thông tin chính xác.");
                        document.getElementById(dob).focus();
                        return;
                    } else {
                        if ($(document.getElementById(mess)).is(":visible")) {
                            alert("Xin quý khách hãy nhập thông tin chính xác.");
                            document.getElementById(mess).focus();
                            return;
                        } else {
                            var boolgen = parseInt($(document.getElementById(gender)).children("option:selected").val());
                            var genderBool = Boolean(boolgen);
                            var passenger = {
                                Fullname: document.getElementById(name).value,
                                Gender: genderBool,
                                Birthday: document.getElementById(dob).value,
                                Type: document.getElementById(type).value,
                            }
                            listPass.push(passenger);
                        }
                    }

                }
            }
            for (var i = 0; i < Kid; i++) {
                var name = "[" + i + "]" + "fullnameKid";
                var gender = "[" + i + "]" + "genderKid";
                var dob = "dobKid+" + i;
                var type = "kid+" + i;
                var mess = 'messageDOBKid+' + i;
                if (document.getElementById(name).value.length == 0) {
                    alert("Xin quý khách hãy nhập thông tin chính xác.");
                    document.getElementById(name).focus();
                    return;
                } else {
                    if (document.getElementById(dob).value.length == 0) {
                        alert("Xin quý khách hãy nhập thông tin chính xác.");
                        document.getElementById(dob).focus();
                        return;
                    } else {
                        if ($(document.getElementById(mess)).is(":visible")) {
                            alert("Xin quý khách hãy nhập thông tin chính xác.");
                            document.getElementById(mess).focus();
                            return;
                        } else {
                            var boolgen = parseInt($(document.getElementById(gender)).children("option:selected").val());
                            var genderBool = Boolean(boolgen);
                            var passenger = {
                                Fullname: document.getElementById(name).value,
                                Gender: genderBool,
                                Birthday: document.getElementById(dob).value,
                                Type: document.getElementById(type).value,
                            }
                            listPass.push(passenger);
                        }
                    }
                }
            }
            for (var i = 0; i < Baby; i++) {
                var name = "[" + i + "]" + "fullnameBaby";
                var gender = "[" + i + "]" + "genderBaby";
                var dob = "dobBaby+" + i;
                var type = "baby+" + i;
                var mess = 'messageDOBBaby+' + i;
                if (document.getElementById(name).value.length == 0) {
                    alert("Xin quý khách hãy nhập thông tin chính xác.");
                    document.getElementById(name).focus();
                    return;
                } else {
                    if (document.getElementById(dob).value.length == 0) {
                        alert("Xin quý khách hãy nhập thông tin chính xác.");
                        document.getElementById(dob).focus();
                        return;
                    } else {
                        if ($(document.getElementById(mess)).is(":visible")) {
                            alert("Xin quý khách hãy nhập thông tin chính xác.");
                            document.getElementById(mess).focus();
                            return;
                        } else {
                            var boolgen = parseInt($(document.getElementById(gender)).children("option:selected").val());
                            var genderBool = Boolean(boolgen);
                            var passenger = {
                                Fullname: document.getElementById(name).value,
                                Gender: genderBool,
                                Birthday: document.getElementById(dob).value,
                                Type: document.getElementById(type).value,
                            }
                            listPass.push(passenger);
                        }
                    }
                }
            }
            $.ajax({
                url: '/Booking/CheckOut',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: JSON.stringify({ Booking: Booking, tbl_Passenger: listPass }),
                success: function (result) {
                    if (result.status == true) {
                        status = 1;
                        usernameGlobal = username;
                        alert("Đăng ký thành công");
                        window.location.reload();
                    } else {
                        status = 0;
                        alert('Đăng ký tour thất bại.');
                    }
                },
                error: function () {
                    status = 0;
                    alert('Đăng ký tour thất bại.');
                }
            })
        }
    });
});

//$(document).ajaxComplete(function () {
    
//});