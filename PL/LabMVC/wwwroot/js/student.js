$(document).ready(function () {
    LoadDataAcceptDeny();
});

function Add() {

    var user = {
        idCard: $('#studentCard').val(),
        name: $('#name').val(),
        lastName: $('#lastName').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        phone: $('#phone').val(),
        address: $('#address').val()

    };

    var messageValidate = validateStudent(user);
    if (messageValidate == "") {


        $.ajax({
            url: "/Home/Insert",
            data: JSON.stringify(user),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                clean();
                LoadDataAcceptDeny();

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

function LoadDataAcceptDeny() {
    $.ajax({
        url: "/Home/GetStudents",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.idCard + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.lastName + '</td>';
                html += '<td>' + item.email + '</td>';
                html += '<td><a onclick= GetStudentByIdCard(' + JSON.stringify(item.idCard) + ')>Estado</a></td>';
            });
            $('.tbodyAcceptDeny').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}


function LoadDataAcceptDeny() {
    $.ajax({
        url: "/Home/GetStudents",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.idCard,
                    item.name,
                    item.lastName,
                    item.email,
                    '<td><a onclick= GetStudentByIdCard(' + JSON.stringify(item.idCard) + ')>Estado</a></td>'
                ];
                dataSet.push(data);
            });
            $('#table').DataTable({
                "searching": true,
                data: dataSet,
                "bDestroy": true
            });

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}


function GetStudentByIdCard(ID) {

    $.ajax({
        url: "/Home/GetStudentById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idStudent').val(result.idCard);
            $('#nameStudent').val(result.name);
            $('#lastNameStudent').val(result.lastName);
            $('#emailStudent').val(result.email);

            $('#modalAcceptDeny').modal('show');
            $('#btnAcceptDeny').show();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
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



function validateStudent(user) {
    var e = user.email + '';
    if (user.idCard == "") {
        return "Se requiere una identificación";
    } else if (user.name == "") {
        return "Se requiere un nombre";
    } else if (user.lastName == "") {
        return "Se requieren apellidos";
    } else if (user.email == "") {
        return "Se requiere un correo electrónico";
    } else if ((user.email + '').includes("@gmail.com") == false) {
        return "El correo debe contener @gmail.com";
    } else if (user.phone == "") {
        return "Se requiere un número de teléfono";
    } else if (user.address == "") {
        return "Se requiere una dirección";
    } else if (user.password == "") {
        return "Se requiere una contraseña";

    } else {
        return "";
    }
}