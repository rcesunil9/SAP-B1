var customerCodeURL = ''; 
var contactPersonURL = '';
var salesQuotationHeaderURL = '';
var billTOIdURL = '';
var shipToIDURL = '';
var itemURL = '';
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
        $(".itemsearch").autocomplete({
            maxShowItems: 10,
            source: function (request, response) {
                var param = $.param({ 'code': request.term })
                sapWEB.ajax.jsonGet(itemURL + "?" + param, function (result) {
                    // response($.map(result.slice(0, 10), function (item) {
                    if (result.errorCode == "1") {
                        response($.map(result.Items, function (item) {
                            return {
                                label: item.Code,
                                price: item.ItemPrice,
                                val: item.Code,
                                name: item.Name
                            };
                        }))
                    }
                }, function (error) {
                    console.log(error);
                })
            },
            select: function (e, i) {
                var selectedId = this.id.split('_')[1];
                sapWEB.helper.SetValue('txtItemCode_' + selectedId, i.item.val);
                sapWEB.helper.SetValue('txtItemName_' + selectedId, i.item.name);
                sapWEB.helper.SetValue('txtPrice_' + selectedId, i.item.price);
            },
            minLength: 3
        })
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
                //fnContactPerson();
                //fnBillToID();
                //fnShipToID();
                fnSalesQuotation();
            },
            minLength: 3,
            scroll: true
        })
        fnChangeEvent();
    }
    var fnChangeEvent = function () {
        $(".quantity,.rate,.disrate").on('change', function () {
            var tr = $(this).closest('tr');
            fnCalculation(tr);
        });
    }
    var fnCalculation = function (tr)
    {
        var itemAmount = 0;
        var quantity = parseFloat($(tr).find('.quantity').val());
        var rate = parseFloat($(tr).find('.rate').val());
        var discountRate = $(tr).find('.disrate').val() ==''?  0 : parseFloat($(tr).find('.disrate').val());
        itemAmount = (quantity * rate);
        disamount = itemAmount * (discountRate / 100);
        $(tr).find('.itemamount').val(itemAmount);
        $(tr).find('.disamount').val(disamount);
        fnTotal();
    }
    var fnTotal = function () {
        var totalItemAmount = 0;
        var totalDiscountRate = 0;
        $("#tbody tr").each(function (row) {
            totalItemAmount += sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtTotalBefore_' + row));
            totalDiscountRate += sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtDiscountPer_' + row));
        })
        sapWEB.helper.SetText('lbTotalAmount', totalItemAmount);
        sapWEB.helper.SetText('lblTotalDiscount', totalDiscountRate);
    }
    var fnSalesQuotation = function () {
        var param = $.param({ 'code': sapWEB.helper.GetString('txtCustomerCode') })
        sapWEB.ajax.jsonGet(salesQuotationHeaderURL + "?" + param,
            function (response) {
                if (response != null && response.errorCode == "1") {
                    $("#ddlContactPerson").html('');
                    $('#ddlContactPerson').append($('<option>select contact person</option>'));
                    $.each(response.ContactPerson, function (i, item) {
                        $('#ddlContactPerson').append($('<option></option>').val(item.CODE).html(item.NAME));
                    });

                    $("#ddlEmployee").html('');
                    $('#ddlEmployee').append($('<option>select contact person</option>'));
                    $.each(response.SalesEmployee, function (i, item) {
                        $('#ddlEmployee').append($('<option></option>').val(item.Code).html(item.Name));
                    });

                    $("#ddlBillToID").html('');
                    $('#ddlBillToID').append($('<option>Select Bill To ID</option>'));
                    $.each(response.BillToAddressDetail, function (i, item) {
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
                        $('#ddlBillToID').append($('<option></option>').val(item.Address).html(address));
                    });
                    $("#ddlShipTOID").html('');
                    $('#ddlShipTOID').append($('<option>Select Bill To ID</option>'));
                    $.each(response.ShipToAddressDetail, function (i, item) {
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
                        $('#ddlShipTOID').append($('<option></option>').val(item.Address).html(address));
                    });
                    $("#ddlSeries").html('');
                    $.each(response.SeriesQuotation, function (i, item) {
                        $('#ddlSeries').append($('<option></option>').val(item.Series).html(item.U_SERIES));
                        sapWEB.helper.SetValue('txtQuotationNumber', item.QuotationNumber);
                    });
                }
            },
            function (error) { })
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
        Init: init,
        AutoComplete : autoComplete
    }
}())