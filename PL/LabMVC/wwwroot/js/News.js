$(document).ready(function () {
    LoadDataNewsStudent();
});

function AddNews() {
    var news = {
     
        Title: $('#nameOfNews').val(),
        Author:"Administrador",
        Category: $('#typeOfNews').val(),
        TextContent: $('#newsContent').val(),
        ExtraFile: $('#fileOfNews').val()
    };

        $.ajax({
            url: "/News/",
            data: JSON.stringify(news),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
               
            },
            error: function (errorMessage) {
               
            }
        });

}


function LoadDataNewsStudent() {
    $.ajax({
        url: "/News/GetNewsForTable",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Nice");
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.title,
                    item.category,
                    item.textContent,
                    item.extraFile,
                    '<td><a onclick= (' + JSON.stringify(item.id) + ')>Comentar</a> </td>'

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
            alert("Error");
            alert(errorMessage.responseText);
        }
    })
}
