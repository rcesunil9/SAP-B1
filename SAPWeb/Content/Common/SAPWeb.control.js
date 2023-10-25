var sapWEB = sapWEB || {}
sapWEB.helper = (function () {

	var convertString = function (id) {
		return ($("#" + id).val() != undefined) ? $('#' + id).val() : '';
	}

	var convertText = function (id) {
		return ($("#" + id).text() != undefined) ? $('#' + id).text() : '';
	}

	var convertStringAttribute = function (id, attribute) {
		return ($("#" + id).attr(attribute) != undefined) ? $('#' + id).attr(attribute) : '';
	}

	var convertNumeric = function (value) {
		return isNaN(parseFloat(value)) ? 0 : parseFloat(value);
	}

	var convertNumericValue = function (id) {
		return isNaN(parseFloat($("#" + id).val())) ? 0 : parseFloat($("#" + id).val());
	}

	var convertNumericAttribute = function (id, attribute) {
		return isNaN(parseFloat($("#" + id).attr(attribute))) ? 0 : parseFloat($("#" + id).attr(attribute));
	}

	var convertBoolean = function (value) {
		return (value != undefined && (value == "true" || value == "True" || value == "1")) ? true : false;
	}

	var convertBooleanValue = function (id) {
		return ($("#" + id).val() != undefined && $("#" + id).val() == "true" || $("#" + id).val() == "True") ? true : false;
	}

	var convertBooleanAttribute = function (id, attribute) {
		return ($("#" + id).attr(attribute) != undefined && $("#" + id).attr(attribute) == "true" || $("#" + id).attr(attribute) == "True") ? true : false;
	}

	var setText = function (id, value) {
		$('#' + id).text(value);
	}
	var setValue = function (id, value) {
		$('#' + id).val(value);
	}
	var setAttribute = function (id, attribute, value) {
		$('#' + id).attr(attribute, value);
	}
	var findObject = function (sourceObject, condition) {
		var obj = []
		if (sourceObject != null && sourceObject != undefined) {
			$.each(sourceObject, function (index, itm) {
				var item = itm;
				if (eval(condition)) {
					obj.push(sourceObject[index]);
				}
			});
		}
		return obj;
	}

	var findIndex = function (sourceObject, condition) {
		var retIndex = -1;
		if (sourceObject != null && sourceObject != undefined) {
			$.each(sourceObject, function (index, itm) {
				var item = itm;
				if (eval(condition)) {
					retIndex = index
					return false;
				}
			});
		}
		return retIndex;
	}

	var convertHtmlToRTF = function (html) {
		if (!(typeof rtf === "string" && rtf)) {
			return null;
		}

		var tmpRichText, hasHyperlinks;
		var richText = rtf;

		// Singleton tags
		richText = richText.replace(/<(?:hr)(?:\s+[^>]*)?\s*[\/]?>/ig, "{\\pard \\brdrb \\brdrs \\brdrw10 \\brsp20 \\par}\n{\\pard\\par}\n");
		richText = richText.replace(/<(?:br)(?:\s+[^>]*)?\s*[\/]?>/ig, "{\\pard\\par}\n");

		// Empty tags
		richText = richText.replace(/<(?:p|div|section|article)(?:\s+[^>]*)?\s*[\/]>/ig, "{\\pard\\par}\n");
		richText = richText.replace(/<(?:[^>]+)\/>/g, "");

		// Hyperlinks
		richText = richText.replace(
			/<a(?:\s+[^>]*)?(?:\s+href=(["'])(?:javascript:void\(0?\);?|#|return false;?|void\(0?\);?|)\1)(?:\s+[^>]*)?>/ig,
			"{{{\n");
		tmpRichText = richText;
		richText = richText.replace(
			/<a(?:\s+[^>]*)?(?:\s+href=(["'])(.+)\1)(?:\s+[^>]*)?>/ig,
			"{\\field{\\*\\fldinst{HYPERLINK\n \"$2\"\n}}{\\fldrslt{\\ul\\cf1\n");
		hasHyperlinks = richText !== tmpRichText;
		richText = richText.replace(/<a(?:\s+[^>]*)?>/ig, "{{{\n");
		richText = richText.replace(/<\/a(?:\s+[^>]*)?>/ig, "\n}}}");

		// Start tags
		richText = richText.replace(/<(?:b|strong)(?:\s+[^>]*)?>/ig, "{\\b\n");
		richText = richText.replace(/<(?:i|em)(?:\s+[^>]*)?>/ig, "{\\i\n");
		richText = richText.replace(/<(?:u|ins)(?:\s+[^>]*)?>/ig, "{\\ul\n");
		richText = richText.replace(/<(?:strike|del)(?:\s+[^>]*)?>/ig, "{\\strike\n");
		richText = richText.replace(/<sup(?:\s+[^>]*)?>/ig, "{\\super\n");
		richText = richText.replace(/<sub(?:\s+[^>]*)?>/ig, "{\\sub\n");
		richText = richText.replace(/<(?:p|div|section|article)(?:\s+[^>]*)?>/ig, "{\\pard\n");

		// End tags
		richText = richText.replace(/<\/(?:p|div|section|article)(?:\s+[^>]*)?>/ig, "\n\\par}\n");
		richText = richText.replace(/<\/(?:b|strong|i|em|u|ins|strike|del|sup|sub)(?:\s+[^>]*)?>/ig, "\n}");

		// Strip any other remaining HTML tags [but leave their contents]
		richText = richText.replace(/<(?:[^>]+)>/g, "");

		// Prefix and suffix the rich text with the necessary syntax
		richText =
			"{\\rtf1\\ansi\n" + (hasHyperlinks ? "{\\colortbl\n;\n\\red0\\green0\\blue255;\n}\n" : "") + richText + "\n}";

		return richText;

	}
	var convertRtfToHTML = function (html) {



		return richText;

	}
	function convertToPlain(rtf) {
		rtf = rtf.replace(/\\par[d]?/g, "");
		rtf = rtf.replace(/\{\*?\\[^{}]+}|[{}]|\\\n?[A-Za-z]+\n?(?:-?\d+)?[ ]?/g, "").trim();
		var parser = new DOMParser();
		var doc = parser.parseFromString(rtf, 'text/html');
		return doc.body.innerHTML;
	}
	function covertprepandZero(n) {
		return n > 9 ? "" + n : "0" + n;
	}
	function tinyMCEInit(selecter) {
		tinymce.remove();
		tinymce.init({
			height: "200px",
			selector: selecter,
			branding: false,
			forced_root_block: false,
			plugins: "table",
			table_default_attributes: {
				'border': '1'
			},
			table_default_styles: {
				'border-collapsed': 'collapse',
				'width': '100%'
			},
			table_responsive_width: true
		});
	}
	function formateDDMMYYYY(id, day = 1) {

		flatpickr("#" + id, {
			noCalendar: false,
			enableTime: false,
			allowInput: true,
			defaultDate: new Date().fp_incr(day),
			dateFormat: 'd/m/Y',
			//minuteIncrement: day,
		});
	}
	function pastDateDisableDDMMYYYYById(id) {
		flatpickr("#" + id, {
			noCalendar: false,
			enableTime: false,
			allowInput: true,
			minDate: "today",
			defaultDate: "today",
			dateFormat: 'd/m/Y',
		});
	}
	function setDateDDMMYYYY(classname) {
		flatpickr("#" + classname, {
			noCalendar: false,
			enableTime: false,
			allowInput: true,
			defaultDate: "today",
			dateFormat: 'd/m/Y',
			//minuteIncrement: day,
		});
		flatpickr("." + classname, {
			noCalendar: false,
			enableTime: false,
			allowInput: true,
			defaultDate: "today",
			dateFormat: 'd/m/Y',
			minuteIncrement: 1,
		});


	}

	function getDayDifferent(startDate, EndDate) {
		var startDay = new Date(startDate);
		var endDay = new Date(EndDate);
		var millisBetween = startDay.getTime() - endDay.getTime();
		var days = millisBetween / (1000 * 3600 * 24);
		return Math.round(Math.abs(days));
	}
	var gridHelper = {
		config: {
			id: '',//table id
			deleteAll: false,//if collection to be allowed empty for delete all row
			actionIndex: 0,//index of column in which add/delete buttons will be places
			deleteBtn: true, //if true, delete button will be added in action index column
			addBtn: true, //if true, add button will be added in action index column
			rowFunc: function () { }//function will be called once add/remove row completed to perform any event
		},

		init: function (config) {
			$.extend(this.config, config);
			InitGrid(this.config.id, this.config.deleteAll, this.config.actionIndex, this.config.rowFunc, this.config.addBtn, this.config.deleteBtn);
		}
	};
	var dataNotFound = function () {
		var htmlContext = '';
		htmlContext += '<div id="notfound-state" class="empty-state">';
		htmlContext += '<div class="empty-state-container">';
		htmlContext += ' <div class="state-figure">';
		htmlContext += '<img class="img-fluid" src="/img/Images/img-2.svg" alt="" style="max-width: 500px">';
		htmlContext += '</div>';
		htmlContext += '<h3 class="state-header"> Data Not found! </h3>';
		htmlContext += '</div>';
		htmlContext += '</div>';
		return htmlContext;
	}

	var workingStatus = function (active) {
		debugger;
		if (!active)
			return "<a href='#' class='btn  btn-sm btn-warning' ><i class='fa fa-thumbs-down'></i></a>";
		else
			return "<a href='#' class='btn  btn-sm btn-success' ><i class='fa fa-thumbs-up'></i></a>";

	}

	var activeInActiveIcon = function (active) {
		debugger;
		if (!active)
			return "<a href='#' class='btn  btn-sm btn-success' ><i class='fa fa-thumbs-up'></i></a>";
		else
			return "<a href='#' class='btn  btn-sm btn-warning' ><i class='fa fa-thumbs-down'></i></a>";
	}
	var filedownload = function (url,filename) {
		var a = document.createElement("a");
		a.href = url;
		a.download = filename;
		// Trigger the download
		a.style.display = "none";
		document.body.appendChild(a);
		a.click();
		// Clean up
		window.URL.revokeObjectURL(a.href);
		document.body.removeChild(a);
	}
	return {
		GetString: convertString,
		GetStringAttribute: convertStringAttribute,
		GetNumeric: convertNumeric,
		GetNumericValue: convertNumericValue,
		GetNumericAttribute: convertNumericAttribute,
		GetBoolean: convertBoolean,
		GetBooleanValue: convertBooleanValue,
		GetBooleanAttribute: convertBooleanAttribute,
		SetValue: setValue,
		SetAttribute: setAttribute,
		SetText: setText,
		FindIndex: findIndex,
		FindObject: findObject,
		GetStringText: convertText,
		GetHtmlToRTF: convertHtmlToRTF,
		GetRtfToHTML: convertRtfToHTML,
		GetRTFtoPlain: convertToPlain,
		GetPrependZero: covertprepandZero,
		FillTinyMCE: tinyMCEInit,
		DateFormateDDMMYYYY: formateDDMMYYYY,
		SetDateFormate: setDateDDMMYYYY,
		GetDayDifferent: getDayDifferent,
		PastDateDisableDDMMYYYYById: pastDateDisableDDMMYYYYById,
		GridHelper: gridHelper,
		DataNotFound: dataNotFound,
		ActiveInActiveIcon: activeInActiveIcon,
		WorkingStatus: workingStatus,
		FileDownload: filedownload

	}


}());

var DialogType = {
	None: 0,
	Success: 1,
	Error: 2,
	Info: 3,
	Warning: 4
}
sapWEB.dialog = (function () {

	var init = function (id) {
		bindToaster();
	}

	var bindToaster = function () {
		toastr.options = {
			"closeButton": true,
			"newestOnTop": true,
			"progressBar": true,
			"positionClass": "toast-top-right",
			"preventDuplicates": true,
			"onclick": null,
			"showDuration": "300",
			"hideDuration": "5000",
			"timeOut": "5000",
			"extendedTimeOut": "1000",
			"showEasing": "swing",
			"hideEasing": "linear",
			"showMethod": "fadeIn",
			"hideMethod": "fadeOut"
		}
	}

	var showToaster = function (type, message) {
		var toastType = 'success';
		switch (type) {
			case DialogType.Success:
				toastType = 'success';
				break;
			case DialogType.Info:
				toastType = 'info';
				break;
			case DialogType.Error:
				toastType = 'error';
				break;
			case DialogType.Warning:
				toastType = 'warning';
				break;
		}
		toastr[toastType](message);
	}
	return {
		Init: init,
		ShowToaster: showToaster
	}

}())

