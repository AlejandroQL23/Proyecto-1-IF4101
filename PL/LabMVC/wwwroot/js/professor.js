$(document).ready(function () {
    LoadDataProfessorForStudentHoursOfAttentiontEF();
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
            linkToFacebookProfessor(ID);
            linkToInstagramProfessor(ID);

           


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
            $('#disableAccountProfessor').show();
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
        instagram: $("#InstagramProfileProfessorModal").val(),
        facebook: $("#FacebookfileProfessorModal").val()
    };

    $.ajax({
        url: "/Professor/UpdateProfessor",
         data: JSON.stringify(user),
         type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

          
            $('#modalProfileProfessor').modal('hide');
            GetProfessorByIdForProfileCardEF(user.idCard);


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


function linkToFacebookProfessor(ID) {
   
    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var link = result.facebook;
            $('#facebookProfileProfessor').attr('href', link);



        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;


}

function linkToInstagramProfessor(ID) {

    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var link = result.instagram;
            $('#instagramProfileProfessor').attr('href', link);



        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;


}


function saveConsultationHours() {
    var user = {
        idCard: $('#idCardProfileProfessor').val(),
        dateTime: $('#Consultation').val()
    };
    $.ajax({
        url: "/Professor/AddDateTimeProfessor",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            cleanProfessorConsultationHours();
            var done = $('#correctLabelAddConsultationHours');
            done.removeClass();
            done.addClass("alert alert-success register-alert")
            done.fadeIn(1500);
            done.fadeOut(4000);
        },
        error: function (errorMessage) {
            var response = $('#incorrectLabelAddConsultationHours');
            response.removeClass();
            response.addClass("alert alert-warning register-alert");
            response.html("El usuario ya está registrado");
            response.fadeIn(1500);
            response.fadeOut(4000);
        }
    });
}


//---------MODAL DE ESTUDIANTE PARA CONSULTA DE PROFESOR
function LoadDataProfessorForStudentHoursOfAttentiontEF() {
    $.ajax({
        url: "/Professor/GetProfessor",
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
                    item.dateTime,
                    '<td><a onclick= GetByIdCardProfessor(' + JSON.stringify(item.idCard) + ')>Consultar</a></td>' //cambiar
                ];
                dataSet.push(data);
            });
            $('#tableProfessorInformationForStudent').DataTable({
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

function GetByIdCardProfessor(ID) {



    $.ajax({
        url: "/Professor/GetProfessorById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idCardForProfessorModal').val(result.idCard);
            $('#nameProfessorForStudentModal').val(result.name);
            $('#emailProfessorForStudentModal').val(result.email);
            $('#modalStudentProfessor').modal('show');
            $('#btnSendConsult').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//---------MODAL DE ESTUDIANTE PARA CONSULTA DE PROFESOR

function cleanProfessorConsultationHours() {
    document.getElementById('Consultation').value = '';

}