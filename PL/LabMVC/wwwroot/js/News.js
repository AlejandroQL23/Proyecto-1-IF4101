$(document).ready(function () {
   // LoadDataNewsStudent();
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


function LoadDataNewsStudent() {
    $.ajax({
        //url: "/Professor/GetProfessor",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.idCard, //cambiar cuendo este
                    item.name,
                    '<td><a onclick= (' + JSON.stringify() + ')>Comentar</a> </td>'

                ];
                dataSet.push(data);
            });
            $('#tableNewsStudent').DataTable({
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
