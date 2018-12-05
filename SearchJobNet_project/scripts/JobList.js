$(function () {
    $("#grid").kendoGrid({
        dataSource: {
            data: products,
            schema: {
                model: {
                    fields: {
                        ProductID: { type: "number" },
                        ProductName: { type: "string" },
                        UnitPrice: { type: "number" },
                        UnitsInStock: { type: "number" },
                        Discontinued: { type: "boolean" }
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
            { field: "ProductID", title: "產品編號", width: "300px" },
            { field: "ProductName", title: "產品名稱", width: "300px" },
            { field: "UnitPrice", title: "價錢", format: "{0:c}", width: "130px" },
            { field: "UnitsInStock", title: "數量", width: "130px" },
            { field: "Discontinued", title: "交易方式", width: "130px" }
        ]
    });



})