var modal = {
    init: function (triggerdelegate, modalid, modalsize, modaltitle, modalbody, triggerselector) {
        var modalclass = "modal-md";
        if (modalsize == "large") {
            modalclass = "modal-lg";
        }
        if (modalsize == "small") {
            modalclass = "modal-sm";
        }
        $("body ").append('<div class="modal fade" id=' + modalid + ' tabindex="-1" role="dialog">' +
            '<div class="modal-dialog ' + modalclass + '"><div class="modal-content">' +
            '<div class="modal-header">' +
            '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
            '<h4 class="modal-title">' + modaltitle + '</h4>' +
            '</div>' +
            '<div class="modal-body">' + modalbody + '</div>' +
            //'<div class="modal-footer">' +
            //'<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>' +
            //'</div>' +
            '</div></div></div>');
        
        if (triggerdelegate == null || triggerdelegate == '') {
            $(triggerselector || ".openPopup").click(function () {
                $(this).create_modal(modalid);
            });
        } else {
            $(triggerdelegate).delegate(triggerselector || '.openPopup', 'click', function () {
                $(this).create_modal(modalid);
            });
        }
        $(".modal").delegate('.Cancel', 'click', function () {
            $("#" + modalid).modal('hide');
        });
    },
    _show: function (modalid) {
        $("#" + modalid).modal();
    },
    _setTitle: function (modalid, modaltitle) {
        $("#" + modalid + " .modal-title").text(modaltitle);
    },
    _setSize: function (modalid, modalsize) {
        var $dialog = $("#" + modalid + " .modal-dialog");
        $dialog.removeClass("modal-*");
        $dialog.addClass("modal-dialog " + modalsize);
    },
    _load: function (modalid, url) {
        $("#" + modalid + " .modal-body").load(url);
    },
    _setBodyContent: function (modalid, htmlcontent) {
        $("#" + modalid + " .modal-body").html(htmlcontent);
    },
}
$.fn.create_modal = function (modalid) {
    $("#" + modalid + " .modal-body").html("<p class='center'><br /><br /><br />جاري التحميل...</p>");
    $("#" + modalid + " .modal-title").text($(this).attr("data-popupTitle"));
    $("#" + modalid).modal('show');
    if ($(this).attr("data-ajax").length && $(this).attr("data-ajax") == "true") {
        $("#" + modalid + " .modal-body").load($(this).attr("data-openPopup"), function (response, status, xhr) {
            if (xhr.status == "200") {
            } else {
                //popup failed to load.
                $("#" + modalid + " .modal-body").html("<p class='center'><br /><br /><br />حدث خطأ! يرجى المحاولة من جديد.</p>");
            }
        });
    } else {
        $("#" + modalid + " .modal-body").html($("#" + $(this).attr("data-openPopup")).html());
    }
}