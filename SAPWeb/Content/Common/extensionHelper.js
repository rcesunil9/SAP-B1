$.fn.extend({
    hasClasses: function (classes) {
        var self = this;
        var result = false;
        $.each(classes, function (i, item) {
            if ($(self).hasClass(item))
                result = true;
        });
        return result;
    },
    whichClass: function (classes) {
        var self = this;
        var result = false;
        $.each(classes, function (i, item) {
            if ($(self).hasClass(item))
                result = item;
        });
        return result;
    }
});

//$.fn.check = function (isChecked) {
//    if (isChecked === undefined || isChecked === null) isChecked = true;
//    this.prop('checked', isChecked).iCheck('update');
//    return this;
//};

//$.fn.uncheck = function () {
//    this.prop('checked', false).iCheck('update');
//    return this;
//};

$.fn.enable = function (isEnable) {
    if (isEnable === undefined || isEnable === null) isEnable = true;
    this.prop('disabled', !isEnable);
    return this;
};

$.fn.disable = function () {
    this.prop('disabled', true);
    return this;
};

$.fn.readOnly = function (isReadOnly) {
    if (isReadOnly === undefined || isReadOnly === null) isReadOnly = true;
    if (isReadOnly)
        $(this).attr('readOnly', 'readOnly').attr('tabindex', '-1');
    else
        $(this).removeAttr('readOnly').removeAttr('tabindex');
    return this;
};

$.fn.showHide = function (isShow) {
    if (isShow) this.show(); else this.hide();
    return this;
};

$.fn.hasAttr = function (name) {
    return this.attr(name) !== undefined;
}

$.dtAddData = function (dt, data) {
    dt.clear().draw();
    dt.rows.add(data).draw();
};

$.fn.rowCount = function () {
    return $('#' + $(this).attr('id') + ' > tbody > tr').length;
};

$.fn.toFloat = function () {
    var number = $(this).val().trim();
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    return parseFloat(number);
};

$.fn.toInt = function () {
    var number = $(this).val().trim();
    if (number == "")
        number = 0;
    else
        number = number.toString().replace(/[^\d\.\-]/g, '');
    return parseInt(number, 10);
};

String.prototype.count = function (char) {
    var strArr = this.split(char);
    return strArr.length - 1;
}

Object.defineProperty(Object.prototype, "IsChecked", {
    get: function () {
        return this.is(':checked');
    }
});

Object.defineProperty(Object.prototype, "IsEnabled", {
    get: function () {
        return !$(this).prop('disabled');
    }
});

Object.defineProperty(Object.prototype, "Id", {
    get: function () {
        return $(this).attr('id');
    }
});

Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}

String.prototype.toDate = function (format) {
    var normalized = this.replace(/[^a-zA-Z0-9]/g, '-');
    var normalizedFormat = format.toLowerCase().replace(/[^a-zA-Z0-9]/g, '-');
    var formatItems = normalizedFormat.split('-');
    var dateItems = normalized.split('-');

    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var hourIndex = formatItems.indexOf("hh");
    var minutesIndex = formatItems.indexOf("ii");
    var secondsIndex = formatItems.indexOf("ss");

    var today = new Date();

    var year = yearIndex > -1 ? dateItems[yearIndex] : today.getFullYear();
    var month = monthIndex > -1 ? dateItems[monthIndex] - 1 : today.getMonth() - 1;
    var day = dayIndex > -1 ? dateItems[dayIndex] : today.getDate();

    var hour = hourIndex > -1 ? dateItems[hourIndex] : today.getHours();
    var minute = minutesIndex > -1 ? dateItems[minutesIndex] : today.getMinutes();
    var second = secondsIndex > -1 ? dateItems[secondsIndex] : today.getSeconds();
    return new Date(year, month, day, hour, minute, second);
};

