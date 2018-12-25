﻿$(function () {

    //生JobListKendoGrid
    var dataSrc = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Job/SendJobListData",
                type: "POST",
                dataType: "json",
                data: {
                    CompName: $("#CompName").val(),
                    Wk_Type: $("#Wk_Type").val(),
                    CityName: $("#CityName").val(),
                    Cjob_Name1: $("#Cjob_Name1").val(),
                }
            }
        },
        pageSize: 20,
        serverPaging: false,
        serverSorting: true
    });

    $("#grid").kendoGrid({
        dataSource: dataSrc,
        scrollable: true,
        sortable: true,
        filterable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { hidden: true, field: "Job_ID" },
            { field: "CompName", title: "公司名稱", width: "160px", attributes: { style: "text-align:left" } },
            { field: "Occu_Desc", title: "職位名稱", width: "450px", attributes: { style: "text-align:left" } },
            { field: "CityName", title: "工作地點", width: "100px", attributes: { style: "text-align:center" } },
        ],
        editable: true,
        editable: "inline"
    });

    //抓取點選職缺ID及傳送至JobDetailView
    $("#grid").data("kendoGrid").table.on("click", "tr", sendJobDetailId);

    function sendJobDetailId(e) {
        dataItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr")).Job_ID;
        var action = "../Job/toJobDetailView";
        //傳資料給後端
        var action2 = '../History/insertHistory'
       document.location.href = "/Job/toJobDetailView?jobID=" + dataItem;
            
         $.post(action2, { jobID: dataItem });
    }

    //點擊搜索職缺
    $("#searchJobButton").click(function (e) {

        // 驗證 輸入公司名稱 是否 非全數字或亂碼
        var reg = /^[\u4E00-\u9FA5]+$/;
        if (($('#CompName').val() != "") && (!reg.test($('#CompName').val()))) {
            swal(
                {
                    title: "請輸入全中文公司名稱",
                    icon: "error"
                }
                );
            $('#CompName').val("");
        }
        else {
            document.location.href = "/Job/Index?CompName=" + $('#CompName').val() + "&Wk_Type=" + $("#WorkType option:selected").text() + "&CityName=" + $("#CityName option:selected").text() + "&Cjob_Name1=" + $("#Cjob_Name1 option:selected").text();
        }
    })

    //點擊登入
    $("#login").click(function (e) {

        // 驗證輸入的帳號(非中文 且 4-10碼) ,密碼(非中文 且 6-10碼) 是否正確
        var namereg = /^\w.{3,11}$/;
        var passwordreg = /^\w.{5,11}$/;

        if (!namereg.test($('#UserName').val())) {
            swal(
                 {
                     title: "帳號格式須為 非中文且4-10碼",
                     icon: "error"
                 }
                );
            $('#UserName').val("");
        }
        else if (!passwordreg.test($('#PassWord').val())) {
            swal(
                 {
                     title: "密碼格式須為 非中文且6-10碼",
                     icon: "error"
                 }
                );
            $('#PassWord').val("");
        }
        else {

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
        }
    })

    //點擊註冊
    $("#register").click(function (e) {

        // 驗證輸入的 身分證(身分證格式) ,帳號(非中文 且 4-10碼) ,密碼(非中文 且 6-10碼) 是否正確
        var idreg = /^[A-Z]\d{9}$/;
        var namereg = /^\w.{3,11}$/;
        var passwordreg = /^\w.{5,11}$/;

        if (!idreg.test($('#personid').val())) {
            swal(
                 {
                     title: "請輸入身分證字號格式",
                     icon: "error"
                 }
                );
            $('#personid').val("");
        }
        else if (!namereg.test($('#account').val())) {
            swal(
                 {
                     title: "帳號格式須為 非中文且4-10碼",
                     icon: "error"
                 }
                );
            $('#account').val("");
        }
        else if (!passwordreg.test($('#password').val())) {
            swal(
                 {
                     title: "密碼格式須為 非中文且6-10碼",
                     icon: "error"
                 }
                );
            $('#password').val("");
            $('#confirmpassword').val("");
        }
        else {
            //取要傳到的action url
            var action = '../Member/registerMember'
            //取form資料
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

})