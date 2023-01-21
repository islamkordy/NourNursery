var manageSliderImage1 = {
    init: function () {
        search();
    },
}
function Save() {

    var $form = $("#ModelForm");
    //if ($form.valid()) {
    var data = new FormData();
    $form.find('input[type="file"]').each(function (count, fileInput) {
        var files = $(fileInput).get(0).files;
        // Add the uploaded image content to the form data collection
        if (files.length > 0) {
            $.each(files, function (index, file) {
                data.append($(fileInput).attr("Id"), file);
                //data.append($(fileInput).attr("name") + "[" + index + "]", file);
            });
        }
    });
    for (instance in CKEDITOR.instances) {
        CKEDITOR.instances[instance].updateElement();
    }
    var formData = $form.serializeArray();
    $.each(formData, function (key, value) {
        data.append(this.name, this.value);
    });
    if (IsValid()) {
        ajaxRequest($("#ModelForm").attr('method'), $("#ModelForm").attr('action'), data, 'json', false, false).done(function (result) {
            var res = result.split(',');
            //debugger;
            if (res[0] == "success") {
                $('#myModalAddEdit').modal('hide');
                toastr.success(res[1]);
                search();
            }
            else
                toastr.error(res[1]);
        });
    }
}
function Create() {
    var Url = "/BasicInput/SliderImage1/Create";
    // window.location = Url;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}

function Details(id) {
    var Url = "/BasicInput/SliderImage1/Details?Id=" + id;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}

function Edit(id) {
    var Url = "/BasicInput/SliderImage1/Edit?Id=" + id;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}
function Delete(id) {
    var Url = "/BasicInput/SliderImage1/Delete?Id=" + id;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}
function DeleteRow(id) {
    var Url = "/BasicInput/SliderImage1/DeleteRow?Id=" + id;
    ajaxRequest("Post", Url, "", 'json', false, false).done(function (result) {
        var res = result.split(',');
        if (res[0] == "success") {
            $('#myModalAddEdit').modal('hide');
            toastr.success(res[1]);
            search();
            //  window.location = "/BasicInput/Benefits/Index";
        }
        else
            toastr.error(res[1]);
    });
}
function IsValid() {
    var isValidItem = true;

    if ($('#DescAr').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك ادخل الوصف عربي ");
    }
    if ($('#DescEn').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك ادخل الوصف إنجليزي ");
    }

    //if ($('#Image').val() == "") {
    //    isValidItem = false;
    //    toastr.error("من فضلك ادخل ملف ");
    //}

    return isValidItem;
}

function search() {

    var url = "/BasicInput/SliderImage1/Search";
    ajaxRequest("post", url, "", 'html').done(function (data) {
        $("#SearchTableContainer").html(data);
    });
}
