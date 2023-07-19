var customerCodeURL = ''; 
var contactPersonURL = '';
var billTOIdURL = '';
var shipToIDURL = '';
var sapWEB = sapWEB || {}
sapWEB.SalesQuotation = (function () {
    var init = function () {
        $('.mydatepicker').datepicker({
            todayHighlight: true,
            format: 'dd/mm/yyyy',
        }).datepicker("setDate", new Date());
        autoComplete();
    }
    var autoComplete = function () {
        $("#txtCustomerCode").autocomplete({
            maxShowItems: 10,
            source: function (request, response) {
                var param = $.param({ 'q': request.term})
                sapWEB.ajax.jsonGet(customerCodeURL + "?" + param, function (result) {
                    if (result.errorCode == "1") {
                        response($.map(result.Customer, function (item) {
                            return {
                                label: item.CardCode,
                                val: item.CardCode,
                                name: item.CardName,
                                currency: item.Currency
                            };
                        }))
                    }
                }, function (error) {
                    console.log(error);
                })
            },
            select: function (e, i) {
                sapWEB.helper.SetValue('txtCustomerCode', i.item.label);
                sapWEB.helper.SetValue('txtCustomerName', i.item.name);
                sapWEB.helper.SetValue('txtCurrency', i.item.currency);
                fnContactPerson();
                fnBillToID();
                fnShipToID();
            },
            minLength: 3,
            scroll: true
        })
    }
    var fnContactPerson = function () {
        var param = $.param({ 'code': sapWEB.helper.GetString('txtCustomerCode') })
        sapWEB.ajax.jsonGet(contactPersonURL + "?" + param,
            function (response) {
                if (response != null && response.errorCode == "1") {
                    $("#ddlContactPerson").html('');
                    $('#ddlContactPerson').append($('<option>select contact person</option>'));
                    $.each(response.ContactPerson, function (i, item) {
                        $('#ddlContactPerson').append($('<option></option>').val(item.CODE).html(item.NAME));
                    });
                }
            },
            function (error) { })
    }
    var fnBillToID = function () {
        var param = $.param({ 'code': sapWEB.helper.GetString('txtCustomerCode') })
        sapWEB.ajax.jsonGet(billTOIdURL + "?" + param,
            function (response) {
                if (response != null && response.errorCode == "1") {
                    var id = "ddlBillToID";
                    $("#" + id).html('');
                    $('#' + id).append($('<option>Select Bill To ID</option>'));
                    $.each(response.AddressDetail, function (i, item) {
                        var address = item.Address;
                        if (item.Street != null) {

                            address = address + ',' + item.Street;
                        }
                        if (item.Block != null) {
                            address = address + "," + item.Block;
                        }
                        if (item.City != null) {
                            address = address + "," + item.City;
                        }
                        if (item.State != null) {
                            address = address + "," + item.State;
                        }
                        if (item.Country != null) {
                            address = address + "," + item.Country;
                        }
                        $('#' + id).append($('<option></option>').val(item.Address).html(address));
                    });
                }
            },
            function (error) { })
    }
    var fnShipToID = function () {
        var param = $.param({ 'code': sapWEB.helper.GetString('txtCustomerCode') })
        sapWEB.ajax.jsonGet(shipToIDURL + "?" + param,
            function (response) {
                if (response != null) {
                    var id = "ddlShipTOID";
                    $("#" + id).html('');
                    $('#' + id).append($('<option>Select Bill To ID</option>'));
                    $.each(response.AddressDetail, function (i, item) {
                        var address = item.Address;
                        if (item.Street != null) {
                            address = address + ',' + item.Street;
                        }
                        if (item.Block != null) {
                            address = address + "," + item.Block;
                        }
                        if (item.City != null) {
                            address = address + "," + item.City;
                        }
                        if (item.State != null) {
                            address = address + "," + item.State;
                        }
                        if (item.Country != null) {
                            address = address + "," + item.Country;
                        }
                        $('#' + id).append($('<option></option>').val(item.Address).html(address));
                    });
                }
            },
            function (error) { })
    }
    return {
        Init :init
    }
}())