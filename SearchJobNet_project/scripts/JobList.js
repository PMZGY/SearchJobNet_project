$(function () {

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
                if (Data.User_ID != "")                                   //userid不為空則登入成功
                    alert(Data.UserName + "登入成功!");
                window.location.reload();
                if (Data.User_ID == "")                                   //userid為空則登入失敗
                    alert("帳號密碼錯誤!");
                $('.close').click();


            })
            .fail(function (Data) {

                if (Data.User_ID == "")
                    alert("登入失敗!");
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
                    debugger;
                    if (Data == "insert success!")
                        alert("註冊成功!");
                    $('.close').click();
                    window.location.reload();
                })
                .fail(function (data) {
                    alert("註冊失敗!");
                });
        } else {
            alert("密碼輸入不同");
        }

    })

    //是否有登入，顯示帳號或會員登入icon
    if ($("#suserName").val() != "") {
        $("#loginimg").hide();
        $("#loginName").show();
        console.log("有");
    } else {
        $("#loginimg").show();
        $("#loginName").hide();
        console.log("沒有");
    }


})