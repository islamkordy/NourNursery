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
        $("#SearchCriteria").css('display', 'none');
        $("#SearchResult").css('display', 'none');
        $("#ModelDetails").css('display', 'none');
        $("#ModelEdit").css('display', '');

    },
    _enableEditMode: function (item) {
        $("#SearchCriteria").css('display', 'none');
        $("#SearchResult").css('display', 'none');
        $("#ModelDetails").css('display', 'none');
        $("#ModelEdit").css('display', ''); 
        populate(item);
    },
    _enableSearchMode: function () {
        $("#SearchCriteria").css('display', '');
        $("#SearchResult").css('display', '');
        $("#ModelDetails").css('display', 'none');
        $('#responsive').modal('hide');
        $("#ModelEdit").css('display', 'none');
        populate({ Id: 0 });
    },
    _enableDetailsMode: function () {
        $("#SearchCriteria").css('display', 'none');
        $("#SearchResult").css('display', 'none');
        $("#ModelEdit").css('display', 'none');
        $("#ModelDetails").css('display', '');
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
    _delete: function () {
        $("#SearchResult").delegate(".Delete", "click", function () {
            var that = this;
            if (confirm("Are you sure?")) {
                ajaxRequest("Post", $(that).attr("href")).done(function (result) {
                    var res = result.split(",");
                    if (res[0] == "success") {
                        $(that).closest('tr').remove();
                        toastr.success(res[1]);
                    }
                    else if (res[0] == "error") {
                        toastr.error(res[1]);
                    }
                });
            }

            //url = $(this).attr('href');
            //$("#ModelConfirm").dialog('open');

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
                    if (result.RowsCount > 0) {
                        search();
                        spa._enableSearchMode();
                    }
                    showMessage(result.Type, result.Title, result.Message);
                });
            }
        });
    },
    _details: function () {
        $("#SearchResult").delegate(".Details", "click", function () {
            url = $(this).attr('href');
            $(".ui-dialog-titlebar").hide();
            $("#ModelDetails").dialog('open');
            return false;
            //var item = spa._selectItem($(this).attr("data-index"));
            //alert(item);
            //console.Log(item);
            //$("#ModelDetails").html('');
            //$("#DetailsTemplate").tmpl(item).appendTo("#ModelDetails");
            //spa._enableDetailsMode();
            //return false;
        });
    },
    _add: function () {
        $("#SearchForm").delegate("#Add", "click", function () {
            //spa._enableAddMode();
            //return false;
            url = $(this).attr('href');
            $(".ui-dialog-titlebar").hide();
            $("#ModelEdit").dialog('open');

            return false;
        });
    },
    _edit: function () {
        $("#SearchResult").delegate(".Edit", "click", function () {
            //var item = spa._selectItem($(this).attr("data-index"));
            //spa._enableEditMode(item);
            //return false;
            url = $(this).attr('href');
            $(".ui-dialog-titlebar").hide();
            $("#ModelEdit").dialog('open');

            return false;
        });
    },
    _sort: function () {
       // $("#SearchResultTitle").delegate("#SearchTable thead .sorting ,#SearchTable thead .sorting_asc ,#SearchTable thead .sorting_desc", "click", function () {
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
        $("#SearchResultTitle").delegate("#FilterBy", "change", function () {
            _searchModel["FilterBy"] = $(this).val();
            _searchModel["Page"] = null;
            ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), _searchModel, 'html').done(function (result) {
                $("#SearchTableContainer").html(result);
            });
        });
    },
    _pageSizeChanged1: function () {
        
        $("#SearchResultTitle").delegate("#PageSize", "change", function () {
            _searchModel["PageSize"] = $(this).val();
            _searchModel["Page"] = null;
            ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), _searchModel, 'html').done(function (result) {
                $("#SearchTableContainer").html(result);
            });
        });
    },
    _pageSizeChanged11: function () {

        $("#SearchResultTitle").delegate("#PageSize", "change", function () {
            //alert($(this).val());
           // $("#PageSize").val($(this).val());
            var data = new FormData();
            var formData = $("#SearchForm").serializeArray();
                $.each(formData, function (key, value) {
                    data.append(this.name, this.value);
                });
                data.append("PageSize", $(this).val());
                data.append("Page", 1);
                ajaxRequest($("#SearchForm").attr('method'), $("#SearchForm").attr('action'), data, 'html',false,false).done(function (result) {
                $("#SearchTableContainer").html(result);
            });
        });
    },
    _pageSizeChanged: function () {
        $("#SearchResultTitle").delegate("#PageSize", "change", function () {
           // alert($(this).val());
            _searchModel["PageSize"] = $(this).val();
            _searchModel["Page"] = null;
            //alert($(this).val());
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
                    if (result.RowsCount > 0) {
                        search();
                        spa._enableSearchMode();
                    }
                    showMessage(result.Type, result.Title, result.Message);
                });
            }
            return false;
        });
    },
    _DDLSearch: function () {
        ///////////////////////////////// for Search /////////////////////////////////////////
        $.widget("custom.combobox", {
            _create: function () {
                this.wrapper = $("<span>")
                  .addClass("custom-combobox")
                  .insertAfter(this.element);

                this.element.hide();
                this._createAutocomplete();
                this._createShowAllButton();
            },
            _createAutocomplete: function () {
                var selected = this.element.children(":selected"),
                  value = selected.val() ? selected.text() : "";

                this.input = $("<input>")
                  .appendTo(this.wrapper)
                  .val(value)
                  .attr("title", "")
                  .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                  .autocomplete({
                      delay: 0,
                      minLength: 0,
                      source: $.proxy(this, "_source")
                  })
                  .tooltip({
                      tooltipClass: "ui-state-highlight"
                  });

                this._on(this.input, {
                    autocompleteselect: function (event, ui) {
                        ui.item.option.selected = true;
                        this._trigger("select", event, {
                            item: ui.item.option
                        });
                    },

                    autocompletechange: "_removeIfInvalid"
                });
            },
            _createShowAllButton: function () {
                var input = this.input,
                  wasOpen = false;

                $("<a>")
                  .attr("tabIndex", -1)
                  .attr("title", "عرض الكل")
                  .tooltip()
                  .appendTo(this.wrapper)
                  .button({
                      icons: {
                          primary: "ui-icon-triangle-1-s"
                      },
                      text: false
                  })
                  .removeClass("ui-corner-all")
                  .addClass("custom-combobox-toggle ui-corner-right")
                  .mousedown(function () {
                      wasOpen = input.autocomplete("widget").is(":visible");
                  })
                  .click(function () {
                      input.focus();

                      // Close if already visible
                      if (wasOpen) {
                          return;
                      }

                      // Pass empty string as value to search for, displaying all results
                      input.autocomplete("search", "");
                  });
            },
            _source: function (request, response) {
                var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                response(this.element.children("option").map(function () {
                    var text = $(this).text();
                    if (this.value && (!request.term || matcher.test(text)))
                        return {
                            label: text,
                            value: text,
                            option: this
                        };
                }));
            },
            _removeIfInvalid: function (event, ui) {
                // Selected an item, nothing to do
                if (ui.item) {
                    return;
                }
                // Search for a match (case-insensitive)
                var value = this.input.val(),
                  valueLowerCase = value.toLowerCase(),
                  valid = false;
                this.element.children("option").each(function () {
                    if ($(this).text().toLowerCase() === valueLowerCase) {
                        this.selected = valid = true;
                        return false;
                    }
                });
                // Found a match, nothing to do
                if (valid) {
                    return;
                }
                // Remove invalid value
                this.input
                  .val("")
                  .attr("title", "لم يتم العثور علي" + " / " + value)
                  .tooltip("open");
                this.element.val("");
                this._delay(function () {
                    this.input.tooltip("close").attr("title", "");
                }, 3000);
                this.input.autocomplete("instance").term = "";
            },
            _destroy: function () {
                this.wrapper.remove();
                this.element.show();
            }
        });
    },
    _CreateModel: function () {
        $("#SearchForm").delegate(".Create", "click", function () {
            var that = this;
            var Url = $(that).attr("href")
            $('#CreateModal').load(Url, function (response, status, xhr) {
                $('#CreateModal').modal('show');
            });


            return false;
        });
    },
    _EditModel: function () {
        $("#SearchResult").delegate(".editModel", "click", function () {
            var that = this;
            var Url = $(that).attr("href")
            $('#CreateModal').load(Url, function (response, status, xhr) {
                $('#CreateModal').modal('show');
            });


            return false;
        });
    },
    _DetailModel: function () {
        $("#SearchResult").delegate(".detailModel", "click", function () {
            var that = this;
            var Url = $(that).attr("href")
            $('#DetailModal').load(Url, function (response, status, xhr) {
                $('#DetailModal').modal('show');
            });
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

/////////////////////////////////added by sayed test/////////////////////////////////////////////////////////
var url = "";
///// dialog alert messages////////////
//$("#ModelAlert").dialog({
//    autoOpen: false,
//    resizable: false,
//    height: 170,
//    width: 1000,
//    show: { effect: 'drop', direction: "up" },
//    modal: true,
//    draggable: true,
//    open: function (event, ui) {
//        $(".ui-dialog-titlebar-close").hide();
//        $(".datepicker").datepicker();
//    },
//    buttons: {
//        "OK": function () {
//            $(this).dialog("close");

//        },
//        "Cancel": function () {
//            $(this).dialog("close");
//        }
//    }
//});

///////////// dialog for insert and edit ////////////////////////
$("#ModelEdit").dialog({
    //title: 'Create Operation',
    autoOpen: false,
    resizable: false,
    width: 1000,
    show: { effect: 'drop', direction: "up" },
    modal: true,
    draggable: true,
    open: function (event, ui) {
        $(".ui-dialog-titlebar-close").hide();
        $(this).load(url);
        $(".datepicker").datepicker();
    },
    buttons: {
        "Cancel": function () {
            $(this).dialog("close");
        }
    }
});

///////////// dialog for Details ////////////////////////

$("#ModelDetails").dialog({
    //title: 'View Object',
    autoOpen: false,
    resizable: false,
    width: 1000,
    show: { effect: 'drop', direction: "up" },
    modal: true,
    draggable: true,
    open: function (event, ui) {
        $(".ui-dialog-titlebar-close").hide();
        $(this).load(url);
        $(".datepicker").datepicker();
    },
    buttons: {
        "Close": function () {
            $(this).dialog("close");
        }
    }
});

