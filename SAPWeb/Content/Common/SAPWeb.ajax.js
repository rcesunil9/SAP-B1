var sapWEB = sapWEB || {}
$(function () {

});

sapWEB.ajax = (function () {

    var options = {
        ShowLoader: true
    }
    var showLoader = function () {
        if (sapWEB.ajax.options.ShowLoader) {
            $('.preloader').show()
        }
    }
    var hideLoader = function () {
        $('.preloader').hide()
    }

    var ajaxGetHtmlResponse = function (url, doneCallback, errorCallback) {
        showLoader()
        $.ajax({
            url: url,
            type: 'GET',
            async: true,
            cache: false,
            success: function (responseData) {
                hideLoader();
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                hideLoader();

                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }

    var ajaxPostHtmlResponse = function (url, requestData, doneCallback, errorCallback) {
        showLoader()
        $.ajax({
            url: url,
            type: 'POST',
            async: true,
            cache: false,
            data: requestData,
            contentType: 'application/json',
            success: function (responseData) {
                hideLoader();
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                hideLoader();
                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }

    var ajaxGetJsonResponse = function (url, doneCallback, errorCallback) {
        showLoader()
        $.ajax({
            url: url,
            type: 'GET',
            async: true,
            cache: false,
            dataType: "json",
            //contentType: "application/json; charset=utf-8",
            //data: requestData,
            success: function (responseData) {
                hideLoader();
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                hideLoader();
                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }

    var ajaxPostJsonResponse = function (url, requestData, doneCallback, errorCallback) {
        showLoader()
        $.ajax({
            url: url,
            type: 'POST',
            async: true,
            cache: false,
            //dataType: "json",
            //contentType: "application/json; charset=utf-8",
            data: requestData,
            success: function (responseData) {
                hideLoader();
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                hideLoader();
                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }
    var ajaxPostFormResponse = function (url, requestData, doneCallback, errorCallback) {
        showLoader()
        $.ajax({
            url: url,
            type: 'POST',
            async: true,
            cache: false,
            dataType: "json",
            contentType: false,
            processData: false,
            data: requestData,
            success: function (responseData) {
                hideLoader();
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                hideLoader();
                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }
    var ajaxPostJsonResponseWithotLoader = function (url, requestData, doneCallback, errorCallback) {
        $.ajax({
            url: url,
            type: 'POST',
            async: true,
            cache: false,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: requestData,
            success: function (responseData) {
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }
    var ajaxPostJsonReponseReportContentTypeURLEncode = function (url, requestData, doneCallback, errorCallback) {
        showLoader()
        $.ajax({
            url: url,
            type: 'POST',
            dataType: "json",
            data: requestData,
            success: function (responseData) {
                hideLoader();
                if (doneCallback) {
                    doneCallback(responseData);
                }
            },
            error: function (responseData) {
                hideLoader();
                if (errorCallback) {
                    errorCallback(responseData);
                }
            }
        });
    }
    return {
        jsonGet: ajaxGetJsonResponse,
        jsonPost: ajaxPostJsonResponse,
        htmlGet: ajaxGetHtmlResponse,
        htmlPost: ajaxPostHtmlResponse,
        formPost: ajaxPostFormResponse,
        jsonPosturlencoded: ajaxPostJsonReponseReportContentTypeURLEncode,
        options: options
    }

}());