/*"http://api.jquery.com/jquery.ajax/"*/

function ajaxRequest(type, url, data, dataType, contentType, processData, cache, async, showLoader) {
    if (dataType == null) {
        dataType = "json";
    }
    if (contentType == null) {
        contentType = 'application/x-www-form-urlencoded; charset=UTF-8';
    }
    if (processData == null) {
        processData = true;
    }
    if (cache == null) {
        cache = true;
    }
    if (async == null) {
        async = true;
    }
    if (showLoader == null) {
        showLoader = true;
    }
    var options = {
        dataType: dataType,
        contentType: contentType,
        cache: cache,
        type: type,
        data: data || null,
        processData: processData,
        async: async,
        beforeSend: function () {
            if (showLoader) {
                /*todo: show loader*/
            }
        },
        error: function (xhr) {
            debugger;
        }
    };
    var antiForgeryToken = $("#antiForgeryToken").val();
    if (antiForgeryToken) {
        options.headers = {
            'RequestVerificationToken': antiForgeryToken
        };
    }
        //return $.ajax(url, options).success(function (data) {

    //return $.ajax(url, options).done(function (data, textStatus, request) {}).complete(function () {/*todo: hide loader*/}).error(function () {
    //    /*todo: hide loader*/
    //    showMessage('error', 'Error', 'error');
    //});

    return $.ajax(url, options).done(function (data, textStatus, request) { });
}

/*----------------------Show Alert Message------------------*/
function showMessage(type, title, message) {
    var $class = "alert-success";
    if (type == "error") {
        $class = "alert-danger";
    } else if (type == "warning") {
        $class = "alert-warning";
    } else if (type == "info") {
        $class = "alert-info";
    }
    $('#messages').append('<div class="control-group"><div class="alert ' + $class + '"><a class="close">×</a><strong>' + (title || '') + '</strong>' + message + '</div></div>');
}


/*------------- DropDownList---------------*/

function fillDropDownList(url, data, tragetDDL) {
    var val = 0;
    tragetDDL.empty();
    ajaxRequest("Post", url, data, "json").done(function (result) {
        $.each(result, function (i, optionData) {
            val = i;
            var option = new Option(optionData.Text, optionData.Value, optionData.Selected);
            tragetDDL.append(option);
        });
        if (val == 0)
            toastr.warning("لا يوجد بيانات مرتبطة");
    });
}