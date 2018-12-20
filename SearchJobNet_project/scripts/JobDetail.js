$(function () {
    $(".column").css({
        "float": "left",
        "width": "100%",
        "padding": "5px"
    });

    $(".row:after").css({
        "content": "",
        "display": "table",
        "clear": "both"
    });

    $("p[name='model_content']").css({
        "background-color": "#A5DEE4"
    });

    $(".detail_table").css({
        "border": "10px #2E5C6E solid",
        "margin-bottom": "50px"
    });

    /*沒登入不能看評論或新增*/
    $("Document").ready(function () {
        if ($("#sessionID").val() == "") {
            $(".comment_table").css({
               "display":"none"
            });
            $("#heart").css({
                "display": "none"
            });
        }
    })

    /* show comment */
    $(document).ready(function () {
        /*用jobID去撈comment*/

        var action = '../../Comment/browseMemberComment'
        var formData = {
            job_ID: $('#Job_ID').val(),
        };

        $.post(action, formData)
             .done(function (Data) {
                 console.log(Data);
                 /*傳一個List<CommentModel> 進來  each 建一個 container 來放資料*/
                 $.each(Data, function (index, Model) {
                     //建一個model來接值
                     var commentModel = Model;

                     //當前job的comment排序
                     var i = index + 1;

                     //建一個comment的位置
                     var comment_container = '<div class="container">' + '<div class="row" style="content = ""; display : table; clear : both;">' +
                                                 //這是一則comment
                                                 '<table style="border : 10px #2E5C6E solid; margin-bottom : 50px; width:100%" cellpadding="10" border=1>' +
                                                     //comment第一行
                                                     '<tr style=" clear : both; ">' +
                                                         //comment編號
                                                         '<td style = " float : left; width : 82%; height:61px; padding : 5px; background-color : #A5DEE4">' +
                                                             '#' + i +
                                                         '</td>' +
                                                         //修改按鈕 + 浮動修改視窗
                                                         '<td style = " float : left; width : 6%; padding : 5px; background-color : #A5DEE4">' +
                                                             '<form>' +
                                                                 '<div class="form-group" style="height: 0% ">' + '</div>' +
                                                                 //叫出浮動視窗的按鈕
                                                                 '<button type="button" class="btn btn-primary" onclick="document.getElementById(\'modify_modal\').style.display=\'block\'">修改</button>' +
                                                                 //modal
                                                                 '<div class="modal" id="modify_modal" tabindex="-1" role="dialog" aria-labelledby="modifying">'+
                                                                     '<div class="modal-dialog modal-dialog-centered" role="document">' +
                                                                         '<div class="modal-content">' +
                                                                             '<div class="modal-header">' +
                                                                                 '<h5 class="modal-title" id="modifying">更新評論</h5>' +
                                                                             '</div>' +
                                                                             '<div class="modal-body">' +
                                                                                 //更新 comment是誰的/哪支comment/誰要改/跟改的內容
                                                                                 '<textarea class="form-control" id="modify_content" placeholder="輸入新的內容" name="modify_content"></textarea>' +
                                                                             '</div>' +
                                                                             '<div class="modal-footer">' +
                                                                                 '<button type="button" class="btn btn-secondary" onclick="document.getElementById(\'modify_modal\').style.display=\'none\'">Close</button>' +
                                                                                 '<button type="button" class="btn btn-primary" id="modify_comment" onclick="modifyComment(\'' + commentModel.Comment_ID + '\')">Save changes</button>' +
                                                                             '</div>' +
                                                                         '</div>' +
                                                                     '</div>' +
                                                                 '</div>' +
                                                             '</form>' +
                                                         '</td>' +
                                                         //檢舉按鈕 comment是誰的/哪支comment/誰要改/跟改的內容
                                                         '<td style = " float : left; width : 6%; padding : 5px; background-color : #A5DEE4">' +
                                                             '<form>' +
                                                                 '<div class="form-group" style="hright: 0%">' +
                                                                 '</div>' +
                                                                 '<button type="button" class="btn btn-default" id="report_comment" onclick="reportComment(\'' + commentModel.Comment_ID + '\')">檢舉</button>' +
                                                             '</form>' +
                                                         '</td>' +
                                                         //刪除按鈕 comment是誰的/哪支comment/誰要改/跟改的內容
                                                         '<td style = " float : left; width : 6%; padding : 5px; background-color : #A5DEE4">' +
                                                             '<form>' +
                                                                 '<div class="form-group" style="hright: 0%">' +
                                                                 '</div>' +
                                                                 '<button type="button" class="btn btn-danger" id="delete_comment" onclick="deleteComment(\'' + commentModel.Comment_ID + '\')">刪除</button>' +
                                                              '</form>' +
                                                         '</td>' +
                                                     '</tr>' +
                                                     //comment第二行
                                                     '<tr style = " clear : both; ">' +
                                                         //comment發表者
                                                         '<td style=" float : left; width : 50%; padding : 5px;">' +
                                                             '會員：' + commentModel.UserName +
                                                         '</td>' +
                                                         //comment發表時間
                                                         '<td  style="float : left; width : 50%; padding : 5px;">' +
                                                             '發表時間：' + commentModel.Time +
                                                         '</td>' +
                                                     '</tr>' +
                                                     //comment第三行
                                                     '<tr style = " clear : both; ">' +
                                                         //comment內容
                                                         '<td colspan"2"  style="float : left; width : 100%; padding : 5px;">' +
                                                             commentModel.Content_Text +
                                                         '</td>' +
                                                     '</tr>' +
                                                 '</table>' +
                                             '</div>' + '</div>'
                     //append這個comment
                     if ($('#sessionID').val() != "") {
                         console.log($('#sessionID').val());
                         $(".comment_table").append(comment_container);
                     }
                 })
             })
         .fail(function () {
             $(".comment_table").append('<div style="color:#AAA; text-align:center;">沒有評論...</div>')
         });
        /* show comment end */             
    })
})

$(document).ready(function () {
    //0 是還沒加入最愛 1是已經加入最愛
    if ($("#Is_Favorite").val() == 0) {
        var myFavoriteString = '<img id="favorite" src="../browser_components/images/dislike.png" onclick="addMyFavorite()" width="30px" hight="auto"> '
    } else {
        var myFavoriteString = '<img id="favorite" src="../browser_components/images/like.png" onclick="cancelMyFavorite()" width="30px" hight="auto">'
    };

    $("#heart").append(myFavoriteString);
})

function addMyFavorite() {
    var action = '../Job/insertMyFavorite'
    var formData = {
        user_ID: $("#sessionID").val(),
        job_ID: $('#Job_ID').val()
    }

    $.post(action, formData)
        .done(function (Data) {
           if (Data == "insert success!")
               ("#favorite").src = "../browser_components/images/like.png";
            $('.close').click();
         })
       .fail(function (Data) {
            alert("加入失敗!");
       });

}

function cancelMyFavorite() {
    var action = '../Job/deleteMyFavorite'
    var formData = {
        user_ID: $("#sessionID").val(),
        job_ID: $('#Job_ID').val()
    }
    $.post(action, formData)
        .done(function (Data) {
            if (Data == "delete success!")
                ("#favorite").src = "../browser_components/images/dislike.png";
            $('.close').click();
        })
        .fail(function (Data) {
            alert("取消失敗!");
        });
}