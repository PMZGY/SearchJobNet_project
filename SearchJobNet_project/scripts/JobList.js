$(function () {


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

    $("#grid").data("kendoGrid").table.on("click", "tr", sendJobDetailId)

    function sendJobDetailId(e) {
        dataItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr")).Job_ID
        alert(dataItem);
    }

    //$("#grid").kendoGrid({
    //    dataSource: {
    //        transport: {
    //            read: {
    //                type: "POST",
    //                url: "/Job/SendJobListData?CompName=" + $("#CompName").val() + "&Wk_Type=" + $("#Wk_Type").val() + "&CityName=" + $("#CityName").val() + "&Cjob_Name1=" + $("#Cjob_Name1").val(),
    //                dataType: "json"
    //            }
                
    //        },
    //        schema: {
    //            model: {
    //                fields: {
    //                    Comp_ID:{type:"number"},
    //                    CompName: { type: "string" },
    //                    Job_ID:{type:"string"},
    //                    CityName: { type: "string" },
    //                    Occu_Desc: { type: "string" },
    //                    Wk_Type:{type:"string"},
    //                    Cjob_ID:{type:"number"},
    //                    Cjob_Name1:{type:"string"}
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