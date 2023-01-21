/// <reference path="autocomplete.js" />
/// <reference path="autocomplete.js" />
$(function () {
    $.widget("custom.combobox", {
        _create: function () {
             this.wrapper = $("<span style='width:400px;' id='d'>")
            //this.wrapper = $("<span>")
              .addClass("custom-combobox")
              .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },


        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
              value = selected.val() ? selected.text() : "";

            this.input = $("<input id='f'>")
              .appendTo(this.wrapper)
              .val(value)
              //.attr("title", "")
                .attr("placeholder", " -- اختر -- ")
              .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                 .addClass("form-control")
                      .addClass("form-control")
              .autocomplete({
                  delay: 0,
                  minLength: 0,
                  selectFirst: true,
                  //appendTo: "#SearchForm",
                  maxShowItems: 10,
                  source: $.proxy(this, "_source"),

              })
              .tooltip({
                  classes: {
                      "ui-tooltip": "ui-state-highlight"
                  }
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

            $("<button type='button'><span class='glyphicon glyphicon-chevron-down'></span> </button>")

              .attr("tabIndex", -1)
              .attr("title", "")
              .tooltip()
              .insertAfter(input)
              .addClass("btn1")
                .addClass("btn")
              .removeClass("ui-corner-all")
              .addClass("custom-combobox-toggle ui-corner-right")
              .on("mousedown", function () {
                  wasOpen = input.autocomplete("widget").is(":visible");
              })
              .on("click", function () {
                  input.trigger("focus");

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
              .attr("title", value + " didn't match any item")
              .tooltip("open");
            this.element.val("");
            this._delay(function () {
                this.input.tooltip("close").attr("title", "");
            }, 2500);
            this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });
    $(".AutoComplete1").combobox({

        select: function (event, ui) {
            $('.type').hide();
            $('#' + $(this).val()).show(500);
        }
    });
    $(".AutoComplete2").combobox({

        select: function (event, ui) {
            if ($('#ItemId').val().trim() != '0') {

                $("#Quantity").val("1");
                ajaxRequest("post", "../ERPStock/ManageERPStock/GetItemPrice?ItemId=" + $("#ItemId").val(), $("#ItemId").val(), 'JSON').done(function (data) {
                    $("#Price").val(data);
                });
            }
            else {
                $("#Quantity").val("");
                $("#Price").val("");
            }
        }
    });
    $(".AutoComplete3").combobox({

        select: function (event, ui) {
            if ($('#ERPItemsId').val().trim() != '0') {
                $("#Quantity").val("1");
              
                ajaxRequest("post", "../ERPStock/ManageERPStock/GetItemPrice?ItemId=" + $("#ERPItemsId").val(), $("#ERPItemsId").val(), 'JSON').done(function (data) {
                    $("#Price").val(data);
                    $("#StoreId").val("1");
                });
            }
            else {
                $("#Quantity").val("");
                $("#Price").val("");
            }
        }
    });
    $(".AutoCompleteModel").combobox({

        select: function (event, ui) {
            if ($('#ModelId').val().trim() != '0') {
                ajaxRequest("post", "../ManageCRM_PricingOffer/GetItemData?ItemId=" + $("#ModelId").val(), $("#ModelId").val(), 'JSON').done(function (data) {
                    $("#Price").val(data["Price"]);
                    $("#OriginalPrice").val(data["Price"]);
                    $("#NameAr").val(data["NameAr"]);
                    $("#NameEn").val(data["NameEn"]);
                    $("#ModelName").val(data["Model"]);
                    $("#Quantity").val(1);
                    $("#TotalPrice").val(data["Price"]);
                    $("#DiffPercent").val(0);
                    $("#DiffAmount").val(0);
                    
                });
            }
            else {
              
                $("#NameAr").val("");
                $("#NameEn").val("");
                $("#Price").val("");
                $("#OriginalPrice").val("");
                $("#ModelName").val("");
                $("#Quantity").val("");
            }
        }
    });
    $(".AutoCompleteModel2").combobox({

        select: function (event, ui) {
            if ($('#ModelIdVm').val().trim() != '0') {


                ajaxRequest("post", "../../../CRMAdmin/ManageCRM_PricingOffer/GetItemData?ItemId=" + $("#ModelIdVm").val(), $("#ModelIdVm").val(), 'JSON').done(function (data) {
                    $("#PriceVm").val(data["Price"]);
                    $("#OriginalPriceVm").val(data["Price"]);
                    $("#NameArVm").val(data["NameAr"]);
                    $("#NameEnVm").val(data["NameEn"]);
                    $("#ModelNameVm").val(data["Model"]);
                    $("#QuantityVm").val(1);
                    $("#TotalPriceVm").val(data["Price"]);
                    $("#DiffPercentVm").val(0);
                    $("#DiffAmountVm").val(0);
                    

                });
            }
            else {

                $("#NameArVm").val("");
                $("#NameEnVm").val("");
                $("#PriceVm").val("");
                $("#OriginalPriceVm").val("");
                $("#ModelNameVm").val("");
                $("#QuantityVm").val("");
            }
        }
    });
    $(".AutoCompleteCustomerOfer").combobox({

        select: function (event, ui) {
            var CustomerId = $("#CustomerId").val();
            document.getElementById("CustomerOfferd").href = "../../CRMAdmin/ManageCRM_PricingOffer/CustomerSearch?CustomerId=" + CustomerId;
            ajaxRequest("Get", "../../CRMAdmin/ManageCRM_PricingOffer/getCustomerResponsibles?id=" + $("#CustomerId").val(), $("#CustomerId").val(), 'JSON').done(function (data) {
                $("#ResponsibleId").empty();
                $.each(data, function () {
                    $("<option />", {
                        val: this.Value,
                        text: this.Text
                    }).appendTo("#ResponsibleId");
                });
            });
           
        }
    });

    $(".AutoComplete4").combobox({

        select: function (event, ui) {
            if ($('#ERPItemsId').val().trim() != '0') {
                $("#Quantity").val("1");
                $("#ItemDiscountPercent").val("0");
                $("#StoreId").val("1");

                ajaxRequest("post", "../../ERPStock/ManageERPStock/GetItemPrice?ItemId=" + $("#ERPItemsId").val(), $("#ERPItemsId").val(), 'JSON').done(function (data) {
                    $("#Price").val(data);
                    $("#StoreId").val("1");
                });

                ajaxRequest("post", "../ERPInvoices/ManageERPSalesInvoice/GetItemBalance?ItemId=" + $("#ERPItemsId").val() + "&StoreId=" + $("#StoreId").val(), $("#ERPItemsId").val(), 'JSON').done(function (data) {
                    $("#itemBalane").val(data);
                });
            }
            else {
                $("#Quantity").val("");
                $("#Price").val("");
            }
        }
    });

    $(".AutoComplete").combobox(
        {
           

        });

});
