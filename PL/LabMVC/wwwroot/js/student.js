$(document).ready(function () {
    LoadDataAcceptDenyStudent();
    LoadDataToForumCourse();
});

function AddStudent() {
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
                LoadDataAcceptDenyStudent();
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

function LoadDataAcceptDenyStudent() {
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
                    '<td><a onclick= GetStudentByIdCard(' + JSON.stringify(item.idCard) + ')>Gestionar</a></td>'
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


function GetStudentByIdCardForProfile(ID) {
    $.ajax({
        url: "/Student/GetStudentById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var getFullName = result.name + " " + result.lastName;

            $('#nameProfileStudent').val(getFullName);
            $('#idCardProfileStudent').val(result.idCard);

            $('#emailProfileStudent').val(result.email);
            $('#phoneProfileStudent').val(result.phone);
            $('#infoProfileStudent').val(result.personalFormation);
            linkToFacebookStudent(ID);
            linkToInstagramStudent(ID);
            ReadImageStudent(ID);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function ObtainStudentProfileInformation() {
    var ID = $('#idCardProfileStudent').val();
    $.ajax({
        url: "/Student/GetStudentById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",

        success: function (result) {
            $('#idCardProfilePStudentModal').val(result.idCard);
            $('#nameProfilePStudentModal').val(result.name);
            $('#emailProfileStudentModal').val(result.email);
            $('#phoneProfileStudentModal').val(result.phone);
            $('#infoProfileStudentModal').val(result.personalFormation);
            $('#facebookProfilePStudentModal').val(result.facebook);
            $('#instagramProfilePStudentModal').val(result.instagram);
            $('#modalProfileStudent').modal('show');
            $('#btnUpdateProfileStudent').show();
            $('#disableAccountStudent').show();
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
        idCard: $('#idCardProfilePStudentModal').val(),
        name: $("#nameProfilePStudentModal").val(),
        email: $("#emailProfileStudentModal").val(),
        phone: $("#phoneProfileStudentModal").val(),
        personalFormation: $("#infoProfileStudentModal").val(),
        instagram: $("#instagramProfilePStudentModal").val(),
        facebook: $("#facebookProfilePStudentModal").val()
    };

    $.ajax({
        url: "/Student/UpdateStudent",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#modalProfileStudent').modal('hide');
            GetStudentByIdCardForProfile(user.idCard);

        },
        error: function (errorMessage) {

        }
    });

}


function UpdateActivityStudent() {

    var act = null;
    if ($('#activityStudentModal').val() == "Activo") {
        act = true;
    } else {
        act = false;
    }

    var user = {
        idCard: $('#idCardProfilePStudentModal').val(),
        name: $("#nameProfilePStudentModal").val(),
        email: $("#emailProfileStudentModal").val(),
        phone: $("#phoneProfileStudentModal").val(),
        personalFormation: $("#infoProfileStudentModal").val(),
        instagram: $("#instagramProfilePStudentModal").val(),
        facebook: $("#facebookProfilePStudentModal").val(),
        activity: act
    };

    $.ajax({
        url: "/Student/UpdateActivityStudent",
        data: JSON.stringify(user),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#modalProfileStudent').modal('hide');
            GetStudentByIdCardForProfile(user.idCard);

        },
        error: function (errorMessage) {

        }
    });

}


function DeleteProfileStudent() {
    var user = {
        idCard: $('#idCardProfilePStudentModal').val()
    };
    $.ajax({
        url: "/Student/DeleteStudent",
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


function linkToFacebookStudent(ID) {

    $.ajax({
        url: "/Student/GetStudentById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var link = result.facebook;
            $('#facebookProfileStudent').attr('href', link);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;


}

function linkToInstagramStudent(ID) {

    $.ajax({
        url: "/Student/GetStudentById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var link = result.instagram;
            $('#instagramProfileStudent').attr('href', link);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function addCommentToForum() {

    var forumComment = {
        CourseInitials: $('#initialsForCourseModal').val(),
        Author: $('#nameProfileStudent').val(),
        TextContent: $('#consultationAreaForCourse').val()
    };

    $.ajax({
        url: "/ForumComment/AddForumComment",
        data: JSON.stringify(forumComment),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#modalStudentCourse').modal('hide');
            LoadDataToForumCourse();
        },
        error: function (errorMessage) {

        }
    });
    document.getElementById('consultationAreaForCourse').value = '';
}


function LoadDataToForumCourse() {
    $.ajax({
        url: "/ForumComment/GetForum",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.id,
                    item.courseInitials,
                    item.author,
                    item.textContent,
                    item.creationDate,
                    '<td><a onclick= modalToAnswerComment(' + JSON.stringify(item.id) + ')>Comentar</a></td>'
                ];
                dataSet.push(data);
            });
            $('#tableForum').DataTable({
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

function AddQuestionProfessor() {
    var ProfessorConsultation = {
        IdCardProffesor: $('#idCardForProfessorModal').val(),
        IdCardStudent: $('#idCardProfileStudent').val(),
        StudentName: $('#nameProfileStudent').val(),
        ConsultationText: $('#consultationAreaForProfessor').val()
    };

    $.ajax({
        url: "/Student/SendConsult",
        data: JSON.stringify(ProfessorConsultation),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#modalStudentProfessor').modal('hide');
            var done = $('#correctLabelSendConsult');
            done.removeClass();
            done.addClass("alert alert-success register-alert")
            done.fadeIn(1500);
            done.fadeOut(4000);
        },
        error: function (errorMessage) {
            $('#modalStudentProfessor').modal('hide');
            var response = $('#incorrectLabelSendConsult');
            response.removeClass();
            response.addClass("alert alert-warning register-alert");
            response.fadeIn(1500);
            response.fadeOut(4000);
        }
    });
    document.getElementById('consultationAreaForProfessor').value = '';
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
    } else if ((user.email + '').includes("@") == false) {
        return "El correo debe contener @";
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

$("#txtFileStudent").change(function (event) {

    var files = event.target.files;

    $("#imgViewerStudentProfile").attr("src", window.URL.createObjectURL(files[0]));

});
$("#btnSaveStudent").click(function () {

    var files = $("#txtFileStudent").prop("files");
    var formData = new FormData();

    for (var i = 0; i < files.length; i++) {
        formData.append("file", files[i]);
    }
    var user = {

        IdCard: $("#idCardProfileStudent").val(),
        Name: $("#nameProfileStudent").val()

    };

    formData.append("IdentityUser", JSON.stringify(user));

    $.ajax({
        type: "POST",
        url: "/Student/SaveStudentPhoto",
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


function ReadImageStudent(ID) {

    $.ajax({
        type: "GET",
        url: "/Student/GetSavedStudentPhoto/" + ID,
        success: function (result) {

            $("#imgViewerStudentProfile").attr("src", "data:image/jpg;base64," + result.photo + "");
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function ResetFields() {
    $("imgViewerStudentProfile").attr("src", "");
}


function modalToAnswerComment(ID) {
    $.ajax({

        url: "/ForumComment/GetForumById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            $('#idForAnswerModal').val(result.id);
            $('#modalCoursesComments').modal('show');
            $('#btnSendCommentToForum').show();
            var ID = $('#idForAnswerModal').val();
            LoadDataAnswerComments(ID);
        },
        error: function (errormessage) {
            alert("Error");
            alert(errormessage.responseText);
        }
    });
    return false;
}


function LoadDataAnswerComments(ID) {
    $.ajax({
        url: "/ForumComment/GetForumAnswer/" + ID,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            dataSet = new Array();
            $.each(result, function (key, item) {

                data = [
                    item.author,
                    item.textContent
                ];
                dataSet.push(data);

            });

            $('#tableStudentNewsCommentsAnswerModal').DataTable({
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

function AddCommentAnswer() {
    var forumCommentAnswer = {
        Author: $('#nameProfileStudent').val(),
        IdComment: parseInt($('#idForAnswerModal').val()),
        TextContent: $('#addCommentsInForum').val()
    };
    $.ajax({
        url: "/ForumComment/AddForumCommentAnswer",
        data: JSON.stringify(forumCommentAnswer),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#modalCoursesComments').modal('hide');
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}
