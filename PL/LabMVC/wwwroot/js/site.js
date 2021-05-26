$(document).ready(function () {
    hydeShowSection('about');
    hydeShowSection('adminProfile');
    hydeShowSection('adminAcceptDeny');
    hydeShowSection('adminProfessor');
    hydeShowSection('adminCourses');
    hydeShowSection('adminNews');
    hydeShowSection('updateNewsAdmin');
    hydeShowSection('studentProfile');
    hydeShowSection('studentCourses');
    hydeShowSection('studentHoursOfAttention');
    hydeShowSection('studentNews');
    hydeShowSection('professorProfile');
    hydeShowSection('ConsultationHours');
    hydeShowSection('professorConsultationRequests');
    hydeShowSection('ProfessorNews');
    hydeShowSection('professor');
    hydeShowSection('student');
    hydeShowSection('admin');
    
});

function hydeShowSection(a) {
    var e = document.getElementById(a);
    if (!e) return true;
    if (e.style.display == "none") {
        e.style.display = "block"
    }
    else {
        e.style.display = "none"
    }
    return true;
}


function keepSingleTabForProfile() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
    document.getElementById('updateNewsAdmin').style.display = 'none';
    
}

function keepSingleTabForAcceptDeny() {
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
    document.getElementById('updateNewsAdmin').style.display = 'none';
}

function keepSingleTabForProfessor() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
    document.getElementById('updateNewsAdmin').style.display = 'none';
}

function keepSingleTabForCourses() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
    document.getElementById('updateNewsAdmin').style.display = 'none';
}

function keepSingleTabForNewsAdmin() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('updateNewsAdmin').style.display = 'none';
}
function keepSingleTabForUpdateNews() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
}
//---
function keepSingleTabForstudentProfile() {
    document.getElementById('studentCourses').style.display = 'none';
    document.getElementById('studentHoursOfAttention').style.display = 'none';
    document.getElementById('studentNews').style.display = 'none';
}

function keepSingleTabForstudentCourses() {
    document.getElementById('studentProfile').style.display = 'none';
    document.getElementById('studentHoursOfAttention').style.display = 'none';
    document.getElementById('studentNews').style.display = 'none';
}

function keepSingleTabForstudentHoursOfAttention() {
    document.getElementById('studentCourses').style.display = 'none';
    document.getElementById('studentProfile').style.display = 'none';
    document.getElementById('studentNews').style.display = 'none';
}

function keepSingleTabForstudentNews() {
    document.getElementById('studentCourses').style.display = 'none';
    document.getElementById('studentHoursOfAttention').style.display = 'none';
    document.getElementById('studentProfile').style.display = 'none';
}
//---
function keepSingleTabForProfessorProfile() {
    document.getElementById('ConsultationHours').style.display = 'none';
    document.getElementById('professorConsultationRequests').style.display = 'none'; 
    document.getElementById('ProfessorNews').style.display = 'none'; 
}

function keepSingleTabForProfessorConsultation() {
    document.getElementById('professorProfile').style.display = 'none';
    document.getElementById('professorConsultationRequests').style.display = 'none'; 
    document.getElementById('ProfessorNews').style.display = 'none'; 
}

function keepSingleTabForProfessorConsultationRequests() {
    document.getElementById('professorProfile').style.display = 'none';
    document.getElementById('ConsultationHours').style.display = 'none';  
    document.getElementById('ProfessorNews').style.display = 'none';  
    
}

function keepSingleTabForNews() {
    document.getElementById('professorProfile').style.display = 'none';
    document.getElementById('ConsultationHours').style.display = 'none';
    document.getElementById('professorConsultationRequests').style.display = 'none'; 
}


function ValidateLogin() {

    var user = {
        idCard: $('#IdCardUser').val(),
        password: $('#passwordUser').val()
    };
    var messageValidateLogin = validateUserLogin(user);
    if (messageValidateLogin == "") {
        $.ajax({
            url: "/Login/Validate",
            data: JSON.stringify(user),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            success: function (result) {

                //alert("Hola soy: " + result.rol);

                //window.location.href = "";


                if (result.rol == "Estudiante") {
                    document.getElementById("student").style.display = "block";
                    document.getElementById('GeneralNews').style.display = 'none';
                    GetStudentByIdCardForProfileEF(user.idCard);
                    linkToFacebookStudent(user.idCard);
                    linkToInstagramStudent(user.idCard);
                } else if (result.rol == "Administrador") {
                    document.getElementById("admin").style.display = "block";
                    document.getElementById('GeneralNews').style.display = 'none';
                    GetAdminByIdForProfileCardEF(user.idCard);
                    linkToFacebookAdmin(user.idCard);
                    linkToInstagramAdmin(user.idCard);
                } else if (result.rol == "Profesor") {
                    document.getElementById("professor").style.display = "block";
                    document.getElementById('GeneralNews').style.display = 'none';
                    GetProfessorByIdForProfileCardEF(user.idCard);
                    linkToFacebookProfessor(user.idCard);
                    linkToInstagramProfessor(user.idCard);
                } else {
                    alert("Error INESPERADO");
                }
                cleanLogin();
            },
            error: function (errorMessage) {
                messageValidateLogin = "";
                messageValidateLogin = "El usuario no existe o aún no ha sido aceptado";
                var response = $('#incorrectLabelLogin');
                response.removeClass();
                response.addClass("alert alert-danger register-alert");
                response.fadeIn(1800);
                response.fadeOut(4000);

            }
        });
    } else {
        var response = $('#incorrectLabelLogin');
        response.removeClass();
        response.addClass("alert alert-danger register-alert");
        response.html(messageValidateLogin);
        response.fadeIn(1800);
        response.fadeOut(4000);

    }
}

function validateUserLogin(user) {
    if (user.idCard == "") {
        return "Se requiere carné Institucional";
    } else if (user.password == "") {
        return "Se requiere contraseña";
    } else {
        return "";
    }
}


function cleanLogin() {
    document.getElementById('IdCardUser').value = '';
    document.getElementById('passwordUser').value = '';
}


function logOut() {
    window.location.href = "";
}
