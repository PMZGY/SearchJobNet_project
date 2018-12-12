$(function () {


    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                type: "POST",
                url: "/Job/JobList",
                dataType: "json"
            },
            schema: {
                model: {
                    fields: {
                        CompName: { type: "string" },
                        Occu_Desc: { type: "string" },
                        CityName: { type: "string" }
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