$(document).ready(function () {
    LoadDataProfessorForStudentHoursOfAttentiontEF();
    LoadDataProfessorStudentConsultationRequests();
});


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
            ReadImageProfessor(ID);
            LoadDataProfessorStudentConsultationRequests();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


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

function UpdateActivityProfessor() {

    var act = null;
    if ($('#activityProfessorModal').val() == "Activo") {
        act = true;
    } else {
        act = false;
    }

    var user = {
        idCard: $('#idCardProfileProfessorModal').val(),
        name: $("#nameProfileProfessorModal").val(),
        email: $("#emailProfileProfessorModal").val(),
        phone: $("#phoneProfileProfessorModal").val(),
        personalFormation: $("#infoProfileProfessorModal").val(),
        instagram: $("#InstagramProfileProfessorModal").val(),
        facebook: $("#FacebookfileProfessorModal").val(),
        activity: act
    };

    $.ajax({
        url: "/Professor/UpdateActivityProfessor",
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

function DeleteProfileProfesor() {
    var user = {
        idCard: $('#idCardProfileProfessorModal').val()
    };
    $.ajax({
        url: "/Professor/DeleteProfessor",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            window.location.href = "";
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
                    '<td><a onclick= GetByIdCardProfessor(' + JSON.stringify(item.idCard) + ')>Consultar</a></td>'
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


function cleanProfessorConsultationHours() {
    document.getElementById('Consultation').value = '';

}

$("#txtFileProfesssor").change(function (event) {
    
    var files = event.target.files;
  
    $("#imgViewer").attr("src", window.URL.createObjectURL(files[0]));
  
});
$("#btnSave").click(function () {

    var files = $("#txtFileProfesssor").prop("files");
    var formData = new FormData();
   
    for (var i = 0; i < files.length; i++) {
        formData.append("file", files[i]);
    }
    var user = {
        
        IdCard: $("#idCardProfileProfessor").val(),
        Name: $("#nameProfileProfessor").val()

    };
  
    formData.append("IdentityUser", JSON.stringify(user));

    $.ajax({
        type: "POST",
        url: "/Professor/SaveFile",
        data: formData,
        processData: false,
        contentType: false,
        success: function (result) {
            ResetFields();
        
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

});



function ReadImageProfessor(ID) {

    $.ajax({
        type: "GET",
        url: "/Professor/GetSavedUser/" + ID,
        success: function (result) {

            $("#imgViewer").attr("src", "data:image/jpg;base64," + result.photo + "");

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function ResetFields() {
    $("imgViewer").attr("src", "");
}

function LoadDataProfessorStudentConsultationRequests() {

    var professorConsultation = {
        idCardProffesor: $('#idCardProfileProfessor').val()
    };

    $.ajax({
        url: "/Professor/GetProfessorConsultations/" + professorConsultation.idCardProffesor,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            $.each(result, function (key, item) {
                var consultId = item.id;
                data = [
                    item.idCardStudent,
                    item.studentName,
                    item.consultationText,
                    '<td><a onclick= AcceptStudentConsult(' + consultId + ')>Aceptar</a> | <a onclick= DenyStudentConsult(' + consultId + ')>Rechazar</a></td>'

                ];
                dataSet.push(data);
            });
            $('#tableProfessorStudentConsultationRequests').DataTable({
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

function AcceptStudentConsult(ID) {
    $.ajax({
        url: "/Professor/AcceptConsult/" + ID,
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataProfessorStudentConsultationRequests();

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });


}

function DenyStudentConsult(ID) {
    $.ajax({
        url: "/Professor/DenyConsult/" + ID,
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataProfessorStudentConsultationRequests();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });


}

