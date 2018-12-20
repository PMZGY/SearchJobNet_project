/*insert comment*/
function insertComment() {
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
            var url = window.location.href;
            if (url.indexOf('?') > -1) {
                url = url + '&jobID=' + $('#Job_ID').val();
            } else {
                url = url + '?jobID=' + $('#Job_ID').val();
            }
            window.location.href = url;
            $('.close').click();

        })
        .fail(function (data) {
            alert("新增失敗!");
        });
}
/*end insert comment*/

/*delete comment*/
//$("#delete_comment.btn.btn-danger").click(function (e) {
function deleteComment(commentID) {
    console.log("kick");
    //取要傳到的action url
    var action = '../../Comment/deleteComment'

    //取form資料
    var formData = {
//        comment_ID: $('#delete_commentID').val()
        comment_ID: commentID
    };
    debugger;
    //傳資料給後端
    $.post(action, formData)
        .done(function (Data) {
            if (Data == "delete success!")
                alert("刪除成功!");
            $('.close').click();
        })
        .fail(function (data) {
            alert("刪除失敗!");
        });
}
/*end delete comment*/

/*modify comment*/
function modifyComment(commentID) {

    //取要傳到的action url
    var action = '../../Comment/modifyComment'

    //取form資料
    var formData = {
        comment_ID: commentID,
        content_text: $('#modify_content').val()
    };

    //傳資料給後端
    $.post(action, formData)
        .done(function (Data) {
            if (Data == "modify success!")
                alert("修改成功!");
            //$('.close').click();
        })
        .fail(function (data) {
            alert("刪除失敗!");
        });
}
/*end modify comment*/

/*report comment*/
function reportComment(commentID) {
    //取要傳到的action url
    var action = '../../Comment/reportComment'

    //取form資料
    var formData = {
        comment_ID: commentID
    };
    //傳資料給後端
    $.post(action, formData)
        .done(function (Data) {
            if (Data == "report success!")
                alert("檢舉成功!");
            if (Data == "Can't report again!") {
                alert("Can't report again!");
            }
            $('.close').click();
        })
        .fail(function (data) {
            alert("檢舉失敗!");
        });
}
/*end report comment*/