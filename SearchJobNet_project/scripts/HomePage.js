
$(function () {

    //點擊搜索職缺
    $("#searchJobButton").click(function (e) {
        document.location.href = "/Job/Index?CompName=" + $('#CompName').val() + "&Wk_Type=" + $("#WorkType option:selected").text() + "&CityName=" + $("#CityName option:selected").text() + "&Cjob_Name1=" + $("#Cjob_Name1 option:selected").text();
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
                       text: Data.UserName+"歡迎您回來!",
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
    if ($("#suserName").val() != "") {
        $("#loginimg").hide();
        $("#loginName").show();
    } else {
        $("#loginimg").show();
        $("#loginName").hide();
    }
})
