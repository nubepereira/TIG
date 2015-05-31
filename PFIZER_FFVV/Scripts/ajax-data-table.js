/************************************************************************
* ajax-data-table 1.0.5
* (c) by Dao Hai Nam, daohainam.com
************************************************************************/

var AjaxDataTable = function () {
};

AjaxDataTable.table_models = {};
AjaxDataTable.table_datas = {};
AjaxDataTable.settings = {};
AjaxDataTable.auto_increament_id = 0;

AjaxDataTable.generate_id = function () {
    var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
    var string_length = 4;
    var id = 'tid_' + AjaxDataTable.auto_increament_id + '_';

    AjaxDataTable.auto_increament_id++;

    for (var i = 0; i < string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length);
        id += chars.substring(rnum, rnum + 1);
    }

    return id;
};

AjaxDataTable.cellClickedHandler = function (id, column_index, row_index) {
    var table_model = AjaxDataTable.table_models[id];
    var table_data = AjaxDataTable.table_datas[id];
    
    if (table_model[column_index].type === "check") {
        var c = $("#" + id + " td[column='" + table_model[column_index].name + "'][row='" + row_index + "'] input.ajax-data-table-check[type='checkbox']");

        //c.prop("checked", !c.prop("checked"));
    }

    if ($.isFunction(AjaxDataTable.settings[id].onCellClicked)) {
        AjaxDataTable.settings[id].onCellClicked(table_model[column_index], table_data, row_index);
    }
};

AjaxDataTable.headerClickedHandler = function (id, column_index) {
    var table_model = AjaxDataTable.table_models[id];
    var table_data = AjaxDataTable.table_datas[id];

    var processEvent = true;
    
    if ($.isFunction(AjaxDataTable.settings[id].onHeaderClicked)) {
        processEvent = AjaxDataTable.settings[id].onHeaderClicked(table_model[column_index], table_data);
    }

    if (processEvent) {
        if (table_model[column_index].sorting_enabled) {
            if (AjaxDataTable.settings[id].sort_by === table_model[column_index].name) {
                if (AjaxDataTable.settings[id].sort_direction === "a") {
                    AjaxDataTable.settings[id].sort_direction = "d";
                }
                else {
                    AjaxDataTable.settings[id].sort_direction = "a";
                }
            }
            else {
                AjaxDataTable.settings[id].sort_by = table_model[column_index].name;
                AjaxDataTable.settings[id].sort_direction = "a";
            }

            AjaxDataTable.go_to_page(id, table_data.current_page);
        }
    }    
};

AjaxDataTable.defaultTableModelProvider = function (url, onsuccess, onerror) {
    if (!$.isFunction(onsuccess) || url == null) {
        return;
    }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'POST',
        data: {
            m: true
        },
        success: function (table_model) {
            onsuccess(table_model);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if ($.isFunction(onerror))
            {
                onerror(jqXHR, textStatus, errorThrown);
            }
        }
    });
}

AjaxDataTable.defaultTableDataProvider = function (url, params, onsuccess, onerror) {
    if (!$.isFunction(onsuccess) || url == null) {
        return;
    }

    $.ajax({
        url: url,
        dataType: 'json',
        type: 'POST',
        data: params,
        success: function (table_model) {
            onsuccess(table_model);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if ($.isFunction(onerror)) {
                onerror(jqXHR, textStatus, errorThrown);
            }
        }
    });
}

AjaxDataTable.RowDraggedHandler = function (id, item) {
    var table_model = AjaxDataTable.table_models[id];
    var table_data = AjaxDataTable.table_datas[id];
    //console.log(item);
    if ($.isFunction(AjaxDataTable.settings[id].onRowDragged)) {
        var org_row_index = item.context.attributes.row.value;
        var new_row_index = item.context.rowIndex - 1;

        AjaxDataTable.settings[id].onRowDragged(table_data, org_row_index, new_row_index);
    }
};

AjaxDataTable.call_bulk_action = function (id, index) {
    var settings = AjaxDataTable.settings[id];
    var data = AjaxDataTable.table_datas[id].data;

    if (index < 0 || settings === null || settings.bulkActions === null || index >= settings.bulkActions.length) {
        console.error("Invalid settings");
        return;
    }

    if ($.isFunction(settings.bulkActions[index].handler)) {
        var checked_boxes = $("#" + id + " input.ajax-data-table-check[type='checkbox']:checked");
        var checked_rows = [];

        checked_boxes.each(function (idx, element) {
            var row = $(this).parents("td[row][column='_check']").attr("row");

            if (row >= 0 && row < data.length)
                checked_rows.push(data[row]);
        });

        settings.bulkActions[index].handler(checked_rows);
    }
};

AjaxDataTable.defaultHeaderCellRenderer = function (column_model) {
    if (column_model.type === "check") {
        return "<input type='checkbox' class='ajax-data-table-check-all' table='" + column_model.table_model.id + "' column='" + column_model.name + "' />";
    }
    else {
        return column_model.title;
    }
};

AjaxDataTable.defaultCellRenderer = function (column_model, table_data, row_index) {
    var value;

    if (column_model === null || table_data === null || table_data.data === null || row_index < 0 || row_index >= table_data.data.length)
        return "";

    var data = table_data.data;

    if (column_model.type === "bool") {
        var v = data[row_index][column_model.name];

        if (v === true) {
            value = "<div class=\"ajax-data-table-true\">&nbsp;<div/>";
        }
        else if (v === false) {
            value = "<div class=\"ajax-data-table-false\">&nbsp;</div>";
        }
        else
            value = v;
    }
    else if (column_model.type === "check") {
        return "<input type='checkbox' class='ajax-data-table-check' />";
    }
    else if (column_model.type === "index") {
        return row_index + (table_data.current_page * table_data.page_size) + 1;
    }
    else {
        value = data[row_index][column_model.name];
    }

    return value;
};

AjaxDataTable.defaultSummaryRenderer = function (column_model, table_data, value) {
    return value;
}

AjaxDataTable.render_table = function (id, model, table_data, sort_by, width) {
    if (model === null || model.length === null) {
        alert("AjaxDataTable: invalid data model");
        return "";
    }

    var html = "";
    var data = table_data.data;

    html += "<table class=\"ajax-data-table-grid\" width=\"" + width + "\"><thead>";
    for (var column = 0; column < model.length; column++) {
        if (model[column].visible) {
            var column_title = AjaxDataTable.settings[id].headerCellRenderer(model[column]);

            html += "<th " + (model[column].width != null ? ("style=\"width: " + model[column].width + "\"") : "") + " onclick='AjaxDataTable.headerClickedHandler(\"" + id + "\", " + column + ");'";

            if (model[column].sorting_enabled) {
                html += " class='ajax-data-table-sortable'";
            }
            html += "><div>";

            html += column_title;

            if (model[column].sorting_enabled) {

                if (model[column].name == AjaxDataTable.settings[id].sort_by) {
                    if (AjaxDataTable.settings[id].sort_direction == "a") {
                        html += "<div class='ascending'></div>";
                    }
                    else {
                        html += "<div class='descending'></div>";
                    }

                }

                html += "</div>";
            }
            html += "</div></th>";
        }
    }
    html += "</thead>";

    //alert(JSON.stringify(data));
    if (data != null && data.length) {
        html += "<tbody>";
        for (i = 0; i < data.length; i++) {
            html += "<tr row='" + i + "'>";
            for (var column = 0; column < model.length; column++) {
                if (model[column].visible) {
                    var value = AjaxDataTable.settings[id].cellRenderer(model[column], table_data, i);
                    var cellClickAction = '';
                    var cls = "";

                    if ($.isFunction(AjaxDataTable.settings[id].onRowDragged) && model[column].type == "index") {
                        cls += " ajax-data-table-drag-hanlder";
                    }

                    if ($.isFunction(AjaxDataTable.settings[id].onCellClicked) && model[column].type != "check") {
                        cls += " ajax-data-table-clickable";
                        cellClickAction = " onclick='AjaxDataTable.cellClickedHandler(\"" + id + "\", " + column + ", " + i + ");' ";
                    }

                    html += "<td align='" + model[column].align + "'" + cellClickAction + " column='" + model[column].name + "' row='" + i + "' class='" + cls + "'> " + value + " </td>"; // alert(html);
                }
            }
            html += "</tr>";
        }
        html += "</tbody>";
    }

    if (table_data.summary != null) {
        var hasSummary = false;

        var summaryHtml = "<tr>";
        for (var column = 0; column < model.length; column++) {
            if (model[column].visible) {
                var summaryValue = AjaxDataTable.settings[id].summaryRenderer(model[column], table_data, table_data.summary[model[column].name]);

                if (summaryValue == null) {
                    summaryValue = "";
                }
                summaryHtml += "<td align='" + model[column].align + "' column='" + model[column].name + "' class='ajax-data-table-summary'> " + summaryValue + " </td>";

                hasSummary = true;
            }
        }
        summaryHtml += "</tr>";

        if (hasSummary)
            html += summaryHtml;
    }

    html += "</table>";
    return html;
};

AjaxDataTable.render_page_index = function (id, current_page, total_page, page_size, total) {
    var paging_html = "<div class=\"pagination\">";
    var texts = AjaxDataTable.settings[id].texts;

    if (current_page === 0)
        paging_html += "<li class=\"previous-off\">" + texts.previous + "</li>";
    else
        paging_html += "<li class=\"previous\"><a href=\"#\" onclick=\"AjaxDataTable.go_to_page('" + id + "', " + (current_page - 1) + "); event.preventDefault();\">" + texts.previous + "</a></li>";

    var paging_list_html = "<div>" + texts.page + " <select onchange=\"AjaxDataTable.go_to_page('" + id + "', this.options[this.selectedIndex].value); event.preventDefault();\">";

    var last_i = 0;
    for (var i = 0; i < total_page; i++) {
        if (Math.abs(last_i - i) === 2)
            paging_html += "<li>...</li>";

        if (i === 0 || i == (total_page - 1) || (Math.abs(current_page - i) <= 3)) {
            paging_html += "<li><a href=\"#\" " + ((current_page === i) ? "class=\"active\"" : "") + "\" onclick=\"AjaxDataTable.go_to_page('" + id + "', " + i + "); event.preventDefault();\">" + (i + 1) + "</a></li>";
            last_i = i;
        }

        paging_list_html += "<option value=\"" + i + "\" " + (i == current_page ? "selected='selected'" : "") + ">" + (i + 1) + "</option>";
    }

    paging_list_html += "</select></div>";

    if (current_page < total_page - 1)
        paging_html += "<li class=\"next\"><a href=\"#\" onclick=\"AjaxDataTable.go_to_page('" + id + "', " + (current_page + 1) + "); event.preventDefault();\">" + texts.next + "</a> </li>";
    else
        paging_html += "<li class=\"next-off\">" + texts.next + "</li>";

    paging_html += paging_list_html;
    //paging_html += "<br/>";

    var start = current_page * page_size;
    var display_text = texts.display.replace("{start}", (start + 1)).replace("{end}", (start + page_size >= total ? total : (start + page_size))).replace("{total}", total);

    paging_html += "<label>" + display_text + "</label>";

    paging_html += "</div>";
    return paging_html;
};

AjaxDataTable.render_bulk_actions = function (id, actions) {
    var html = "";

    if (actions == null || !$.isArray(actions))
        return html;
    if (actions.length <= 0)
        return html;

    html = "<ul class='ajax-data-table-bulk-actions'>";
    for (var i = actions.length - 1; i >= 0 ; i--) {

        if (actions[i].title != null && $.isFunction(actions[i].handler)) {
            html += "<li><a href='#' onclick='AjaxDataTable.call_bulk_action(\"" + id + "\", " + i + "); event.preventDefault();'>" + actions[i].title + "</a></li>";
        }
    }
    html += "</ul>";
    //console.log(html);
    return html;
};

AjaxDataTable.render_with_page = function (id, url, page) {
    //get table model
    var table_container = $("#" + id + ".ajax-data-table-container");
    //console.log(id + ":" + AjaxDataTable.settings[id]);
    
    AjaxDataTable.settings[id].modelProvider(url,
        function (table_model) {
            var params = {
                page: page,
                sort_by: AjaxDataTable.settings[id].sort_by,
                sort_direction: AjaxDataTable.settings[id].sort_direction
            };
            var onQuery = AjaxDataTable.settings[id].onQuery;

            if ($.isFunction(onQuery)) {
                //alert(JSON.stringify(onQuery()));

                var onQuery_result = onQuery();
                if (onQuery_result !== null && $.isPlainObject(onQuery_result)) {
                    params = $.extend(onQuery_result, params);
                }
            }

            //console.log(params);
            AjaxDataTable.settings[id].dataProvider(
                url, params,
                function (table_data) {
                    table_data.id = id;
                    table_model.id = id;
                    for (var column = 0; column < table_model.length; column++) {
                        table_model[column].table_model = table_model;
                    }

                    AjaxDataTable.table_models[id] = table_model;
                    AjaxDataTable.table_datas[id] = table_data;

                    if (table_data.sort_by != null) {
                        AjaxDataTable.settings[id].sort_by = table_data.sort_by;
                        AjaxDataTable.settings[id].sort_direction = table_data.sort_direction;
                    } else {
                        AjaxDataTable.settings[id].sort_by = null;
                        AjaxDataTable.settings[id].sort_direction = null;
                    }

                    if ($.isFunction(AjaxDataTable.settings[id].onPreRender)) {
                        AjaxDataTable.settings[id].onPreRender(id, table_model, table_data);
                    }

                    var table_html = AjaxDataTable.render_table(id, table_model, table_data, "", AjaxDataTable.settings[id].width); //alert(JSON.stringify(table_data));

                    if (table_data.total_page === 0)
                        table_data.total_page = 1;

                    var paging_html = AjaxDataTable.render_page_index(id, table_data.current_page, table_data.total_page, table_data.page_size, table_data.total);
                    var bulk_actions_html = AjaxDataTable.render_bulk_actions(id, AjaxDataTable.settings[id].bulkActions);

                    table_container.attr("page", page);
                    table_container.html(paging_html + "<br class=\"ajax-data-table-break\" />" + table_html + bulk_actions_html + "<br class=\"ajax-data-table-break\" />" + paging_html);

                    //
                    $("input.ajax-data-table-check-all[type='checkbox']", table_container).change(function () {
                        var table = $(this).attr("table");
                        var column = $(this).attr("column");

                        var checked = this.checked;

                        var t = $("#" + id + ".ajax-data-table-container");
                        $("td[column='" + column + "'] input.ajax-data-table-check[type='checkbox']", t).prop("checked", checked);
                    });

                    if ($.isFunction(AjaxDataTable.settings[id].onLoaded)) {
                        AjaxDataTable.settings[id].onLoaded();
                    }


                    if ($.isFunction(AjaxDataTable.settings[id].onRowDragged)) {
                        $("table.ajax-data-table tbody").sortable({
                            helper: function (e, ui) {
                                ui.children().each(function () {
                                    $(this).width($(this).width());
                                });
                                return ui;
                            },
                            opacity: 0.5,
                            handle: ".ajax-data-table-drag-hanlder",
                            stop: function (event, ui) {
                                AjaxDataTable.RowDraggedHandler(id, ui.item);
                            }
                        });
                    }
                },
                function (jqXHR, textStatus, errorThrown) {
                    console.error(errorThrown);
                }
            );
        },
        function (jqXHR, textStatus, errorThrown) {
            //table_container.html("<div class='error'>" + errorThrown + "</div>");
            //console.error(errorThrown);
        }
    );
};

AjaxDataTable.go_to_page = function (id, page) {
    var table_container = $("#" + id);

    AjaxDataTable.render_with_page(id, table_container.attr("href"), page);
};

AjaxDataTable.defaults = {
    width: "100%",
    headerCellRenderer: AjaxDataTable.defaultHeaderCellRenderer,
    cellRenderer: AjaxDataTable.defaultCellRenderer,
    summaryRenderer: AjaxDataTable.defaultSummaryRenderer,
    onCellClicked: null, //column_model, table_data, row_index
    onHeaderClicked: null, //column_model, table_data
    onRowDragged: null, //table_data, row_index, to_row_index
    onQuery: function () {
        return null;
    },
    onPreRender: function (id, model, table_data) {
        return null;
    },
    onLoaded: function () {
        //do nothing
    },
    modelProvider: AjaxDataTable.defaultTableModelProvider,
    dataProvider: AjaxDataTable.defaultTableDataProvider,
    bulkActions: null,
    sort_by: null,
    sort_direction: "a",
    texts: {
        next: "Next »",
        previous: "« Previous",
        page: "Page",
        display: "Displayed from {start} to {end} out of {total}"
    }
};

AjaxDataTable.render = function (o, options) {
    
    if (o === null || o.length === null || o.length === 0)
        return;
    if (options === null || options === undefined || $.isPlainObject(options)) {
        //var settings = AjaxDataTable.defaults;

        o.each(function (index, element) {
            var settings = $.extend({}, AjaxDataTable.defaults, options);
            var obj = $(this);

            var url = obj.attr("href");
            var table_id = obj.attr("table-id");

            if (url == null || url === "") {
                console.log("Skip ajax-data-table rendering because missing href");
                return;
            }

            if (table_id == null) {
                //var table_container = $("#" + table_id + ".ajax-data-table-container", obj.parent());
                //if (table_container.length == 0) {
                table_id = AjaxDataTable.generate_id();

                obj.after("<div class='ajax-data-table-container' href='" + url + "' id='" + table_id + "'></div>");
                obj.attr("table-id", table_id);

                table_container = $("div.ajax-data-table-container", obj.parent());

                settings.table_id = table_id;
                AjaxDataTable.settings[table_id] = settings;
                //}
            }

            AjaxDataTable.render_with_page(table_id, url, 0);
        });

    }
    else {
        var action = options;
        if (action != "refresh") {
            console.error("Invalid action"); return;
        }
        
        o.each(function (index, element) {

            var obj = $(this);

            var url = obj.attr("href");
            var table_id = obj.attr("table-id");

            if (table_id == null) {
                console.log("Skip ajax-data-table rendering because it is not initialized");
                return;
            }

            if (url == null || url == "") {
                console.log("Skip ajax-data-table rendering because missing href");
                return;
            }

            var table_container = $("#" + table_id + ".ajax-data-table-container", obj.parent());

            if (table_container.length == 1) {
                if (action == "refresh") {
                    var id = table_container.attr("id");
                    var href = table_container.attr("href");
                    var page = obj.attr("page");
                    if (!$.isNumeric(page)) {
                        page = 0;
                    }

                    AjaxDataTable.render_with_page(id, href, page);
                }
            }
        });
    }

};

$(function () {
    //console.log($(".ajax-data-table"));
    AjaxDataTable.render($(".ajax-data-table[href]"));
});