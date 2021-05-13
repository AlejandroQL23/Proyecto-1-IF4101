﻿$(document).ready(function () {
    LoadDataAcceptDenyEF();
});

function AddEF() {
    var user = {
        idCard: $('#studentCard').val(),
        name: $('#name').val(),
        lastName: $('#lastName').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        phone: $('#phone').val(),
        address: $('#address').val(),
        rol: 'Estudiante',
        activity: false,
        approval: 'En Espera',
        presidency: false
    };

    var messageValidate = validateStudent(user);
    if (messageValidate == "") {
        $.ajax({
            url: "/Student/AddStudent",
            data: JSON.stringify(user),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                clean();
                LoadDataAcceptDenyEF();
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

function LoadDataAcceptDenyEF() {
    $.ajax({
        url: "/Student/GetWaitingStudents",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.idCard,
                    item.name,
                    item.lastName,
                    item.email,
                    '<td><a onclick= GetStudentByIdCardEF(' + JSON.stringify(item.idCard) + ')>Estado</a></td>'
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



function GetStudentByIdCardEF(ID) {
    $.ajax({
        url: "/Student/GetStudentById/" + ID,
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


function ObtainStudentProfileInformation() {

    $.ajax({
        //url: "/Home/GetStudentById/",
        //type: "GET",
        contentType: "application/json;charset=UTF-8",
        //dataType: "json",

        success: function (result) {

            $('#nameProfilePStudentModal').val(document.getElementById('nameProfileStudent').innerHTML);
            $('#emailProfileStudentModal').val(document.getElementById('emailProfileStudent').innerHTML);
            $('#phoneProfileStudentModal').val(document.getElementById('phoneProfileStudent').innerHTML);
            $('#infoProfileStudentModal').val(document.getElementById('infoProfileStudent').innerHTML);

            $('#modalProfileStudent').modal('show');
            $('#btnUpdateProfileStudent').show();
            $('#deleteProfileStudent').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function UpdateProfileStudent() {
    var user = {
        name: $("#nameProfilePStudentModal").val(),
        email: $("#emailProfileStudentModal").val(),
        phone: $("#phoneProfileStudentModal").val(),
        personalFormation: $("#infoProfileStudentModal").val()
    };

    $.ajax({
        // url: "/Home/UpdateApprovalAcceptDeny",
        //  data: JSON.stringify(user),
        // type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#modalProfileStudent').modal('hide');


        },
        error: function (errorMessage) {

        }
    });

}


function DeleteProfileStudent(EMAIL) {
    $.ajax({
        // url: "/Home/DeleteCourse/" + EMAIL,
        // type: "POST",
        contentType: "application/json;charset=UTF-8",
        // dataType: "json",
        success: function (result) {
            //cargar la dat en el perfil de neuvo
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
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