var customerCodeURL = '';
var salesQuotationSaveURL = '';
var contactPersonURL = '';
var salesQuotationHeaderURL = '';
var salesQuotationGetURL = '';
var billTOIdURL = '';
var shipToIDURL = '';
var itemURL = '';
var SalesQuotationDetails;
var dataTable;
var nextLink;
var prevLink;
var paging = false;
var firstLoad = true;
var slpCode = 0;
var sapWEB = sapWEB || {}
sapWEB.SalesQuotation = (function () {
    var init = function () {
        
        $('.mydatepicker').datepicker({
            todayHighlight: true,
            format: 'dd/mm/yyyy',
        }).datepicker("setDate", new Date());

        autoComplete();
        $(".btnSave").off('click').on('click', function () {
            saveSalesOrder();
        })
        $("#rdtRoundOff").off('change').on('change', function () {
            if ($("#rdtRoundOff").is(':checked')) {
                $("#txtRounding").removeAttr('disabled')
            }
            else {
                $("#txtRounding").attr('disabled', true)
                $("#txtRounding").val('');
                fnTotal();
            }
        })
        
        loadGrid(salesQuotationGetURL);
       
    }
    var loadGrid = function (linkUrl) {
        
        $("#tblSalesOrder").DataTable({
            "processing": true, // for show progress bar
            "bDestroy": true,
            "lengthChange": false ,
            "serverSide": false, // for process server side
            "filter": true, // this is for disable filter (search box)
            "orderMulti": false, // for disable multiple column at once
            responsive: true,
            "ordering": false,
            "paging": paging, // Disable pagination
            "ajax": {
                "url": linkUrl,
                "type": "get",
                "datatype": "json",
                "dataSrc": function (json) {
                    nextLink = json.QuotationDetails.NextLink;
                    return json.QuotationDetails.Value;
                }
            },
            "pagingType":"simple",
            "language": {
                "emptyTable": "Data Not Found",
                    "paginate": {
                        "previous": "Previous",
                        "next": "Next"
                    }
            },

            "columns": [
                { "data": "U_USER", "name": "U_USER", "autoWidth": true },
                { "data": "CardCode", "name": "CardCode", "autoWidth": true },
                { "data": "CardName", "name": "CardName", "autoWidth": true },
                { "data": "DocEntry", "name": "DocEntry", "autoWidth": true },
                { "data": "DocNum", "name": "DocNum", "autoWidth": true, "className": "numeric" },
                { "data": "DocDate", "name": "DocDate", "autoWidth": true },
                { "data": "NumAtCard", "name": "NumAtCard", "autoWidth": true },
                {
                    "className": "text-center",
                    "orderable": false,
                    data: null,
                    render: function (data, type, row) {
                        var htmlContent = '';
                        if (row.DocumentStatusName == "OPEN" || row.DocumentStatusName == "APPROVED") {
                            htmlContent += '<span class="label label-success">' + row.DocumentStatusName + '</span>'
                        }
                        else if (row.DocumentStatusName == "CLOSE")
                        {
                            htmlContent += '<span class="label label-warning">' + row.DocumentStatusName + '</span>'
                        }
                        else if (row.DocumentStatusName == "DRAFT")
                        {
                            htmlContent += '<span class="label label-danger">' + row.DocumentStatusName + '</span>'
                        }
                        else if (row.DocumentStatusName == "CANCEL") {
                            htmlContent += '<span class="label label-danger">' + row.DocumentStatusName + '</span>'
                        }
                        return htmlContent
                    }
                },
                {
                    "className": "text-center",
                    "orderable": false,
                    data: null,
                    render: function (data, type, row) {
                        var htmlContent = "";
                        htmlContent += "<a href='/SalesQuotation/Create/" + row.DocEntry + "/" + row.DocumentStatusName +"' class='btn btn-sm btn-primary' style='margin-right:5px;' onclick='' ><i class='fa fa-edit'></i></a>";
                        if (row.DocumentStatusName !== "DRAFT") {
                            htmlContent += "<a href='#' class='btn  btn-sm btn-success' onclick='getReport(" + row.DocEntry + ")' ><i class='fa fa-print'></i></a>";
                        }
                        return htmlContent
                    }
                }
            ],"initComplete": function (settings, json) {
                // Conditionally set the number of records to display
                if (firstLoad) {
                    this.api().page.len(-1).draw(); // Load maximum records on the first load
                    firstLoad = false;
                } else {
                    this.api().page.len(20).draw(); // Limit subsequent loads to 20 records
                }
            }
        });
        $('.dataTables_filter input').css('background-color', 'rgba(128, 128, 128, 0.1)');
        $('.dataTables_filter input').addClass('input-sm');
        
    }
    var saveSalesOrder = function () {
        if (sapWEB.helper.GetString('txtCustomerCode') == '') {
            sapWEB.dialog.ShowToaster(DialogType.Error, "Please Enter Customer Code");
            return;
        }
        if (sapWEB.helper.GetString('txtCustomerName') == '') {
            sapWEB.dialog.ShowToaster(DialogType.Error, "Please Enter Customer Name");
            return;
        }
        if (sapWEB.helper.GetString('ddlContactPerson option:selected') == '') {
            sapWEB.dialog.ShowToaster(DialogType.Error, "Please Select ContactPerson");
            return;
        }
        if (sapWEB.helper.GetString('ddlEmployee option:selected') == '') {
            sapWEB.dialog.ShowToaster(DialogType.Error, "Please Select Sales Employeee");
            return;
        }
        //if (sapWEB.helper.GetString('ddlBillToID') == '') {
        //    sapWEB.dialog.ShowToaster(DialogType.Error, "Please Select BillTo");
        //    return;
        //}
        //if (sapWEB.helper.GetString('ddlShipTOID') == '') {
        //    sapWEB.dialog.ShowToaster(DialogType.Error, "Please Select ShipTO");
        //    return;
        //}
        if (sapWEB.helper.GetString('ddlSeries') == '') {
            sapWEB.dialog.ShowToaster(DialogType.Error, "Please Select Series");
            return;
        }
        if (sapWEB.helper.GetString('txtPostingDate') == '') {
            sapWEB.dialog.ShowToaster(DialogType.Error, "Please Select Posting Date");
            return;
        }
        var isValidRow = true;
        var rowMessage = [];
        $('#tbody tr').each(function (row) {
            if (sapWEB.helper.GetString('txtItemCode_' + row) == '') {
                isValidRow = false;
                rowMessage.push('Please enter a Item Code At th Row ' + row + 1);
                return;
            }
            if (sapWEB.helper.GetNumericValue('txtQTY_' + row) <= 0) {
                isValidRow = false;
                rowMessage.push('Please enter a quantity greater than 0 At th Row ' + row + 1);
                return;
            }
            if (sapWEB.helper.GetNumericValue('txtPrice_' + row) <= 0) {
                isValidRow = false;
                rowMessage.push('Please enter a unit price greater than 0 At th Row ' + row + 1);
                return;
            }
            if (!isValidRow) {
                return;
            }
        });
        if (!isValidRow) {
            sapWEB.dialog.ShowToaster(DialogType.Error, rowMessage.join(','));
            return;
        }
        var dataItems = [];
        $('#tbody tr').each(function (row) {
            var uniqueId = parseInt($(this).attr('data-row-id'));
            dataItems.push({
                Linenum: -1,
                QuotaionDetailsID: sapWEB.helper.GetString('hdnQuotaionDetailsID_' + row),
                ItemItemCode: sapWEB.helper.GetString('txtItemCode_' + row),
                ItemDescription: sapWEB.helper.GetString('txtItemName_' + row),
                ItemQuantity: sapWEB.helper.GetNumericValue('txtQTY_' + row),
                ItemPrice: sapWEB.helper.GetNumericValue('txtPrice_' + row),
                ItemTax: sapWEB.helper.GetString('ddlTaxCode_' + row + ' option:selected'),
                DiscountPercent: sapWEB.helper.GetNumericValue('txtDiscountPer_' + row),
                WarehouseCode: sapWEB.helper.GetString('ddlWarCode_' + row + ' option:selected'),
            })
        })


        var model = {
            QuotaionID: sapWEB.helper.GetString('hdnQuotaionID'),
            DocEntry: sapWEB.helper.GetString('hdnDocEntry'),
            U_USER: sapWEB.helper.GetString('hdnU_User'),
            CardCode: sapWEB.helper.GetString('txtCustomerCode'),
            CardName: sapWEB.helper.GetString('txtCustomerName'),
            NumAtCard: sapWEB.helper.GetString('txtCustomerRefNo'),
            ContactPersonCode: sapWEB.helper.GetString('ddlContactPerson option:selected'),
            DocumentStatus: sapWEB.helper.GetString('ddlStatus option:selected'),
            U_Territory: sapWEB.helper.GetString('ddlU_Territory option:selected'),
            DocCurrency: sapWEB.helper.GetString('txtCurrency'),
            U_ExchRate: sapWEB.helper.GetString('txtExchangeRate'),
            PayToCode: sapWEB.helper.GetString('ddlBillToID option:selected'),
            ShipToCode: sapWEB.helper.GetString('ddlShipTOID option:selected'),
            Series: sapWEB.helper.GetString('ddlSeries option:selected'),
            DocDate: sapWEB.helper.GetString('txtDocumentDate'),
            PostingDate: sapWEB.helper.GetString('txtPostingDate'),
            DeliveryDate: sapWEB.helper.GetString('txtDueDate'),
            SalesEmployee: sapWEB.helper.GetString('ddlEmployee option:selected'),
            Comments: sapWEB.helper.GetString('txtOtherRemarks'),
            RoundingDiffAmount: sapWEB.helper.GetNumericValue('txtRounding'),
            Rounding: $("#rdtRoundOff").is(':checked')?"tYES":"tNO",
            DocumentLines: dataItems
        }
        sapWEB.ajax.jsonPost(salesQuotationSaveURL, { 'model': model },
            function (response) {
       
                if (response.errorCode == "1") {
                    sapWEB.dialog.ShowToaster(DialogType.Success, response.errorMsg);
                    setTimeout(function () {
                        window.location.href = "/SalesQuotation";
                    }, 2000);
                }
                else {
                    sapWEB.dialog.ShowToaster(DialogType.Error, response.errorMsg);
                }
            },
            function (error) {

                sapWEB.dialog.ShowToaster(DialogType.Error, error.responseText);

            })

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
            minLength: 2
        })
        $(".itemsearchname").autocomplete({
            maxShowItems: 10,
            source: function (request, response) {
                var param = $.param({ 'code': request.term })
                sapWEB.ajax.jsonGet(itemURL + "?" + param, function (result) {
                    // response($.map(result.slice(0, 10), function (item) {
                    if (result.errorCode == "1") {
                        response($.map(result.Items, function (item) {
                            return {
                                label: item.Name,
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
            minLength: 2
        })
        $("#txtCustomerName").autocomplete({
            maxShowItems: 10,
            source: function (request, response) {
                var param = $.param({ 'q': request.term })
                sapWEB.ajax.jsonGet(customerCodeURL + "?" + param, function (result) {
                    if (result.errorCode == "1") {
                        response($.map(result.Customer, function (item) {
                            return {
                                label: item.CardName,
                                val: item.CardCode,
                                name: item.CardName,
                                currency: item.Currency,
                                U_Territory: item.U_Territory,
                                Rate: item.Rate
                            };
                        }))
                    }
                }, function (error) {
                    console.log(error);
                })
            },
            select: function (e, i) {
                sapWEB.helper.SetValue('txtCustomerCode', i.item.val);
                sapWEB.helper.SetValue('txtCustomerName', i.item.name);
                sapWEB.helper.SetValue('txtCurrency', i.item.currency);
                sapWEB.helper.SetValue('txtTerritoty', i.item.U_Territory);
                sapWEB.helper.SetValue('txtExchangeRate', i.item.Rate);
                //fnContactPerson();
                //fnBillToID();
                //fnShipToID();
                fnSalesQuotation();
            },
            minLength: 2,
            scroll: true
        })
        $("#txtCustomerCode").autocomplete({
            maxShowItems: 10,
            source: function (request, response) {
                var param = $.param({ 'q': request.term })
                sapWEB.ajax.jsonGet(customerCodeURL + "?" + param, function (result) {
                    if (result.errorCode == "1") {
                        response($.map(result.Customer, function (item) {
                            return {
                                label: item.CardCode,
                                val: item.CardCode,
                                name: item.CardName,
                                currency: item.Currency,
                                U_Territory: item.U_Territory,
                                Rate: item.Rate
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
                sapWEB.helper.SetValue('txtTerritoty', i.item.U_Territory);
                sapWEB.helper.SetValue('txtExchangeRate', i.item.Rate);
                //fnContactPerson();
                //fnBillToID();
                //fnShipToID();
                fnSalesQuotation();
            },
            minLength: 2,
            scroll: true
        })
        fnChangeEvent();
    }
    var fnChangeEvent = function () {
        $(".quantity,.rate,.disrate,.taxcode").on('change', function () {
            var tr = $(this).closest('tr');
            fnCalculation(tr);
        });
        $("#tbody tr").each(function () {
            var tr = $(this).closest('tr');
            fnCalculation(tr);
        })
        $("#txtRounding").on('change', function () {
            fnTotal();
        })
        $("#ddlBillToID").on('change', function () {
            var address = $("#ddlBillToID option:selected").data('address');
            $("#txtBillToAddress").val(address);
            $("#txtBillToAddress").text(address);
        })
        $("#ddlShipTOID").on('change', function () {
            var address = $("#ddlShipTOID option:selected").data('address');
            $("#txtShipAddress").val(address);
            $("#txtShipAddress").text(address);
        })
    }
    var fnCalculation = function (tr) {
        var itemAmount = 0;
        var quantity = parseFloat($(tr).find('.quantity').val() == "" ? 0 : $(tr).find('.quantity').val());
        var rate = parseFloat($(tr).find('.rate').val() == "" ? 0 : $(tr).find('.rate').val());
        var discountRate = $(tr).find('.disrate').val() == '' ? 0 : parseFloat($(tr).find('.disrate').val());
        var taxRate = $(tr).find('select.taxcode option:selected').data('rate') == undefined || $(tr).find('select.taxcode option:selected').data('rate') == "" ? 0 : parseFloat($(tr).find('select.taxcode option:selected').data('rate'));
        itemAmount = (quantity * rate);
        disamount = itemAmount * (discountRate / 100);
        $(tr).find('.itemamount').val(itemAmount);
        $(tr).find('.disamount').val(disamount);
        $(tr).find('.lineAmount').val(itemAmount - disamount);
        $(tr).find('.taxAmount').val(((itemAmount - disamount) * taxRate) / 100);
        fnTotal();
    }
    var fnTotal = function () {
        var totalItemAmount = 0;
        var totalDiscountRate = 0;
        var totalTaxTotal = 0;
        var totalDocument = 0;
        $("#tbody tr").each(function (row) {
            totalItemAmount += sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtTotalBefore_' + row));
            totalDiscountRate += sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtDiscountAmount_' + row));
            totalTaxTotal += sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtAmount_' + row));
            totalDocument += sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtAmount_' + row)) + sapWEB.helper.GetNumeric(sapWEB.helper.GetString('txtLineQTY_' + row));;
        })
        var roundingAmount = sapWEB.helper.GetNumericValue('txtRounding')
        sapWEB.helper.SetText('lbTotalAmount', totalItemAmount);
        sapWEB.helper.SetText('lblTotalDiscount', totalDiscountRate);
        sapWEB.helper.SetText('lblTotalTax', totalTaxTotal);
        sapWEB.helper.SetText('lblDocumentTotal', totalDocument + roundingAmount);
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
                    $('#ddlEmployee').append($('<option>select sales employee</option>'));
                    $.each(response.SalesEmployee, function (i, item) {
                        $('#ddlEmployee').append($('<option></option>').val(item.Code).html(item.Name));
                    });
                    var contact = $("#ddlContactPerson").data('contact');
                    $("#ddlContactPerson").val(contact);
                    var employee = $("#ddlEmployee").data('employee');
                    if (employee == "") {
                        employee = slpCode;
                    }
                    $("#ddlEmployee").val(employee);
                    $("#ddlBillToID").html('');
                    $('#ddlBillToID').append($('<option value="">Select Bill To ID</option>'));
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
                        // Create a new <option> element with a data-address attribute
                        var option = $('<option></option>').val(item.Address).html(item.Address);

                        // Add the data-address attribute with the address value
                        option.attr('data-address', address);

                        // Append the option to the select element with id ddlBillToID
                        $('#ddlBillToID').append(option);
                    });
                    var BillTo = $("#ddlBillToID").data('billto');
                    $("#ddlBillToID").val(BillTo);
                    $("#ddlShipTOID").html('');
                    $("#ddlBillToID").trigger('change');
                    $('#ddlShipTOID').append($('<option value="">Select Ship To ID</option>'));
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
                        // Create a new <option> element with a data-address attribute
                        var option = $('<option></option>').val(item.Address).html(item.Address);

                        // Add the data-address attribute with the address value
                        option.attr('data-address', address);

                        // Append the option to the select element with id ddlBillToID
                        $('#ddlShipTOID').append(option);
                    });
                    var ShipTo = $("#ddlShipTOID").data('shipto');
                    $("#ddlShipTOID").val(ShipTo);
                    $("#ddlShipTOID").trigger('change');
                    $("#ddlSeries").html('');
                    $.each(response.SeriesQuotation, function (i, item) {
                        $('#ddlSeries').append($('<option></option>').val(item.Series).html(item.U_SERIES));
                        if (sapWEB.helper.GetNumericValue('hdnDocEntry') <= 0) {
                            sapWEB.helper.SetValue('txtQuotationNumber', item.QuotationNumber);
                        }
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
        AutoComplete: autoComplete,
        FNSalesQuotation: fnSalesQuotation,
        FNChangeEvent: fnChangeEvent,
        LoadGrid: loadGrid
    }
}())