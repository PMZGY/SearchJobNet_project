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



    //點擊搜索職缺
    $("#searchJobButton").click(function (e) {
        document.location.href = "/Job/Index?CompName=" + $('#DCompName').val() + "&Wk_Type=" + $("#DWorkType option:selected").text() + "&CityName=" + $("#DCityName option:selected").text() + "&Cjob_Name1=" + $("#DCjob_Name1 option:selected").text();
    })

    //點擊登入
    $("#login").click(function (e) {
        //取要傳到的action url
        var action = '../Member/loginMember'

        //取form資料
        var formData = {
            UserName: $('#UserName').val(),
            PassWord: $('#PassWord').val()
        };

        //傳資料給後端
        $.post(action, formData)
            .done(function (Data) {
                if (Data.User_ID != "") {                                  //userid不為空則登入成功
                    swal({
                        title: "登入成功",
                        text: Data.UserName + "歡迎您回來!",
                        icon: "success"
                    });
                    window.location.reload();
                }
                if (Data.User_ID == "") {                                   //userid為空則登入失敗
                    swal({
                        title: "帳號密碼錯誤",
                        icon: "error"
                    });
                    $('.close').click();
                }
            })
            .fail(function (Data) {

                if (Data.User_ID == "")
                    swal({
                        title: "登入失敗",
                        icon: "error"
                    });
            });
    })

    //點擊註冊
    $("#register").click(function (e) {
        //取要傳到的action url
        var action = '../Member/registerMember'
        //取form資料
        //var formData = $('form#memberRegisterTable').serializeArray();
        if ($('#confirmpassword').val() === $('#password').val()) {
            var formData = {
                User_ID: $('#personid').val(),
                UserName: $('#account').val(),
                PassWord: $('#password').val(),
                Re_Time: null
            };
            //傳資料給後端
            $.post(action, formData)
                .done(function (Data) {
                    if (Data == "insert success!") {
                        swal({
                            title: "註冊成功",
                            icon: "success"
                        });
                        $('.close').click();
                        window.location.reload();
                    } else { Data = "重複會員名稱!需換會員名稱" } {
                        swal({
                            title: "重複會員名稱",
                            text: "需更換會員名稱",
                            icon: "error"
                        });
                    }
                })
                .fail(function (data) {
                    swal({
                        title: "註冊失敗",
                        icon: "error"
                    });
                });
        } else {
            swal({
                title: "密碼輸入不同",
                icon: "error"
            });
        }

    })


    //是否有登入，顯示帳號或會員登入icon
    if ($("#suserName").val() != "") {//有登入
        $("#loginimg").hide();
        $("#loginName").show();
        $("#myfavoriteview").show();
        $("#historyview").show();
    } else {//未登入
        $("#loginimg").show();
        $("#loginName").hide();
        $("#myfavoriteview").hide();
        $("#historyview").hide();
    }

    //點擊登出
    $("#exitimg").click(function () {
        //取要傳到的action url
        var action = '../Member/logoutMember'

        //傳資料給後端
        $.post(action)
            .done(function (Data) {
                if (Data == "logout success!") {
                    swal({
                        title: "登出成功",
                        icon: "success"
                    });
                    location.href = '/';
                } else {
                    swal({
                        title: "登出失敗",
                        icon: "error"
                    });
                }
            })
            .fail(function (Data) {
                swal({
                    title: "登出失敗",
                    icon: "error"
                });
            });
    });

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
                                                                 '<button type="button" class="btn btn-primary" onclick="document.getElementById(\'modify_modal' + commentModel.Comment_ID + '\').style.display=\'block\'">修改</button>' +
                                                                 //modal
                                                                 '<div class="modal" id="modify_modal' + commentModel.Comment_ID + '" tabindex="-1" role="dialog" aria-labelledby="modifying">' +
                                                                     '<div class="modal-dialog modal-dialog-centered" role="document">' +
                                                                         '<div class="modal-content">' +
                                                                             '<div class="modal-header">' +
                                                                                 '<h5 class="modal-title" id="modifying">更新評論</h5>' +
                                                                             '</div>' +
                                                                             '<div class="modal-body">' +
                                                                                 //更新 comment是誰的/哪支comment/誰要改/跟改的內容
                                                                                 '<textarea class="form-control" id="modify_content' + commentModel.Comment_ID + '" placeholder="輸入新的內容" name="modify_content"></textarea>' +
                                                                             '</div>' +
                                                                             '<div class="modal-footer">' +
                                                                                 '<button type="button" class="btn btn-secondary" onclick="document.getElementById(\'modify_modal' + commentModel.Comment_ID + '\').style.display=\'none\'">Close</button>' +
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
                     if (commentModel.Is_Alive != "false") {
                         console.log(commentModel.Is_Alive);
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
        $("#dislike").show();
        $("#like").hide();

    } else {
        $("#dislike").hide();
        $("#like").show();
    };




})

function addMyFavorite() {
    var action = '../Job/insertMyFavorite'
    var formData = {
        user_ID: $("#sessionID").val(),
        job_ID: $('#Job_ID').val()
    }

    $.ajax({
        type: "POST",
        url: action,
        data: formData,
        dataType: "text",
        success: function (Data) {
            $("#like").show();
            $("#dislike").hide();
        }
    })

}

function cancelMyFavorite() {
    var action = '../Job/deleteMyFavorite'
    var formData = {
        user_ID: $("#sessionID").val(),
        job_ID: $('#Job_ID').val()
    }

    $.ajax({
        type: "POST",
        url: action,
        data: formData,
        dataType: "text",
        success: function (Data) {
            $("#dislike").show();
            $("#like").hide();
        }
    })

}
