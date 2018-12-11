$(function () {

    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                type: "POST",
                url: "/PeopleData/PeopleList",
                dataType: "json",
                contentType: "application/json"
        },
        //batch: true,
        schema: {
            //取出資料陣列
            data: function (d) { return d.PeopleDataList; },
            //取出資料總筆數(計算頁數用)
            total: function (d) { return d.Count; },
            model: {
                id: "PeopleID",
                fields: {
                    PeopleID: { editable: false, nullable: true },
                    CN: { validation: { required: true } },
                    Depart: { defaultValue: { DepartID: 0, DepartName: "Please wait" } },
                    Pasd: { validation: { required: true } },
                    Name: { validation: { required: true } },
                    Mail: { type: "email", validation: { required: true } },
                }
            }
        },
        pageSize: 10,
        serverPaging: true,
        serverSorting: true
    });


    $("#grid").kendoGrid({
        dataSource: {
            data: Job,
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

})