$(document).ready(function () {

});

function AddProfessor() {
    var user = {
        idCard: $('#CardProfessor').val(),
        name: $('#nameProfessor').val(),
        lastName: $('#lastNameProfessor').val(),
        email: $('#emailProfessor').val(),
        password: $('#passwordProfessor').val(),
        phone: $('#phoneProfessor').val(),
        address: $('#addressProfessor').val(),
        rol: 'Profesor',
        activity: true,
        approval: 'Aceptado',
        presidency: false
    };
    var messageValidate = validateProfessor(user);
    if (messageValidate == "") {
        $.ajax({
            url: "/Professor/AddProfessor",
            data: JSON.stringify(user),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                cleanProfessor();
                var done = $('#correctLabelAddProfessor');
                done.removeClass();
                done.addClass("alert alert-success register-alert")
                done.fadeIn(1500);
                done.fadeOut(4000);
            },
            error: function (errorMessage) {
                var response = $('#incorrectLabelAddProfessor');
                response.removeClass();
                response.addClass("alert alert-warning register-alert");
                response.html("El usuario ya está registrado");
                response.fadeIn(1500);
                response.fadeOut(4000);
            }
        });

    } else {
        var response = $('#incorrectLabelAddProfessor');
        response.removeClass();
        response.addClass("alert alert-danger register-alert");
        response.html(messageValidate);
        response.fadeIn(1800);
        response.fadeOut(4000);
    }
}

function AcceptDenyStudent() {

    var presi = null;
    if ($('#presidency').val() == 1) {
        presi = true;
    } else if ($('#presidency').val() == -1) {
        presi = -1;
    } else {
        presi = false;
    }

    var user = {
        idCard: $("#idStudent").val(),
        name: $("#nameStudent").val(),
        lastName: $("#lastNameStudent").val(),
        email: $("#emailStudent").val(),
        approval: $("#condition").val(),
        rol: "Estudiante",
        presidency: presi
    };

    $.ajax({
        url: "/Student/UpdateApprovalAcceptDenyStudent",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataAcceptDenyEF();
            $('#modalAcceptDeny').modal('hide');
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
    $('#presidency').val('-1');
}


function GetAdminByIdForProfileCardEF(ID) {
    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var getFullName = result.name + " " + result.lastName;

            $('#nameProfileAdmin').val(getFullName);
            $('#idCardProfileAdmin').val(result.idCard);

            $('#emailProfileAdmin').val(result.email);
            $('#phoneProfileAdmin').val(result.phone);
            $('#infoProfileAdmin').val(result.personalFormation);


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function ObtainAdminProfileInformation() {
    var ID = $('#idCardProfileProfessor').val();
    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",

        success: function (result) {

            $('#idCardProfileAdminModal').val(result.idCard);
            $('#nameProfileAdminModal').val(result.name);
            $('#emailProfileAdminModal').val(result.email);
            $('#phoneProfileAdminModal').val(result.phone);
            $('#infoProfileAdminModal').val(result.personalFormation);

            $('#FacebookfileAdminModal').val(result.facebook);
            $('#InstagramProfileAdminModal').val(result.instagram);

            $('#modalProfileAdmin').modal('show');
            $('#btnUpdateProfileAdmin').show();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function UpdateProfileAdmin() {
    var user = {
        idCard: $('#idCardProfileAdminModal').val(),
        name: $("#nameProfileAdminModal").val(),
        email: $("#emailProfileAdminModal").val(),
        phone: $("#phoneProfileAdminModal").val(),
        personalFormation: $("#infoProfileAdminModal").val(),
        instagram: $("#instagramProfileAdmin").val(),
        facebook: $("#facebookProfileAdmin").val()
    };

    $.ajax({
        url: "/Professor/UpdateProfessor",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {


            $('#modalProfileAdmin').modal('hide');
            GetAdminByIdForProfileCardEF(user.idCard);


        },
        error: function (errorMessage) {

        }
    });

}

function validateProfessor(user) {
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

function cleanProfessor() {
    document.getElementById('CardProfessor').value = '';
    document.getElementById('nameProfessor').value = '';
    document.getElementById('lastNameProfessor').value = '';
    document.getElementById('emailProfessor').value = '';
    document.getElementById('passwordProfessor').value = '';
    document.getElementById('phoneProfessor').value = '';
    document.getElementById('addressProfessor').value = '';

}