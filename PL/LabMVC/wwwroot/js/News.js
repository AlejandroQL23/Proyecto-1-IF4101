$(document).ready(function () {
    LoadDataNewsStudent();
    LoadDataNewsStudentComments();
    LoadDataNewsDeleteAdmin();
    LoadDataNewsProfessor();
    LoadDataNewsAdminUpdate();
    LoadDataNewsProfessorComments();
    LoadDataNewsGeneral();
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
                LoadDataNewsDeleteAdmin();
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

$("#profileImage").click(function (e) {
    $("#imageUpload").click();
});

function fasterPreview(uploader) {
    if (uploader.files && uploader.files[0]) {
        $('#profileImage').attr('src', window.URL.createObjectURL(uploader.files[0]));
    }
}

$("#imageUpload").change(function () {
    fasterPreview(this);
});

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
            alert(errorMessage.responseText);
        }
    });
}

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
            LoadDataNewsDeleteAdmin();
            LoadDataNewsAdminUpdate();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function LoadDataNewsProfessor() {
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
                    '<td><a onclick= modalToCommentNewsProfessor(' + JSON.stringify(item.id) + ')>Comentar</a> </td>'
                ];
                dataSet.push(data);
            });
            $('#tableNewsProfessor').DataTable({
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


function modalToCommentNewsProfessor(ID) {
    $.ajax({
        url: "/News/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idNewsModalProfessor').val(result.id);
            $('#modalNewsProfessorComments').modal('show');
            $('#btnCommentNewsProfessor').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function LoadDataNewsProfessorComments() {
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
            $('#tableLoadNewsCommentForProfessor').DataTable({
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

function AddCommentProfessorNews() {
    var newscomment = {
        Author: $('#nameProfileProfessor').val(),
        TextContent: $('#addCommentsProfessorNews').val(),
        NewsId: parseInt($('#idNewsModalProfessor').val())
    };

    $.ajax({
        url: "/NewsComment/Post",
        data: JSON.stringify(newscomment),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataNewsProfessorComments();
        },
        error: function (errorMessage) {

            alert(errorMessage.responseText);
        }
    });
}

function LoadDataNewsGeneral() {
    $.ajax({
        url: "/News/GetNewsForTable",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            dataSet = new Array();
            $.each(result, function (key, item) {
                data = [
                    item.title,
                    item.category,
                    item.textContent,
                    item.extraFile
                ];
                dataSet.push(data);
            });
            $('#tableNewsGeneral').DataTable({
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

function LoadDataNewsAdminUpdate() {
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
                    '<td><a onclick= modalToUpdateNews(' + JSON.stringify(item.id) + ')>Actualizar</a> </td>'
                ];
                dataSet.push(data);
            });
            $('#tableNewsUpdateAdmin').DataTable({
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

function modalToUpdateNews(ID) {
    $.ajax({
        url: "/News/" + ID, 
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idNewsModalUpdate').val(result.id);
            $('#titleNewsModalUpdate').val(result.title);
            $('#contentNewsModalUpdate').val(result.textContent);
            $('#modalNewsUpdate').modal('show');
            $('#btnUpdateNews').show();
        },
        error: function (errormessage) {
            alert("Error");
            alert(errormessage.responseText);
        }
    });
    return false;
}

function UpdateNews() {
    ID = $('#idNewsModalUpdate').val();
    var news = {
        Title: $('#titleNewsModalUpdate').val(),
        Author: "Administrador",
        Category: $('#categNewsModalUpdate').val(),
        TextContent: $('#contentNewsModalUpdate').val()
    };
    $.ajax({
        url: "/News/"+ ID,
        data: JSON.stringify(news),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            LoadDataNewsDeleteAdmin();
            LoadDataNewsAdminUpdate();
            $('#modalNewsUpdate').modal('hide');
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}