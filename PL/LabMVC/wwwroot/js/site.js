// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    GetNationality();
    GetMajors();
   

});

function Add() {
  
    var student = {

        name: $('#name').val(),
        email: $('#email').val(),
        password: $('#password').val(),
         nationality: $("#nationality").val(),
        major: $("#major").val()
    };

    var messageValidate = validateStudent(student);
    if (messageValidate == "") {

        $.ajax({
            url: "/Home/Insert",
            data: JSON.stringify(student),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                document.getElementById('name').value = '';
                document.getElementById('email').value = '';
                document.getElementById('password').value = '';
                document.getElementById('nationality').value = 0;
                document.getElementById('major').value = 0;
                //-----------------------------------------------
                var done = $('#correctLabel');
                done.removeClass();
                done.addClass("alert alert-success register-alert")
                done.fadeIn(500);
                done.fadeOut(4000);

            },
            error: function (errorMessage) {
                var response = $('#incorrectLabel');
                response.removeClass();
                response.addClass("alert alert-warning register-alert");
                response.html("This email has already been registered");
                response.fadeIn(500);
                response.fadeOut(4000);


            }
        });
    } else {
        var error = $('#incorrectLabel');
        error.removeClass();
        error.addClass("alert alert-danger register-alert");
        error.html(messageValidate);
        error.fadeIn(500);
        error.fadeOut(4000);
    }
        

}

function validateStudent(student) {
    var e = student.email + '';
    var eval = e.includes("@gmail.com");
    if (student.name == "") {
        return "Name is required";
    } else if (student.email == "") {
        return "Email is required";
    } else if (student.password == "") {
        return "Password is required";
    } else if (eval == false) {
        return "Email required an '@gmail.com'";
    } else if (student.nationality == 0) {
        return "Nationality is required";
    } else if (student.major == 0) {
        return "Major is required";
    }else {
        return "";
    }
}


function GetMajors() {

    $.ajax({
        url: "/Home/GetMajors",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
            //llenar el dropdowns
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value="' + item.id + '">' + item.name + '</option>';
            });
            $('#major').append(html);

        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);

        }
    });

    //alert("Botón sirve");


}



function GetNationality() {

    $.ajax({
        url: "/Home/GetNationality",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            //llenar el dropdowns
            var html = '';
            $.each(result, function (key, item) {
                html += '<option value="' + item.id + '">' + item.name + '</option>';
            });
            $('#nationality').append(html);

        },
        error: function (errorMessage) {
            alert("Error");
            alert(errorMessage.responseText);

        }
    });

    //alert("Botón sirve");


}