
$(function () {
 
    var formSelector = "form#searchJobTable",
        formModel = //$(formSelector).toJSON();
        JSON.stringify($(formSelector)[0]);
    var model = new kendo.observable(formModel);

    $("#searchJobButton").click(function (e) {

        //取要傳到的action url
        var action = $(e.target).attr('data-url')
        //取form資料
        var formData = $('form#searchJobTable').serializeArray();

        //傳資料給後端
        $.post(action, formData)
            .done(function (Data) {
                
                //接到職缺的值，傳回JobListView
                $.post("Job/Index")
                .done(function () {
                   // Url.Action("Index", "Job");
                })
                .fail(function () {

                });
            })
            .fail(function (data) {
                
            });
    })

    
})
