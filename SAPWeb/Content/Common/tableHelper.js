function RenameCloneIdsAndNames(objClone, removeData) {
    var isChildTable = false;
    if (objClone.hasClass('innerRow'))
        isChildTable = true;
    var dataRowId = 0;
    if (!objClone.attr('data-row-id')) {
        console.error('Cloned object must have \'data-row-id\' attribute.');
    }
    dataRowId = objClone.attr('data-row-id')
    if (removeData)
        dataRowId = parseInt(dataRowId) + 1;
    if (objClone.attr('id')) {
        objClone.attr('id', objClone.attr('id').replace(/\d+$/, function (strId) { return dataRowId; }));
    }

    objClone.attr('data-row-id', objClone.attr('data-row-id').replace(/\d+$/, function (strId) { return dataRowId; }));

    objClone.find('[data-id]').each(function () {
        var strNewId = $(this).attr('data-id').replace(/\d+$/, function (strId) { return dataRowId; });
        $(this).attr('data-id', strNewId);
    });

    /* To Remove disabled attributes from textbox Start */
    objClone.find('td input').each(function () {
        var strNewId = $(this).removeAttr('disabled');
    });
    /* End */
    objClone.find('[id]').each(function () {
        var obj = $(this);
        var dotCount = 0;
        var strNewName;
        if (obj.attr('name')) {
            dotCount = obj.attr('name').count('.');
            if (dotCount >= 2) {
                var arr = obj.attr('name').split('.');
                var left = "", right = "";
                for (var i = 0; i < arr.length; i++) {
                    if (i < dotCount - 1)
                        left += arr[i] + '.';
                    else
                        right = (right == "" ? arr[i] : (right + '.' + arr[i]));
                }
                if (!isChildTable)
                    strNewName = (left.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return '[' + intNumber + ']'
                    })) + right;
                else
                    strNewName = left + (right.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return '[' + intNumber + ']'
                    }));
            }
            else {
                strNewName = obj.attr('name').replace(/[\d[\]']+/g, function (strName) {
                    strName = strName.replace(/[\[\]']+/g, '');
                    var intNumber = dataRowId;
                    return '[' + intNumber + ']'
                });
            }
            obj.attr('name', strNewName);
        }


        if (obj.attr('id')) {
            if (dotCount >= 2) {
                var arr = obj.attr('id').split('_');
                var a = obj.closest('table').Id;
                var left = "", right = "";
                for (var i = 0; i < arr.length; i++) {
                    if (i < dotCount)
                        left += arr[i] + '_';
                    else
                        right = (right == "" ? arr[i] : (right + '_' + arr[i]));
                }
                if (!isChildTable)
                    strNewName = (left.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return intNumber
                    })) + right;
                else
                    strNewName = left + (right.replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return intNumber
                    }));

                strNewName = strNewName.replace(/\./g, '_').replace(/\[/g, '').replace(/\]/g, '');
            }
            else {
                strNewName = obj.attr('id').replace(/\d+$/, function (strId) { return dataRowId; })
            }
            obj.attr('id', strNewName);

            if (removeData) {

                if (obj.attr('id').substring(0, 3) == 'ddl' && !obj.IsEnabled)
                    obj.val(obj.val());
                else if (obj.hasClasses(['numeric', 'numeric2', 'numeric3']))
                    obj.val(0);
                else if (obj.hasClasses(['numericdecimal', 'numericdecimalnegativeallow']))
                    obj.val(0.0);
                else if (obj.attr('id').substring(0, 3) == 'lbl')
                    obj.text('');
                else if (obj.attr('id').substring(0, 3) == 'chk') {
                    obj.prop('checked', false);
                    var dv = obj.closest('div.checkbox');
                    dv.find('.icheckbox_minimal-blue').remove();
                    obj.appendTo(dv);
                }
                else if (obj.hasClasses(['subItem'])) {
                    obj.prop('disabled', 'disabled');
                    obj.removeAttr('onclick')
                }
                else if (obj.attr('id').substring(0, 2) == 'rd') {
                    obj.prop('checked', false);
                    var dv = obj.closest('div.radio');
                    dv.find('.iradio_minimal-blue').remove();
                    obj.appendTo(dv);
                }
                else
                    obj.val('');
            }
        }

        if (obj.attr('for')) {
            var strNewfor = obj.attr('for').replace(/\d+$/, function (strId) { return dataRowId; });
            obj.attr('for', strNewfor);
        }

        var span = obj.nextAll('span');
        if (span) {
            if (span.length == 0)
                span = obj.nextAll('div').find('span').first();
            if (span.hasAttr('data-valmsg-for')) {
                var strNewName;
                var dotCount = span.attr('data-valmsg-for').count('.');
                if (dotCount >= 2) {
                    var arr = span.attr('data-valmsg-for').split('.');
                    var left = "", right = "";
                    for (var i = 0; i < arr.length; i++) {
                        if (i < dotCount - 1)
                            left += arr[i] + '.';
                        else
                            right = (right == "" ? arr[i] : (right + '.' + arr[i]));
                    }
                    if (!isChildTable)
                        strNewName = (left.replace(/[\d[\]']+/g, function (strName) {
                            strName = strName.replace(/[\[\]']+/g, '');
                            var intNumber = dataRowId;
                            return '[' + intNumber + ']'
                        })) + right;
                    else
                        strNewName = left + (right.replace(/[\d[\]']+/g, function (strName) {
                            strName = strName.replace(/[\[\]']+/g, '');
                            var intNumber = dataRowId;
                            return '[' + intNumber + ']'
                        }));
                }
                else {
                    strNewName = span.attr('data-valmsg-for').replace(/[\d[\]']+/g, function (strName) {
                        strName = strName.replace(/[\[\]']+/g, '');
                        var intNumber = dataRowId;
                        return '[' + intNumber + ']'
                    });
                }
                span.attr('data-valmsg-for', strNewName);
                if (removeData)
                    span.html('');
            }
        }
    });
    return objClone;
}

function ManageTableAddRemove(tableId, allowDeleteAll) {
    allowDeleteAll = (allowDeleteAll != undefined && allowDeleteAll != null) ? allowDeleteAll : false;
    var rowCount = $('#' + tableId).rowCount();
    var rowIndex = 0;
    $('#' + tableId + ' > tbody > tr').each(function () {
        $(this).attr('data-row-id', rowIndex);
        RenameCloneIdsAndNames($(this), false);
        $(this).find('#lblSrNo_' + rowIndex).text(rowIndex+1);
        $(this).find('[id=btnAdd]').hide();
        if (!allowDeleteAll)
            $(this).find('[id=btnRemove]').show();
        rowIndex++;
    });
    if (rowCount == 1) {
        $('#' + tableId + ' > tbody > tr:last').find('[id=btnAdd]').show();
        if (!allowDeleteAll)
            $('#' + tableId + ' > tbody > tr:last').find('[id=btnRemove]').hide();
    }
    $('#' + tableId + ' > tbody > tr:last').find('[id=btnAdd]').show();
    disableDiv();
}

function AddTableRow(tableId, allowDeleteAll, asFirstRow) {
    if (IsObjectNullOrEmpty(asFirstRow)) asFirstRow = false;
    var trFirst = $('#' + tableId + ' > tbody > tr:first');
    var trLast = $('#' + tableId + ' > tbody > tr:last');
    var trNew = trFirst.clone();

    //var radios = trFirst.find('input[type="radio"]');
    //var radioData = [];
    //if (radios.length > 0) {
    //    radios.each(function (i, item) {
    //        rd = $(this);
    //        radioData.push({ Id: rd.Id, IsChecked: rd.IsChecked });
    //    })
    //}

    if (asFirstRow) {
        trFirst.before(trNew);
        trNew.attr('data-row-id', '-1');
    }
    else {
        RenameCloneIdsAndNames(trNew, true);
        if (trNew.attr('data-row-id'))
            trLast.after(trNew);
    }

    ManageTableAddRemove(tableId, allowDeleteAll);

    //setTimeout(function () { $('#' + objid).check(false); }, 1);

    //$('#' + tableId).find('input[type="checkbox"], input[type="radio"]').iCheck({
    //    checkboxClass: "icheckbox_minimal-blue",
    //    radioClass: "iradio_minimal-blue"
    //});
    //RegisterDynamicValidation($('#' + tableId));

    trLast = $('#' + tableId + ' > tbody > tr:last');
    var elements = trLast.find(':text,:radio,:checkbox,select,textarea').filter(function () {
        return !this.readOnly &&
            !this.disabled &&
            $(this).parentsUntil('form', 'div').css('display') != "none";
    });
    if (elements.length > 0)
        elements[0].focus();

    trLast.find('input:first(:visible,not:disabled)').focus();
    $('#' + tableId + ' > tbody > tr:last').find('[id*=chk]').val('true');

    //$('#' + tableId + ' > tbody > tr:last').find('input[type="checkbox"]').check(false);

    //first = $('#' + tableId + ' > tbody > tr:first')
    //$.each(radioData, function (i, item) {
    //    if (item.IsChecked) {
    //        var rd = first.find('[id*="' + item.Id + '"]');
    //        $('#' + tableId + ' > tbody > tr').find('[name="' + rd.attr('name') + '"]').check(false).removeAttr('checked');
    //        first.find('[id*="' + item.Id + '"]').check(item.IsChecked);
    //    }
    //});

    return false;
}

function RemoveTableRowXXX(object, allowDeleteAll, fnInitTable) {
    allowDeleteAll = (allowDeleteAll != undefined && allowDeleteAll != null) ? allowDeleteAll : false;

    var tr = object.closest('tr');
    var table = tr.closest('table');
    var rowCount = table.rowCount();

    if (rowCount == 1) {
        if (allowDeleteAll) {
            if (!confirm('Are you sure that you want to remove last record?'))
                return false;
        }
        else {
            ShowMessage('You cannot remove last record');
            return false;
        }
    }
    tr.remove();
    rowCount = table.rowCount();

    if (fnInitTable == null || fnInitTable == '' || fnInitTable == undefined)
        InitTable();
    else
        fnInitTable.call(this, table.Id);
    trLast = $('#' + table.Id + ' > tbody > tr:last');
    trLast.find('input:first').focus();
    return false;
}

function RemoveTableRow(object, allowDeleteAll, fnInitTable) {
    allowDeleteAll = (allowDeleteAll != undefined && allowDeleteAll != null) ? allowDeleteAll : false;

    var deletedRecord = false;
    var tr = object.closest('tr');
    var table = tr.closest('table');
    var rowCount = table.rowCount();

    if (fnInitTable == null || fnInitTable == '' || fnInitTable == undefined)
        InitTable();
    else
        deletedRecord = fnInitTable.call(object, table.Id);
    console.log("msg1 " + deletedRecord);
    if (deletedRecord) {
        if (rowCount == 1) {
            if (allowDeleteAll) {
                if (!confirm('Are you sure that you want to remove last record?'))
                    return false;
            }
            else {
                ShowMessage('You cannot remove last record');
                return false;
            }
        }
        tr.remove();
        rowCount = table.rowCount();


        trLast = $('#' + table.Id + ' > tbody > tr:last');
        trLast.find('input:first').focus();
        disableDiv();
        return false;
    }

}

function InitGrid(objId, allowDeleteAllRow, actionColumnIndex, rowEventFunction, addBtn, deleteBtn) {

    var tbl = $('#' + objId);

    tbl.addClass('table nowrap table-bordered table-striped table-condensed');

    tbl.closest('div').addClass('no-more-tables');

    $('#' + objId + ' > tbody > tr:last').attr('data-row-id', '0');
    $('#' + objId + ' > thead > th').css("tabindex", "-1");

    var fnName = arguments[3].name;

    var buttons = '';
    if (addBtn)
        buttons += '<button type="button" id="btnAdd" onclick="return AddGridRow($(this),\'' + objId + '\',' + allowDeleteAllRow + ',' + fnName + ')" class="btn btn-primary btn-sm dt-edit btn-ripple"><span class="glyphicon glyphicon-plus-sign"></span></button>';
    if (deleteBtn)
        buttons += '<button type="button" id="btnRemove" onclick="return RemoveGridRow($(this),\'' + objId + '\',' + allowDeleteAllRow + ',' + fnName + ')" class="btn btn-danger btn-sm dt-delete btn-ripple" style="margin-left: 3px;"><span class="glyphicon glyphicon-trash"></span></button>';

    $('#' + objId + ' > tbody > tr').each(function () {
        $(this).find('td:eq(' + actionColumnIndex + ')').html(buttons).css("min-width", "85px");
    });

    ManageTableAddRemove(objId, allowDeleteAllRow);

    if (rowEventFunction != null && rowEventFunction != '' && rowEventFunction != undefined)
        rowEventFunction.call(this, objId);

    return tbl;
}

function AddGridRow(btn, objId, allowDeleteAllRow, rowEventFunction, asFirstRow) {
    if (IsObjectNullOrEmpty(asFirstRow)) asFirstRow = false;
    AddTableRow(objId, allowDeleteAllRow, asFirstRow);
    rowEventFunction.call(btn, objId);
}

function RemoveGridRow(btn, objId, allowDeleteAllRow, rowEventFunction) {
    RemoveTableRow(btn, allowDeleteAllRow, rowEventFunction);
    ManageTableAddRemove(objId, allowDeleteAllRow);
}