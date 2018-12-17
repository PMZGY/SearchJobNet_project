﻿$(function () {

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
        height: 550,
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


})