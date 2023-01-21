var _items;
var _searchModel;
var spa = {
    _setModel: function (model, searchModel) {
        _items = model;
        _searchModel = searchModel;
        var re = new RegExp("^\/?Date[(][0-9]+[)]\/?$");
        /*/Date(1420149600000)/*/
        $.each(_items, function (index, item) {
            $.each(item, function (key, data) {
                if (data != null && data != "" && re.test(data) && (/Invalid|NaN/.test(new Date(data)))) {
                    item[key] = dateFormat(new Date(parseInt(data.substr(6))), "dd/mm/yyyy");
                }
            });
        });
    },
    _selectItem: function (index) {
        return _items[index];
    },
    _enableAddMode: function () {
        populate({ Id: 0 });
        //$("#SearchCriteria").css('display', 'none');
        //$("#SearchResult").css('display', 'none');
        //$("#ModelDetails").css('display', 'none');
        //$("#ModelEdit").css('display', '');
        pop("ModelEdit");
        
    },
    _enableEditMode: function (item) {
        //$("#SearchCriteria").css('display', 'none');
        //$("#SearchResult").css('display', 'none');
        //$("#ModelDetails").css('display', 'none');
        //$("#ModelEdit").css('display', '');
        pop("ModelEdit");
        hide('ModelDetails');
        populate(item);
    },
    _enableSearchMode: function () {
        //$("#SearchCriteria").css('display', '');
        //$("#SearchResult").css('display', '');
        //$("#ModelDetails").css('display', 'none');
        //$('#responsive').modal('hide');
        //$("#ModelEdit").css('display', 'none');
        closePopup();
        populate({ Id: 0 });
    },
    _enableDetailsMode: function () {
        //$("#SearchCriteria").css('display', 'none');
        //$("#SearchResult").css('display', 'none');
        //$("#ModelEdit").css('display', 'none');
        //$("#ModelDetails").css('display', '');
        hide('ModelEdit');
        pop("ModelDetails");
    },
    _documentReady: function () {
        $(document).ready(function () {
            search();
        });
    },
    _cancel: function () {
        $("#ModelEdit ,#ModelDetails").delegate(".Cancel", "click", function () {
            spa._enableSearchMode();
            return false;
        });
    },
    ///////////////////////////////////


    _enableShowMore: function () {
        populate({ Id: 0 });
        //$("#SearchCriteria").css('display', 'none');
        //$("#SearchResult").css('display', 'none');
        //$("#ModelDetails").css('display', 'none');
        //$("#ModelEdit").css('display', '');
        pop1("ShowMore");

    },

    _showMore: function () {
        debugger;
        $("#ModelEdit ,#ModelDetails").delegate(".ShowMore", "click", function () {
            spa._enableShowMore();
            return false;
        });
    },
    _cancelLast: function () {
        $("#ModelEdit ,#ModelDetails").delegate(".CancelLast", "click", function () {
            hide("ShowMore");
            return false;
        });
    },

    ///////////////////////////////////
    _delete: function () {
        $("#SearchResult").delegate(".Delete", "click", function () {
            var that = this;
            if (confirm("Are you sure?")) {
                ajaxRequest("Post", $(that).attr("href")).done(function (result) {
                    if (result.RowsCount > 0) {
                        $(that).closest('tr').remove();
                    }
                    showMessage(result.Type, result.Title, result.Message);
                });
            }
            return false;
        });
    },
    _search: function () {
        $("#SearchCriteria #Search").click(function () {
            
            search();
        });
    },
    _save: function () {
        $("#ModelEdit").delegate("#Save", "click", function () {
            if ($("#ModelForm").valid()) {
                ajaxRequest($("#ModelForm").attr('method'), $("#ModelForm").attr('action'), $("#ModelForm").serializeArray()).done(function (result) {
                    debugger;
                    if (result.RowsCount > 0) {
                        search();
                        //spa._enableSearchMode();
                    }
                    showMessage(result.Type, result.Title, result.Message);
                });
            }
        });
    },
    _details: function () {
        $("#SearchResult").delegate(".Details", "click", function () {
            var item = spa._selectItem($(this).attr("data-index"));
            $("#ModelDetails").html('');
            $("#DetailsTemplate").tmpl(item).appendTo("#ModelDetails");
            spa._enableDetailsMode();
            return false;
        });
    },
    _add: function () {
        $("#SearchResult").delegate("#Add", "click", function () {
            spa._enableAddMode();
            return false;
        });
    },
    _edit: function () {
        $("#SearchResult").delegate(".Edit", "click", function () {
            var item = spa._selectItem($(this).attr("data-index"));
            spa._enableEditMode(item);
            return false;
        });
    },
    _sort: function () {
        $("#SearchResult").delegate("#SearchTable thead .sorting ,#SearchTable thead .sorting_asc ,#SearchTable thead .sorting_desc", "click", function () {
            var sortType = 0;
            if ($(this).hasClass('sorting_asc')) {
                sortType = 1;
            }
            _searchModel["Orderby"] = sortType;
            _searchModel["SortBy"] = $(this).attr("data-sortby");
            _searchModel["Page"] = null;
            ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), _searchModel, 'html').done(function (result) {
                $("#SearchTableContainer").html(result);
                var $th = $("#SearchTable thead").find('th[data-sortby="' + _searchModel["SortBy"] + '"]');
                if (sortType == 0) {
                    $th.removeClass('sorting').addClass('sorting_asc');
                } else {
                    $th.removeClass('sorting').addClass('sorting_desc');
                }
            });
            return false;
        });
    },
    _filter: function () {
        $("#SearchResult").delegate("#FilterBy", "change", function () {
            _searchModel["FilterBy"] = $(this).val();
            _searchModel["Page"] = null;
            ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), _searchModel, 'html').done(function (result) {
                $("#SearchTableContainer").html(result);
            });
        });
    },
    _pageSizeChanged: function () {
        
        $("#SearchResult").delegate("#PageSize", "change", function () {
            alert("ddd")
            _searchModel["PageSize"] = $(this).val();
            _searchModel["Page"] = null;
            ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), _searchModel, 'html').done(function (result) {
                $("#SearchTableContainer").html(result);
            });
        });
    },
    _saveajaxwithupload: function () {
        $(" #ModelEdit").delegate("#Save", "click", function () {
            var that = this;
            var $form = $(this).closest('form');
            if ($form.valid()) {
                var data = new FormData();
                $form.find('input[type="file"]').each(function (count, fileInput) {
                    var files = $(fileInput).get(0).files;
                    // Add the uploaded image content to the form data collection
                    if (files.length > 0) {
                        $.each(files, function (index, file) {
                            data.append($(fileInput).attr("name") + "[" + index + "]", file);
                        });
                    }
                });
                var formData = $form.serializeArray();
                $.each(formData, function (key, value) {
                    data.append(this.name, this.value);
                });
                ajaxRequest($form.attr('method'), $form.attr('action'), data, 'json', false, false).done(function (result) {
                    debugger;
                    if (result.RowsCount > 0) {
                        search();
                        //spa._enableSearchMode();
                    }
                    showMessage(result.Type, result.Title, result.Message);
                });
            }
            return false;
        });
    },
};
function search() {
    var data = $("#SearchForm").serializeArray();
    ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), data, 'html').done(function (html) {
        $("#SearchTableContainer").html(html);
    });
}
function populate(item) {
    $("#ModelForm").populate(item);
    $('#ModelForm').find("select").each(function (count, select) {
        if (item[$(select).attr("name")] == null) {
            item[$(select).attr("name")] = "";
        } else {
            $(select).find("option[value='" + item[$(select).attr("name")] + "']").attr("selected", 'selected');
        }
    });
    /*$('select').selectpicker('refresh');*/
}



function pop(div) {
    var docHeight = $(document).height(); //grab the height of the page
    var scrollTop = $(window).scrollTop(); //grab the px value from the top of the page to where you're scrolling
    $('.overlay-bg').show().css({ 'height': docHeight }); //display your popup background and set height to the page height
    document.getElementById(div).style.display = 'block';
}
function pop1(div) {
    document.getElementById(div).style.display = 'block';
}

function hide(div) {
    document.getElementById(div).style.display = 'none';
}
//To detect escape button
document.onkeydown = function (evt) {
    evt = evt || window.event;
    if (evt.keyCode == 27) {
        closePopup();
    }
};
$('.overlay-bg').click(function () {
    closePopup();
});
function closePopup() {
    search();
    $('.overlay-bg').hide();
    hide('ModelEdit');
    hide('ModelDetails');
}