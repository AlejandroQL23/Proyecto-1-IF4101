$(document).ready(function () {
    hydeShowSection('about');
    hydeShowSection('adminProfile');
    hydeShowSection('adminAcceptDeny');
    hydeShowSection('adminProfessor');
    hydeShowSection('adminCourses');
    hydeShowSection('adminNews');
    hydeShowSection('studentProfile');
    hydeShowSection('studentCourses');
    hydeShowSection('studentHoursOfAttention');
    hydeShowSection('studentNews');
    hydeShowSection('professorProfile');
    hydeShowSection('ConsultationHours');

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
}

function keepSingleTabForAcceptDeny() {
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
}

function keepSingleTabForProfessor() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
}

function keepSingleTabForCourses() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminNews').style.display = 'none';
}

function keepSingleTabForNews() {
    document.getElementById('adminAcceptDeny').style.display = 'none';
    document.getElementById('adminProfessor').style.display = 'none';
    document.getElementById('adminProfile').style.display = 'none';
    document.getElementById('adminCourses').style.display = 'none';
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
}

function keepSingleTabForProfessorConsultation() {
    document.getElementById('professorProfile').style.display = 'none';
}










function validateUserLogin(user) {
    
    if (user.idCard == "") {
        return "Se requiere Carné Institucional";
    } else if (user.password == "") {
        return "Se requiere coontraseña";
    } else {
        return "";
    }
}


function cleanLogin() {
    document.getElementById('IdCardUser').value = '';
    document.getElementById('passwordUser').value = '';
}


