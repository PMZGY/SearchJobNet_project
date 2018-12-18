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

    /*insert comment*/
    $("#insert_comment").click(function (e) {
        //取要傳到的action url
        var action = '../../Comment/insertComment'
        //var date = new Date.toString();
        
        //取form資料
        var formData = {
            Job_ID: $('#Job_ID').val(),
            User_ID: $('#User_ID').val(),
            Content_Text: $('#Content_Text').val(),
            Time: 'date',
        };
        debugger;
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
                console.log('post nooooooooooo');
            });
    })
    /*end insert comment*/

    /*delete comment*/
    $("#delete_comment").click(function (e) {
        //取要傳到的action url
        var action = '../Comment/deleteComment'

        //取form資料
        var formData = {
            Comment_ID: $('delete_commentID').val()
        };

        //看看是不是評論者本人
        if ($('delete_userID').val() == $('delete_sessionID').val()) {
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
        } else {
            alert("你不能刪除不是你的評論。")
        };
    })
    /*end delete comment*/

    /*modify comment*/
    $("#modify_comment").click(function (e) {
        //取要傳到的action url
        var action = '../Comment/modifyComment'

        //取form資料
        var formData = {
            Comment_ID: $('modify_commentID').val(),
           // Content_Text: $('')
        };

        //看看是不是評論者本人
        if ($('delete_userID').val() == $('delete_sessionID').val()) {
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
        } else {
            alert("你不能刪除不是你的評論。")
        };
    })
    /*end modify comment*/

    /*report comment*/
    $("#report_comment").click(function (e) {
        //取要傳到的action url
        var action = '../Comment/reportComment'

        //取form資料
        var formData = {
            Comment_ID: $('report_commentID').val(),
            User_ID: $('report_sessionID').val()
        };

        //看看是不是評論者本人
        if ($('report_userID').val() != $('report_sessionID').val()) {
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
        } else {
            alert("你不能檢舉這則評論。")
        };
    })
    /*end report comment*/

    /* show comment */    
    $("Document").ready(function (jobID) {

        /*用jobID去撈comment*/
  
        var action = '../../Comment/browseMemberComment'
           var formData = {
               ID: 1,
               phase: 1
           };

           $.post(action,formData)
                .done(function (Data) {                    
                    /*傳一個List<CommentModel> 進來  each 建一個 container 來放資料*/
                    $.each(Data,function (index , Model) {
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
                                                                    '<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modify_modal">修改</button>' +
                                                                    //modal
                                                                    '<div class="modal fade" id="modify_modal" tabindex="-1" role="dialog" aria-labelledby="modifying" aria-hidden="true">' +
                                                                        '<div class="modal-dialog modal-dialog-centered" role="document">' +
                                                                            '<div class="modal-content">' +
                                                                                '<div class="modal-header">' +
                                                                                    '<h5 class="modal-title" id="modifying">更新評論</h5>' +
                                                                                    '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                                                                                        '<span aria-hidden="true">&times;</span>' +
                                                                                    '</button>' +
                                                                                '</div>' +
                                                                                '<div class="modal-body">' +
                                                                                    //更新 comment是誰的/哪支comment/誰要改/跟改的內容
                                                                                    '<input type="hidden" id="modify_userID" value="' + commentModel.User_ID + '">' +
                                                                                    '<input type="hidden" id="modify_commentID" value="' + commentModel.Comment_ID + '">' +
                                                                                    '<input type="hidden" id="modify_sessionID" value="' + '!!!當前seeion的USER!!!!' + '">' +
                                                                                    '<textarea class="form-control" id="modify_content" placeholder="輸入新的內容" name="modify_content"></textarea>'+
                                                                                '</div>' +
                                                                                '<div class="modal-footer">' +
                                                                                    '<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>' +
                                                                                    '<button type="button" class="btn btn-primary" id="modify_comment">Save changes</button>' +
                                                                                '</div>' +
                                                                            '</div>' +
                                                                        '</div>' +
                                                                    '</div>'+
                                                                '</form>' +
                                                            '</td>' +
                                                            //檢舉按鈕 comment是誰的/哪支comment/誰要改/跟改的內容
                                                            '<td style = " float : left; width : 6%; padding : 5px; background-color : #A5DEE4">' +
                                                                '<form>' +
                                                                    '<div class="form-group" style="hright: 0%">' +
                                                                        '<input type="hidden" id="report_userID" value="' + commentModel.User_ID +'">' +
                                                                        '<input type="hidden" id="report_commentID" value="' + commentModel.Comment_ID + '">' +
                                                                        '<input type="hidden" id="report_sessionID" value="' + '!!!當前seeion的USER!!!!' + '">' +
                                                                    '</div>' +
                                                                    '<button type="submit" class="btn btn-default" id="report_comment">檢舉</button>' +
                                                                '</form>' +
                                                            '</td>' +
                                                            //刪除按鈕 comment是誰的/哪支comment/誰要改/跟改的內容
                                                            '<td style = " float : left; width : 6%; padding : 5px; background-color : #A5DEE4">' +
                                                                '<form>' +
                                                                    '<div class="form-group" style="hright: 0%">' +
                                                                        '<input type="hidden" id="delete_userID" value="' + commentModel.User_ID + '">' +
                                                                        '<input type="hidden" id="delete_commentID" value="' + commentModel.Comment_ID + '">' +
                                                                        '<input type="hidden" id="delete_sessionID" value="' + '!!!當前seeion的USER!!!!' + '">' +
                                                                    '</div>' +
                                                                    '<button type="submit" class="btn btn-danger" id="delete_comment">刪除</button>' +
                                                                 '</form>' +
                                                            '</td>' +
                                                        '</tr>' +
                                                        //comment第二行
                                                        '<tr style = " clear : both; ">' +
                                                            //comment發表者
                                                            '<td style=" float : left; width : 50%; padding : 5px;">' +
                                                                '會員：' + commentModel.User_ID +
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
                        $(".comment_table").append(comment_container)
                    })
                })
            .fail(function () {
                $(".comment_table").append('<div style="color:#AAA; text-align:center;">沒有評論...</div>')
            });
        /* show comment end */
       })   
})