$(function () {
    $("#detailcontainer").css({
        "display": "grid",
        "grid-gap": "16px",
        "grid-template-columns": "repeat(2, 1fr) minmax(50px, 1fr)",
        "grid-template-rows": "repeat(10, min-content)"
    });

    $("#dtable").css({
        "align": "center",
        "width": "300px",
        "border": "10px"
    });

    $(".column").css({
        "float": "left",
        "width": "100%",
        "padding": "5px",
    });

    $(".row:after").css({
        "content": "",
        "display": "table",
        "clear": "both"
    });

    /*function gridView() {
        for (i = 0; i < elements.length; i++) {
            elements[i].style.width = "50%";
        }
    }*/

    $("p[name='model_content']").css({
        "background-color": "#A5DEE4"
    });

    $(".detail_table").css({
        "border": "10px #2E5C6E solid",
        "margin-bottom": "50px"
    });
    /*
    array.each(function () {
        $("#" + key).innerHTML(value)
    })*/

    /* 以下function */


    $("Document").ready(function (abc) {
        console.log(jobID);

            /*用jobID去撈comment*/
           var action = '../Comment/browseMemberComment'

           jobID = 1;
           var JID = Convert.Int32(jobID); 

          var formData = {
          //     ID   : JID,
              ID : jobID,
              phase: 1
           };

           console.log('post???');

        $.post(action,formData)
                .done(function (Data) {

                    console.log('posted');
                    console.log(Data);
                    console.log('posted2');

                    var arr = Data;

                    $.each(arr, function (key, value) {
                        console.log(key);
                        alert(key.val() + ": " + value.val());
                    });

                    /*傳一個Data: List<CommentModel> 進來  each 建一個 container 來放資料*/
                    //$.forEach(function (Model) {

                    //    console.log(Model);
                    //    //建一個model來接值
                    //    var commentModel = Model;
                 
                    //    // var commentModel

                    //    var comment_container = '<div class="container">' +
                    //                                '<div class="row">' +
                    //                                    '<div class="column">' +
                    //                                        commentModel.Job_ID +
                    //                                    '</div>' +
                    //                                '</div>' +
                    //                                '<div class="row">' +
                    //                                    '<div class="column">' +
                    //                                        //commentModel.userid
                    //                                    '</div>' +
                    //                                    '<div class="column">' +
                    //                                        //commentModel.time
                    //                                    '</div>' +
                    //                                '</div>' +
                    //                                '<div class="row">' +
                    //                                    '<div class="column">' +
                    //                                        //commentModel.contentTEXT
                    //                                    '</div>' +
                    //                                '</div>' +
                    //                            '</div>';

                    //    $(".comment_table").append(comment_container);
                    //})
                })
            .fail(function () {
                $(".comment_table").append('<div style="color:#AAA; text-align:center;">沒有評論...</div>')
            });
        /* comment end */
       })   
})