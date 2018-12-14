
$(function () {
 
    var formSelector = "form#searchJobTable",
        formModel = //$(formSelector).toJSON();
        JSON.stringify($(formSelector)[0]);
    //var model = new kendo.observable(formModel);

    //點擊搜索職缺
    $("#searchJobButton").click(function (e) {

        //取要傳到的action url
        var action = $(e.target).attr('data-url')
        //取form資料
        var formData = $('form#searchJobTable').serializeArray();
        debugger;
        //傳資料給後端
        $.post(action, formData)
            .done(function (Data) {
                

            })
            .fail(function (data) {
                
            });
    })

    //點擊登入
    $("#login").click(function (e) {
        //取要傳到的action url
        var action = 'Member/loginMember'

        //取form資料
        var formData = {
            UserName: $('#UserName').val(),
            PassWord: $('#PassWord').val()
        };

        //傳資料給後端
        $.post(action, formData)
            .done(function (Data) {
                if (Data == "login success")
                alert("登入成功!");
                $('.close').click();

            })
            .fail(function (data) {
                alert("登入失敗!");
            });
    })
    
    //點擊註冊
    $("#register").click(function (e) {
        //取要傳到的action url
        var action = $(e.target).attr('data-url')
        //取form資料
        //var formData = $('form#memberRegisterTable').serializeArray();
        if ($('#confirmpassword').val() === $('#password').val()) {
            var formData = {                
                User_ID: $('#personid').val(),
                UserName: $('#account').val(),
                PassWord: $('#password').val(),
                Re_Time: null
            };
            debugger;
            //傳資料給後端
            $.post(action, formData)
                .done(function (Data) {
                    debugger;
                    if (Data == "insert success!")
                    alert("註冊成功!");
                    $('.close').click();
                })
                .fail(function (data) {
                    alert("註冊失敗!");
                });
        } else {
            alert("密碼輸入不同");
        }
        
    })
})
