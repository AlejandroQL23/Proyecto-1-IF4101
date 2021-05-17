$(document).ready(function () {

});




//---------------------------------------

function GetProfessorByIdForProfileCardEF(ID) {
    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var getFullName = result.name + " " + result.lastName;

            $('#nameProfileProfessor').val(getFullName);
            $('#idCardProfileProfessor').val(result.idCard);

            $('#emailProfileProfessor').val(result.email);
            $('#phoneProfileProfessor').val(result.phone);
            $('#infoProfileProfessor').val(result.personalFormation);


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//-------------------------------------





function ObtainProfessorProfileInformation() {
   var ID = $('#idCardProfileProfessor').val();
    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",

        success: function (result) {

            $('#idCardProfileProfessorModal').val(result.idCard);
            $('#nameProfileProfessorModal').val(result.name);
            $('#emailProfileProfessorModal').val(result.email);
            $('#phoneProfileProfessorModal').val(result.phone);
            $('#infoProfileProfessorModal').val(result.personalFormation);

            $('#FacebookfileProfessorModal').val(result.facebook);
           $('#InstagramProfileProfessorModal').val(result.instagram);

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
        idCard: $('#idCardProfileProfessorModal').val(),
        name: $("#nameProfileProfessorModal").val(),
        email: $("#emailProfileProfessorModal").val(),
        phone: $("#phoneProfileProfessorModal").val(),
        personalFormation: $("#infoProfileProfessorModal").val(),
        instagram: $("#instagramProfileProfessor").val(),
        facebook: $("#facebookProfileProfessor").val()
    };

    $.ajax({
        url: "/Professor/UpdateProfessor",
         data: JSON.stringify(user),
         type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

          
            $('#modalProfileProfessor').modal('hide');
            GetStudentByIdForProfileCardEF(user.idCard);


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