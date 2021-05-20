$(document).ready(function () {
});

function AddEF() {
    var news = {
     
        title: $('#nameOfNews').val(),
        category: $('#typeOfNews').val(),
        content: $('#newsContent').val(),
        file: $('#fileOfNews').val()
    };

        $.ajax({
         //   url: "/Student/AddStudent",
         //   data: JSON.stringify(user),
         //   type: "POST",
         //   contentType: "application/json;charset=utf-8",
         //   dataType: "json",
            success: function (result) {
               
            },
            error: function (errorMessage) {
               
            }
        });

}