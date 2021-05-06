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
            LoadDataCourses();

        },
        error: function (errorMessage) {

           

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
            dataSet = new Array();
            var html = '';
            $.each(result, function (key, item) {

                data = [
                    item.initials,
                    item.name,
                    item.credits,
                    item.semester,
                    item.activity,
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
