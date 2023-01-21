/// <reference path="autocomplete.js" />
/// <reference path="autocomplete.js" />
$(function () {
    $.widget("custom.combobox", {
        _create: function () {
            //    this.wrapper = $("<span style='width:400px;' id='d'>")
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

            this.input = $("<input id='auto'>")
              .appendTo(this.wrapper)
              .val(value)
              //.attr("title", "")
                .attr("placeholder", " -- اختر -- ")
              .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                 .addClass("form-control")
              .autocomplete({
                  delay: 0,
                  minLength: 0,
                  selectFirst: true,
                  //appendTo : _parentElement,
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
    $(".AutoComplete11").combobox({

        select: function (event, ui) {
            $('.type').hide();
            $('#' + $(this).val()).show(500);
        }
    });
   
    $(".AutoCompleteCustomer").combobox({

        select: function (event, ui) {
            ajaxRequest("post", "../ManageCRMInstallation/GetCustomerData?CustumerId=" + $("#CustomerId").val(), $("#CustomerId").val(), 'JSON').done(function (data) {
                $("#Mobile").val(data["Mobile"]);
                $("#CityId").val(data["CityId"]);
            });
        }
    });
    $(".AutoCompleteCustomer").combobox({

        select: function (event, ui) {
            ajaxRequest("post", "../ManageCRMInstallation/GetCustomerData?CustumerId=" + $("#CustomerId").val(), $("#CustomerId").val(), 'JSON').done(function (data) {
                $("#Mobile").val(data["Mobile"]);
                $("#CityId").val(data["CityId"]);
            });
        }
    });
    $(".AutoCompleteCustomer2").combobox({

        select: function (event, ui) {
            ajaxRequest("post", "../ManageCRMInstallation/GetCustomerData?CustumerId=" + $("#MainCustomerId").val(), $("#MainCustomerId").val(), 'JSON').done(function (data) {
                $("#MainMobile").val(data["Mobile"]);
                $("#MainCityId").val(data["CityId"]);
            });
        }
    });
    $(".AutoCompleteCustomer3").combobox({

        select: function (event, ui) {
            ajaxRequest("post", "../ManageCRMInstallation/GetCustomerData?CustumerId=" + $("#PrevCustomerId").val(), $("#PrevCustomerId").val(), 'JSON').done(function (data) {
                $("#PrevMobile").val(data["Mobile"]);
                $("#PrevCityId").val(data["CityId"]);
            });
        }
    });
    $(".AutoCompleteAll").combobox(
        {
            


        });

});
