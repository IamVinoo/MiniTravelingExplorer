// Initializations
var windowLocation = window.location;
var windowPathName = windowLocation.pathname;
var windowLocationSearch = windowLocation.search;
var urlParams = new URLSearchParams(windowLocationSearch);
var bodySelector = $("body");
var windowWidth = $(window).width();
var windowInnerWidth = $(window).innerWidth();
var whiteSpaceString = " ";
var hash_selector = "#";
var period_selector = ".";
var empty_string = "";
var comma = ",";
var colon = ":";
var z_character = "z";
var forwardSlash = "/";
var ellipsis = "...";
var imageFileType = "image";
var imageFileTypeList = ["image/jpeg", "image/jpg", "image/png", "image/gif", "image/bmp", "image/tiff", "image/webp"];
var checkedString = "Checked";
var uncheckedString = "Unchecked";
var emailString = "Email";
var copyLinkString = "CopyLink";
var copyLinkClipboardString = "Copy Link to Clipboard";
var mmddyyyyDateFormat = "MM/DD/YYYY";
var clearKeyCodes = [8, 46, 37, 39];
var cardNumberValidLength = 16;
var cvcValidLength = 3;
var orderAsc = "asc";
var orderDesc = "desc";
var toastCount = 1;

// Local Variables
var userProfileImageData;
var userProfileFileName;
var userProfileFileType;
var checkedStatusString;
var shareLinkTitleString;
var isUserLoginEmail;
var maxTicketAllowedToBookValue;
var isPromoCodeValidated;
var promotionValue;
var isPercent;
var getLocalDateTime;
var getLocalDate;
var setDisplayDate;
var getDisplayDateTime;
var initSessionTimeoutAlert;
var closeToastNotification;
var isSmallView;
var isMediumView;
var isLargeView;
var maxDataTableColumnLength;

// Local Storage Keys
var loginEmailKey = "loginEmailKey";
var waitTimeToResendCodeKey = "waitTimeToResendCodeKey";
var isFirstTimeLocationPageVisitKey = "isFirstTimeLocationPageVisit";
var isFirstTimeChecklistPageVisitKey = "isFirstTimeChecklistPageVisit";

// Regex Patterns
var emailRegexPattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
var dateRegexPattern = /^\d{2}\/\d{2}\/\d{4}$/;
var passwordRegexPattern = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$*]).{8,}$/;
var lowerCaseMatchRegexPattern = /[a-z]/g;
var upperCaseMatchRegexPattern = /[A-Z]/g;
var numericMatchRegexPattern = /[0-9]/g;
var specialCharacterMatchRegexPattern = /[!@#$*]/g;
var whiteSpaceRegexPattern = /\s/g;

// Classes
var rowClass = "row";
var colMd6Class = "col-md-6";
var colMd10Class = "col-md-10";
var colMd12Class = "col-md-12";
var textRightClass = "text-right";
var textSuccessClass = "text-success";
var textDangerClass = "text-danger";
var marginBottom12Class = "margin-bottom-12";
var cursorPointerClass = "cursor-pointer";
var pl15Class = "pl-15";
var mb2Class = "margin-bottom-2";
var mb25Class = "margin-bottom-25";
var mb49Class = "margin-bottom-49";
var errorFocusControlClass = "error-focus-control";
var bookPromoCodeContainerClass = "d-flex align-items-end " + colMd6Class;
var validationClass = mb2Class + whiteSpaceString + errorFocusControlClass;
var responsiveMessageClass = ".reponsive-message";
var backToTopClass = ".back-to-top";

// Window paths
var defaultWindowPath = "/";

// Modal
var messageModalId = "#message_modal";
var messageModalTitleId = "#message_modal_title";
var messageModalBodyId = "#message_modal_body";
var messageModalBodyIconContainerId = "#message_modal_body_icon_container";
var messageModalBodyIconId = "#message_modal_body_icon";
var messageModalBodyContentId = "#message_modal_body_content";
var messageModalOkButtonId = "#message_modal_ok_button";
var messageModalOkButtonTextId = "#message_modal_ok_button_text";
var messageModalCancelButtonId = "#message_modal_cancel_button";
var messageModalCancelButtonTextId = "#message_modal_cancel_button_text";
var messageModalCloseIconId = ".message-modal-close-icon";
var yesText = "Yes";
var noText = "No";
var okText = "OK";
var closeText = "Close";
var createText = "Create";
var shareText = "Share";
var bookText = "Book";
var loginText = "Login";
var cancelText = "Cancel";

// HTML Classes and Ids
var toastNotificationTimeout = "#toast_notification_timeout";
var toastNotificationHeaderId = "#toast_notification_header";
var toastNotificationCloseIconId = "#toast_notification_close_icon";
var toastNotificationCloseIconClass = ".toast-notification-close-icon";

var loginSmallButtonId = "#login_sm_button";
var loginLargeButtonId = "#login_lg_button";

//Responsiveness
function checkForSmallScreen() {
    isSmallView = $(window).innerWidth() < 720;
}

function checkForMediumScreen() {
    isMediumView = $(window).innerWidth() > 720 && $(window).innerWidth() < 1007;
}

function checkForLargeScreen() {
    isLargeView = $(window).innerWidth() > 1007;
}

// Back to Top
$(window).on("scroll", function () {
    if (windowPathName.indexOf("Admin/") > -1) {
        if (window.scrollY > 100) {
            $(backToTopClass).addClass("active");
        } else {
            $(backToTopClass).removeClass("active");
        }
    }
    else {
        if ($(this).scrollTop() > 300) {
            $(backToTopClass).fadeIn("slow");
        } else {
            $(backToTopClass).fadeOut("slow");
        }
    }
});
$(backToTopClass).on("click", function () {
    scrollTo();
    return false;
});

// Toast notification
function showToastNotification(title, message, type) {
    var iconElement;
    var toastId = "toast_" + toastCount;
    let toast = document.createElement("div");
    $(toast).addClass("mte-toast");
    $(toast).attr("id", toastId);

    switch (type?.toLowerCase()) {
        case "success":
            iconElement = "<i class='fa fa-check'></i>";
            break;
        case "error":
            toast.classList.add("error");
            iconElement = "<i class='fa fa-times-circle'></i>";
            break;
        case "warning":
            toast.classList.add("invalid");
            iconElement = "<i class='fa fa-exclamation-triangle'></i>";
            break;
        default:
            toast.classList.add("info");
            iconElement = "<i class='fa fa-info-circle'></i>";
            break;
    }

    toast.innerHTML = iconElement + "<div class='d-flex flex-direction-column'><span id='" + toastNotificationHeaderId.substring(hash_selector.length) + "'><h6>" + title + "</h6><i class='fa fa-times-circle hide-lg " + toastNotificationCloseIconClass.substring(period_selector.length) + "' onclick=closeToastNotification(" + toastId + ")></i></span><span class='toast-message'>" + message + "</span></div>";
    toastBox.appendChild(toast);

    var toastSlideTime = parseInt($(toastNotificationTimeout).val());
    var toastRemoveTime = toastSlideTime + 100;

    var toastSlideTimeout = setTimeout(() => {
        toast.classList.add("remove", "hide-toast");
        clearTimeout(toastSlideTimeout);
    }, toastSlideTime);

    var toastRemoveTimeout = setTimeout(() => {
        toast.remove();
        clearTimeout(toastRemoveTimeout);
    }, toastRemoveTime);

    toastCount++;
}

closeToastNotification = function closeToastNotification(toastId) {
    $(toastId).remove();
};

// Spinner
var spinner = function () {
    setTimeout(function () {
        if ($('#spinner').length > 0) {
            $('#spinner').removeClass('show');
        }
    }, 1);
};
spinner();

function showSpinner() {
    $("#spinner").addClass("show");
}

function hideSpinner(hideSpinnerTimeOut) {
    hideSpinnerTimeOut = hideSpinnerTimeOut ? hideSpinnerTimeOut : 0;

    setTimeout(function () {
        $("#spinner").removeClass("show");
    }, hideSpinnerTimeOut);
}

function scrollTo(targetElementId, adjusingOffset, parentElementId) {
    parentElementId = parentElementId ? parentElementId : "html, body";
    var top = targetElementId ? ($(targetElementId).offset().top + (adjusingOffset ? adjusingOffset : 0)) : 0;
    $(parentElementId).animate({ scrollTop: top }, 1500);
}

function isMessageModalShown() {
    return $(messageModalId).hasClass("show");
}

function showMessageModal() {
    $(messageModalId).addClass("show");
};

function closeMessageModal() {
    $(messageModalId).removeClass("show");
};

function closeRefreshMessageModal() {
    closeMessageModal();
    windowLocation.reload();
}

function setMessageModelData(modalTitle, modalBody, modalOkButtonText, modalCancelButtonText, okFunction, closeFunction, okMessageData, cancelMessageData, iconType) {
    $(messageModalTitleId).text(modalTitle);
    $(messageModalBodyContentId).html(modalBody);
    $(messageModalOkButtonId).removeClass("hide").off();
    $(messageModalCancelButtonId).removeClass("hide").off();

    var iconTypeClass = "fa-info-circle";
    var iconClass = "info";

    if (iconType) {
        switch (iconType.toLowerCase()) {
            case "info":
                iconTypeClass = "fa-info-circle";
                iconClass = "info";
                break;
            case "success":
                iconTypeClass = "fa-check";
                iconClass = "success";
                break;
            case "error":
                iconTypeClass = "fa-times-circle";
                iconClass = "error";
                break;
            case "warning":
                iconTypeClass = "fa-exclamation-triangle";
                iconClass = "invalid";
                break;
        }

        $(messageModalBodyIconContainerId).html("<i id='message_modal_body_icon' class='fa " + iconTypeClass + "'></i>");
        $(messageModalBodyIconId).addClass(iconClass);
        $(messageModalBodyContentId).addClass(colMd10Class);
        $(messageModalBodyIconContainerId).removeClass("hide");
    }
    else {
        $(messageModalBodyIconContainerId).addClass("hide");
        $(messageModalBodyContentId).removeClass(colMd10Class);
    }

    if (modalOkButtonText) {
        $(messageModalOkButtonTextId).text(modalOkButtonText);

        $(messageModalOkButtonId).on("click", function () {
            okFunction(okMessageData);
        });
    }
    else {
        $(messageModalOkButtonId).addClass("hide");
    }

    if (modalCancelButtonText) {
        $(messageModalCancelButtonTextId).text(modalCancelButtonText);

        $(messageModalCancelButtonId).on("click", function () {
            closeFunction(cancelMessageData);
        });
    }
    else {
        $(messageModalCancelButtonId).addClass("hide");
    }

    $(messageModalCloseIconId).on("click", function () {
        closeFunction(cancelMessageData);
    });
}

function logoutCloseMessageModal(messageData) {
    closeModalRedirection(messageData)
}

function closeModalRedirection(messageData) {
    $(messageModalId).removeClass("show");

    if (messageData && messageData.isRedirect) {
        navigateToUrl(messageData.controller, messageData.action);
    }
}

function setMessageData(isRedirect, controller, action) {
    return { isRedirect: isRedirect, controller, action };
}

function navigateToUrl(controller, action, url, isForceReload) {
    var navigationUrl;

    if (url) {
        if (!isForceReload && url == windowPathName) {
            return;
        }

        navigationUrl = url;
    }
    else if (controller && action) {
        navigationUrl = defaultWindowPath + controller + defaultWindowPath + action;
    }
    else {
        navigationUrl = defaultWindowPath;
    }

    windowLocation.href = navigationUrl;
}

function emailValidation(emailElementId, emailErrorMessageId, invalidErrorMessageId, isSkipInvalidationCheck, emailToCheckId) {
    var isValid = true;

    $(emailErrorMessageId).addClass("hide");
    $(invalidErrorMessageId).addClass("hide");

    var emailValue = $(emailElementId).val();
    $(emailElementId).removeClass(validationClass);

    if (!emailValue) {
        $(emailElementId).addClass(validationClass);
        $(emailErrorMessageId).removeClass("hide");
        isValid = false;
    }
    else if (!isSkipInvalidationCheck && !emailRegexPattern.test(emailValue)) {
        $(emailElementId).addClass(validationClass);
        $(invalidErrorMessageId).removeClass("hide");
        isValid = false;
    }
    else if (emailToCheckId) {
        var emailToCheckValue = $(emailToCheckId).val();

        if (emailToCheckValue && (emailToCheckValue.toLowerCase() != emailValue.toLowerCase())) {
            $(emailElementId).addClass(validationClass);
            $(invalidErrorMessageId).removeClass("hide");
            isValid = false;
        }
    }

    return isValid;
}

function passwordValidation(passwordElementId, passwordErrorMessgaeId, passwordInvalidErrorMessgaeId, passwordToCheckId, passwordConfirmErrorMessgaeId, isTestPassword, passwordRequirementsErrorMessageId, isSameValidation, passwordSameErrorMessageId) {
    var isValid = true;
    var passwordValue = $(passwordElementId).val();

    $(passwordErrorMessgaeId).addClass("hide");
    $(passwordConfirmErrorMessgaeId).addClass("hide");
    $(passwordInvalidErrorMessgaeId).addClass("hide");
    $(passwordRequirementsErrorMessageId).addClass("hide");
    $(passwordSameErrorMessageId).addClass("hide");
    $(passwordElementId).removeClass(validationClass);

    if (isSameValidation) {
        if (passwordValue == $(passwordToCheckId).val()) {
            $(passwordElementId).addClass(validationClass);
            $(passwordSameErrorMessageId).removeClass("hide");
            isValid = false;
        }
    }
    else {
        if (!passwordValue) {
            $(passwordElementId).addClass(validationClass);
            $(passwordErrorMessgaeId).removeClass("hide");
            isValid = false;
        }
        else if (passwordToCheckId) {
            var passwordToCheckValue = $(passwordToCheckId).val();

            if (passwordToCheckValue && passwordValue != passwordToCheckValue) {
                $(passwordElementId).addClass(validationClass);
                $(passwordInvalidErrorMessgaeId).removeClass("hide");
                isValid = false;
            }
        }
        else if (isTestPassword && !passwordRegexPattern.test(passwordValue)) {
            $(passwordElementId).addClass(validationClass);
            $(passwordRequirementsErrorMessageId).removeClass("hide");
            isValid = false;
        }
    }

    if (isValid) {
        $(loginSmallButtonId).removeClass("mt-3");
        $(loginLargeButtonId).removeClass("mt-2");
    }
    else {
        $(loginSmallButtonId).addClass("mt-3");
        $(loginLargeButtonId).addClass("mt-2");
    }

    return isValid;
}

function ajaxRequest(type, url, data, dataType, successFunction, errorFunction) {
    showSpinner();
    type = type ? type : "GET";
    dataType = dataType ? dataType : "JSON";

    $.ajax({
        type: type,
        url: url,
        data: data,
        dataType: dataType,
        success: successFunction,
        error: errorFunction
    });
}

function isRedirection(result, isSkipSessionTimeout, isSkipInitSessionTimeoutAlert) {
    if (!isSkipInitSessionTimeoutAlert && isSkipSessionTimeout) {
        initSessionTimeoutAlert(isSkipSessionTimeout);
    }

    return result && result.StatusCode == 200 && result.IsRedirect && result.Action && result.Controller;
}

function isvalidResponse(result, isSkipInitSessionTimeoutAlert) {
    if (!isSkipInitSessionTimeoutAlert) {
        initSessionTimeoutAlert();
    }

    return result && result.StatusCode == 200 && result.SuccessMessage;
}

function isInvalidResponse(result) {
    return result && result.StatusCode != 200 && result.ErrorMessage;
}

function getErrorMessage(result) {
    var errorMessage = "Unexpected error. Please try again later.";

    if (result && result.StatusCode != 200 && result.ErrorMessage) {
        errorMessage = result.ErrorMessage;
    }

    return errorMessage;
}

function setTableData(isDestroy, container, dataSet, columns, columnDefs, order) {

    if (isDestroy) {
        $(container).DataTable().clear();
        $(container).DataTable().destroy();
    }

    dataSet = dataSet.map(function (obj) {
        return Object.values(obj);
    });

    new DataTable(container, {
        order: (order ? order : false),
        columns: columns,
        columnDefs: columnDefs,
        data: dataSet
    });
}

function setDataTableColumnText(columnData, maxLength) {
    if (columnData && columnData.length > maxDataTableColumnLength && maxLength) {
        columnData = "<span title='" + columnData + "'>" + columnData.substring(0, maxLength) + ellipsis + "</span>";
    }

    return columnData;
}

function setMaxDataTableColumnLength(targetElement, targetClass, length_primary, length_secondary) {
    if (targetElement && targetClass) {
        if (targetElement.hasClass(targetClass)) {
            maxDataTableColumnLength = length_secondary;
        }
        else {
            maxDataTableColumnLength = length_primary;
        }
    }
    else {
        maxDataTableColumnLength = length_primary;
    }
}

getLocalDateTime = function getLocalDateTime(value) {
    return new Date(value);
}

getLocalDate = function getLocalDate(value) {
    return getLocalDateTime(value).toJSON().slice(0, 10).split("-").reverse().join(forwardSlash);
}

setDisplayDate = function setDisplayDate(targetElementId, dateValue) {
    $(targetElementId).text(getLocalDate(dateValue));
}

getDisplayDateTime = function getDisplayDateTime(dateValue) {
    var displayDateTime = empty_string;

    if (dateValue) {
        displayDateTime = new Date(dateValue + z_character).toLocaleString().replace(comma, empty_string);
    }

    return displayDateTime;
}