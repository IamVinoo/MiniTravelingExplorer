// Variables
var isAdminLoginButtonClicked;
var initUsersListPage;
var tempUsersListData;
var initUserIpInfoListPage;
var tempUserIpInfoListData;

// Classes & Ids
var toggleSidebarClass = "toggle-sidebar";

var adminEmailId = "#admin_email";
var adminEmailErrorMessageId = "#admin_email_error_message";
var adminEmailErrorMessageTextId = "#admin_email_error_message_text";
var adminEmailInvalidErrorMessageId = "#admin_email_invalid_error_message";
var adminEmailInvalidErrorMessageTextId = "#admin_email_invalid_error_message_text";
var adminPasswordId = "#admin_password";
var adminPasswordErrorMessageId = "#admin_password_error_message";
var adminPasswordErrorMessageTextId = "#admin_password_error_message_text";

var userSwitchClass = ".user-switch";
var userSwitchInputClass = ".user-switch-input";
var userSwitchTextClass = ".user-switch-text";

var userListContainerClass = ".user-list-container";
var userListContainerId = "#user_list_container";

var userIpInfoListContainerClass = ".user-ip-info-list-container";
var userIpInfoListContainerId = "#user_ip_info_list_container";

var adminDashboardMenuId = "#admin_dashboard";
var adminUsersMenuId = "#admin_users";
var adminUserIpInfoMenuId = "#admin_user_ip_info";
var adminLogFileMenuId = "#admin_log_file";

var adminLogoutClass = ".admin-logout";

// Window Path
var adminLoginWindowPath = "/Admin/Login";
var adminHomePageWindowPath = "/Admin/Home";
var adminHomePageWindowPath2 = "/Admin";
var adminUsersPageWindowPath = "/Admin/Users";
var adminUserIpInfoPageWindowPath = "/Admin/UserIpInfo";

// Url
var adminUserLoginApiUrl = "/Admin/UserLogin";
var getLogFileApiUrl = "/Admin/GetLogFile";
var adminUserLogoutApiUrl = "/Admin/Logout";

if (windowPathName == adminHomePageWindowPath || windowPathName == adminHomePageWindowPath2) {
    $(adminDashboardMenuId).removeClass("collapsed");
}
if (windowPathName == adminLoginWindowPath) {
    $(adminDashboardMenuId).removeClass("collapsed");

    initAdminLoginPage();
}
else if (windowPathName == adminUsersPageWindowPath) {
    $(adminUsersMenuId).removeClass("collapsed");

    checkForLargeScreen();

    if (urlParams.get("isAdmin").toLowerCase() == "true") {
        $(userSwitchInputClass).removeAttr("checked");
        $(userSwitchTextClass).text("Admin Users");
    }
    else {
        $(userSwitchInputClass).attr("checked", "checked");
    }

    $(window).on("resize", function () {
        checkForLargeScreen();
        initUsersListPage(tempUsersListData);
    });
}
else if (windowPathName == adminUserIpInfoPageWindowPath) {
    $(adminUserIpInfoMenuId).removeClass("collapsed");

    checkForLargeScreen();

    $(window).on("resize", function () {
        checkForLargeScreen();
        initUserIpInfoListPage(tempUserIpInfoListData);
    });
}

/**
 * Sidebar toggle
 */
$(".toggle-sidebar-btn").on("click", function () {
    bodySelector.toggleClass(toggleSidebarClass);

    if (windowPathName == adminUsersPageWindowPath) {
        setTimeout(function () {
            initUsersListPage(tempUsersListData);
        }, 200);
    }
    else if (windowPathName == adminUserIpInfoPageWindowPath) {
        setTimeout(function () {
            initUserIpInfoListPage(tempUserIpInfoListData, bodySelector.hasClass(toggleSidebarClass));
        }, 200);
    }
});

function initAdminLoginPage() {
    setMessageModelData(
        "Admin - Login",
        "<div class='row'><div class='" + colMd12Class + "'><div class='form-group'><label>Email</label><input type='text' id='" + adminEmailId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Email'  maxlength='20'/><span id='" + adminEmailErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(adminEmailErrorMessageTextId).val() + "</span><span id='" + adminEmailInvalidErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(adminEmailInvalidErrorMessageTextId).val() + "</span>" +
        "<div><div class='form-group'><label>Password</label><input type='password' id='" + adminPasswordId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Password' /><span id='" + adminPasswordErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(adminPasswordErrorMessageTextId).val() + "</span></div></div></div>",
        okText,
        cancelText,
        adminUserLogin,
        closeMessageModal);

    $(messageModalTitleId).html("<div class='display-flex'><a href='/Home/Home'><img class='admin-logo' src='https://i.imghippo.com/files/hm8881725048826.png' alt='Mini Traveling Explorer' /></a><span class='align-self-center margin-left-10'>Admin - Login</span></div>");

    showMessageModal();
}

$(adminEmailId).on("focusout", function () {
    if (isAdminLoginButtonClicked) {
        emailValidation(adminEmailId, adminEmailErrorMessageId, adminEmailInvalidErrorMessageId);
    }
});

$(adminPasswordId).on("focusout", function () {
    if (isAdminLoginButtonClicked) {
        passwordValidation(adminPasswordId, adminPasswordErrorMessageId);
    }
});

$(adminEmailId).on("keyup", function (event) {
    triggerAdminLogin(event);
});

$(adminPasswordId).on("keyup", function (event) {
    triggerAdminLogin(event);
});

function adminUserLogin() {
    isAdminLoginButtonClicked = true;
    var isEmailValid = emailValidation(adminEmailId, adminEmailErrorMessageId, adminEmailInvalidErrorMessageId);
    var isPhoneValid = passwordValidation(adminPasswordId, adminPasswordErrorMessageId);

    if (isEmailValid && isPhoneValid) {
        ajaxRequest(
            "POST",
            adminUserLoginApiUrl,
            {
                Email: $(adminEmailId).val(),
                Password: $(adminPasswordId).val()
            },
            "JSON",
            adminUserLoginSuccess,
            adminUserLoginError
        );
    }
}

function triggerAdminLogin(event) {
    if (event.keyCode == 13) {
        adminUserLogin();
    }
}

function adminUserLoginSuccess(successResult) {
    if (isRedirection(successResult, true, true)) {
        navigateToUrl(successResult.Controller, successResult.Action);
    }
    else if (isvalidResponse(successResult, true)) {
        closeMessageModal();
        showToastNotification("Admin Login", successResult.SuccessMessage, "success");
        setTimeout(function () {
            navigateToUrl("", "", adminHomePageWindowPath);
        }, 1500);
    }
    else if (isInvalidResponse(successResult)) {
        adminLoginError(successResult.ErrorMessage);
    }

    hideSpinner();
}

function adminUserLoginError(errorResult) {
    adminLoginError(getErrorMessage(errorResult));
    hideSpinner();
}

function adminLoginError(errorMessage) {
    showToastNotification("Admin Login", errorMessage, "error");
}

$(userSwitchInputClass).on("change", function (event) {
    var isAdminUser = !event.currentTarget.checked;

    showSpinner();

    if (isAdminUser) {
        $(userSwitchTextClass).text("Admin Users");
    }

    navigateToUrl("", "", (adminUsersPageWindowPath + "?isAdmin=" + isAdminUser.toString()));
});

initUsersListPage = function initUsersListPage(userList) {
    var isDestroy = tempUsersListData;
    setMaxDataTableColumnLength(bodySelector, toggleSidebarClass, 25, 40);

    if (!tempUsersListData && userList) {
        tempUsersListData = userList;
    }

    if (userList) {
        if (userList.length) {
            if (!isLargeView) {
                $(userListContainerClass).addClass("hide");
                $(userSwitchClass).addClass("hide");
                $(userSwitchTextClass).addClass("hide");
                $(responsiveMessageClass).removeClass("hide");
            }
            else {
                $(userListContainerClass).removeClass("hide");
                $(userSwitchClass).removeClass("hide");
                $(userSwitchTextClass).removeClass("hide");
                $(responsiveMessageClass).addClass("hide");
            }

            var columns = [
                {
                    title: "Name",
                    render: function (data, type, rowData) {
                        return "<img class='user-image-table' src='" + (rowData[25] ? rowData[25] : "../../Images/User-transparent-background.png") + "' alt='" + (rowData[23] ? rowData[23] : rowData[25]) + "' />" + rowData[16];
                    }
                },
                {
                    title: "Date of Birth",
                    render: function (data, type, rowData) {
                        return getLocalDate(rowData[19]);
                    }
                },

                {
                    title: "Email",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[17], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Phone",
                    render: function (data, type, rowData) {
                        return rowData[18];
                    }
                },
                {
                    title: "Gender",
                    render: function (data, type, rowData) {
                        return rowData[20];
                    }
                },
                {
                    title: "Status",
                    className: "text-center",
                    render: function (data, type, rowData) {
                        var statusClass = "text-danger fa fa-times-circle";

                        if (rowData[1]) {
                            statusClass = "text-success ri-checkbox-circle-fill";
                        }

                        return "<div class='icon''><i class='" + statusClass + "'></i ></div>";
                    },

                }
            ];

            setTableData(
                isDestroy,
                userListContainerId,
                userList,
                columns
            );
        }
    }
}

initUserIpInfoListPage = function initUserIpInfoListPage(userIpInfoList, isSidebarcollapsed) {
    var isDestroy = tempUserIpInfoListData;
    setMaxDataTableColumnLength(bodySelector, toggleSidebarClass, 21, 40);

    if (!tempUserIpInfoListData && userIpInfoList) {
        tempUserIpInfoListData = userIpInfoList;
    }

    if (userIpInfoList) {
        if (userIpInfoList.length) {
            if (!isLargeView) {
                $(userIpInfoListContainerClass).addClass("hide");
                $(responsiveMessageClass).removeClass("hide");
            }
            else {
                $(userIpInfoListContainerClass).removeClass("hide");
                $(responsiveMessageClass).addClass("hide");
            }

            var columns = [
                {
                    title: "User",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[1], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Ip",
                    render: function (data, type, rowData) {
                        return rowData[0];
                    }
                },
                {
                    title: "Browser",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[3], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Device",
                    className: "text-center",
                    render: function (data, type, rowData) {
                        return "<div class='icon'><i class='" + (rowData[5] ? "bi bi-phone" : "bx bx-laptop") + "'></i></div>";
                    }
                },
                {
                    title: "Platform",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[6], maxDataTableColumnLength);
                    }
                },
                {
                    title: "City",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[8], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Region",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[9], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Country",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[10], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Organization",
                    className: "admin-column-text",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[13], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Type",
                    className: "text-center",
                    render: function (data, type, rowData) {
                        return "<div class='icon'><i class='" + (rowData[14] ? "text-secondary ri-user-settings-fill" : "text-primary ri-user-3-fill") + "'></i></div>";
                    }
                },
                {
                    title: "Date",
                    render: function (data, type, rowData) {
                        return getDisplayDateTime(rowData[15]);
                    }
                }
            ];

            var columnDefs = [{
                target: 4,
                visible: (isSidebarcollapsed ? true : false),
                searchable: (isSidebarcollapsed ? true : false)
            },
            {
                target: 10,
                orderable: false
            }];

            setTableData(
                isDestroy,
                userIpInfoListContainerId,
                userIpInfoList,
                columns,
                columnDefs
            );
        }
    }
}

$(adminLogFileMenuId).on("click", function () {
    window.open(getLogFileApiUrl);
});

$(adminLogoutClass).on("click", function () {
    setMessageModelData("Logout", "<span>Are you sure you want to Logout?</span>", yesText, noText, adminLogout, closeMessageModal, null, null, "warning");
    showMessageModal();
});

function adminLogout() {
    ajaxRequest(
        "POST",
        adminUserLogoutApiUrl,
        "",
        "JSON",
        adminLogoutSuccess);
}

function adminLogoutSuccess(successResult) {
    if (isRedirection(successResult, true, true)) {
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Logout Success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, "", logoutCloseMessageModal, logoutCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
        hideSpinner();
    }
}