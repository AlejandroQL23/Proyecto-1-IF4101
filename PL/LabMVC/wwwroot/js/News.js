﻿$(document).ready(function () {
    LoadDataNewsStudent();
    LoadDataNewsStudentComments();
    LoadDataNewsDeleteAdmin();
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
                cleanNews();
                var done = $('#correctLabelAddNews');
                done.removeClass();
                done.addClass("alert alert-success register-alert")
                done.fadeIn(1500);
                done.fadeOut(4000);
            },
            error: function (errorMessage) {
                var response = $('#incorrectLabelAddNews');
                response.removeClass();
                response.addClass("alert alert-warning register-alert");
                response.fadeIn(1500);
                response.fadeOut(4000);
            }
        });

}

function cleanNews() {
    document.getElementById('nameOfNews').value = '';
    document.getElementById('newsContent').value = '';
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
        Author: $('#nameProfileStudent').val(),
        TextContent: $('#addCommentsToNews').val(),
        NewsId: parseInt($('#idNewsModal').val())
    };

    $.ajax({
        url: "/NewsComment/Post",
        data: JSON.stringify(newscomment),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataNewsStudentComments();
        },
        error: function (errorMessage) {

            // errorMessage.responseText

            alert(errorMessage.responseText);
        }
    });
}


//------
function LoadDataNewsDeleteAdmin() {
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
                    '<td><a onclick= DeleteOldNews(' + JSON.stringify(item.id) + ')>Borrar</a> </td>'

                ];
                dataSet.push(data);
            });
            $('#tableAdminDeleteNews').DataTable({
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


function DeleteOldNews(ID) {
    $.ajax({
        url: "/News/" + ID,
         type: "DELETE",
         contentType: "application/json;charset=UTF-8",
        success: function (result) {
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}