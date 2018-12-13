$(function () {



    $("#jobgrid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: "/History/browseHistoryjob",
                    dataType: "json"
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


})