$(function () {

    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    type: "POST",
                    url: "/Job/memberToMyFavoriteView",
                    dataType: "json",
                                  
                }
            },
            schema: {
                model: {
                    fields: {
                        Comp_ID: { type: "number" },
                        CompName: { type: "string" },
                        Job_ID: { type: "string" },
                        CityName: { type: "string" },
                        Occu_Desc: { type: "string" },
                        Wk_Type: { type: "string" },
                        Cjob_ID: { type: "number" },
                        Cjob_Name1: { type: "string" }
                    }
                }
            },
            pageSize: 20
        },
        scrollable: true,
        sortable: true,
        filterable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { field: "CompName", title: "公司名稱", width: "300px" },
            { field: "Occu_Desc", title: "職務名稱", width: "300px" },
            { field: "CityName", title: "地點", width: "130px" }
        ]
    });

    //點擊搜索職缺
    $("#searchJobButton").click(function (e) {
        document.location.href = "/Job/Index?CompName=" + $('#DCompName').val() + "&Wk_Type=" + $("#DWorkType option:selected").text() + "&CityName=" + $("#DCityName option:selected").text() + "&Cjob_Name1=" + $("#DCjob_Name1 option:selected").text();
    })

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