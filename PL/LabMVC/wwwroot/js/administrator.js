$(document).ready(function () {
   
});

function AddProfessor() {

    var professor = {
        idCard: $('#CardProfessor').val(),
        name: $('#nameProfessor').val(),
        lastName: $('#lastNameProfessor').val(),
        email: $('#emailProfessor').val(),
        password: $('#passwordProfessor').val(),
        phone: $('#phoneProfessor').val(),
        address: $('#addressProfessor').val()

    };

    $.ajax({
        url: "/Home/InsertProfessor",
        data: JSON.stringify(professor),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Bien");


        },
        error: function (errorMessage) {

            alert("Mal");
        }
    });


}





function AcceptDenyStudent() {

    var student = {

        idCard: $("#idStudent").val(),
        name: $("#nameStudent").val(),
        lastName: $("#lastNameStudent").val(),
        email: $("#emailStudent").val(),
        Approval: $("#condition").val()
    };

    $.ajax({
        url: "/Home/UpdateApprovalAcceptDeny",
        data: JSON.stringify(student),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            LoadDataAcceptDeny();

        },
        error: function (errorMessage) {


        }
    });


}
