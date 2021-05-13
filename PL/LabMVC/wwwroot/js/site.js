$(document).ready(function () {
    hydeShowSection('about');
    hydeShowSection('adminProfile');
    hydeShowSection('adminAcceptDeny');
    hydeShowSection('adminProfessor');
    hydeShowSection('adminCourses');
    hydeShowSection('studentProfile');
    hydeShowSection('studentCourses');
    hydeShowSection('studentHoursOfAttention');
    hydeShowSection('studentNews');
    hydeShowSection('professorProfile');
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
}

function keepSingleTabForAcceptDeny() {
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
}

function keepSingleTabForProfessor() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
}

function keepSingleTabForCourses() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
}

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

function ValidateLogin() {

    var user = {
        idCard: $('#IdCardUser').val(),
        password: $('#passwordUser').val()
    };

    var messageValidateLogin = validateUserLogin(user);
    if (messageValidateLogin == "") {
        $.ajax({
            url: "/User/Index",
            data: JSON.stringify(user),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                cleanLogin();
                LoadDataAcceptDenyEF();
                var done = $('#correctLabelLogin');
                done.removeClass();
                done.addClass("alert alert-success register-alert")
                done.fadeIn(1500);
                done.fadeOut(4000);
            },
            error: function (errorMessage) {
                var response = $('#incorrectLabelLogin');
                response.removeClass();
                response.addClass("alert alert-warning register-alert");
                response.html("No existe un usuario con esas credenciales");
                response.fadeIn(1500);
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


//--------------------------------------------------------
function validateUserLogin(user) {
    
    if (user.idCard == "") {
        return "Se requiere Carné Institucional";
    } else if (user.password == "") {
        return "Se requiere coontraseña";
    } else {
        return "";
    }
}

//--------------------------------------------------------
function cleanLogin() {
    document.getElementById('IdCardUser').value = '';
    document.getElementById('passwordUser').value = '';
}

//--------------------------------------------------------