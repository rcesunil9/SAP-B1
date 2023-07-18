$(document).ready(function () {
    sapWEB.dialog.Init();
});
$(function () {
    $(".alpha").on('keypress', function (e) {
        validAlfaNum(e);
    })
    $(".numeric").on('keypress', function (e) {
        return validInt(e);
    })
    $(".numericdecimal").on('keypress', function (e) {
        return validFloat(e, $(this).val());
    })
    $(".numericdecimalnegativeallow").on('keypress', function (e) {
        return validAllowNegetiveFloat(e, $(this).val());
    })

    $(".onlynumeric").on('keypress', function (e) {
        return validOnlyInt(e);
    })
})
function validInt(e) {
    var code;
    if (!e) var e = window.event;
    if (e.keyCode)
        code = e.keyCode;
    else if (e.which)
        code = e.which;
    else
        return true;

    if (code == 13 || code == 8 || code == 9 || code == 37)// || code == 39)
        return true;

    let key = Number(e.key)
    if (isNaN(key) || e.key === null || e.key === ' ') {
        return false;
    }
    else {
        return true;
    }
};
function validOnlyInt(e) {
    var code;
    if (!e) var e = window.event;
    if (e.keyCode)
        code = e.keyCode;
    else if (e.which)
        code = e.which;
    else
        return true;

    if (code == 13 || code == 8 || code == 9)// || code == 39)
        return true;

    let key = Number(e.key)
    if (isNaN(key) || e.key === null || e.key === ' ') {
        return false;
    }
    else {
        return true;
    }
};
function validFloat(e, txt) {
    var code;
    //var tb = txtid;
    //var txt = txt;

    if (!e) var e = window.event;
    if (e.keyCode)
        code = e.keyCode;
    else if (e.which)
        code = e.which;
    else
        return true;

    if (code == 13 || code == 8 || code == 9 || code == 37 || code == 39)
        return true;

    if (code == 46)
        if (txt.indexOf('.') != -1)
            code = 0;

    if ((code < 46 || code > 57) || code == 47) { code = 0; return false; }
    else {
        return true;
    }
};
function validAllowNegetiveInt(e, txt) {
    var code;
    if (!e) var e = window.event;
    if (e.keyCode)
        code = e.keyCode;
    else if (e.which)
        code = e.which;
    else
        return true;

    if (code == 13 || code == 8 || code == 9 || code == 37 || code == 39)
        return true;


    if (txt.length == 1 && code == 45) {
        if (txt.indexOf('-') != -1)
            code = 0;
    }

    if (code == 45)
        if (txt.indexOf('-') != -1)
            code = 0;

    if (code < 48 || code > 57) {
        code = 0;
        return false;
    }
}
function validAlfaNum(e) {
    var code;
    if (!e) var e = window.event;
    if (e.keyCode)
        code = e.keyCode;
    else if (e.which)
        code = e.which;
    else
        return true;

    if (code == 13 || code == 8 || code == 9 || code == 32 || code == 37 || code == 39)
        return true;

    if (code < 48) {
        code = 0; return false;
    }
    if (code > 122) {
        code = 0; return false;
    }
    if (code > 92 && code < 97) {
        code = 0; return false;
    }

    if (code > 57 && code < 65) {
        code = 0; return false;
    }
};
function disableDiv() {
    $('.disableDiv input').prop('disabled', true);
    $('.disableDiv select').prop('disabled', true);
    $('.disableDiv button').prop('disabled', true);
    $('.disableDiv textarea').prop('disabled', true);
    $('.disableDiv').find('a').attr('OnClick', '');
    $('.disableDiv tr').prop('disabled', true);
}
function IsObjectNullOrEmpty(obj) {
    try {

        if ((obj != undefined) && (obj != null) && (obj.toString().trim() != '')) {
            return false;
        }
        else {
            return true;
        }
    }
    catch (err) {
        return true;
    }
}
