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

    $.ajax({
        url: "/Professor/AddProfessor",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

        },
        error: function (errorMessage) {

        }
    });
}

function AcceptDenyStudent() {
    var user = {
        idCard: $("#idStudent").val(),
        name: $("#nameStudent").val(),
        lastName: $("#lastNameStudent").val(),
        email: $("#emailStudent").val(),
        approval: $("#condition").val(),
        rol: "Estudiante"
        
    };

    $.ajax({
        url: "/Student/UpdateApprovalAcceptDenyStudent",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("bien");
            LoadDataAcceptDenyEF();
            $('#modalAcceptDeny').modal('hide');
        },
        error: function (errorMessage) {
            alert("mal");
        }
    });

}

function ObtainAdminProfileInformation() {

    $.ajax({
        //url: "/Home/GetStudentById/",
        //type: "GET",
        contentType: "application/json;charset=UTF-8",
        //dataType: "json",

        success: function (result) {

            $('#nameProfileAdminModal').val(document.getElementById('nameProfileAdmin').innerHTML);
            $('#emailProfileAdminModal').val(document.getElementById('emailProfileAdmin').innerHTML);
            $('#phoneProfileAdminModal').val(document.getElementById('phoneProfileAdmin').innerHTML);
            $('#infoProfileAdminModal').val(document.getElementById('infoProfileAdmin').innerHTML);

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
        name: $("#nameProfileAdminModal").val(),
        email: $("#emailProfileAdminModal").val(),
        phone: $("#infoProfileAdminModal").val(),
        personalFormation: $("#infoProfileAdminModal").val()
    };

    $.ajax({
        // url: "/Home/UpdateApprovalAcceptDeny",
        //  data: JSON.stringify(user),
        // type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#modalProfileAdmin').modal('hide');


        },
        error: function (errorMessage) {

        }
    });

}