$(document).ready(function () {
    LoadDataCourses();
    LoadDataToCourseStudent();
});

function AddCourse() {
    var activityBoolean = null;
    if ($('#conditionCourse').val()==1) {
        activityBoolean = true;
    }else if ($('#conditionCourse').val() == -1) {
        activityBoolean = -1;
    }else {
        activityBoolean = false;
    }

    var course = {
        initials: $('#acronymCourse').val(),
        name: $('#nameCourses').val(),
        credits: parseInt($('#creditsCourse').val()),
        semester: $('#semester').val(),
        scheduleId: $('#scheduleCourse').val(),
        activity: activityBoolean
    };

    var messageValidate = validateCourse(course);
    if (messageValidate == "") {
        $.ajax({
            url: "/Course/AddCourse",
            data: JSON.stringify(course),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                cleanCourseSpace();
                LoadDataCourses();
                LoadDataToCourseStudent();
                var done = $('#correctLabelCourse');
                done.removeClass();
                done.addClass("alert alert-success register-alert")
                done.fadeIn(1500);
                done.fadeOut(4000);
            },
            error: function (errorMessage) {
                var response = $('#incorrectLabelCourse');
                response.removeClass();
                response.addClass("alert alert-warning register-alert");
                response.html("El curso ya está registrado");
                response.fadeIn(1500);
                response.fadeOut(4000);
            }
        });
    } else {
        var response = $('#incorrectLabelCourse');
        response.removeClass();
        response.addClass("alert alert-danger register-alert");
        response.html(messageValidate);
        response.fadeIn(1800);
        response.fadeOut(4000);
    }
}

function LoadDataCourses() {
    $.ajax({
        url: "/Course/GetCourses",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            var activity = '';
            $.each(result, function (key, item) {
                activity = item.activity == 0 ? '<td>' + "Inactivo" + '</td>' : '<td>' + "Activo" + '</td>';
                data = [
                    item.initials,
                    item.name,
                    item.credits,
                    item.semester,
                    activity,
                    '<td><a onclick= GetByInitials(' + JSON.stringify(item.initials) + ')>Actualizar</a> | <a onclick= DeleteCourse(' + JSON.stringify(item.initials) + ')>Eliminar</a></td>'
                ];
                dataSet.push(data);
            });
            $('#tableCourses').DataTable({
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

function DeleteCourse(ID) {
    $.ajax({
        url: "/Course/RemoveCourse/" + ID,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            LoadDataCourses();
            alert("Se ha eliminado 1 noticia del registro oficial con éxito.");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetByInitials(ID) {
    var update;
    if ($('#activityCourse').val() == "true") {
        update = "Activo";
    } else if ($('#activityCourse').val() == -1) {
        update = -1;
    } else {
        update = "Inactivo";
    }
    $.ajax({
        url: "/Course/GetCourseById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idCourse').val(result.initials);
            $('#nameCourse').val(result.name);
            $('#creditCourse').val(result.credits);
            $('#semesterCourse').val(result.semester);
            $('#activityCourse').val(update);
            $('#modalCourse').modal('show');
            $('#buttonUpdateCourse').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function UpdateCourse() {
    var update;
    if ($('#activityCourse').val() == 1) {
        update = true;
    } else if ($('#activityCourse').val() == -1) {
        update = -1;
    } else {
        update = false;
    }

    var course = {
        initials: $('#idCourse').val(),
        name: $('#nameCourse').val(),
        credits: parseInt($('#creditCourse').val()),
        semester: $('#semesterCourse').val(),
        activity: update
    };
    $.ajax({
        url: "/Course/EditCourse",
        data: JSON.stringify(course),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataCourses();
            $('#modalCourse').modal('hide');
            $('#idCourse').val("");
            $('#nameCourse').val("");
            $('#creditCourse').val("");
            $('#semesterCourse').val("");
            update;
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $('#activityCourse').val('-1');
}

function LoadDataToCourseStudent() {
    $.ajax({
        url: "/Course/GetCoursesBySemester",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.initials,
                    item.name,
                    item.credits,
                    item.schedule,
                    '<td><a onclick= GetByInitialsForModalStudent(' + JSON.stringify(item.initials) + ')>Consultar</a></td>'
                ];
                dataSet.push(data);
            });
            $('#tableStudentCourses').DataTable({
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

function GetByInitialsForModalStudent(ID) {
    $.ajax({
        url: "/Course/GetCourseById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#initialsForCourseModal').val(result.initials);
            $('#nameCourseStudentModal').val(result.name);
            $('#modalStudentCourse').modal('show');
            $('#buttonpostInForum').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function cleanCourseSpace() {
    document.getElementById('acronymCourse').value = '';
    document.getElementById('nameCourses').value = '';
    document.getElementById('creditsCourse').value = '';
    document.getElementById('semester').value = 0;
    document.getElementById('scheduleCourse').value = 0;
    document.getElementById('conditionCourse').value = -1;
}

function validateCourse(course) {

    if (course.initials == "") {
        return "Se requieren iniciales";
    } else if (course.name == "") {
        return "Se requiere un nombre";
    } else if (isNaN(course.credits)) {
        return "Se requieren creditos";
    } else if (course.semester == "") {
        return "Se requiere especificar un semestre";
    } else if (course.scheduleId == "") {
        return "Se requiere especificar el horario";
    } else if (course.activity==-1) {
        return "Se requiere especificar la actividad";
    } else {
        return "";
    }
}