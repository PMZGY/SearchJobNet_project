$(function () {
    $("#detailcontainer").css({
        "display": "grid",
        "grid-gap": "16px",
        "grid-template-columns": "repeat(2, 1fr) minmax(50px, 1fr)",
        "grid-template-rows": "repeat(10, min-content)"
    })
    $("#dtable").css({
        "align": "center",
        "width": "300px",
        "border": "10px"
    })

    $(".column").css({
        "float": "left",
        "width": "100%",
        "padding": "5px",
    })

    $(".row:after").css({
        "content": "",
        "display": "table",
        "clear": "both"
    })

    /*function gridView() {
        for (i = 0; i < elements.length; i++) {
            elements[i].style.width = "50%";
        }
    }*/

    $("p[name='model_content']").css({
        "background-color": "#81C7d4"
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

    /*   $("Document").ready(function (jobID) {
           //取要傳到的action url
           var action = 'Comment/browseComment( jobid )'
   
   
       })   */

    /*傳一個List<CommentModel> 進來  each 建一個 caotainer 來放資料*/
    /*
    Array.each(function (commentID) {
        var comment_container = '<div class="container">' +
                                    '<div class="row">'   +
                                        '<div class="column">' +
                                            //model.jobid
                                        '</div>' +
                                    '</div>' +
                                    '<div class="row">' +
                                        '<div class="column">' +
                                            //model.userid
                                        '</div>' +
                                        '<div class="column">' +
                                            //model.time
                                        '</div>' +
                                    '</div>' +
                                    '<div class="row">' +
                                        '<div class="column">' +
                                            //model.contentTEXT
                                        '</div>' +
                                    '</div>' +
                                '</div>'

        $(".comment_table").append(comment_container)
    })
    */
})