$(document).ready(function () {
    LoadDataNewsStudent();
    LoadDataNewsStudentComments();
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
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.id,
                    item.title,
                    item.category,
                    item.textContent,
                    item.extraFile,
                    '<td><a onclick= modalToCommentNews(' + JSON.stringify(item.id) + ')>Comentar</a> </td>'

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


function modalToCommentNews(ID) {
    $.ajax({
        url: "/News/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            $('#idNewsModal').val(result.id);
            $('#modalNewsComments').modal('show');
            $('#btnSendCommentToNews').show();
        },
        error: function (errormessage) {
            alert("Error");
            alert(errormessage.responseText);
        }
    });
    return false;
}


function LoadDataNewsStudentComments() {
    $.ajax({
        url: "/NewsComment/Get",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
           
                dataSet = new Array();
                $.each(result, function (key, item) {
                    data = [
                        item.author,
                        item.textContent
                    ];
                    dataSet.push(data);

                });
            
            $('#xs').DataTable({
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

function AddCommentNews() {
    var newscomment = {
        author: $('#nameProfileStudent').val(),
        textContent: $('#addCommentsToNews').val(),
        newsId: $('#idNewsModal').val()
    };
    alert(newscomment.author);
    alert(newscomment.textContent);
    alert(newscomment.newsId);
    $.ajax({
            url: "/NewsComment/",
            data: JSON.stringify(newscomment),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert("vi");
            },
            error: function (errorMessage) {
                alert("mAA");
            }
        });
}