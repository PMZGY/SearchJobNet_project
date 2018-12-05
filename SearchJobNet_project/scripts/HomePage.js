
$(function () {
 
    var formSelector = "form#searchJobTable",
          formModel = //$(formSelector).toJSON();
        JSON.stringify($(formSelector)[0]);
    var model = new kendo.observable(formModel);
    $("#home").click(function () {
        console.log("AAAA");
        //window.location("View/Home/HomePageView.cshtml");
    });

    $("#searchJobButton").click(function (e) {
        //取資料
        var $form = $(formSelector),
            action = $(e.target).attr('data-url'),
            searchModel = this,
            data = JSON.stringify(this);

        //傳資料給後端
        $.post(action, data)
            .done(function (data) {
                //重整畫面
                // $form.find('[data-role=grid]').data('kendoGrid').dataSource.read();             
            })
            .fail(function (data) {
                
            });
    })

    
})
