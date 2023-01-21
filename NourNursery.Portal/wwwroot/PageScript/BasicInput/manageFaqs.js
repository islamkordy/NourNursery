var manageFaqs = {
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
    var OffersSubs = new Array();
    $("#FeatureTB TBODY TR").each(function () {
        var row = $(this);
        var obj = {
            id: row.find("TD").eq(0).html(),
            QuestionAr: row.find("TD").eq(1).html(),
            QuestionEn: row.find("TD").eq(2).html(),
            DescAr: row.find("TD").eq(3).html(),
            DescEn: row.find("TD").eq(4).html(),
        };
        OffersSubs.push(obj);
    });
    data.append("FaqsDetailsStr", JSON.stringify(OffersSubs));
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
    var Url = "/BasicInput/Faqs/Create";
    // window.location = Url;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}

function Details(id) {
    var Url = "/BasicInput/Faqs/Details?Id=" + id;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}

function Edit(id) {
    var Url = "/BasicInput/Faqs/Edit?Id=" + id;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}
function Delete(id) {
    var Url = "/BasicInput/Faqs/Delete?Id=" + id;
    $('#myModalAddEdit').load(Url, function (response, status, xhr) {
        $('#myModalAddEdit').modal('show');
    });
}
function DeleteRow(id) {
    var Url = "/BasicInput/Faqs/DeleteRow?Id=" + id;
    ajaxRequest("Post", Url, "", 'json', false, false).done(function (result) {
        var res = result.split(',');
        if (res[0] == "success") {
            $('#myModalAddEdit').modal('hide');
            toastr.success(res[1]);
            search();
            //  window.location = "/BasicInput/Features/Index";
        }
        else
            toastr.error(res[1]);
    });
}
function IsValid() {
    var isValidItem = true;

    if ($('#TitleAr').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك ادخل العنوان عربي ");
    }
    if ($('#TitleEn').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك ادخل العنوان إنجليزي ");
    }

    return isValidItem;
}

function search() {

    var url = "/BasicInput/Faqs/Search";
    ajaxRequest("post", url, "", 'html').done(function (data) {
        $("#SearchTableContainer").html(data);
    });
}


//----------------- Feature -------------------------
function AddFeature() {
    for (instance in CKEDITOR.instances) {
        CKEDITOR.instances[instance].updateElement();
    }
    var QuestionAr = $('#QuestionAr').val();
    var QuestionEn = $('#QuestionEn').val();
    var DescAr = $('#DescAr').val();
    var DescEn = $('#DescEn').val();
    var DetailId = $('#DetailId').val();

    var isValidItem = true;

    //$('#FeatureTB TBODY TR').each(function () {
    //    var row = $(this);
    //    if (parseInt(row.find("TD").eq(1).html()) == parseInt(FK_Features)) {
    //        toastr.error('تم الإضافة من قبل')
    //        isValidItem = false;
    //        return false; // breaks
    //    }
    //});

    if (isValidItem && IsValidFeature()) {
        var tBody = $("#FeatureTB > TBODY")[0];

        var row = tBody.insertRow(-1);
        var cell = $(row.insertCell(-1));
        cell.html(DetailId);
        cell.attr("hidden", true);

        cell = $(row.insertCell(-1));
        cell.html(QuestionAr);
        cell = $(row.insertCell(-1));
        cell.html(QuestionEn);

        cell = $(row.insertCell(-1));
        cell.html(DescAr);
        cell = $(row.insertCell(-1));
        cell.html(DescEn);

        // removed button
        cell = $(row.insertCell(-1));
        var btnRemove = $("<a  />");
        btnRemove.attr("type", "button");
        btnRemove.attr("style", "color: red;");

        //btnRemove.addClass("btn btn-danger");
        btnRemove.attr("onclick", "RemoveFeature(this);");
        btnRemove.html("<i class=\"fa fa-trash\"></i>");
        cell.append(btnRemove);

        // edit button
        cell = $(row.insertCell(-1));
        var btnRemove = $("<a  />");
        btnRemove.attr("type", "button");
        //  btnRemove.addClass("btn btn-info");
        btnRemove.attr("onclick", "EditFeature(this);");
        btnRemove.html("<i class=\"fa fa-edit\"></i>");
        cell.append(btnRemove);

        $('#QuestionAr').val("");
        $('#QuestionEn').val("");
        $('#DescAr').val("");
        $('#DescEn').val("");
        $('#DetailId').val("0");
    }



}
function IsValidFeature() {
    var isValidItem = true;

    if ($('#QuestionAr').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك ادخل السؤال عربي ");
    }
    if ($('#QuestionEn').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك ادخل السؤال إنجليزي ");
    }

    if ($('#DescAr').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك أدخل الوصف عربي");
    }
    if ($('#DescEn').val() == "") {
        isValidItem = false;
        toastr.error("من فضلك أدخل الوصف إنجليزي");
    }
    return isValidItem;
}

function RemoveFeature(button) {
    var row = $(button).closest("TR");
    // var id = row.find("TD").eq(0).html();
    //if (id != "0") {
    //    var Url = "/Bank/TRXBankState/DeleteFeature?Id=" + id;

    //    ajaxRequest("Post", Url, "", 'json', false, false).done(function (result) {
    //        var res = result.split(',');
    //        if (res[0] == "success") {
    //            row.remove();
    //        }
    //        else
    //            toastr.error(res[1]);
    //    });
    //}
    //else
    row.remove();
}

function EditFeature(button) {
    var row = $(button).closest("TR");
    DetailId = row.find("TD").eq(0).html();
    QuestionAr = row.find("TD").eq(1).html();
    QuestionEn = row.find("TD").eq(2).html();
    DescAr = row.find("TD").eq(3).html();
    DescEn = row.find("TD").eq(4).html();
    for (instance in CKEDITOR.instances) {
        CKEDITOR.instances[instance].updateElement();
    }
    $('#QuestionAr').val(QuestionAr);
    $('#QuestionEn').val(QuestionEn);
    $('#DescAr').val(DescAr);
    $('#DescEn').val(DescEn);
    $('#DetailId').val(DetailId);
    for (instance in CKEDITOR.instances) {
        CKEDITOR.instances[instance].updateElement();
    }
    row.remove();

}