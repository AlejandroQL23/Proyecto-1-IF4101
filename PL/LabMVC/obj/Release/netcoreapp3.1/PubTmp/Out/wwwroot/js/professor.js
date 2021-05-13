$(document).ready(function () {

});
function ObtainProfessorProfileInformation() {

    $.ajax({
        //url: "/Home/GetStudentById/",
        //type: "GET",
        contentType: "application/json;charset=UTF-8",
        //dataType: "json",

        success: function (result) {

            $('#nameProfileProfessorModal').val(document.getElementById('nameProfileProfessor').innerHTML);
            $('#emailProfileProfessorModal').val(document.getElementById('emailProfileProfessor').innerHTML);
            $('#phoneProfileProfessorModal').val(document.getElementById('phoneProfileProfessor').innerHTML);
            $('#infoProfileProfessorModal').val(document.getElementById('infoProfileProfessor').innerHTML);

            $('#modalProfileProfessor').modal('show');
            $('#btnUpdateProfileProfessor').show();
            $('#deleteProfileProfessor').show();
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function UpdateProfileProfessor() {
    var user = {
        name: $("#nameProfileProfessorModal").val(),
        email: $("#emailProfileProfessorModal").val(),
        phone: $("#phoneProfileProfessorModal").val(),
        personalFormation: $("#infoProfileProfessorModal").val()
    };

    $.ajax({
        // url: "/Home/UpdateApprovalAcceptDeny",
        //  data: JSON.stringify(user),
        // type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#modalProfileProfessor').modal('hide');


        },
        error: function (errorMessage) {

        }
    });

}


function DeleteProfileProfesor(EMAIL) {
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