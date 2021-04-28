﻿$(document).ready(function () {
    hydeShowSection('about');
    GetStudents();
});


function hydeShowSection(a) {
    var e = document.getElementById(a);
    if (!e) return true;
    if (e.style.display == "none") {
        e.style.display = "block"
    }
    else {
        e.style.display = "none"
    }
    return true;
}

function Add() {

    var student = {
        idCard: $('#studentCard').val(),
        name: $('#name').val(),
        lastName: $('#lastName').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        phone: $('#phone').val(),
        address: $('#address').val()

    };

    var messageValidate = validateStudent(student);
    if (messageValidate == "") {


        $.ajax({
            url: "/Home/Insert",
            data: JSON.stringify(student),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                clean();

                var done = $('#correctLabel');
                done.removeClass();
                done.addClass("alert alert-success register-alert")
                done.fadeIn(1500);
                done.fadeOut(4000);

            },
            error: function (errorMessage) {
                var response = $('#incorrectLabel');
                response.removeClass();
                response.addClass("alert alert-warning register-alert");
                response.html("El usuario ya está registrado");
                response.fadeIn(1500);
                response.fadeOut(4000);

            }
        });
    } else {
        var response = $('#incorrectLabel');
        response.removeClass();
        response.addClass("alert alert-danger register-alert");
        response.html(messageValidate);
        response.fadeIn(1800);
        response.fadeOut(4000);
    }

}

function GetStudents() {

    $.ajax({
        url: "/Home/GetStudents",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            $.each(result, function (key, item) {
                html += '<option value="' + item.idCard + '">' + item.name + '</option>';
            });
            $('#student').append(html);

        },
        error: function (errorMessage) {

            alert(errorMessage.responseText);
        }
    });
}


function clean() {
    document.getElementById('studentCard').value = '';
    document.getElementById('name').value = '';
    document.getElementById('lastName').value = '';
    document.getElementById('email').value = '';
    document.getElementById('password').value = '';
    document.getElementById('phone').value = '';
    document.getElementById('address').value = '';
}

function validateStudent(student) {
    var e = student.email + '';
    if (student.idCard == "") {
        return "Se requiere una identificación";
    } else if (student.name == "") {
        return "Se requiere un nombre";
    } else if (student.lastName == "") {
        return "Se requieren apellidos";
    } else if (student.email == "") {
        return "Se requiere un correo electrónico";
    } else if ((student.email + '').includes("@gmail.com") == false) {
        return "El correo debe contener @gmail.com";
    } else if (student.phone == "") {
        return "Se requiere un número de teléfono";
    } else if (student.address == "") {
        return "Se requiere una dirección";
    } else if (student.password == "") {
        return "Se requiere una contraseña";

    } else {
        return "";
    }
}
