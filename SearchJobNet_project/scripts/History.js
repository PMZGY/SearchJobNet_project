$(function () {
   
    //頁面進來只顯示瀏覽history 隱藏評論history
    $("#commonGrid").hide();
    $("#jobGrid").show();
    //呼叫job grid
    $("#jobGrid").kendoGrid({
        
        dataSource: {
            
            transport: {
                read: {
                    type: "POST",
                    url: "/History/browseHistoryjob",
                    dataType: "json",
                   
                    
                }

            },
           
            schema: {
                model: {
                    fields: {
                        searchjobModel:{Comp_ID: { type: "number" },
                            CompName: { type: "string" },
                            Job_ID: { type: "string" },
                            CityName: { type: "string" },
                            Occu_Desc: { type: "string" },
                            Wk_Type: { type: "string" },
                            Cjob_ID: { type: "number" },
                            Cjob_Name1: { type: "string" }},
                        Time:{type:"string"}
                    }
                }
            },
            pageSize: 20
        },
        height: 550,
        scrollable: true,
        sortable: true,
        filterable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { field: "searchjobModel.CompName", title: "公司名稱", width: "130px" },
            { field: "searchjobModel.Occu_Desc", title: "職務名稱", width: "130px" },
            { field: "searchjobModel.CityName", title: "地點", width: "130px" },
            { field: "Time", title: "上次瀏覽時間", width: "130px"}
        ]
        
    });
    $("#jobGrid").data("kendoGrid").table.on("click", "tr", sendJobDetailId);

    function sendJobDetailId(e) {
        dataItem = $("#jobGrid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr")).searchjobModel.Job_ID;
        var action = "../Job/toJobDetailView";
        document.location.href = "/Job/toJobDetailView?jobID=" + dataItem;
    }
 //按下job button只顯示瀏覽history 隱藏評論history
$("#jobGridButton").click(function () {
    $("#jobGrid").show();
    $("#commonGrid").hide();

});

    //點擊搜索職缺
$("#searchJobButton").click(function (e) {
    document.location.href = "/Job/Index?CompName=" + $('#CompName').val() + "&Wk_Type=" + $("#WorkType option:selected").text() + "&CityName=" + $("#CityName option:selected").text() + "&Cjob_Name1=" + $("#Cjob_Name1 option:selected").text();
})

//按下comment button只顯示評論history 隱藏瀏覽history 
$("#commonGridButton").click(function () {
    $("#jobGrid").hide();
    $("#commonGrid").show();
    $("#commonGrid").kendoGrid({

        dataSource: {

            transport: {
                read: {
                    type: "POST",
                    url: "/History/browseHistoryComment",
                    dataType: "json",
                    

                }

            },

            schema: {
                model: {
                    fields: {
                        Comment_ID   :  { type: "number" },
                        Job_ID       :  { type: "number" },
                        User_ID      :  { type: "string" },
                        Content_Text :  { type: "string" },
                        Time         :  { type: "string" },
                        Report_no    :  { type: "number" },
                        Is_Alive     :  { type: "string" },
                        Occu_Desc    :  { type: "string" },
                        CompName     :  { type: "string" }
                    }
                }
            },
            pageSize: 20
        },
        height: 550,
        scrollable: true,
        sortable: true,
        filterable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { field: "Occu_Desc", title: "評論職務名稱", width: "110px" },
            { field: "CompName", title: "評論公司名稱", width: "140px" },
            { field: "Content_Text", title: "評論內容", width: "160px" },
            { field: "Is_Alive", title: "是否存活", width: "80px" },
            { field: "Time", title: "評論時間", width: "80px" }
        ]

    });

});
    
})


//$("#grid").kendoGrid({
    //    dataSource: {
    //        data: Job,
    //        schema: {
    //            model: {
    //                fields: {
    //                    CompName: { type: "string" },
    //                    Occu_Desc: { type: "string" },
    //                    CityName: { type: "string" }
    //                }
    //            }
    //        },
    //        pageSize: 20
    //    },
    //    height: 550,
    //    scrollable: true,
    //    sortable: true,
    //    filterable: true,
    //    pageable: {
    //        input: true,
    //        numeric: false
    //    },
    //    columns: [
    //        { field: "CompName", title: "公司名稱", width: "300px" },
    //        { field: "Occu_Desc", title: "職務名稱", width: "300px" },
    //        { field: "CityName", title: "地點", width: "130px" }
    //    ]
    //});