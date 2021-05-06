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
        address: $('#addressProfessor').val()

    };

    $.ajax({
        url: "/Home/InsertProfessor",
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
        Approval: $("#condition").val()
    };

    $.ajax({
        url: "/Home/UpdateApprovalAcceptDeny",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            LoadDataAcceptDeny();
            $('#modalAcceptDeny').modal('hide');

        },
        error: function (errorMessage) {


        }
    });


}
