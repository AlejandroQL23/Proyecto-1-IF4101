$(document).ready(function () {
    LoadDataCourses();
});

function AddCourse() {

    var course = {
        initials: $('#acronymCourse').val(),
        name: $('#nameCourses').val(),
        credits: parseInt($('#creditsCourse').val()),
        semester: $('#semester').val(),
        scheduleId: parseInt($('#scheduleCourse').val()),
        activity: parseInt($('#conditionCourse').val())

    };
   

    $.ajax({
        url: "/Home/InsertCourses",
        data: JSON.stringify(course),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            cleanCourse();

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
            response.html("Ocurrio un problema");
            response.fadeIn(1500);
            response.fadeOut(4000);

        }
    });

    

}


function LoadDataCourses() {
    $.ajax({
        url: "/Home/GetCourses",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.initials + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.credits + '</td>';
                html += '<td>' + item.semester + '</td>';
                html += '<td>' + item.activity + '</td>';
                html += '<td><a onclick= GetByInitials(' + JSON.stringify(item.initials) + ')>Actualizar</a> | <a onclick= DeleteCourse(' + JSON.stringify(item.initials) + ')>Eliminar</a></td>';
            });
            $('.tbodyCourse').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}

function DeleteCourse(ID) {

    $.ajax({

        url: "/Home/DeleteCourse/" + ID,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            LoadDataCourses();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });


}

function GetByInitials(ID) {

    $.ajax({
        url: "/Home/GetById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idCourse').val(result.initials);
            $('#nameCourse').val(result.name);
            $('#creditCourse').val(result.credits);
            $('#semesterCourse').val(result.semester);
            $('#activityCourse').val(result.activity);



            $('#modalCourse').modal('show');
            $('#btnUpdateCourse').show();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function UpdateCourse() {
    alert("actualizanding");
    var Course = {

        initials: $('#idCourse').val(),
        name: $('#nameCourse').val(),
        credits: parseInt($('#creditCourse').val()),
        semester: $('#semesterCourse').val(),
        activity: parseInt($('#activityCourse').val())

    };
    $.ajax({
        url: "/Home/UpdateCourse",
        data: JSON.stringify(Course),
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
            $('#activityCourse').val("");


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
