var datatable = {
    _register: function (url, urldata, tableId, columns, aoColumnDefs, dataTableLanguage, maxTableHeight, bPaginate, bFilter, bInfo) {
        ajaxRequest("POST", url, urldata).done(function (result) {
            var data = result.data;
            maxTableHeight = maxTableHeight || $(window).height() - 260 + "px";
            var allRequestsTable = enableDataTable(tableId, data, columns, aoColumnDefs, dataTableLanguage, maxTableHeight, bPaginate, bFilter, bInfo);
            $(window).resize(function (e) {
                resizeDataTable(allRequestsTable, maxTableHeight);
            });
        });
    },
    _enable: function (tableId) {
        var lastcolumn = $(tableId || "#SearchTable").find("thead tr:first th").length-1;
        $(tableId || "#SearchTable").DataTable({
            "language": rm.dataTableLanguage,
            "aoColumnDefs": [
                      { "bSortable": false, "aTargets": [lastcolumn] }
            ]
        });
    }
}
function enableDataTable(tableId, data, columns, aoColumnDefs, dataTableLanguage, maxTableHeight, bPaginate, bFilter, bInfo) {
    if (bPaginate == null) {
        bPaginate = true;
    }
    if (bFilter == null) {
        bFilter = true;
    }
    if (bInfo == null) {
        bInfo = true;
    }
    var datatable = $(tableId).on('order.dt', function () { iniDataTableActions(); })
            .on('search.dt', function () { iniDataTableActions(); })
            .on('page.dt', function () { iniDataTableActions(); })
        .dataTable({
            "language": dataTableLanguage,
            stateSave: true,
            "scrollY": maxTableHeight,
            "scrollCollapse": true,
            "processing": true,
            data: data,
            "columns": columns,
            "aoColumnDefs": aoColumnDefs,
            destroy: true,
            "bPaginate": bPaginate,
            "bFilter": bFilter,
            "bInfo": bInfo,
        });
    return datatable;
}

function iniDataTableActions() {
    $('.dataTable .actionsButton').unbind("click");
    $('.dataTable .actionsButton').click(function (e) {
        $(this).parent().find('.actions').stop().slideDown(250);
    });
    $('.dataTable .actions').unbind('mouseenter').unbind('mouseleave');
    $('.dataTable .actions').hover(
        function (e) {
        },
        function (e) {
            $(this).stop().slideUp(250);
        }
    );
    $(".dataTables_scrollBody").scrollTop(0);
}

function resizeDataTable(dataTable, maxTableHeight) {
    var oSettings = dataTable.fnSettings();
    oSettings.oScroll.sY = maxTableHeight;
    dataTable.fnDraw();
}