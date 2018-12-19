/*insert comment*/
$("#insert_comment").click(function () {
    //取要傳到的action url
    var action = '../../Comment/insertComment'

    //取form資料
    var formData = {
        Job_ID: $('#Job_ID').val(),
        Content_Text: $('#Content_Text').val(),
    };

    //傳資料給後端
    $.post(action, formData)
        .done(function (Data) {
            alert(Data);
            if (Data == "insert success!")
                alert("新增成功!");
            $('.close').click();

        })
        .fail(function (data) {
            alert("新增失敗!");
        });
})
/*end insert comment*/

/*delete comment*/
$("#delete_comment.btn.btn-danger").click(function (e) {
    alert("A");
    console.log("kick");
    //取要傳到的action url
    var action = '../../Comment/deleteComment'
    debugger
    //取form資料
    var formData = {
        comment_ID: $('#delete_commentID').val()
    };

    //傳資料給後端
    $.post(action, formData)
    console.log("posted")
    .done(function (Data) {
        if (Data == "delete success!")
            alert("刪除成功!");
        $('.close').click();
    })
    .fail(function (data) {
        alert("刪除失敗!");
    });
})
/*end delete comment*/

/*modify comment*/
$("#modify_comment").click(function (e) {
    //取要傳到的action url
    var action = '../../Comment/modifyComment'

    //取form資料
    var formData = {
        comment_ID: $('#modify_commentID').val(),
        content_text: $('#modify_content').val()
    };

    //傳資料給後端
    $.post(action, formData)
        .done(function (Data) {
            if (Data == "modify success!")
                alert("修改成功!");
            $('.close').click();
        })
        .fail(function (data) {
            alert("刪除失敗!");
        });
})
/*end modify comment*/

/*report comment*/
$("#report_comment").click(function (e) {
    //取要傳到的action url
    var action = '../../Comment/reportComment'

    //取form資料
    var formData = {
        comment_ID: $('#report_commentID').val()
    };

    //傳資料給後端
    $.post(action, formData)
        .done(function (Data) {
            if (Data == "report success!")
                alert("檢舉成功!");
            $('.close').click();
        })
        .fail(function (data) {
            alert("檢舉失敗!");
        });
})
/*end report comment*/