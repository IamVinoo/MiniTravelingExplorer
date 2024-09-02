// Variables
var resetPasswordRecaptchaId = "#reset_password_recaptcha";
var resetPasswordRecaptchaErrorMessageId = "#reset_password_recaptcha_error_message";
var resetPasswordEmailId = "#reset_password_email";
var googleRecaptchaResponse = "";
var initBookingListPage;
var tempBookingListData;
var getMyChecklistItem;
var createMyChecklist;
var deleteMyChecklist;
var createMyChecklistItem;
var checkMyChecklistItem;
var updateMyChecklistItem;
var updateChecklistItem;
var updateChecklistItemOnEnterKey;
var deleteMyChecklistItem;
var getChecklistShareLink;
var bookMyTicket;
var sessionTimeoutFunction;
var sessionTimeoutInterval;
var isChecklistItemNameUpdating = false;
var emailCodeSendObject = { firstTime: true, waitTime: 0 };
var sessionAboutToLogout = { time: 60 };

// Classes
var bookPromoCodeApplyButtonId = "#book_promo_code_apply_button";
var bookPromoCodeApplyButtonClass = "btn btn-primary mb-2 book-promo-code-apply-button";

var headerProfileImageClass = ".profile_image";

var registerFirstNameId = "#register_first_name";
var registerLastNameId = "#register_last_name";
var registerPasswordId = "#register_password";
var registerConfirmPasswordId = "#register_confirm_password";
var registerDateOfBirthId = "#register_date_of_birth";
var registerEmailId = "#register_email";
var registerPhoneId = "#register_phone";
var registerSecurityQuestionId = "#register_security_question";
var registerSecurityAnswerId = "#register_security_answer";
var registerRadioButtonContainerId = "#register_gender_container";
var registerMaleGenderId = "#register_male_gender";
var registerFemaleGenderId = "#register_female_gender";
var registerButtonId = "#register_button";
var logOutLinkClass = ".log-out";

var registerFirstNameErrorMessageId = "#register_first_name_error_message";
var registerLastNameErrorMessageId = "#register_last_name_error_message";
var registerPasswordErrorMessageId = "#register_password_error_message";
var registerPasswordInvalidErrorMessageId = "#register_password_invalid_error_message";
var registerPasswordRequirementsErrorMessageId = "#register_password_requirements_error_message";
var registerConfirmPasswordErrorMessageId = "#register_confirm_password_error_message";
var registerConfirmPasswordInvalidErrorMessageId = "#register_confirm_password_invalid_error_message";
var registerDateOfBirthErrorMessageId = "#register_date_of_birth_error_message";
var registerDateOfBirthInvalidErrorMessageId = "#register_date_of_birth_invalid_error_message";
var registerEmailErrorMessageId = "#register_email_error_message";
var registerEmailInvalidErrorMessageId = "#register_email_invalid_error_message";
var registerPhoneErrorMessageId = "#register_phone_error_message";
var registerPhoneInvalidErrorMessage = "#register_phone_invalid_error_message";
var registerSecurityQuestionErrorMessageId = "#register_security_question_error_message";
var registerSecurityAnswerErrorMessageId = "#register_security_answer_error_message";
var registerGenderErrorMessageId = "#register_gender_error_message";

var loginEmailId = "#login_email";
var loginPasswordId = "#login_password";
var loginPasswordEyeIconClass = ".login-password-eye-icon";
var loginPasswordEyeSlashIconClass = ".login-password-eye-slash-icon";
var loginEmailErrorMessageId = "#login_email_error_message";
var loginEmailInvalidErrorMessageId = "#login_email_invalid_error_message";
var loginPasswordErrorMessageId = "#login_password_error_message";
var loginPasswordInvalidErrorMessageId = "#login_password_invalid_error_message";
var loginButtonClass = ".btnLogin";

var resetPasswordPasswordId = "#reset_password_password";
var resetPasswordConfirmPasswordId = "#reset_password_confirm_password";
var resetPasswordEmailErrorMessageId = "#reset_password_email_error_message";
var resetPasswordEmailInvalidErrorMessageId = "#reset_password_email_invalid_error_message";
var resetPasswordPasswordErrorMessageId = "#reset_password_password_error_message";
var resetPasswordPasswordInvalidErrorMessageId = "#reset_password_password_invalid_error_message";
var resetPasswordPasswordRequirementsErrorMessageId = "#reset_password_password_requirements_error_message";
var resetPasswordConfirmPasswordErrorMessageId = "#reset_password_confirm_password_error_message";
var resetPasswordConfirmPasswordInvalidErrorMessageId = "#reset_password_confirm_password_invalid_error_message";
var resetPasswordLinkSmallButtonId = "#reset_password_link_sm_button";
var resetPasswordLinkLargeButtonId = "#reset_password_link_lg_button";
var resetPasswordSmallButtonId = "#reset_password_sm_button";
var resetPasswordLargeButtonId = "#reset_password_lg_button";

var userActivationButtonId = "#user_activation_button";

var userProfileContainerClass = ".user-profile-container";
var userProfileDateOfBirthValueId = "#user_profile_date_of_birth_value";
var userProfilePhoneValueId = "#user_profile_phone_value";
var userProfileGenderValueId = "#user_profile_gender_value";
var userProfileSecurityQuestionValueId = "#user_profile_security_question_value";
var userProfileImageValueId = "#user_profile_image_value";
var userProfileImageNameValueId = "#user_profile_image_name_value";
var userProfileImageTypeValueId = "#user_profile_image_type_value";
var userProfileImageMaxSizeValueId = "#user_profile_image_max_size_value";
var userProfileFirstNameId = "#user_profile_first_name";
var userProfileLastNameId = "#user_profile_last_name";
var userProfileDateOfBirthId = "#user_profile_date_of_birth";
var userProfilePhoneId = "#user_profile_phone";
var userProfileSecurityQuestionId = "#user_profile_security_question";
var userProfileSecurityAnswerId = "#user_profile_security_answer";
var userProfileRadioButtonContainerId = "#user_profile_gender_container";
var userProfileMaleGenderId = "#user_profile_male_gender";
var userProfileFemaleGenderId = "#user_profile_female_gender";
var userProfileUploadId = "#user_profile_upload";
var userProfileImageId = "#user_profile_image";
var userProfileDefaultImageId = "#user_profile_default_image";
var userProfileRemoveImageClass = ".user-profile-remove-image";
var userProfileImageDragAndDropContainerClass = ".user-profile-image-drag-and-drop-container";
var userProfileImageInputTextId = "#user_profile_image_input_text";
var userProfileUploadContainerId = "#user_profile_upload_container";
var userProfileButtonId = "#user_profile_button";

var userProfileFirstNameErrorMessageId = "#user_profile_first_name_error_message";
var userProfileLastNameErrorMessageId = "#user_profile_last_name_error_message";
var userProfileDateOfBirthErrorMessageId = "#user_profile_date_of_birth_error_message";
var userProfileDateOfBirthInvalidErrorMessageId = "#user_profile_date_of_birth_invalid_error_message";
var userProfilePhoneErrorMessageId = "#user_profile_phone_error_message";
var userProfilePhoneInvalidErrorMessage = "#user_profile_phone_invalid_error_message";
var userProfileSecurityQuestionErrorMessageId = "#user_profile_security_question_error_message";
var userProfileSecurityAnswerErrorMessageId = "#user_profile_security_answer_error_message";
var userProfileGenderErrorMessageId = "#user_profile_gender_error_message";

var myChecklistClass = ".my-checklist";
var myChecklistMessageClass = ".checklist-message";
var myChecklistActiveBookingId = "#my_checklist_active_booking";
var myChecklistCheklistNameId = "#my_checklist_checklist_name";
var myChecklistBookingNameId = "#my_checklist_booking_name";
var myChecklistCheklistNameErrorMessageId = "#my_checklist_checklist_name_error_message";
var myChecklistBookingNameErrorMessageId = "#my_checklist_booking_name_error_message";
var myChecklistChecklistNameErrorMessageTextId = "#my_checklist_checklist_name_error_message_text";
var myChecklistBookingNameErrorMessageText = "#my_checklist_booking_name_error_message_text";
var myChecklistItemContainerClass = ".my-checklist-item-container";
var myChecklistItemEmptyListContainerClass = ".my-checklist-item-empty-list-container";
var myChecklistItemListContainerClass = ".my-checklist-item-list-container";
var myChecklistItemAddButtonClass = ".my-checklist-item-add";
var myChecklistItemNameId = "#my_checklist_item_name";
var myChecklistItemNameErrorMessageId = "#my_checklist_item_name_error_message";
var myChecklistItemEmptyMessageContainerClass = ".my-checklist-item-empty-message-container";
var myChecklistItemTableRowId = "#my_checklist_item_table_row_";
var myChecklistItemTableRowClass = ".my-checklist-item-table-row";
var myChecklistItemTableBodyClass = ".my-checklist-item-table-body";
var myChecklistItemTableCheckboxContainerClass = ".my-checklist-item-table-checkbox-container";
var myChecklistItemCheckboxId = "#my_checklist_item_checkbox_";
var myChecklistItemCheckboxClass = ".my-checklist-item-checkbox";
var myChecklistItemTableNameContainerClass = ".my-checklist-item-table-name-container";
var myChecklistItemTableNameClass = ".my-checklist-item-table-name";
var myChecklistItemListContainerTableElementClass = "table my-checklist-item-table";
var myChecklistItemTableEditIconElementClasses = "fa fa-pencil-alt text-success cursor-pointer my-checklist-item-edit-icon";
var myChecklistItemTableDeleteIconElementClasses = "fa fa-trash text-danger cursor-pointer my-checklist-item-delete-icon";
var myChecklistItemTableSpacerClass = ".my-checklist-item-table-spacer";
var myChecklistItemTableNameId = "#my_checklist_item_table_name_";
var myChecklistItemTableNameInputId = "#my_checklist_item_table_name_input_";
var myChecklistShareEmailId = "#my_checklist_share_email";
var myChecklistShareEmailErrorMessageId = "#my_checklist_share_email_error_message";
var myChecklistShareEmailErrorMessageTextId = "#my_checklist_share_email_error_message_text";
var myChecklistShareEmailInvalidErrorMessageId = "#my_checklist_share_email_invalid_error_message";
var myChecklistShareEmailInvalidErrorMessageTextId = "#my_checklist_share_email_invalid_error_message_text";
var myChecklistShareIconClass = ".my-checklist-share-icon";

var bookCardUserLoginEmailId = "#book_card_user_login_email";
var bookCardEmailId = "#book_card_email";
var bookCardEmailErrorMessageId = "#book_card_email_error_message";
var bookCardEmailErrorMessageTextId = "#book_card_email_error_message_text";
var bookCardEmailInvalidErrorMessageId = "#book_card_email_invalid_error_message";
var bookCardEmailInvalidErrorMessageTextId = "#book_card_email_invalid_error_message_text";
var bookCardConfirmEmailId = "#book_card_confirm_email";
var bookCardConfirmEmailErrorMessageId = "#book_card_confirm_email_error_message";
var bookCardConfirmEmailErrorMessageTextId = "#book_card_confirm_email_error_message_text";
var bookCardConfirmEmailInvalidErrorMessageId = "#book_card_confirm_email_invalid_error_message";
var bookCardConfirmEmailInvalidErrorMessageTextId = "#book_card_confirm_email_invalid_error_message_text";
var bookCardEmailMessageId = "#book_card_email_message";
var bookCardEmailMessageTextId = "#book_card_email_message_text";
var bookCardCheckboxClass = ".book-card-checkbox";
var bookCardCheckboxTextClass = ".book-card-checkbox-text";
var bookCardCheckboxTextMessageId = "#book_card_checkbox_text_message";
var bookCardContainerId = "#book_card_container";
var bookcardCardNumberId = "#book_card_container .card-number";
var bookcardCardNumberErrorMessageId = "#book_card_card_number_error_message";
var bookcardCardNumberInvalidErrorMessageId = "#book_card_card_number_invalid_error_message";
var bookcardCardNumberErrorMessageTextId = "#book_card_card_number_error_message_text";
var bookcardCardNumberInvalidErrorMessageTextId = "#book_card_card_number_invalid_error_message_text";
var bookCardCardNameId = "#book_card_container .name";
var bookcardCardNameErrorMessageTextId = "#book_card_card_name_error_message_text";
var bookcardCardNameErrorMessageId = "#book_card_card_name_error_message";
var bookCardExpiryId = "#book_card_container .expiry";
var bookcardExpiryErrorMessageId = "#book_card_expiry_error_message";
var bookcardExpiryInvalidErrorMessageId = "#book_card_expiry_invalid_error_message";
var bookcardExpiryErrorMessageTextId = "#book_card_expiry_error_message_text";
var bookcardExpiryInvalidErrorMessageTextId = "#book_card_expiry_invalid_error_message_text";
var bookCardCvcId = "#book_card_container .cvc";
var bookcardCvcErrorMessageId = "#book_card_cvc_error_message";
var bookcardCvcInvalidErrorMessageId = "#book_card_cvc_invalid_error_message";
var bookcardCvcErrorMessageTextId = "#book_card_cvv_error_message_text";
var bookcardCvcInvalidErrorMessageTextId = "#book_card_cvv_invalid_error_message_text";
var bookTripDateId = "#book_trip_date";
var bookTripDateErrorMessageId = "#book_trip_date_error_message";
var bookTripDateErrorMessageTextId = "#book_trip_date_error_message_text";
var bookTripDateInvalidErrorMessageId = "#book_trip_date_invalid_error_message";
var bookTripDateInvalidErrorMessageTextId = "#book_trip_date_invalid_error_message_text";
var bookAmountTitleClass = ".book-amount-title";
var bookAmountClass = ".book-amount";
var bookNumberOfTicketId = "#book_number_of_ticket";
var bookMaxNumberOfTicketId = "#book_max_number_of_ticket";
var bookNumberOfTicketErrorMessageId = "#book_number_of_ticket_error_message";
var bookNumberOfTicketErrorMessageTextId = "#book_number_of_ticket_error_message_text";
var bookPromoCodeId = "#book_promo_code";
var bookPromoCodeErrorMessageId = "#book_promo_code_error_message";
var bookPromoCodeErrorMessageTextId = "#book_promo_code_error_message_text";
var bookPromoCodeValidateErrorMessageId = "#book_promo_code_validate_error_message";
var bookPromoCodeValidateErrorMessageTextId = "#book_promo_code_validate_error_message_text";
var bookPromoCodeValidateSuccessMessageId = "#book_promo_code_validate_success_message";
var maxTicketAllowedToBookId = "#max_ticket_allowed_to_book";
var locationDetailCurrencySymbolId = "#location_detail_currency_symbol";
var locationDetailRateId = "#location_detail_rate";
var locationDetailAvailableTicketId = "#location_detail_available_ticket";

var myBookingClass = ".my-booking";
var bookingListContainerClass = ".booking-list-container";
var bookingListContainerId = "#booking_list_container";
var bookingDetailContainerWrapperClass = ".booking-detail-container-wrapper";

var changeEmailClass = ".change-email";
var changeEmailWaitingTimeValueId = "#change_email_waiting_time_value";
var changeEmailCodeInputClass = ".email-change-code-input";
var changeEmailEmailId = "#change_email_email";
var changeEmailEmailErrorMessageId = "#change_email_email_error_message";
var changeEmailEmailInvalidErrorMessageId = "#change_email_email_invalid_error_message";
var changeEmailButtonId = "#change_email_button";
var changeEmailSendCodeClass = ".change-email-send-code";
var changeEmailResendCodeClass = ".change-email-resend-code";
var changeEmailResendCodeTimeClass = ".change-email-resend-code-time";
var changeEmailCodeContainerClass = ".email-change-code-container";

var changePasswordClass = ".change-password";
var changePasswordSmallButtonId = "#change_password_sm_button";
var changePasswordLargeButtonId = "#change_password_lg_button";

var changePasswordCurrentPasswordId = "#change_password_current_password";
var changePasswordPasswordId = "#change_password_password";
var changePasswordConfirmPasswordId = "#change_password_confirm_password";
var changePasswordCurrentPasswordErrorMessageId = "#change_password_current_password_error_message";
var changePasswordPasswordErrorMessageId = "#change_password_password_error_message";
var changePasswordPasswordInvalidErrorMessageId = "#change_password_password_invalid_error_message";
var changePasswordPasswordRequirementsErrorMessageId = "#change_password_password_requirements_error_message";
var changePasswordConfirmPasswordErrorMessageId = "#change_password_confirm_password_error_message";
var changePasswordConfirmPasswordInvalidErrorMessageId = "#change_password_confirm_password_invalid_error_message";
var changePasswordPasswordSameAsCurrentPasswordErrorMessageId = "#change_password_password_same_as_current_password_error_message";

var changeEmailEmailSendVerificationCodeErrorMessage = "#change_email_email_send_verification_code_error_message";
var changeEmailEmailCodeVerificationErrorMessage = "#change_email_email_code_verification_error_message";

var isRegisterButtonClicked;
var isLoginButtonClicked;
var isResetPasswordLinkButtonClicked;
var isResetPasswordButtonClicked;
var isUserProfileButtonClicked;
var isChangeEmailButtonClicked;
var isChangePasswordButtonClicked;
var isEmailSubscriptionButtonClicked;
var isMyChecklistCreateButtonClicked;
var isMyChecklistItemAddButtonClicked;
var isMyChecklistShareEmailButtonClicked;
var isBookCardButtonClicked;

var registerGenderDataId = Object.values({ registerMaleGenderId, registerFemaleGenderId });
var userProfileGenderDataId = Object.values({ userProfileMaleGenderId, userProfileFemaleGenderId });

// HTML Classes and Ids
var mteDatePickerClass = ".mte-date-picker";
var mtePhoneControlClass = ".mte-phone-control";
var tooltipContentElementClass = ".tooltip-content";
var userProfileImageTargetClass = ".user-profile-image-target";
var logOutLinkClass = ".log-out";
var homeSearchContainerClass = ".home-search-container";
var homeLandingSearchButtonClass = ".home-landing-search-button";
var homeServiceContainerClass = ".service-container";
var roomItemNameContainerClass = ".room-item-name-container";
var roomItemDescriptionClass = ".room-item-description";
var homeVideoPlayButtonId = "#home_video_play_button";
var homeVideoModalId = "#home_video_modal";
var homeVideoIframeId = "#home_video_iframe";
var testimonialItemReviewClass = ".testimonial-item-review";
var footerSubscriptionEmailId = "#footer_subscription_email";
var footerSubscriptionButtonId = "#footer_subscription_button";
var footerSubscriptionEmailErrorMessageId = "#footer_subscription_email_error_message";
var footerSubscriptionEmailInvalidErrorMessageId = "#footer_subscription_email_invalid_error_message";
var footerSubscriptionEmailContainerClass = ".footer-subscription-email-container";
var footerSubscriptionMessageClass = ".footer-subscription-message";
var homeAboutLocationCountId = "#home_about_location_count";
var homeAboutRoomCountId = "#home_about_room_count";
var homeAboutStaffCountId = "#home_about_staff_count";
var homeAboutTestimonialCountId = "#home_about_testimonial_count";
var homeTestimonialContainerClass = ".home-testimonial-container";
var contactTeamContainerClass = ".contact-team-container";
var containerHighlight = "container-highlight";
var systemCookieExpirationTimeId = "#system_cookie_expiration_time";
var sessionExpirationTime = "#session_expiration_time";
var profileTabContainerClass = ".profile_tab_container";
var locationSearchValueClass = ".location-search-value";
var locationSearchButtonClass = ".location-search-button";
var locationSearchClearIconClass = ".location-search-clear-icon";
var locationSearchAdvancedFilterContainerClass = ".location-search-advanced-filter-container";
var locationSearchFilterCriteriaContainerClass = ".location-search-filter-criteria-container";
var locationSearchAdvancedLinkId = "#location_search_advanced_link";
var locationSearchAngleUpClass = ".location-search-angle-up-icon";
var locationSearchAngleDownClass = ".location-search-angle-down-icon";
var dataLattitudeName = "lattitude";
var dataLongitudeName = "longitude";
var dataLocationNameName = "location-name";
var leftHandIconContainerClass = ".left-hand-icon-container";
var locationSearchFilterCriteriaActivityId = "#location_search_filter_criteria_activity";
var locationSearchFilterCriteriaWeatherId = "#location_search_filter_criteria_weather";
var locationSearchFilterCriteriaPriceSliderId = "#location_search_filter_criteria_price_slider";
var locationSearchFilterCriteriaTemperatureSliderId = "#location_search_filter_criteria_temperature_slider";
var locationDataMinimumPriceId = "#location_data_minimum_price";
var locationDataMaximumPriceId = "#location_data_maximum_price";
var locationDataMinimumTemperatureId = "#location_data_minimum_temperature";
var locationDataMaximumTemperatureId = "#location_data_maximum_temperature";
var locationSearchFilterCriteriaMinimumPriceId = "#location_search_filter_criteria_minimum_price";
var locationSearchFilterCriteriaMaximumPriceId = "#location_search_filter_criteria_maximum_price";
var locationSearchFilterCriteriaMinimumTemperatureId = "#location_search_filter_criteria_minimum_temperature";
var locationSearchFilterCriteriaMaximumTemperatureId = "#location_search_filter_criteria_maximum_temperature";
var locationSearchFilterCriteriaClearId = "#location_search_filter_criteria_clear";

// Page Name
var userProfile = "userProfile";

// Maps
var contactMapElementId = "contact_map";

// URL
var emailSubscriptionApiUrl = "/Home/EmailSubscription?email=";
var insertUserApiUrl = "/Register/InsertUser";
var updateUserApiUrl = "/Register/UpdateUser";
var loginApiUrl = "/Login/UserLogin";
var sendPasswordResetApiUrl = "/Login/SendPasswordResetLink";
var resetPasswordApiUrl = "/Login/UserPasswordReset?resetPasswordData={0}&Password={1}";
var sendEmailVerificationCodeApiUrl = "/Account/SendEmailVerificationCode";
var changeUserEmailApiUrl = "/Account/ChangeUserEmail";
var changeUserPasswordApiUrl = "/Account/ChangeUserPassword";
var checklistItemApiUrl = "/Account/MyChecklistItem?checklistId={0}&bookingId={1}";
var createMyChecklistApiUrl = "/Account/InsertMyChecklist?checklistName={0}&bookingId={1}";
var deleteMyChecklistApiUrl = "/Account/DeleteMyChecklist?checklistId={0}&bookingId={1}";
var createUpdateMyChecklistItemApiUrl = "/Account/InsertUpdateMyChecklistItem";
var deleteMyChecklistItemApiUrl = "/Account/DeleteMyChecklistItem?checklistItemId={0}&checklistId={1}&bookingId={2}";
var getChecklistShareDataApiUrl = "/Account/GetChecklistShareData"
var validatePromoCodeApiUrl = "/Booking/ValidatePromoCode"
var bookMyTicketApiUrl = "/Booking/BookMyTicket"
var bookingDetailApiUrl = "/Booking/Detail?bookingId=";
var logoutApiUrl = "/Account/Logout";

// Window paths
var homeWindowPath = "/Home/Home";
var roomWindowPath = "/Room/List";
var aboutWindowPath = "/Home/About";
var contactWindowPath = "/Home/Contact";
var registerWindowPath = "/Register/Register";
var loginWindowPath = "/Login/Login";
var loginWindowPath2 = "/Login";
var resetPasswordPath = "/Login/ResetPassword";
var userProfileWindowPath = "/Account/UserProfile";
var myChecklistPath = "/Account/MyChecklist";
var myChecklistItemPath = "/Account/MyChecklistItem";
var changeEmailPath = "/Account/ChangeEmail";
var changePasswordPath = "/Account/ChangePassword";
var keepSessionAlivePath = "/Account/KeepSessionAlive";
var locationListWindowPath = "/Location/List";
var locationDetailWindowPath = "/Location/Detail";
var bookingListPath = "/Booking/List";
var bookingDetailPath = "/Booking/Detail?bookingId=";

checkForSmallScreen();
checkForMediumScreen();
checkForLargeScreen();

// Init local storages
if (localStorage.getItem(isFirstTimeLocationPageVisitKey) === null) {
    localStorage.setItem(isFirstTimeLocationPageVisitKey, "true");
}

if (localStorage.getItem(isFirstTimeChecklistPageVisitKey) === null) {
    localStorage.setItem(isFirstTimeChecklistPageVisitKey, "true");
}

// Document click event
$(document).on("click", function (event) {
    if (isSmallView || isMediumView) {
        $(myChecklistShareIconClass + whiteSpaceString + tooltipContentElementClass).css("visibility", "");

        if ($(event.target).hasClass(myChecklistShareIconClass.substring(period_selector.length)) && $(myChecklistShareIconClass + whiteSpaceString + tooltipContentElementClass).css("visibility") == "visible") {
            return;
        }

        $(myChecklistShareIconClass + whiteSpaceString + tooltipContentElementClass).css("visibility", "hidden");
    }
});

// Phone control masking
$(mtePhoneControlClass).inputmask({ "mask": "(999) 999-9999" });

// Glow Cookies
glowCookies.start("en", {
    hideAfterClick: true,
    border: "border",
    position: "right",
    bannerHeading: "We respect your privacy",
    bannerDescription: "We use cookies and other technologies to operate our website, improve usability and personalize your experience. To learn more about how we collect and protect your data, visit our",
    bannerLinkText: "privacy policy.",
    rejectBtnHide: "hide",
    policyLink: "../../Template/Pdf/Privacy Policy.pdf",
    policyLinkColor: "var(--primary)",
    acceptBtnColor: "#fff",
    acceptBtnBackground: "var(--primary)",
    acceptBtnWidth: "100%"
});

// jQuery UI Datepicker
var datepickerTodayInterval = setInterval(function () {
    var datepickerTodayButton = $(".ui-datepicker-buttonpane button.ui-datepicker-current");
    if (datepickerTodayButton.length) {
        datepickerTodayButton.removeClass("ui-priority-secondary").addClass("ui-priority-primary");
        clearInterval(datepickerTodayInterval);
    }
}, 100);

var _gotoToday = jQuery.datepicker._gotoToday;
jQuery.datepicker._gotoToday = function (a) {
    var target = jQuery(a);
    var inst = this._getInst(target[0]);
    _gotoToday.call(this, a);
    jQuery.datepicker._selectDate(a, jQuery.datepicker._formatDate(inst, inst.selectedDay, inst.selectedMonth, inst.selectedYear));
};

var locationMinimumPrice = $(locationDataMinimumPriceId).val();
var locationMaximumPrice = $(locationDataMaximumPriceId).val();
var locationMinimumTemperature = $(locationDataMinimumTemperatureId).val();
var locationMaximumTemperature = $(locationDataMaximumTemperatureId).val();
$(locationSearchFilterCriteriaMinimumPriceId).val(locationMinimumPrice);
$(locationSearchFilterCriteriaMaximumPriceId).val(locationMaximumPrice);
$(locationSearchFilterCriteriaMinimumTemperatureId).val(locationMinimumTemperature);
$(locationSearchFilterCriteriaMaximumTemperatureId).val(locationMaximumTemperature);

// Tooltip position
var tooltipContainer = $(".tooltip-container");
tooltipContainer.hover(function () {
    var tooltipContent = this.querySelector(tooltipContentElementClass);

    if (tooltipContent) {
        $(tooltipContent).addClass("visible").removeClass("invisible");
        var result = isElementInViewport(tooltipContent);
        var topValue = (!result.isBottomVisible ? "-" + (result.topValueBottomHidden) + "px" : "0px");
        $(tooltipContent).css("top", topValue);
    }
});

$(tooltipContentElementClass).mouseleave(function () {
    var tooltipTimeout = setTimeout(function () {
        $(tooltipContentElementClass).removeClass("visible");
        clearTimeout(tooltipTimeout);
    }, 100);
});

$(".tooltip-close-icon").on("click", function () {
    $(this).closest(tooltipContentElementClass).addClass("invisible").removeClass("visible");
});

$(".fa-icon").on("click", function () {
    $(this).siblings(tooltipContentElementClass).addClass("visible").removeClass("invisible");
});

// Initiate the wowjs
new WOW().init();

// Dropdown on mouse hover
const $dropdown = $(".dropdown");
const $dropdownToggle = $(".dropdown-toggle");
const $dropdownMenu = $(".dropdown-menu");
const showClass = "show";

$(window).on("load resize", function () {
    if (this.matchMedia("(min-width: 992px)").matches) {
        $dropdown.hover(
            function () {
                const $this = $(this);
                $this.addClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "true");
                $this.find($dropdownMenu).addClass(showClass);
            },
            function () {
                const $this = $(this);
                $this.removeClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "false");
                $this.find($dropdownMenu).removeClass(showClass);
            }
        );
    } else {
        $dropdown.off("mouseenter mouseleave");
    }

    windowInnerWidth = $(window).innerWidth();

    checkForSmallScreen();
    checkForMediumScreen();
    checkForLargeScreen();
});

// Facts counter
$('[data-toggle="counter-up"]').counterUp({
    delay: 10,
    time: 2000
});

// Modal Video
$(document).ready(function () {
    var videoSource;
    $(homeVideoPlayButtonId).click(function () {
        videoSource = $(this).data("src");
    });

    $(homeVideoModalId).on("shown.bs.modal", function (e) {
        $(homeVideoIframeId).attr("src", videoSource);
    })

    $(homeVideoModalId).on("hide.bs.modal", function (e) {
        $(homeVideoIframeId).attr("src", videoSource);
    })

    initSelectCustomization();

    // Init session timeout alert
    if ($(profileTabContainerClass).length) {
        initSessionTimeoutAlert();
    }
});

function initSelectCustomization() {
    $("select").on("change", function () {
        setSelectStyle(this, "select-text");
    });

    $("select").on("focusin", function () {
        setSelectStyle(this, "select-text");
    });

    $("select").on("focusin", function () {
        setSelectStyle(this, "select-text");
    });
}

function setSelectStyle(targetElement, classToAdd) {
    if ($(targetElement).val()) {
        $(targetElement).addClass(classToAdd);
    } else {
        $(targetElement).removeClass(classToAdd);
    }
}

// Testimonials carousel
$(".testimonial-carousel").owlCarousel({
    autoplay: true,
    smartSpeed: 1000,
    margin: 25,
    dots: false,
    loop: true,
    nav: true,
    navText: [
        '<i class="bi bi-arrow-left"></i>',
        '<i class="bi bi-arrow-right"></i>'
    ],
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2
        }
    }
});

if (isLargeView) {
    $("#register_tab_sm").remove();
    $(".login-register-button").addClass("hover-float-shadow");
}
else {
    $("#register_tab_lg").remove();
    $(".login-register-button").removeClass("hover-float-shadow");
}

// Intervals
var resendCodeInterval = setInterval(function () {
    if (sendEmailCodeTimer(false, localStorage.getItem(waitTimeToResendCodeKey)) <= 0) {
        clearInterval(resendCodeInterval);
    }
}, 1000);

// Set active tabs
$("#register_tab").removeClass("active");
$("#login_tab").removeClass("active");
$("#home_tab").removeClass("active");
$("#location_tab").removeClass("active");
$("#about_tab").removeClass("active");
$("#rooms_tab").removeClass("active");
$("#contact_tab").removeClass("active");
$("#regitser_login_sm_tab").removeClass("active");
$("#register_login_lg_button").removeClass("hide");

$(userProfileImageTargetClass).removeClass("text-primary");
$(myBookingClass).removeClass("text-primary");
$(myChecklistClass).removeClass("text-primary");
$(changeEmailClass).removeClass("text-primary");
$(changePasswordClass).removeClass("text-primary");

if (windowPathName == defaultWindowPath || windowPathName == homeWindowPath) {
    $("#home_tab").addClass("active");
    setEqualElementHeight(roomItemNameContainerClass);
    setEqualElementHeight(roomItemDescriptionClass);
    setEqualElementHeight(testimonialItemReviewClass);

    if (windowLocationSearch == "?showService=true") {
        scrollTo(homeServiceContainerClass);
    }
}
else if (windowPathName == changePasswordPath) {
    initChangePasswordPage();
    $(changePasswordClass).addClass("text-primary");
}
else if (windowPathName == locationListWindowPath) {
    $("#location_tab").addClass("active");
    initLocationListPage();
}
else if (windowPathName == locationDetailWindowPath) {
    $("#location_tab").addClass("active");
    initLocationDetailPage();
}
else if (windowPathName == roomWindowPath) {
    $("#rooms_tab").addClass("active");
    setEqualElementHeight(roomItemNameContainerClass);
    setEqualElementHeight(roomItemDescriptionClass);
}
else if (windowPathName == aboutWindowPath) {
    $("#about_tab").addClass("active");
}
else if (windowPathName == contactWindowPath) {
    initContactMap();
    $("#contact_tab").addClass("active");
}
else if (windowPathName == resetPasswordPath) {
    $("#regitser_login_sm_tab").addClass("active");

    preventCopyPaste(resetPasswordConfirmPasswordId);
    var allowToReset = windowLocationSearch.split("allowToReset=").pop();
    allowToReset = allowToReset.substring(0, allowToReset.indexOf("&"));

    if (allowToReset.toLowerCase() == "true") {
        var resetPasswordData = windowLocationSearch.split("resetPasswordData=").pop();
        resetPasswordApiUrl = resetPasswordApiUrl.replace("{0}", resetPasswordData);
        $(".reset-password-link-container").addClass("hide");
        $(".reset-password--container").removeClass("hide");
    }
    else {
        $(".reset-password-container").addClass("hide");
        $(".reset-password-link-container").removeClass("hide");
    }
}
else if (windowPathName == bookingListPath) {
    $(myBookingClass).addClass("text-primary");

    $(window).on("resize", function () {
        checkForLargeScreen();
        initBookingListPage(tempBookingListData);
    });
}
else if (windowPathName == bookingDetailPath.substring(0, bookingDetailPath.indexOf("?"))) {
    $(myBookingClass).addClass("text-primary");
    initBookingDetail();

    $(window).on("resize", function () {
        checkForLargeScreen();
        initBookingDetail();
    });
}
else if (windowPathName == myChecklistPath) {
    $(myChecklistClass).addClass("text-primary");

    if (localStorage.getItem(isFirstTimeChecklistPageVisitKey) == "false") {
        $(myChecklistMessageClass).addClass("hide");
    }
}
else if (windowPathName == myChecklistItemPath) {
    $(myChecklistClass).addClass("text-primary");
}
else if (windowPathName == changeEmailPath) {
    $(changeEmailClass).addClass("text-primary");
}
else if (windowPathName == userProfileWindowPath) {
    initDragAndDrop(userProfileImageDragAndDropContainerClass);
    setAcceptForFileUpload(userProfileUploadId, arrayToString(imageFileTypeList, ", "));
    $(userProfileImageTargetClass).addClass("text-primary");
}
else if (windowPathName == registerWindowPath) {
    $("#register_tab").addClass("active");
    $("#register_login_lg_button").addClass("hide");
    $("#regitser_login_sm_tab").addClass("active");
    initRegisterPage();

    if (isSmallView) {
        $("html").css("background-color", "var(--primary)");
    }
}
else if (windowPathName == loginWindowPath || windowPathName == loginWindowPath2) {
    $("#login_tab").addClass("active");
    $("#register_login_lg_button").addClass("hide");
    $("#regitser_login_sm_tab").addClass("active");
    $(loginEmailId).focus();
}

// Prevent clicks
$('#register_tab').on("click", function () {
    return !(windowPathName == registerWindowPath);
});

$('#login_tab').on("click", function () {
    return !(windowPathName == loginWindowPath || windowPathName == loginWindowPath2);
});

// Check element visibility in viewport
function isElementInViewport(element) {
    var top = element.offsetTop;
    var left = element.offsetLeft;
    var width = element.offsetWidth;
    var height = element.offsetHeight;

    var topValueBottomHidden = 0;

    while (element.offsetParent) {
        element = element.offsetParent;
        top += element.offsetTop;
        left += element.offsetLeft;
    }

    var isTopVisible = (top >= window.pageYOffset);
    var isLeftVisible = (left >= window.pageXOffset);
    var isBottomVisible = ((top + height) <= (window.pageYOffset + window.innerHeight));
    var isRightVisible = ((left + width) <= (window.pageXOffset + window.innerWidth));

    if (!isBottomVisible) {
        topValueBottomHidden = (top + height - window.innerHeight);
    }

    return ({
        isTopVisible: isTopVisible,
        isLeftVisible: isLeftVisible,
        isBottomVisible: isBottomVisible,
        isRightVisible: isRightVisible,
        topValueBottomHidden: topValueBottomHidden,
        isAllVisible: isTopVisible && isLeftVisible && isBottomVisible && isRightVisible
    });
}

$(userProfileImageTargetClass).on("click", function () {
    navigateToUrl("", "", userProfileWindowPath);
});

$("#services_tab").on("click", function () {
    if (windowPathName == defaultWindowPath || windowPathName == homeWindowPath) {
        scrollTo(homeServiceContainerClass);
    }
    else {
        navigateToUrl("", "", homeWindowPath + "?showService=true");
    }
});

$(homeLandingSearchButtonClass).on("click", function () {
    scrollTo(homeSearchContainerClass, -25);
});

$(locationSearchButtonClass).on("click", function () {
    var concatenatedValue = "";
    var isAdvanceSearch;
    var locationApiUrl = locationListWindowPath;
    var locationSearchValue = $(locationSearchValueClass).val();
    var locationSearchActivityValue = $(locationSearchFilterCriteriaActivityId).val();
    var locationSearchWeatherValue = $(locationSearchFilterCriteriaWeatherId).val();

    var locationSearchMinPriceValue;
    var locationSearchMaxPriceValue;
    var locationSearchMinTemperatureValue;
    var locationSearchMaxTemperatureValue;

    if (windowPathName == locationApiUrl) {
        locationSearchMinPriceValue = $(locationSearchFilterCriteriaPriceSliderId).slider("values", 0);
        locationSearchMaxPriceValue = $(locationSearchFilterCriteriaPriceSliderId).slider("values", 1);
        locationSearchMinTemperatureValue = $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 0);
        locationSearchMaxTemperatureValue = $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 1);
    }

    if (locationSearchValue) {
        locationApiUrl += "?searchString=" + locationSearchValue;
        concatenatedValue += locationSearchValue;
    }

    if (locationSearchActivityValue) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "activitySearchString=" + locationSearchActivityValue;
        concatenatedValue += locationSearchActivityValue;
        isAdvanceSearch = true;
    }

    if (locationSearchWeatherValue) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "weatherSearchString=" + locationSearchWeatherValue;
        concatenatedValue += locationSearchWeatherValue;
        isAdvanceSearch = true;
    }

    if (locationSearchMinPriceValue && locationSearchMinPriceValue != locationMinimumPrice) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "minRate=" + locationSearchMinPriceValue;
        concatenatedValue += locationSearchMinPriceValue;
        isAdvanceSearch = true;
    }

    if (locationSearchMaxPriceValue && locationSearchMaxPriceValue != locationMaximumPrice) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "maxRate=" + locationSearchMaxPriceValue;
        concatenatedValue += locationSearchMaxPriceValue;
        isAdvanceSearch = true;
    }

    if (locationSearchMinTemperatureValue && locationSearchMinTemperatureValue != locationMinimumTemperature) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "minTemperature=" + locationSearchMinTemperatureValue;
        concatenatedValue += locationSearchMinTemperatureValue;
        isAdvanceSearch = true;
    }

    if (locationSearchMaxTemperatureValue && locationSearchMaxTemperatureValue != locationMaximumTemperature) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "maxTemperature=" + locationSearchMaxTemperatureValue;
        isAdvanceSearch = true;
    }

    if (isAdvanceSearch) {
        locationApiUrl += getUrlAppender(concatenatedValue) + "isShowAdvanceFilter=true";
    }

    navigateToUrl("", "", locationApiUrl, true);
});

$(locationSearchClearIconClass).on("click", function () {
    $(locationSearchValueClass).val("");
    $(this).addClass("hide");
});

$(locationSearchAdvancedLinkId).on("click", function () {
    toggleAdvanceSearchContainer();
});

$(locationSearchFilterCriteriaMinimumPriceId).on("keydown", function (event) {
    codeInputFormat(this, event);
});

$(locationSearchFilterCriteriaMaximumPriceId).on("keydown", function (event) {
    codeInputFormat(this, event);
});

$(locationSearchFilterCriteriaMinimumTemperatureId).on("keydown", function (event) {
    codeInputFormat(this, event);
});

$(locationSearchFilterCriteriaMaximumTemperatureId).on("keydown", function (event) {
    codeInputFormat(this, event);
});

$(locationSearchFilterCriteriaMinimumPriceId).on("keyup", function () {
    $(locationSearchFilterCriteriaPriceSliderId).slider("values", 0, parseInt(this.value));
});

$(locationSearchFilterCriteriaMaximumPriceId).on("keyup", function () {
    $(locationSearchFilterCriteriaPriceSliderId).slider("values", 1, parseInt(this.value));
});

$(locationSearchFilterCriteriaMinimumTemperatureId).on("keyup", function (event) {
    $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 0, parseInt(this.value));
});

$(locationSearchFilterCriteriaMaximumTemperatureId).on("keyup", function (event) {
    $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 1, parseInt(this.value));
});

$(locationSearchFilterCriteriaClearId).on("click", function () {
    $(locationSearchFilterCriteriaActivityId).val("");
    $(locationSearchFilterCriteriaWeatherId).val("");
    $(locationSearchFilterCriteriaPriceSliderId).slider("values", 0, locationMinimumPrice);
    $(locationSearchFilterCriteriaMinimumPriceId).val(locationMinimumPrice);
    $(locationSearchFilterCriteriaPriceSliderId).slider("values", 1, locationMaximumPrice);
    $(locationSearchFilterCriteriaMaximumPriceId).val(locationMaximumPrice);
    $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 0, locationMinimumTemperature);
    $(locationSearchFilterCriteriaMinimumTemperatureId).val(locationMinimumTemperature);
    $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 1, locationMaximumTemperature);
    $(locationSearchFilterCriteriaMaximumTemperatureId).val(locationMaximumTemperature);
});

$(homeAboutLocationCountId).on("click", function () {
    navigateToUrl("", "", locationListWindowPath);
});

$(homeAboutRoomCountId).on("click", function () {
    navigateToUrl("", "", roomWindowPath);
});

$(homeAboutStaffCountId).on("click", function () {
    navigateToUrl("", "", contactWindowPath + "?isStaff=true");
});

$(homeAboutTestimonialCountId).on("click", function () {
    var homeTestimonialContainerClassElement = $(homeTestimonialContainerClass);

    if (homeTestimonialContainerClassElement) {
        scrollTo(homeTestimonialContainerClass);
    }
});

$(footerSubscriptionButtonId).on("click", function () {
    isEmailSubscriptionButtonClicked = true;
    emailSubscriptionValidation();
});

$(userActivationButtonId).on("click", function () {
    navigateToUrl("", "", loginWindowPath);
});

$(myChecklistClass).on("click", function () {
    navigateToUrl("", "", myChecklistPath);
});

$(myBookingClass).on("click", function () {
    navigateToUrl("", "", bookingListPath);
});

$(changeEmailClass).on("click", function () {
    navigateToUrl("", "", changeEmailPath);
});

$(changePasswordClass).on("click", function () {
    navigateToUrl("", "", changePasswordPath);
});

$(registerButtonId).click(function () {
    isRegisterButtonClicked = true;
    registerButtonValidation();
});

$(loginSmallButtonId).click(function () {
    isLoginButtonClicked = true;
    loginButtonValidation();
});

$(loginLargeButtonId).click(function () {
    isLoginButtonClicked = true;
    loginButtonValidation();
});

$(resetPasswordLinkSmallButtonId).click(function () {
    isResetPasswordLinkButtonClicked = true;
    resetPasswordLinkButtonValidation();
});

$(resetPasswordLinkLargeButtonId).click(function () {
    isResetPasswordLinkButtonClicked = true;
    resetPasswordLinkButtonValidation();
});

$(resetPasswordSmallButtonId).click(function () {
    isResetPasswordButtonClicked = true;
    resetPasswordButtonValidation();
});

$(resetPasswordLargeButtonId).click(function () {
    isResetPasswordButtonClicked = true;
    resetPasswordButtonValidation();
});

$(userProfileButtonId).click(function () {
    isUserProfileButtonClicked = true;
    userProfileButtonValidation();
});

$(changeEmailButtonId).click(function () {
    isChangeEmailButtonClicked = true;
    changeEmailButtonValidation();
});

$(changeEmailSendCodeClass).click(function () {
    isChangeEmailButtonClicked = true;
    $(changeEmailCodeInputClass).val("");
    if (changeEmailButtonValidation(true)) {
        sendEmailVerificationCode();
    }
});

$(changePasswordSmallButtonId).click(function () {
    isChangePasswordButtonClicked = true;
    changePasswordButtonValidation();
});

$(changePasswordLargeButtonId).click(function () {
    isChangePasswordButtonClicked = true;
    changePasswordButtonValidation();
});

$(footerSubscriptionEmailId).on("focusout", function () {
    if (isEmailSubscriptionButtonClicked) {
        emailValidation(footerSubscriptionEmailId, footerSubscriptionEmailErrorMessageId, footerSubscriptionEmailInvalidErrorMessageId);
    }
});

$(registerFirstNameId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        textBoxValidation(registerFirstNameId, registerFirstNameErrorMessageId);
    }
});

$(registerLastNameId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        textBoxValidation(registerLastNameId, registerLastNameErrorMessageId);
    }
});

$(registerPasswordId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        passwordValidation(registerPasswordId, registerPasswordErrorMessageId, registerPasswordInvalidErrorMessageId, "", true, true, registerPasswordRequirementsErrorMessageId);

        if ($(registerConfirmPasswordId).val()) {
            passwordValidation(registerConfirmPasswordId, registerConfirmPasswordErrorMessageId, registerConfirmPasswordInvalidErrorMessageId, registerPasswordId, true);
        }
    }
});

$(registerPasswordId).on("focusin", function () {
    $(this).data('val', $(this).val());
});

$(registerPasswordId).on("keydown", function () {
    checkPasswordRequirements(this, registerPasswordId);
});

$(registerConfirmPasswordId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        passwordValidation(registerConfirmPasswordId, registerConfirmPasswordErrorMessageId, registerConfirmPasswordInvalidErrorMessageId, registerPasswordId, true);
    }
});

$(registerDateOfBirthId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        var dateBoxTimeout = setTimeout(function () {
            dateBoxValidation(registerDateOfBirthId, registerDateOfBirthErrorMessageId, registerDateOfBirthInvalidErrorMessageId);
            clearTimeout(dateBoxTimeout);
        }, 250);
    }
});

$(registerEmailId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        emailValidation(registerEmailId, registerEmailErrorMessageId, registerEmailInvalidErrorMessageId);
    }
});

$(registerPhoneId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        textBoxValidation(registerPhoneId, registerPhoneErrorMessageId, true, registerPhoneInvalidErrorMessage);
    }
});

$(registerSecurityQuestionId).on("change", function () {
    if (isRegisterButtonClicked) {
        textBoxValidation(registerSecurityQuestionId, registerSecurityQuestionErrorMessageId);
    }
});

$(registerSecurityAnswerId).on("focusout", function () {
    if (isRegisterButtonClicked) {
        textBoxValidation(registerSecurityAnswerId, registerSecurityAnswerErrorMessageId);
    }
});

$(registerMaleGenderId).on("click", function () {
    if (getRadioButtonValue(registerMaleGenderId)) {
        $(registerFemaleGenderId).prop("checked", false);
    }

    if (isRegisterButtonClicked) {
        radioButtonValidation(registerGenderDataId, registerRadioButtonContainerId, registerGenderErrorMessageId);
    }
});

$(registerFemaleGenderId).on("click", function () {
    if (getRadioButtonValue(registerFemaleGenderId)) {
        $(registerMaleGenderId).prop("checked", false);
    }

    if (isRegisterButtonClicked) {
        radioButtonValidation(registerGenderDataId, registerRadioButtonContainerId, registerGenderErrorMessageId);
    }
});

$(loginEmailId).on("focusout", function () {
    if (isLoginButtonClicked) {
        emailValidation(loginEmailId, loginEmailErrorMessageId, loginEmailInvalidErrorMessageId);
    }
});

$(loginPasswordId).on("focusout", function () {
    if (isLoginButtonClicked) {
        passwordValidation(loginPasswordId, loginPasswordErrorMessageId, loginPasswordInvalidErrorMessageId);
    }
});

$(loginEmailId).on("keyup", function (event) {
    triggerLogin(event);
});

$(loginPasswordId).on("keyup", function (event) {
    triggerLogin(event);
});

$(resetPasswordEmailId).on("focusout", function () {
    if (isResetPasswordButtonClicked || isResetPasswordLinkButtonClicked) {
        emailValidation(resetPasswordEmailId, resetPasswordEmailErrorMessageId, resetPasswordEmailInvalidErrorMessageId);
    }
});

$(resetPasswordPasswordId).on("focusout", function () {
    if (isResetPasswordButtonClicked) {
        passwordValidation(resetPasswordPasswordId, resetPasswordPasswordErrorMessageId, resetPasswordPasswordInvalidErrorMessageId, "", true, true, resetPasswordPasswordRequirementsErrorMessageId);

        if ($(resetPasswordConfirmPasswordId).val()) {
            passwordValidation(resetPasswordConfirmPasswordId, resetPasswordConfirmPasswordErrorMessageId, resetPasswordConfirmPasswordInvalidErrorMessageId, resetPasswordPasswordId, true);
        }
    }
});

$(resetPasswordPasswordId).on("focusin", function () {
    $(this).data('val', $(this).val());
});

$(resetPasswordPasswordId).on("keydown", function () {
    checkPasswordRequirements(this, resetPasswordPasswordId);
});

$(resetPasswordConfirmPasswordId).on("focusout", function () {
    if (isResetPasswordButtonClicked) {
        passwordValidation(resetPasswordConfirmPasswordId, resetPasswordConfirmPasswordErrorMessageId, resetPasswordConfirmPasswordInvalidErrorMessageId, resetPasswordPasswordId, true);
    }
});

// Load user profile data
$(userProfileContainerClass).ready(function () {
    $(userProfileDateOfBirthId).val(new Date($(userProfileDateOfBirthValueId).val()));
    $(userProfilePhoneId).val($(userProfilePhoneValueId).val());
    $(userProfileDateOfBirthId).val(moment($(userProfileDateOfBirthValueId).val()).format(mmddyyyyDateFormat));
    $(userProfileSecurityQuestionId).val($(userProfileSecurityQuestionValueId).val()).change();
    setImage($(userProfileImageValueId).val(), userProfileImageId, userProfileRemoveImageClass, userProfileDefaultImageId);

    userProfileGenderDataId.forEach(function (userProfileGenderId) {
        setRadioButtonSelection(userProfileGenderId, $(userProfileGenderValueId).val());
    });
});

$(userProfileFirstNameId).on("focusout", function () {
    if (isUserProfileButtonClicked) {
        textBoxValidation(userProfileFirstNameId, userProfileFirstNameErrorMessageId);
    }
});

$(userProfileLastNameId).on("focusout", function () {
    if (isUserProfileButtonClicked) {
        textBoxValidation(userProfileLastNameId, userProfileLastNameErrorMessageId);
    }
});

$(userProfileDateOfBirthId).on("focusout", function () {
    if (isUserProfileButtonClicked) {
        var dateBoxTimeout = setTimeout(function () {
            dateBoxValidation(userProfileDateOfBirthId, userProfileDateOfBirthErrorMessageId, userProfileDateOfBirthInvalidErrorMessageId);
            clearTimeout(dateBoxTimeout);
        }, 250);
    }
});

$(userProfilePhoneId).on("focusout", function () {
    if (isUserProfileButtonClicked) {
        textBoxValidation(userProfilePhoneId, userProfilePhoneErrorMessageId, true, userProfilePhoneInvalidErrorMessage);
    }
});

$(userProfileSecurityQuestionId).on("change", function () {
    if (isUserProfileButtonClicked) {
        textBoxValidation(userProfileSecurityQuestionId, userProfileSecurityQuestionErrorMessageId);
    }
});

$(userProfileSecurityAnswerId).on("focusout", function () {
    if (isUserProfileButtonClicked) {
        textBoxValidation(userProfileSecurityAnswerId, userProfileSecurityAnswerErrorMessageId);
    }
});

$(userProfileMaleGenderId).on("click", function () {
    if (getRadioButtonValue(userProfileMaleGenderId)) {
        $(userProfileFemaleGenderId).prop("checked", false);
    }

    if (isUserProfileButtonClicked) {
        radioButtonValidation(userProfileGenderDataId, userProfileRadioButtonContainerId, userProfileGenderErrorMessageId);
    }
});

$(userProfileFemaleGenderId).on("click", function () {
    if (getRadioButtonValue(userProfileFemaleGenderId)) {
        $(userProfileMaleGenderId).prop("checked", false);
    }

    if (isUserProfileButtonClicked) {
        radioButtonValidation(userProfileGenderDataId, userProfileRadioButtonContainerId, userProfileGenderErrorMessageId);
    }
});

$(userProfileUploadId).on("change", function () {
    handleUploadedFiles(this.files, userProfileImageId, userProfile, imageFileType, "", true);
});

$(userProfileImageId).on("load", function () {
    hideShowUserImage(userProfileImageId, userProfileRemoveImageClass, userProfileDefaultImageId, userProfileImageDragAndDropContainerClass);
});

$(userProfileUploadId).on("click", function (event) {
    event.target.value = "";
});

$(userProfileRemoveImageClass).on("click", function () {
    $(userProfileImageId).attr("src", "");
    userProfileImageData = "";
    userProfileFileName = "";
    userProfileFileType = "";
    hideShowUserImage(userProfileImageId, userProfileRemoveImageClass, userProfileDefaultImageId, userProfileImageDragAndDropContainerClass);
});

$(changeEmailCodeInputClass).on("keyup", function (event) {
    focusNextElementOnNumberInput(this, event);
});

$(changeEmailCodeInputClass).on("keydown", function (event) {
    codeInputFormat(this, event, true);
});

$(changeEmailCodeInputClass).on("focusout", function () {
    if (isChangeEmailButtonClicked) {
        $(this).removeClass(validationClass);

        if (!this.value) {
            $(this).addClass(validationClass);
        }
    }
});

$(changeEmailEmailId).on("focusout", function () {
    if (isChangeEmailButtonClicked) {
        var isEmailValid = emailValidation(changeEmailEmailId, changeEmailEmailErrorMessageId, changeEmailEmailInvalidErrorMessageId);
        formatClassStyle(isEmailValid, changeEmailSendCodeClass, "mt-0");

        if (!isEmailValid) {
            $(changeEmailEmailSendVerificationCodeErrorMessage).addClass("hide");
            $(changeEmailEmailCodeVerificationErrorMessage).addClass("hide");
        }
    }
});

$(changePasswordCurrentPasswordId).on("focusout", function () {
    if (isChangePasswordButtonClicked) {
        textBoxValidation(changePasswordCurrentPasswordId, changePasswordCurrentPasswordErrorMessageId);
    }
});

$(changePasswordPasswordId).on("focusout", function () {
    if (isChangePasswordButtonClicked) {
        passwordValidation(changePasswordPasswordId, changePasswordPasswordErrorMessageId, changePasswordPasswordInvalidErrorMessageId, "", true, true, changePasswordPasswordRequirementsErrorMessageId);
        passwordValidation(changePasswordPasswordId, "", "", changePasswordCurrentPasswordId, "", false, "", true, changePasswordPasswordSameAsCurrentPasswordErrorMessageId);

        if ($(changePasswordConfirmPasswordId).val()) {
            passwordValidation(changePasswordConfirmPasswordId, changePasswordConfirmPasswordErrorMessageId, changePasswordConfirmPasswordInvalidErrorMessageId, changePasswordPasswordId, true);
        }
    }
});

$(changePasswordPasswordId).on("focusin", function () {
    $(this).data('val', $(this).val());
});

$(changePasswordPasswordId).on("keydown", function () {
    checkPasswordRequirements(this, changePasswordPasswordId);
});

$(changePasswordConfirmPasswordId).on("focusout", function () {
    if (isChangePasswordButtonClicked) {
        passwordValidation(changePasswordConfirmPasswordId, changePasswordConfirmPasswordErrorMessageId, changePasswordConfirmPasswordInvalidErrorMessageId, changePasswordPasswordId, true);
    }
});

$(myChecklistItemNameId).on("focusout", function () {
    if (isMyChecklistItemAddButtonClicked) {
        textBoxValidation(myChecklistItemNameId, myChecklistItemNameErrorMessageId);
    }
});

$(loginPasswordEyeIconClass).on("click", function () {
    $(loginPasswordEyeSlashIconClass).removeClass("hide");
    $(loginPasswordEyeIconClass).addClass("hide");
    $(loginPasswordId).attr("type", "password");
});

$(loginPasswordEyeSlashIconClass).on("click", function () {
    $(loginPasswordEyeIconClass).removeClass("hide");
    $(loginPasswordEyeSlashIconClass).addClass("hide");
    $(loginPasswordId).attr("type", "text");
});

$(leftHandIconContainerClass).hover(function () {
    localStorage.setItem(isFirstTimeLocationPageVisitKey, "false");
});

$(myChecklistItemAddButtonClass).on("click", function () {
    isMyChecklistItemAddButtonClicked = true;

    if (textBoxValidation(myChecklistItemNameId, myChecklistItemNameErrorMessageId)) {
        ajaxRequest(
            "POST",
            createUpdateMyChecklistItemApiUrl,
            {
                ChecklistId: urlParams.get("checklistId"),
                ChecklistItemName: $(myChecklistItemNameId).val(),
                BookingId: urlParams.get("bookingId")
            },
            "JSON",
            createMyChecklistItemSuccess,
            createMyChecklistItemError
        );
    }
});

function createMyChecklistItemSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        showToastNotification("Checklist Item - Add", successResult.SuccessMessage, "success");
        appendChecklistItem(successResult?.ResponseData);
    }
    else if (isInvalidResponse(successResult)) {
        showToastNotification("Checklist Item - Add", successResult.ErrorMessage, "error");
    }

    hideSpinner();
}

function createMyChecklistItemError(errorResult) {
    showToastNotification("Checklist Item - Add", getErrorMessage(errorResult), "error");
    hideSpinner();
}

function appendChecklistItem(data) {
    if (data) {
        var checklistItemId = data["ChecklistItemId"];
        var targetElementId = myChecklistItemTableRowId.substring(hash_selector.length) + checklistItemId;

        var trElement = document.createElement("tr");
        $(trElement).attr("id", targetElementId);
        $(trElement).addClass(myChecklistItemTableRowClass.substring(period_selector.length));

        var tdElement = document.createElement("td");
        $(tdElement).addClass(myChecklistItemTableCheckboxContainerClass.substring(period_selector.length));

        let checkboxInputElement = document.createElement("input");
        $(checkboxInputElement).attr("type", "checkbox");
        $(checkboxInputElement).attr("id", myChecklistItemCheckboxId.substring(hash_selector.length) + checklistItemId);
        $(checkboxInputElement).addClass(myChecklistItemCheckboxClass.substring(period_selector.length) + whiteSpaceString + cursorPointerClass);
        $(checkboxInputElement).attr("onclick", "checkMyChecklistItem('" + checklistItemId + "')")

        $(tdElement).append(checkboxInputElement);
        $(trElement).append(tdElement);

        tdElement = document.createElement("td");
        $(tdElement).addClass(myChecklistItemTableNameContainerClass.substring(period_selector.length));

        let spanElement = document.createElement("span");
        $(spanElement).attr("id", myChecklistItemTableNameId.substring(hash_selector.length) + checklistItemId);
        $(spanElement).addClass(myChecklistItemTableNameClass.substring(period_selector.length));
        $(spanElement).text(data["Name"]);

        $(tdElement).append(spanElement);

        let textInputElement = document.createElement("input");
        $(textInputElement).attr("type", "text");
        $(textInputElement).attr("id", myChecklistItemTableNameInputId.substring(hash_selector.length) + checklistItemId);
        $(textInputElement).addClass("form-control" + whiteSpaceString + "hide");
        $(textInputElement).attr("onkeyup", "updateChecklistItemOnEnterKey(event, " + checklistItemId  + ");");
        $(textInputElement).attr("onblur", "updateChecklistItem(" + checklistItemId + ");");

        $(tdElement).append(textInputElement);
        $(trElement).append(tdElement);

        tdElement = document.createElement("td");

        var iElement = document.createElement("i");
        $(iElement).addClass(myChecklistItemTableEditIconElementClasses);
        $(iElement).attr("onclick", "updateMyChecklistItem('" + checklistItemId + "')");
        $(iElement).attr("title", "Edit");

        $(tdElement).append(iElement);
        $(trElement).append(tdElement);

        tdElement = document.createElement("td");
        $(tdElement).addClass(pl15Class);

        iElement = document.createElement("i");
        $(iElement).addClass(myChecklistItemTableDeleteIconElementClasses);
        $(iElement).attr("onclick", "deleteMyChecklistItem('" + checklistItemId + "')");
        $(iElement).attr("title", "Delete");

        $(tdElement).append(iElement);
        $(trElement).append(tdElement);

        var myChecklistItemTableBodyElement = $(myChecklistItemTableBodyClass);

        if (myChecklistItemTableBodyElement.length) {
            myChecklistItemTableBodyElement.append(trElement);
            myChecklistItemTableBodyElement.append(getTableRowSpacer());
        }
        else {
            var myChecklistItemListContainerRowElement = document.createElement("div");
            $(myChecklistItemListContainerRowElement).addClass(rowClass);

            var myChecklistItemListContainerColumnElement = document.createElement("div");
            $(myChecklistItemListContainerColumnElement).addClass(colMd12Class);

            var myChecklistItemListContainerTableElement = document.createElement("table");
            $(myChecklistItemListContainerTableElement).addClass(myChecklistItemListContainerTableElementClass);

            var myChecklistItemListContainerTableBodyElement = document.createElement("tbody");
            $(myChecklistItemListContainerTableBodyElement).addClass(myChecklistItemTableBodyClass.substring(period_selector.length));

            $(myChecklistItemListContainerTableBodyElement).append(trElement);
            $(myChecklistItemListContainerTableBodyElement).append(getTableRowSpacer());
            $(myChecklistItemListContainerTableElement).append(myChecklistItemListContainerTableBodyElement);
            $(myChecklistItemListContainerColumnElement).append(myChecklistItemListContainerTableElement);
            $(myChecklistItemListContainerRowElement).append(myChecklistItemListContainerColumnElement);
            $(myChecklistItemListContainerClass).append(myChecklistItemListContainerRowElement);
        }

        $(myChecklistItemNameId).val("");
        isMyChecklistItemAddButtonClicked = false;

        if ($(myChecklistItemTableBodyClass).children().length > 12) {
            scrollTo(hash_selector + targetElementId, -10);
        }
    }
}

function getTableRowSpacer() {
    var trElement = document.createElement("tr");
    $(trElement).addClass(myChecklistItemTableSpacerClass.substring(period_selector.length));

    var tdElement = document.createElement("td");
    $(tdElement).attr("colspan", "100");

    $(trElement).append(tdElement);

    return trElement;
}

$(logOutLinkClass).on("click", function () {
    setMessageModelData("Logout", "<span>Are you sure you want to Logout?</span>", yesText, noText, logout, closeMessageModal, null, null, "warning");
    showMessageModal();
});

function checkPasswordRequirements(targetElementId, passwordId) {
    var passwordValue = $(targetElementId).val();
    var checkElements = $(".password-requirement-group .fa-check");
    var timesElements = $(".password-requirement-group .fa-times");
    var passwordValue = $(passwordId).val();

    checkElements.each(function (index, value) {
        $(value).addClass("hide");
    });

    timesElements.each(function (index, value) {
        $(value).addClass("hide");
    });

    if (passwordValue) {
        passwordMeetingRequirementCheck("#password_requirement_length", (passwordValue.length >= 8));
        passwordMeetingRequirementCheck("#password_requirement_lower_case_character", (passwordValue.match(lowerCaseMatchRegexPattern)?.length));
        passwordMeetingRequirementCheck("#password_requirement_upper_case_character", (passwordValue.match(upperCaseMatchRegexPattern)?.length));
        passwordMeetingRequirementCheck("#password_requirement_number", (passwordValue.match(numericMatchRegexPattern)?.length));
        passwordMeetingRequirementCheck("#password_requirement_special_character", (passwordValue.match(specialCharacterMatchRegexPattern)?.length));
    }
}

function passwordMeetingRequirementCheck(targetElementId, isValid) {
    if (isValid) {
        $(targetElementId + " .fa-check").removeClass("hide");
        $(targetElementId + " .fa-times").addClass("hide");
    }
    else {
        $(targetElementId + " .fa-check").addClass("hide");
        $(targetElementId + " .fa-times").removeClass("hide");
    }
}

function setRadioButtonSelection(targetElementId, targetValue) {
    if ($(targetElementId).siblings(".radio-option").text() == targetValue) {
        $(targetElementId).prop("checked", "true");
    }
}

function getRadioButtonValue(targetElementId) {
    var selectedValue = "";

    if ($(targetElementId + ":checked").val() == "on") {
        selectedValue = $(targetElementId).siblings(".radio-option").text();
    }

    return selectedValue;
}

function textBoxValidation(targetElementId, errorMessageId, isPhone, phoneErrorMessageId) {
    var isValid = true;

    $(errorMessageId).addClass("hide");
    var targetElementValue = $(targetElementId).val();
    $(targetElementId).removeClass(validationClass);

    if (!targetElementValue) {
        $(targetElementId).addClass(validationClass);
        $(errorMessageId).removeClass("hide");
        isValid = false;
    }
    else if (isPhone) {
        $(phoneErrorMessageId).addClass("hide");
        var phone = targetElementValue.replace(/_/g, "").replace("(", "").replace(")", "").replace("-", "").replace(whiteSpaceString, "");

        if (phone.length < 10) {
            $(targetElementId).addClass(validationClass);
            $(phoneErrorMessageId).text();
            $(phoneErrorMessageId).removeClass("hide");
            $(targetElementId).addClass("margin-bottom-5");
            isValid = false;
        }
    }

    return isValid;
}

function dateBoxValidation(dateBoxElementID, dateBoxErrorMessageId, dateBoxInvalidErrorMessageId) {
    var isValid = true;

    $(dateBoxErrorMessageId).addClass("hide");
    $(dateBoxInvalidErrorMessageId).addClass("hide");
    var dateBoxValue = $(dateBoxElementID).val();
    $(dateBoxElementID).removeClass(validationClass);

    if (!dateBoxValue) {
        $(dateBoxElementID).addClass(validationClass);
        $(dateBoxErrorMessageId).removeClass("hide");
        isValid = false;
    }
    else if ((!dateRegexPattern.test(dateBoxValue)) || (!moment(dateBoxValue, mmddyyyyDateFormat, true).isValid())) {
        $(dateBoxElementID).addClass(validationClass);
        $(dateBoxInvalidErrorMessageId).removeClass("hide");
        isValid = false;
    }

    if (isValid) {
        var currentDate = new Date();
        var selectedDate = new Date(dateBoxValue);
        var minDate = $(dateBoxElementID).datepicker("option", "minDate");
        var maxDate = $(dateBoxElementID).datepicker("option", "maxDate");

        if ((minDate != null && selectedDate < currentDate) || (maxDate != null && selectedDate > currentDate)) {
            $(dateBoxElementID).addClass(validationClass);
            $(dateBoxInvalidErrorMessageId).removeClass("hide");
            isValid = false;
        }
    }

    return isValid;
}

function radioButtonValidation(radionButtonData, radioButtonContainerId, radioButtonErrorMessageId) {
    var isValid = false;
    $(radioButtonErrorMessageId).addClass("hide");
    $(radioButtonContainerId).removeClass("margin-left-m10 ml-0");

    if (isLargeView) {
        $(radioButtonContainerId).addClass("margin-left-m65")
    }

    radionButtonData.forEach(function (value) {
        if (getRadioButtonValue(value)) {
            isValid = true;
            return;
        }
    });

    if (!isValid) {
        if (!isLargeView) {
            $(radioButtonContainerId).addClass("ml-0")
        }
        else {
            $(radioButtonContainerId).addClass("margin-left-m10");
        }

        $(radioButtonErrorMessageId).removeClass("hide");
    }

    return isValid;
}

function numberValidation(numberElementId, numberErrorMessageId, numberInvalidErrorMessageId, length, isNoMarginBottom, isValidateEqualLength) {
    var isValid = true;
    var numberValidationClass = isNoMarginBottom ? errorFocusControlClass : validationClass;

    $(numberErrorMessageId).addClass("hide");
    $(numberInvalidErrorMessageId).addClass("hide");

    var numberValue = $(numberElementId).val();
    $(numberElementId).removeClass(numberValidationClass);

    if (!numberValue || !parseInt(numberValue)) {
        $(numberElementId).addClass(numberValidationClass);
        $(numberErrorMessageId).removeClass("hide");
        isValid = false;
    }
    else if (isValidateEqualLength && numberValue.replace(whiteSpaceRegexPattern, "").length != length) {
        $(numberElementId).addClass(numberValidationClass);
        $(numberInvalidErrorMessageId).removeClass("hide");
        isValid = false;
    }

    return isValid;
}

function cardNumberValidation(numberElementId, numberErrorMessageId, numberInvalidErrorMessageId, length, isNoMarginBottom, isValidateEqualLength) {
    var isValid = numberValidation(numberElementId, numberErrorMessageId, numberInvalidErrorMessageId, length, isNoMarginBottom, isValidateEqualLength);
    var cardNumberValidationClass = isNoMarginBottom ? errorFocusControlClass : validationClass;

    if (isValid) {
        isValid = $(".card-type-icon").hasClass("show");

        if (!isValid) {
            $(numberElementId).addClass(cardNumberValidationClass);
            $(numberInvalidErrorMessageId).removeClass("hide");
        }
    }

    return isValid;
}

function cardExpiryValidation(targetElementId, errorMessageId, invalidErrorMessageId) {
    var isValid = true;

    $(errorMessageId).addClass("hide");
    $(invalidErrorMessageId).addClass("hide");

    var targetElementValue = $(targetElementId).val();
    $(targetElementId).removeClass(errorFocusControlClass);

    if (!targetElementValue) {
        $(targetElementId).addClass(errorFocusControlClass);
        $(errorMessageId).removeClass("hide");
        isValid = false;
    }
    else {
        targetElementValue = targetElementValue.replace(whiteSpaceRegexPattern, "");
        isValid = targetElementValue.length == 5;

        if (isValid) {
            var dateParts = targetElementValue.split(forwardSlash);
            var currentDate = new Date();

            var month = parseInt(dateParts[0]);
            var year = parseInt(dateParts[1]);

            var currentMonth = currentDate.getMonth() + 1;
            var currentYear = parseInt(currentDate.getFullYear().toString().substring(2));

            isValid = (year > currentYear) || (year === currentYear && month >= currentMonth);
        }

        if (!isValid) {
            $(targetElementId).addClass(errorFocusControlClass);
            $(invalidErrorMessageId).removeClass("hide");
            isValid = false;
        }
    }

    return isValid;
}

function grecaptchaValidation(recaptchaId, recaptchaErrorMessageId) {
    var isValid = true;
    $(recaptchaErrorMessageId).addClass("hide");

    var response = grecaptcha.getResponse();
    if (!response.length) {
        $(recaptchaId + " iframe").css("border", "1px solid #f00").css("box-shadow", "0 0 0 0.1rem rgb(254 165 22 / 24%)").css("border-radius", "5px");
        $(recaptchaErrorMessageId).removeClass("hide");
        isValid = false;
    }

    return isValid;
}

function registerButtonValidation() {
    var isFirstNameValid = textBoxValidation(registerFirstNameId, registerFirstNameErrorMessageId);
    var isLastNameValid = textBoxValidation(registerLastNameId, registerLastNameErrorMessageId);
    var isPasswordValid = passwordValidation(registerPasswordId, registerPasswordErrorMessageId, registerPasswordInvalidErrorMessageId, "", true, true, registerPasswordRequirementsErrorMessageId);
    var isConfirmPasswordValid = passwordValidation(registerConfirmPasswordId, registerConfirmPasswordErrorMessageId, registerConfirmPasswordInvalidErrorMessageId, registerPasswordId, true);
    var isDateOfBirthValid = dateBoxValidation(registerDateOfBirthId, registerDateOfBirthErrorMessageId, registerDateOfBirthInvalidErrorMessageId);
    var isEmailValid = emailValidation(registerEmailId, registerEmailErrorMessageId, registerEmailInvalidErrorMessageId);
    var isPhoneValid = textBoxValidation(registerPhoneId, registerPhoneErrorMessageId, true);
    var isSecurityQuestionValid = textBoxValidation(registerSecurityQuestionId, registerSecurityQuestionErrorMessageId);
    var isSecurityAnswerValid = textBoxValidation(registerSecurityAnswerId, registerSecurityAnswerErrorMessageId);
    var isGenderValid = radioButtonValidation(registerGenderDataId, registerRadioButtonContainerId, registerGenderErrorMessageId);

    if (isFirstNameValid && isLastNameValid && isPasswordValid && isConfirmPasswordValid && isDateOfBirthValid &&
        isEmailValid && isPhoneValid && isSecurityQuestionValid && isSecurityAnswerValid && isGenderValid) {

        var selectedGender;
        registerGenderDataId.forEach(function (value) {
            var gender = getRadioButtonValue(value);
            if (gender) {
                selectedGender = gender;
                return;
            }
        });

        ajaxRequest(
            "POST",
            insertUserApiUrl,
            {
                FirstName: $(registerFirstNameId).val(),
                LastName: $(registerLastNameId).val(),
                Password: $(registerPasswordId).val(),
                DateOfBirth: $(registerDateOfBirthId).val(),
                Email: $(registerEmailId).val(),
                Phone: $(registerPhoneId).val(),
                SecurityQuestionId: $(registerSecurityQuestionId).val(),
                SecurityAnswer: $(registerSecurityAnswerId).val(),
                Gender: selectedGender
            },
            "JSON",
            registerSuccess,
            registerError
        );
    }
}

var registerSuccess = function (successResult) {
    if (isRedirection(successResult)) {
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Registration Success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, closeText, registerCloseMessageModal, registerCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        setMessageModelData("Registraion Error", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
    }

    hideSpinner();
}

var registerError = function (errorResult) {
    setMessageModelData("Registraion Error", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function loginButtonValidation() {
    var isEmailValid = emailValidation(loginEmailId, loginEmailErrorMessageId, loginEmailInvalidErrorMessageId);
    var isPhoneValid = passwordValidation(loginPasswordId, loginPasswordErrorMessageId, loginPasswordInvalidErrorMessageId);

    if (isEmailValid && isPhoneValid) {
        ajaxRequest(
            "GET",
            loginApiUrl + windowLocationSearch,
            {
                Email: $(loginEmailId).val(),
                Password: $(loginPasswordId).val()
            },
            "JSON",
            loginSuccess,
            loginError
        );
    }
}

function triggerLogin(event) {
    if (event.keyCode == 13) {
        $(loginButtonClass).click();
    }
}

var loginSuccess = function (successResult) {
    if (isRedirection(successResult)) {
        var loginEmailValue = successResult.ResponseData["Email"];
        var loginEmailKeyValue = localStorage.getItem(loginEmailKey);

        if (loginEmailKeyValue && loginEmailValue && (loginEmailKeyValue != loginEmailValue)) {
            sendEmailCodeTimer(false, 0);
        }

        localStorage.setItem(loginEmailKey, loginEmailValue);
        navigateToUrl(successResult.Controller, successResult.Action);
        hideSpinner(2000);
    }
    else if (isInvalidResponse(successResult)) {
        setMessageModelData("Login Error", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
        hideSpinner();
    }
}

var loginError = function (errorResult) {
    setMessageModelData("Login Error", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, loginCloseMessageModal, loginCloseMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function logout() {
    ajaxRequest(
        "POST",
        logoutApiUrl,
        "",
        "JSON",
        logoutSuccess);
}

var logoutSuccess = function (successResult) {
    if (isRedirection(successResult, true)) {
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Logout Success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, "", logoutCloseMessageModal, logoutCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
        hideSpinner();
    }
}

function keepSessionAlive() {
    ajaxRequest(
        "GET",
        keepSessionAlivePath,
        "",
        "JSON",
        keepSessionAliveSuccess,
        keepSessionAliveError);
}

function keepSessionAliveSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        clearInterval(sessionTimeoutInterval);
        closeMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        unauthorizedErrorMessageModal(successResult.ErrorMessage);
    }
    hideSpinner();
}

function keepSessionAliveError(errorResult) {
    unauthorizedErrorMessageModal(getErrorMessage(errorResult));
    hideSpinner();
}

function unauthorizedErrorMessageModal(errorMessage) {
    setMessageModelData("Unathorized Access", "<span>" + (errorMessage ? errorMessage : "Unauthorized access!") + "</span>", okText, closeText, closeNavigateToLoginPage, closeNavigateToLoginPage, null, null, "error");
    showMessageModal();
}

function closeNavigateToLoginPage() {
    navigateToUrl("", "", loginWindowPath);
}

function resetPasswordLinkButtonValidation() {
    var isEmailValid = emailValidation(resetPasswordEmailId, resetPasswordEmailErrorMessageId, resetPasswordEmailInvalidErrorMessageId);
    var isRecaptchaValid = grecaptchaValidation(resetPasswordRecaptchaId, resetPasswordRecaptchaErrorMessageId);

    if (isEmailValid && isRecaptchaValid) {
        ajaxRequest(
            "POST",
            sendPasswordResetApiUrl,
            {
                Email: $(resetPasswordEmailId).val(),
                GoogleRecaptchaResponse: googleRecaptchaResponse
            },
            "JSON",
            sendPasswordResetLinkSuccess,
            sendPasswordResetLinkError
        );
    }
}

function resetPasswordButtonValidation() {
    var isPasswordValid = passwordValidation(resetPasswordPasswordId, resetPasswordPasswordErrorMessageId, resetPasswordPasswordInvalidErrorMessageId, "", true, true, resetPasswordPasswordRequirementsErrorMessageId);
    var isConfirmPasswordValid = passwordValidation(resetPasswordConfirmPasswordId, resetPasswordConfirmPasswordErrorMessageId, resetPasswordConfirmPasswordInvalidErrorMessageId, resetPasswordPasswordId, true);

    if (isPasswordValid && isConfirmPasswordValid) {
        ajaxRequest(
            "GET",
            resetPasswordApiUrl.replace("{1}", $(resetPasswordPasswordId).val()),
            "",
            "JSON",
            resetPasswordSuccess,
            resetPasswordError
        );
    }
}

var sendPasswordResetLinkSuccess = function (successResult) {
    if (isRedirection(successResult)) {
        sendPasswordResetLinkSuccessShowMessageModal(successResult);
    }
    else if (isInvalidResponse(successResult)) {
        sendPasswordResetLinkErrorShowMessageModal(successResult);
    }
    hideSpinner();
}

var sendPasswordResetLinkError = function (errorResult) {
    sendPasswordResetLinkErrorShowMessageModal(errorResult);
    hideSpinner();
}

var resetPasswordSuccess = function (successResult) {
    if (isRedirection(successResult)) {
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Password Reset", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, closeText, resetPasswordCloseMessageModal, resetPasswordCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        setMessageModelData("Profile Reset", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
    }
    hideSpinner();
}

var resetPasswordError = function (errorResult) {
    setMessageModelData("Password Reset", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function userProfileButtonValidation() {
    var isFirstNameValid = textBoxValidation(userProfileFirstNameId, userProfileFirstNameErrorMessageId);
    var isLastNameValid = textBoxValidation(userProfileLastNameId, userProfileLastNameErrorMessageId);
    var isDateOfBirthValid = dateBoxValidation(userProfileDateOfBirthId, userProfileDateOfBirthErrorMessageId, userProfileDateOfBirthInvalidErrorMessageId);
    var isPhoneValid = textBoxValidation(userProfilePhoneId, userProfilePhoneErrorMessageId, true);
    var isSecurityQuestionValid = textBoxValidation(userProfileSecurityQuestionId, userProfileSecurityQuestionErrorMessageId);
    var isSecurityAnswerValid = textBoxValidation(userProfileSecurityAnswerId, userProfileSecurityAnswerErrorMessageId);
    var isGenderValid = radioButtonValidation(userProfileGenderDataId, userProfileRadioButtonContainerId, userProfileGenderErrorMessageId);

    if (isFirstNameValid && isLastNameValid && isDateOfBirthValid && isPhoneValid &&
        isSecurityQuestionValid && isSecurityAnswerValid && isGenderValid) {

        var selectedGender;
        userProfileGenderDataId.forEach(function (value) {
            var gender = getRadioButtonValue(value);
            if (gender) {
                selectedGender = gender;
                return;
            }
        });

        if (!userProfileImageData && $(userProfileDefaultImageId).hasClass("hide")) {
            var userProfileImageSource = $("#user_profile_image").attr("src");
            userProfileImageData = $(userProfileImageId).attr("src").substring(userProfileImageSource.indexOf(comma) + 1);
            userProfileFileName = $(userProfileImageNameValueId).val();
            userProfileFileType = $(userProfileImageTypeValueId).val();
        }

        ajaxRequest(
            "POST",
            updateUserApiUrl,
            {
                FirstName: $(userProfileFirstNameId).val(),
                LastName: $(userProfileLastNameId).val(),
                DateOfBirth: $(userProfileDateOfBirthId).val(),
                Phone: $(userProfilePhoneId).val(),
                SecurityQuestionId: $(userProfileSecurityQuestionId).val(),
                SecurityAnswer: $(userProfileSecurityAnswerId).val(),
                Gender: selectedGender,
                UserPhoto: userProfileImageData,
                UserPhotoName: userProfileFileName,
                UserPhotoType: userProfileFileType
            },
            "JSON",
            updateUserSuccess,
            updateUserError
        );
    }
}

var updateUserSuccess = function (successResult) {
    if (isRedirection(successResult)) {
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Profile update Success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, closeText, userProfileCloseMessageModal, userProfileCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
    }
    else if (isvalidResponse(successResult)) {
        setMessageModelData("Profile update Success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "success");
        setImage(((userProfileFileType && userProfileImageData) ? (userProfileFileType + userProfileImageData) : "../../Images/User.jpg"), headerProfileImageClass);
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        setMessageModelData("Profile update Error", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
    }

    hideSpinner();
}

var updateUserError = function (errorResult) {
    setMessageModelData("Profile update Error", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function changeEmailButtonValidation(isSkipCodeSentValidation) {
    $(changeEmailEmailSendVerificationCodeErrorMessage).addClass("hide");
    $(changeEmailEmailCodeVerificationErrorMessage).addClass("hide");
    $(changeEmailEmailId).removeClass(mb2Class);
    $(changeEmailCodeInputClass).removeClass(validationClass);

    var isValid;
    var isCodeNotSent;
    var isCodeValid = true;
    var code;
    var isEmailValid = emailValidation(changeEmailEmailId, changeEmailEmailErrorMessageId, changeEmailEmailInvalidErrorMessageId);

    if (!isSkipCodeSentValidation) {
        isCodeNotSent = $(changeEmailCodeContainerClass).hasClass("hide");

        if (isCodeNotSent) {
            formatClassStyle(isValid, changeEmailSendCodeClass, "mt-0");
        }
    }

    $(changeEmailCodeInputClass).each(function (index, item) {
        if (!$(item).val()) {
            $(this).addClass(validationClass);
            isCodeValid = false;
        }
        else {
            if (!isNaN($(item).val())) {
                if (!code) {
                    code = $(item).val().toString();
                }
                else {
                    code += $(item).val().toString();
                }
            }
        }
    });

    isValid = isEmailValid && (isSkipCodeSentValidation || (!isCodeNotSent && isCodeValid));

    if (isCodeNotSent) {
        $(changeEmailEmailId).addClass(mb2Class);
        $(changeEmailEmailSendVerificationCodeErrorMessage).removeClass("hide");
    }

    if (isValid && !isSkipCodeSentValidation) {
        ajaxRequest(
            "GET",
            changeUserEmailApiUrl,
            {
                ChangeEmailRequested: $(changeEmailEmailId).val(),
                ChangeEmailCode: code
            },
            "JSON",
            changeUserEmailSuccess,
            changeUserEmailError
        );
    }

    return isValid;
}

function changeUserEmailSuccess(successResult) {
    var isSuccess;

    if (isRedirection(successResult)) {
        isSuccess = true;
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Email update success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, closeText, changeUserEmailCloseMessageModal, changeUserEmailCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
    }
    else if (isvalidResponse(successResult)) {
        isSuccess = true;
        setMessageModelData("Email update success", "<span>" + successResult.SuccessMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        setMessageModelData("Email update error", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
    }

    if (isSuccess) {
        sendEmailCodeTimer(true, 0, true);
    }

    hideSpinner();
}

function changeUserEmailError(errorResult) {
    setMessageModelData("Email update error", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function sendEmailVerificationCode() {
    $(changeEmailSendCodeClass).addClass("hide");

    ajaxRequest(
        "GET",
        sendEmailVerificationCodeApiUrl,
        {
            ChangeEmailRequested: $(changeEmailEmailId).val()
        },
        "JSON",
        sendEmailVerificationCodeSuccess,
        sendEmailVerificationCodeError
    );
}

function sendEmailVerificationCodeSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        $(changeEmailResendCodeClass).addClass("hide");
        $(changeEmailCodeContainerClass).removeClass("hide");

        var waitTimeToResendCode = $(changeEmailWaitingTimeValueId).val();
        var key = localStorage.getItem(waitTimeToResendCodeKey);

        if (key && key > 0) {
            waitTimeToResendCode = key;
        } else {
            localStorage.setItem(waitTimeToResendCodeKey, waitTimeToResendCode);
        }

        emailCodeSendObject.waitTime = waitTimeToResendCode;

        resendCodeInterval = setInterval(function () {
            if (sendEmailCodeTimer(emailCodeSendObject.firstTime, emailCodeSendObject.waitTime, true) <= 0) {
                clearInterval(resendCodeInterval);
            }
        }, 1000);

        hideSpinner();
    }
    else if (isInvalidResponse(successResult)) {
        $(changeEmailSendCodeClass).removeClass("hide");
        setMessageModelData("Internal Server Error", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
        hideSpinner();
    }
}

function sendEmailVerificationCodeError(errorResult) {
    $(changeEmailSendCodeClass).removeClass("hide");
    setMessageModelData("Internal Servor Error", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function changePasswordButtonValidation() {
    var isCurrentPasswordValid = textBoxValidation(changePasswordCurrentPasswordId, changePasswordCurrentPasswordErrorMessageId);
    var isPasswordValid = passwordValidation(changePasswordPasswordId, changePasswordPasswordErrorMessageId, changePasswordPasswordInvalidErrorMessageId, "", true, true, changePasswordPasswordRequirementsErrorMessageId);
    var isConfirmPasswordValid = passwordValidation(changePasswordConfirmPasswordId, changePasswordConfirmPasswordErrorMessageId, changePasswordConfirmPasswordInvalidErrorMessageId, changePasswordPasswordId, true);
    var isPasswordSameAsCurrentPassword = passwordValidation(changePasswordPasswordId, "", "", changePasswordCurrentPasswordId, "", false, "", true, changePasswordPasswordSameAsCurrentPasswordErrorMessageId);

    if (isCurrentPasswordValid && isPasswordValid && isConfirmPasswordValid && isPasswordSameAsCurrentPassword) {
        ajaxRequest(
            "GET",
            changeUserPasswordApiUrl,
            {
                CurrentPassword: $(changePasswordCurrentPasswordId).val(),
                Password: $(changePasswordPasswordId).val()
            },
            "JSON",
            changeUserPasswordSuccess,
            changeUserPasswordError
        );
    }
}

function changeUserPasswordSuccess(successResult) {
    if (isRedirection(successResult)) {
        var messageData = setMessageData(successResult.IsRedirect, successResult.Controller, successResult.Action);
        setMessageModelData("Password update success", "<span>" + successResult.SuccessMessage ? successResult.SuccessMessage : "" + "</span>", okText, closeText, changeUserPasswordCloseMessageModal, changeUserPasswordCloseMessageModal, messageData, messageData, "success");
        showMessageModal();
    }
    else if (isvalidResponse(successResult)) {
        setMessageModelData("Password update success", "<span>" + successResult.SuccessMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        setMessageModelData("Password update error", "<span>" + successResult.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
        showMessageModal();
    }
    hideSpinner();
}

function changeUserPasswordError(errorResult) {
    setMessageModelData("Password update error", "<span>" + getErrorMessage(errorResult) + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
    hideSpinner();
}

function emailSubscriptionValidation() {
    var isEmailValid = emailValidation(footerSubscriptionEmailId, footerSubscriptionEmailErrorMessageId, footerSubscriptionEmailInvalidErrorMessageId);

    if (isEmailValid) {
        ajaxRequest(
            "GET",
            emailSubscriptionApiUrl + $(footerSubscriptionEmailId).val(),
            "",
            "JSON",
            emailSubscriptionSuccess,
            emailSubscriptionError
        );
    }
}

function emailSubscriptionSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        $(footerSubscriptionEmailContainerClass).addClass("hide");
        $(footerSubscriptionMessageClass).text(successResult.SuccessMessage).removeClass("hide text-danger");
    }
    else if (isInvalidResponse(successResult)) {
        $(footerSubscriptionEmailContainerClass).addClass("hide");
        $(footerSubscriptionMessageClass).text(successResult.ErrorMessage).removeClass("hide").addClass("text-danger");
    }
    hideSpinner();
}

function emailSubscriptionError(errorResult) {
    var errorMessage = getErrorMessage(errorResult);

    if (!errorMessage) {
        $(footerSubscriptionEmailContainerClass).addClass("hide");
        $(footerSubscriptionMessageClass).text(errorMessage).removeClass("hide").addClass("text-danger");
    }

    hideSpinner();
}

$(myChecklistShareIconClass).on("click", function () {
    if (isSmallView) {
        $(myChecklistShareIconClass + whiteSpaceString + tooltipContentElementClass).css("visibility", "visible");
    }
});

createMyChecklist = function createMyChecklist() {
    var options = JSON.parse($(myChecklistActiveBookingId).val());
    var optionData = "<option value='' class='select-placeholder hidden'>Booking</option>";
    options.forEach(function (value) {
        optionData += "<option value='" + value["BookingId"] + "'>" + value["BookingName"] + "</option>"
    });

    setMessageModelData(
        "Checklist - Create",
        "<div class='row'><div class='" + colMd12Class + "'><div class='form-group'><label>Checklist Name</label><input type='text' id='" + myChecklistCheklistNameId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Checklist Name'  maxlength='100'/><span id='" + myChecklistCheklistNameErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(myChecklistChecklistNameErrorMessageTextId).val() + "</span><div><div class='form-group'><label>Booking</label><select id='my_checklist_booking_name' class='form-control mb-2'>"
        + optionData + "</select><span id='" + myChecklistBookingNameErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(myChecklistBookingNameErrorMessageText).val() + "</span></div></div></div>",
        createText,
        cancelText,
        createChecklist,
        closeMessageModal);
    showMessageModal();
    initSelectCustomization();
}

function createChecklist() {
    if (!isMyChecklistCreateButtonClicked) {
        $(myChecklistCheklistNameId).on("focusout", function () {
            if (isMyChecklistCreateButtonClicked) {
                textBoxValidation(myChecklistCheklistNameId, myChecklistCheklistNameErrorMessageId);
            }
        });

        $(myChecklistBookingNameId).on("change", function () {
            if (isMyChecklistCreateButtonClicked) {
                textBoxValidation(myChecklistBookingNameId, myChecklistBookingNameErrorMessageId);
            }
        });
    }

    var isCheckingNameValid = textBoxValidation(myChecklistCheklistNameId, myChecklistCheklistNameErrorMessageId);
    var isBookingNameValid = textBoxValidation(myChecklistBookingNameId, myChecklistBookingNameErrorMessageId);

    if (isCheckingNameValid && isBookingNameValid) {
        ajaxRequest(
            "GET",
            createMyChecklistApiUrl.replace("{0}", $(myChecklistCheklistNameId).val()).replace("{1}", $(myChecklistBookingNameId).val()),
            "",
            "JSON",
            createChecklistSuccess,
            createChecklistError
        );
    }

    isMyChecklistCreateButtonClicked = true;
}

function createChecklistSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        setMessageModelData("Checklist - Create", "<span>" + successResult.SuccessMessage + "</span>", okText, "", closeRefreshMessageModal, closeRefreshMessageModal, null, null, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        showChecklistErrorMessageModel(successResult.ErrorMessage, "Checklist - Create");
    }
    hideSpinner();
}

function createChecklistError(errorResult) {
    showChecklistErrorMessageModel(getErrorMessage(errorResult), "Checklist - Create");
    hideSpinner();
}

deleteMyChecklist = function deleteMyChecklist(checklistId, bookingId) {
    setMessageModelData("Checklist - Delete", "<span>Are you sure to delete the checklist and the items?</span>", yesText, noText, deleteChecklist, closeMessageModal, { checklistId, bookingId }, null, "warning");
    showMessageModal();
}

function deleteChecklist(data) {
    ajaxRequest(
        "GET",
        deleteMyChecklistApiUrl.replace("{0}", data["checklistId"]).replace("{1}", data["bookingId"]),
        "",
        "JSON",
        deleteChecklistSuccess,
        deleteChecklistError
    );
}

function deleteChecklistSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        setMessageModelData("Checklist - Delete", "<span>" + successResult.SuccessMessage + "</span>", okText, "", closeRefreshMessageModal, closeRefreshMessageModal, null, null, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        showChecklistErrorMessageModel(successResult.ErrorMessage, "Checklist - Delete");
    }
    hideSpinner();
}

function deleteChecklistError(errorResult) {
    showChecklistErrorMessageModel(getErrorMessage(errorResult), "Checklist - Delete");
    hideSpinner();
}

getMyChecklistItem = function getMyChecklistItem(checklistId, bookingId) {
    navigateToUrl("", "", checklistItemApiUrl.replace("{0}", checklistId).replace("{1}", bookingId));
}

createMyChecklistItem = function createMyChecklistItem() {
    if ($(myChecklistItemEmptyListContainerClass).hasClass("hide")) {
        $(myChecklistItemContainerClass).removeClass("mt-5").addClass("pt-10");
        $(myChecklistItemEmptyListContainerClass).removeClass("hide");
        $(myChecklistItemEmptyMessageContainerClass).addClass("hide");
        scrollTo();
    }
}

checkMyChecklistItem = function checkMyChecklistItem(checklistItemId) {
    var isChecked = $(myChecklistItemCheckboxId + checklistItemId).is(":checked");
    checkedStatusString = isChecked ? checkedString : uncheckedString;

    ajaxRequest(
        "POST",
        createUpdateMyChecklistItemApiUrl,
        {
            ChecklistItemId: checklistItemId,
            ChecklistId: urlParams.get("checklistId"),
            IsChecked: isChecked,
            BookingId: urlParams.get("bookingId")
        },
        "JSON",
        checkMyChecklistItemSuccess,
        checkMyChecklistItemError
    );
}

function checkMyChecklistItemSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        showToastNotification("Checklist Item - " + checkedStatusString, successResult.SuccessMessage, "success");
    }
    else if (isInvalidResponse(successResult)) {
        showToastNotification("Checklist Item - " + checkedStatusString, successResult.ErrorMessage, "error");
    }
    hideSpinner();
}

function checkMyChecklistItemError(errorResult) {
    showToastNotification("Checklist Item - " + checkedStatusString, getErrorMessage(errorResult), "error");
    hideSpinner();
}

updateMyChecklistItem = function updateMyChecklistItem(checklistItemId) {
    isChecklistItemNameUpdating = false;
    var checklistNameElement = $(myChecklistItemTableNameId + checklistItemId);
    checklistNameElement.addClass("hide");
    $(myChecklistItemTableNameInputId + checklistItemId).removeClass("hide").val(checklistNameElement.text()).focus();
}

updateChecklistItem = function updateChecklistItem(checklistItemId) {
    if (!isChecklistItemNameUpdating && resetChecklistItemNameControls(checklistItemId)) {
        isChecklistItemNameUpdating = true;
        $(myChecklistItemTableNameId + checklistItemId).removeClass("hide");
        $(myChecklistItemTableNameInputId + checklistItemId).addClass("hide");

        ajaxRequest(
            "POST",
            createUpdateMyChecklistItemApiUrl,
            {
                ChecklistItemId: checklistItemId,
                ChecklistId: urlParams.get("checklistId"),
                IsChecked: $(myChecklistItemCheckboxId + checklistItemId).is(":checked"),
                ChecklistItemName: $(myChecklistItemTableNameInputId + checklistItemId).val(),
                BookingId: urlParams.get("bookingId")
            },
            "JSON",
            updateChecklistItemSuccess,
            updateChecklistItemError
        );
    }
}

updateChecklistItemOnEnterKey = function updateChecklistItemOnEnterKey(event, checklistItemId) {
    if ((event.keyCode === 13 || event.key === "Enter") && resetChecklistItemNameControls(checklistItemId)) {
        updateChecklistItem(checklistItemId);
    }
}

function updateChecklistItemSuccess(successResult) {
    isChecklistItemNameUpdating = false;
    var checklistItemId = (successResult?.ResponseData && successResult?.ResponseData["ChecklistItemId"] ? successResult?.ResponseData["ChecklistItemId"] : 0);
    if (isvalidResponse(successResult)) {
        $(myChecklistItemTableNameId + checklistItemId).text($(myChecklistItemTableNameInputId + checklistItemId).val());
        showToastNotification("Checklist Item Name Update", successResult.SuccessMessage, "success");
    }
    else if (isInvalidResponse(successResult)) {
        showToastNotification("Checklist Item Name Update", successResult.ErrorMessage, "error");
    }
    hideSpinner();
}

function updateChecklistItemError(errorResult) {
    isChecklistItemNameUpdating = false;
    showToastNotification("Checklist Item Name Update", getErrorMessage(errorResult), "error");
    hideSpinner();
}

deleteMyChecklistItem = function deleteMyChecklistItem(checklistItemId) {
    setMessageModelData("Checklist Item - Delete", "<span>Are you sure to delete the checklist item?</span>", yesText, noText, deleteChecklistItem, closeMessageModal, checklistItemId, null, "warning");
    showMessageModal();
}

function deleteChecklistItem(checklistItemId) {
    ajaxRequest(
        "GET",
        deleteMyChecklistItemApiUrl.replace("{0}", checklistItemId).replace("{1}", urlParams.get("checklistId")).replace("{2}", urlParams.get("bookingId")),
        "",
        "JSON",
        deleteChecklistItemSuccess,
        deleteChecklistItemError
    );
}

function deleteChecklistItemSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        var checklistItemId = (successResult?.ResponseData && successResult.ResponseData["checklistItemId"] ? successResult.ResponseData["checklistItemId"] : 0);
        setMessageModelData("Checklist Item - Delete", "<span>" + successResult.SuccessMessage + "</span>", okText, "", removeChecklistItem, removeChecklistItem, checklistItemId, null, "success");
        showMessageModal();
    }
    else if (isInvalidResponse(successResult)) {
        showChecklistErrorMessageModel(successResult.ErrorMessage, "ChecklistItem - Delete");
    }
    hideSpinner();
}

function deleteChecklistItemError(errorResult) {
    showChecklistErrorMessageModel(getErrorMessage(errorResult), "Checklist Item - Delete");
    hideSpinner();
}

function showChecklistErrorMessageModel(errorMessage, modalHeading) {
    setMessageModelData(modalHeading, "<span>" + errorMessage + "</span>", okText, "", closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
}

function removeChecklistItem(checklistItemId) {
    closeMessageModal();
    var myChecklistItemTableRowElement = $(myChecklistItemTableRowId + checklistItemId);
    myChecklistItemTableRowElement.next()[0].remove();
    myChecklistItemTableRowElement.remove();

    if (!$(myChecklistItemTableRowClass).length) {
        $(myChecklistItemEmptyListContainerClass).addClass("hide");
        $(myChecklistItemListContainerClass).addClass("hide");
        $(myChecklistItemEmptyMessageContainerClass).removeClass("hide");
    }
}

getChecklistShareLink = function getChecklistShareLink(option, checklistId, checklistName, bookingId) {
    setOptionForShareLink(option, true);

    if (option.toLowerCase() == emailString.toLowerCase()) {
        setMessageModelData(
            "Checklist Link - " + shareLinkTitleString,
            "<div class='row'><div class='" + colMd12Class + "'><div class='form-group'><label class='mb-2'>Email</label><input type='text' id='" + myChecklistShareEmailId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Email' maxlength='100'/><span id='" + myChecklistShareEmailErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(myChecklistShareEmailErrorMessageTextId).val() + "</span><span id='" + myChecklistShareEmailInvalidErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(myChecklistShareEmailInvalidErrorMessageTextId).val() + "</span></div>",
            shareText,
            cancelText,
            shareChecklistLinkViaEmail,
            closeMessageModal,
            {
                option,
                checklistId,
                checklistName,
                bookingId
            });
        showMessageModal();

        $(myChecklistShareEmailId).on("focusout", function () {
            if (isMyChecklistShareEmailButtonClicked) {
                emailValidation(myChecklistShareEmailId, myChecklistShareEmailErrorMessageId, myChecklistShareEmailInvalidErrorMessageId);
            }
        });
    }
    else if (option.toLowerCase() == copyLinkString.toLowerCase()) {
        getChecklistShareData(option, checklistId, checklistName, bookingId);
    }
}

function getChecklistShareData(option, checklistId, checklistName, bookingId, emailTo) {
    ajaxRequest(
        "POST",
        getChecklistShareDataApiUrl,
        {
            Option: option,
            ChecklistId: checklistId,
            Name: checklistName,
            BookingId: bookingId,
            EmailTo: emailTo
        },
        "JSON",
        getChecklistShareDataSuccess,
        getChecklistShareDataError
    );
}

function shareChecklistLinkViaEmail(checklistData) {
    isMyChecklistShareEmailButtonClicked = true;
    var isEmailValid = emailValidation(myChecklistShareEmailId, myChecklistShareEmailErrorMessageId, myChecklistShareEmailInvalidErrorMessageId);

    if (isEmailValid && checklistData) {
        getChecklistShareData(checklistData.option, checklistData.checklistId, checklistData.checklistName, checklistData.bookingId, $(myChecklistShareEmailId).val());
    }
}

function getChecklistShareDataSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        var option;
        var checklistShareLink;
        var message = successResult.SuccessMessage;
        var messageType = "success";

        if (successResult?.ResponseData) {
            option = successResult?.ResponseData["Option"];
            checklistShareLink = successResult?.ResponseData["ShareLink"];
        }

        if (option.toLowerCase() == copyLinkString.toLowerCase()) {
            if (checklistShareLink) {
                setOptionForShareLink(option, false, checklistShareLink);
            }
            else {
                message = "Unable to copy link at the moment. Please try again later.";
                messageType = "warning";
            }
        }
        else if (option.toLowerCase() == emailString.toLowerCase()) {
            closeMessageModal();
        }

        showToastNotification("Checklist Link - " + shareLinkTitleString, message, messageType);

        hideSpinner();
    }
    else if (isInvalidResponse(successResult)) {
        showToastNotification("Checklist Link - " + shareLinkTitleString, successResult.ErrorMessage, "error");
        hideSpinner();
    }
}

function getChecklistShareDataError(errorResult) {
    showToastNotification("Checklist Link - " + shareLinkTitleString, getErrorMessage(errorResult), "error");
    hideSpinner();
}

bookMyTicket = function bookMyTicket(locationId) {
    if ($("#regitser_login_sm_tab").length || $("#register_login_lg_button").length) {
        setMessageModelData(
            "Login",
            "<span>Please login to book this amazing trip!</span>",
            loginText,
            cancelText,
            navigateTologinModal,
            closeBookTicketModal,
            locationId,
            null,
            "info"
        );

        showMessageModal();
        return;
    }

    isPromoCodeValidated = false;
    isBookCardButtonClicked = false;
    promotionValue = 0;
    isPercent = 0;

    setMessageModelData(
        "Book Ticket",
        "<div class='row'>"
        + "<div class='" + colMd6Class + "'><div class='form-group'><label class='mb-2 " + bookAmountTitleClass.substring(period_selector.length) + "'>Number of Ticket(s) <span id='" + bookMaxNumberOfTicketId.substring(hash_selector.length) + "'>(Max: " + maxTicketAllowedToBookValue + ")</span></label><input id='" + bookNumberOfTicketId.substring(hash_selector.length) + "' type='number' class='form-control mb-2' /></div><span id='" + bookNumberOfTicketErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookNumberOfTicketErrorMessageTextId).val() + "</span></div>"
        + "<div class='" + colMd6Class + whiteSpaceString + textRightClass + "'><h4>Total Amount</h4><h4 class='mb-0 " + bookAmountClass.substring(period_selector.length) + whiteSpaceString + textSuccessClass + "'>$0.00</h4></div>"
        + "<div class='" + rowClass + "'><div class='" + colMd6Class + "'><div class='form-group'><label class='mb-2'>Promo Code</label><input id='" + bookPromoCodeId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Promo Code' maxlength='10' /><span id='" + bookPromoCodeErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookPromoCodeErrorMessageTextId).val() + "</span><span id='" + bookPromoCodeValidateErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookPromoCodeValidateErrorMessageTextId).val() + "</span></div></div>"
        + "<div class='" + bookPromoCodeContainerClass + "'><button id='" + bookPromoCodeApplyButtonId.substring(hash_selector.length) + "' class='" + bookPromoCodeApplyButtonClass + "'>Apply</button></div></div>"
        + "<div class='" + colMd12Class + "'><div class='form-group'><label class='mb-2'>Trip Date</label><input id='" + bookTripDateId.substring(hash_selector.length) + "' class='form-control mb-2 " + mteDatePickerClass.substring(period_selector.length) + "' placeholder='Trip Date (mm/dd/yyyy)' /><span id='"
        + bookTripDateErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookTripDateErrorMessageTextId).val() + "</span><span id='" + bookTripDateInvalidErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookTripDateInvalidErrorMessageTextId).val() + "</span></div></div>"
        + "<div class='" + colMd12Class + "'><div class='form-group'><label class='mb-2'>Email</label><input type='text' id='"
        + bookCardEmailId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Email'  maxlength='100'/><span id='"
        + bookCardEmailErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>"
        + $(bookCardEmailErrorMessageTextId).val() + "</span><span id='" + bookCardEmailInvalidErrorMessageId.substring(hash_selector.length)
        + "' class='field-validation-error hide'>" + $(bookCardEmailInvalidErrorMessageTextId).val() + "</span></div></div><div class='"
        + colMd12Class + "'><div class='form-group'><label class='mb-2'>Confirm Email</label><input type='text' id='"
        + bookCardConfirmEmailId.substring(hash_selector.length) + "' class='form-control mb-2' placeholder='Confirm Email' maxlength='100'/><span id='"
        + bookCardConfirmEmailErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>"
        + $(bookCardConfirmEmailErrorMessageTextId).val() + "</span><span id='" + bookCardConfirmEmailInvalidErrorMessageId.substring(hash_selector.length)
        + "' class='field-validation-error hide'>" + $(bookCardConfirmEmailInvalidErrorMessageTextId).val() + "</span></div></div><div class='"
        + colMd12Class + " mb-1'><span id='" + bookCardEmailMessageId.substring(hash_selector.length) + "'>"
        + $(bookCardEmailMessageTextId).val() + "</span></div><div class='" + colMd12Class + whiteSpaceString + marginBottom12Class + "'><input type='checkbox' class='"
        + bookCardCheckboxClass.substring(period_selector.length) + "' /><span class='" + bookCardCheckboxTextClass.substring(period_selector.length)
        + "'>" + $(bookCardCheckboxTextMessageId).val() + "</span></div>"
        + "<div class='" + colMd12Class + " mb-2'><div id='" + bookCardContainerId.substring(hash_selector.length) + "' class='card-js form-group' data-icon-colour='var(--primary)'><input class='card-number form-control' name='my-custom-form-field__card-number' placeholder='Enter your card number' autocomplete='off'><input class='name form-control' id='the-card-name-id' name='my-custom-form-field__card-name' placeholder='Enter the name on your card' autocomplete='off'><input class='expiry form-control' autocomplete='off'><input class='expiry-month' name='my-custom-form-field__card-expiry-month'><input class='expiry-year' name='my-custom-form-field__card-expiry-year'><input class='cvc form-control' name='my-custom-form-field__card-cvc' autocomplete='off'></div></div>"
        + "<div class='" + colMd12Class + "'><span id='" + bookcardCardNumberErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardCardNumberErrorMessageTextId).val() + "</span><span id='" + bookcardCardNumberInvalidErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardCardNumberInvalidErrorMessageTextId).val() + "</span></div>"
        + "<div class='" + colMd12Class + "'><span id='" + bookcardCardNameErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardCardNameErrorMessageTextId).val() + "</span></div>"
        + "<div class='" + colMd12Class + "'><span id='" + bookcardExpiryErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardExpiryErrorMessageTextId).val() + "</span><span id='" + bookcardExpiryInvalidErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardExpiryInvalidErrorMessageTextId).val() + "</span></div>"
        + "<div class='" + colMd12Class + "'><span id='" + bookcardCvcErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardCvcErrorMessageTextId).val() + "</span><span id='" + bookcardCvcInvalidErrorMessageId.substring(hash_selector.length) + "' class='field-validation-error hide'>" + $(bookcardCvcInvalidErrorMessageTextId).val() + "</span></div>"
        + "</div><script src='../../Scripts/card-js.min.js'></script>",
        bookText,
        cancelText,
        bookTicket,
        closeBookTicketModal,
        locationId
    );

    showMessageModal();

    $(bookCardCardNameId).attr("maxlength", "50");

    preventCopyPaste(bookCardConfirmEmailId);

    $(bookPromoCodeId).on("focusin", function () {
        if ($(bookPromoCodeValidateErrorMessageId).hasClass("hide")) {
            $(bookPromoCodeId).removeClass(validationClass);
            $(bookPromoCodeApplyButtonId).removeClass(mb25Class);
            $(bookPromoCodeErrorMessageId).addClass("hide");
        }
    });

    $(bookPromoCodeId).on("focusout", function () {
        if (isBookCardButtonClicked && !isPromoCodeValidated) {
            promoCodeValidation();
        }
    });

    $(bookPromoCodeApplyButtonId).on("click", function () {
        var bookPromoCodeValue = $(bookPromoCodeId).val();
        if (bookPromoCodeValue) {
            ajaxRequest(
                "POST",
                validatePromoCodeApiUrl,
                {
                    NumberOfTicket: $(bookNumberOfTicketId).val(),
                    PromoCode: bookPromoCodeValue,
                    Rate: $(locationDetailRateId).text()
                },
                "JSON",
                validatePromoCodeSuccess,
                validatePromoCodeError
            );
        }
    });

    $(bookNumberOfTicketId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            numberValidation(bookNumberOfTicketId, bookNumberOfTicketErrorMessageId);
        }
    });

    $(bookNumberOfTicketId).on("keydown", function (event) {
        var isValidKey = (event.keyCode == 9) || (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105) || (clearKeyCodes.includes(event.keyCode));

        if (!isValidKey) {
            event.preventDefault();
        }
    });

    $(bookNumberOfTicketId).on("keyup", function () {
        calculateTotalAmount();
    });

    $(bookTripDateId).datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        minDate: 1
    });

    $(bookTripDateId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            var dateBoxTimeout = setTimeout(function () {
                dateBoxValidation(bookTripDateId, bookTripDateErrorMessageId, bookTripDateInvalidErrorMessageId);
                clearTimeout(dateBoxTimeout);
            }, 250);
        }
    });

    $(bookCardEmailId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            emailValidation(bookCardEmailId, bookCardEmailErrorMessageId, bookCardEmailInvalidErrorMessageId);

            if ($(bookCardConfirmEmailId).val()) {
                emailValidation(bookCardConfirmEmailId, bookCardConfirmEmailErrorMessageId, bookCardConfirmEmailInvalidErrorMessageId, true, bookCardEmailId);
            }
        }
    });

    $(bookCardConfirmEmailId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            emailValidation(bookCardConfirmEmailId, bookCardConfirmEmailErrorMessageId, bookCardConfirmEmailInvalidErrorMessageId, true, bookCardEmailId);
        }
    });

    $(bookCardCheckboxClass).on("click", function () {
        isUserLoginEmail = $(bookCardCheckboxClass).is(":checked");

        if (isUserLoginEmail) {
            var userLoginEmail = $(bookCardUserLoginEmailId).val();
            $(bookCardEmailId).val(userLoginEmail).attr("disabled", "disabled").removeClass(validationClass);
            $(bookCardConfirmEmailId).val(userLoginEmail).attr("disabled", "disabled").removeClass(validationClass);
            $(bookCardEmailErrorMessageId).addClass("hide");
            $(bookCardEmailInvalidErrorMessageId).addClass("hide");
            $(bookCardConfirmEmailErrorMessageId).addClass("hide");
            $(bookCardConfirmEmailInvalidErrorMessageId).addClass("hide");
            $(bookCardEmailMessageId).addClass("hide");
        }
        else {
            $(bookCardEmailId).val("").removeAttr("disabled");
            $(bookCardConfirmEmailId).val("").removeAttr("disabled");
            $(bookCardEmailMessageId).removeClass("hide");
        }
    });

    $(bookcardCardNumberId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            cardNumberValidation(bookcardCardNumberId, bookcardCardNumberErrorMessageId, bookcardCardNumberInvalidErrorMessageId, cardNumberValidLength, true, true);
        }
    });

    $(bookCardCardNameId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            textBoxValidation(bookCardCardNameId, bookcardCardNameErrorMessageId);
        }
    });

    var bookCardExpiryIdTimeout = setTimeout(function () {
        $(bookCardExpiryId).on("focusout", function () {
            if (isBookCardButtonClicked) {
                cardExpiryValidation(bookCardExpiryId, bookcardExpiryErrorMessageId, bookcardExpiryInvalidErrorMessageId);
            }
        });

        clearTimeout(bookCardExpiryIdTimeout);
    }, 100);

    $(bookCardCvcId).on("focusout", function () {
        if (isBookCardButtonClicked) {
            numberValidation(bookCardCvcId, bookcardCvcErrorMessageId, bookcardCvcInvalidErrorMessageId, cvcValidLength, false, true);
        }
    });
}

function validatePromoCodeSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        isPromoCodeValidated = true;
        $(bookPromoCodeId).removeClass(validationClass);
        $(bookPromoCodeErrorMessageId).addClass("hide");
        $(bookPromoCodeValidateErrorMessageId).addClass("hide");
        $(bookPromoCodeApplyButtonId).removeClass(mb25Class + whiteSpaceString + mb49Class);

        if (successResult.ResponseData) {
            promotionValue = successResult.ResponseData["PromotionValue"];
            isPercent = successResult.ResponseData["IsPercent"];

            calculateTotalAmount();
        }

        showToastNotification("Promo Code", $(bookPromoCodeValidateSuccessMessageId).val(), "success");
        hideSpinner();
    }
    else if (isInvalidResponse(successResult)) {
        promoCodeValidationError();
    }
}

function validatePromoCodeError() {
    promoCodeValidationError();
}

function promoCodeValidationError() {
    isPromoCodeValidated = false
    $(bookPromoCodeId).addClass(validationClass);
    $(bookPromoCodeErrorMessageId).removeClass("hide");
    $(bookPromoCodeValidateErrorMessageId).addClass("hide");
    $(bookPromoCodeApplyButtonId).addClass(mb25Class).removeClass(mb49Class);
    hideSpinner();
}

function navigateTologinModal() {
    navigateToUrl("", "", loginWindowPath + "?ReturnUrl=" + windowPathName.substring(1) + windowLocationSearch);
}

function closeBookTicketModal() {
    isBookCardButtonClicked = false;
    isPromoCodeValidated = false;
    closeMessageModal();
}

function bookTicket() {
    isBookCardButtonClicked = true;

    var isBookCardEmailVaild = true;
    var isBookCardConfirmEmailVaild = true;

    if (!isUserLoginEmail) {
        isBookCardEmailVaild = emailValidation(bookCardEmailId, bookCardEmailErrorMessageId, bookCardEmailInvalidErrorMessageId);
        isBookCardConfirmEmailVaild = emailValidation(bookCardConfirmEmailId, bookCardConfirmEmailErrorMessageId, bookCardConfirmEmailInvalidErrorMessageId, true, bookCardEmailId);
    }

    var isPromoCodeValid = !$(bookPromoCodeId).hasClass(validationClass);
    var isNumberOfTicketValid = numberValidation(bookNumberOfTicketId, bookNumberOfTicketErrorMessageId);
    var isTripDateValid = dateBoxValidation(bookTripDateId, bookTripDateErrorMessageId, bookTripDateInvalidErrorMessageId);
    var isCardNumberValid = cardNumberValidation(bookcardCardNumberId, bookcardCardNumberErrorMessageId, bookcardCardNumberInvalidErrorMessageId, cardNumberValidLength, true, true);
    var isCardNameValid = textBoxValidation(bookCardCardNameId, bookcardCardNameErrorMessageId);
    var isExpiryValid = cardExpiryValidation(bookCardExpiryId, bookcardExpiryErrorMessageId, bookcardExpiryInvalidErrorMessageId);
    var isCvcValid = numberValidation(bookCardCvcId, bookcardCvcErrorMessageId, bookcardCvcInvalidErrorMessageId, cvcValidLength, false, true);

    var isUserDetailVaid = isPromoCodeValid && isNumberOfTicketValid && isTripDateValid && isBookCardEmailVaild && isBookCardConfirmEmailVaild;
    var isCardDetailValid = isCardNumberValid && isCardNameValid && isExpiryValid && isCvcValid;
    var isPromoCodeDetailValid = promoCodeValidation();
    var isBookingDetailValid = isUserDetailVaid && isPromoCodeDetailValid && isCardDetailValid;

    if (isBookingDetailValid) {
        ajaxRequest(
            "POST",
            bookMyTicketApiUrl,
            {
                LocationId: urlParams.get("locationId"),
                Email: $(bookCardEmailId).val(),
                IsUserLoginEmail: isUserLoginEmail,
                CardNumber: $(bookcardCardNumberId).val(),
                CardName: $(bookCardCardNameId).val(),
                Expriy: $(bookCardExpiryId).val(),
                Cvc: $(bookCardCvcId).val(),
                NumberOfTicket: $(bookNumberOfTicketId).val(),
                TripDate: $(bookTripDateId).val(),
                PromoCode: $(bookPromoCodeId).val()
            },
            "JSON",
            bookTicketSuccess,
            bookTicketError
        );
    }
    else if (!isCardDetailValid) {
        scrollTo(messageModalOkButtonId, 0, messageModalBodyId);
    }
    else if (!isPromoCodeDetailValid) {
        scrollTo(0, 0, messageModalBodyId);
    }
}

function bookTicketSuccess(successResult) {
    if (isvalidResponse(successResult)) {
        $(locationDetailAvailableTicketId).text($(locationDetailAvailableTicketId).text() - $(bookNumberOfTicketId).val());
        var bookingId = (successResult?.ResponseData && successResult?.ResponseData["BookingId"]) ? successResult?.ResponseData["BookingId"] : 0;
        setMessageModelData("Book Ticket - Success", "<span>" + successResult.SuccessMessage + "</span>", okText, closeText, navigateToBookingDetailModal, closeMessageModal, bookingId, null, "success");
    }
    else if (isInvalidResponse(successResult)) {
        if (successResult.ResponseData && successResult.ResponseData["IsInvalidPromoCode"]) {
            $(bookPromoCodeId).addClass(validationClass);
            $(bookPromoCodeApplyButtonId).addClass(mb25Class).removeClass(mb49Class);
            $(bookPromoCodeErrorMessageId).removeClass("hide");
            scrollTo(0, 0, messageModalBodyId);
        }
        else {
            showBookTicketErrorMessageModal(successResult.ErrorMessage);
        }
    }

    hideSpinner();
}

function bookTicketError(errorResult) {
    showBookTicketErrorMessageModal(getErrorMessage(errorResult));
    hideSpinner();
}

function navigateToBookingDetailModal(bookingId) {
    navigateToUrl("", "", bookingDetailApiUrl + bookingId);
}

function showBookTicketErrorMessageModal(errorMessage) {
    isPromoCodeValidated = false;
    setMessageModelData("Book Ticket - Error", "<span>" + errorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
}

function promoCodeValidation() {
    var isValid = ($(bookPromoCodeId).val() && !isPromoCodeValidated) ? false : true;
    $(bookPromoCodeId).removeClass(validationClass);
    $(bookPromoCodeErrorMessageId).addClass("hide");
    $(bookPromoCodeValidateErrorMessageId).addClass("hide");
    $(bookPromoCodeApplyButtonId).removeClass(mb49Class);

    if (!isValid) {
        $(bookPromoCodeId).addClass(validationClass);
        $(bookPromoCodeValidateErrorMessageId).removeClass("hide");
        $(bookPromoCodeApplyButtonId).addClass(mb49Class);
    }

    return isValid;
}

function calculateTotalAmount() {
    var numberOfTicket = parseInt($(bookNumberOfTicketId).val());
    var currencySymbol = $(locationDetailCurrencySymbolId).text();
    var rate = $(locationDetailRateId).text();
    var calculatedRate = 0;
    var discountedAmount = 0;

    if (numberOfTicket) {
        if (numberOfTicket > maxTicketAllowedToBookValue) {
            $(bookNumberOfTicketId).val(maxTicketAllowedToBookValue);
            numberOfTicket = maxTicketAllowedToBookValue;
        }

        calculatedRate = (numberOfTicket * rate);

        if (calculatedRate && promotionValue) {
            discountedAmount = isPercent ? ((calculatedRate * promotionValue) / 100) : promotionValue;
            calculatedRate = (discountedAmount >= calculatedRate) ? 0 : (calculatedRate - discountedAmount);
        }
    }

    $(bookAmountClass).text(currencySymbol + calculatedRate.toFixed(2));
}

initSessionTimeoutAlert = function initSessionTimeoutAlert(isSkipSessionTimeout) {
    if (isSkipSessionTimeout) {
        clearInterval(sessionTimeoutInterval);
        clearTimeout(sessionTimeoutFunction);
        return;
    };

    var systemCookieExpirationTime = $(systemCookieExpirationTimeId).val();

    if (systemCookieExpirationTime) {
        systemCookieExpirationTime = (systemCookieExpirationTime - 1) * 60 * 1000;

        sessionTimeoutFunction = setTimeout(function () {
            var isModalShown;
            setMessageModelData("Session Expiration", "<span>Your session is about to logout in <span id='session_expiration_time'></span> second(s). Do you want to keep your session alive?</span>", yesText, "", keepSessionAlive, closeMessageModal, null, null, "warning");

            sessionTimeoutInterval = setInterval(function () {
                if (!isMessageModalShown() && !isModalShown) {
                    showMessageModal();
                }

                isModalShown = true;
                sessionAboutToLogout.time -= 1;
                $(sessionExpirationTime).text(sessionAboutToLogout.time);

                if (!sessionAboutToLogout.time) {
                    navigateToUrl("", "", loginWindowPath);
                    clearInterval(sessionTimeoutInterval);
                }
            }, 1000);

            clearTimeout(sessionTimeoutFunction);
        }, systemCookieExpirationTime);
    }
}

function sendEmailCodeTimer(isStoreKey, waitTime, isFromEmailSentSuccess) {
    if (isStoreKey) {
        localStorage.setItem(waitTimeToResendCodeKey, waitTime);
        emailCodeSendObject.firstTime = false;
    }

    waitTime -= 1;

    if (isFromEmailSentSuccess) {
        emailCodeSendObject.waitTime = waitTime;
    }

    localStorage.setItem(waitTimeToResendCodeKey, waitTime);
    $(changeEmailSendCodeClass).addClass("hide");
    $(changeEmailResendCodeClass).removeClass("hide");

    var isEmailCodeContainerHidden = $(changeEmailCodeContainerClass).hasClass("hide");

    var waitTimeString = waitTime.toString();
    $(changeEmailResendCodeTimeClass).text(waitTimeString.length == 1 ? ("0" + waitTimeString) : waitTimeString);

    if (waitTime <= 0) {
        $(changeEmailSendCodeClass).removeClass("hide");
        $(changeEmailResendCodeClass).addClass("hide");
        $(changeEmailCodeContainerClass).addClass("hide");
    }
    else if (isEmailCodeContainerHidden) {
        $(changeEmailCodeContainerClass).removeClass("hide");
    }

    return waitTime;
}

function setOptionForShareLink(option, isSetTitle, data) {
    switch (option) {
        case emailString:
            if (isSetTitle) {
                shareLinkTitleString = emailString;
            }
            break;
        case copyLinkString:
            if (isSetTitle) {
                shareLinkTitleString = copyLinkClipboardString;
            }
            else {
                copyToClipboard(data);
            }
            break;
    }
}

function hideShowUserImage(targetImage, removeIcon, defaultImage, messageElement) {
    if ($(targetImage).attr("src")) {
        $(removeIcon).removeClass("hide");
        $(targetImage).removeClass("hide");
        $(defaultImage).addClass("hide");
        $(userProfileUploadContainerId).addClass("hide");
        $(userProfileImageInputTextId).text("Change");
        $(messageElement).addClass("hide");
    }
    else {
        $(removeIcon).addClass("hide");
        $(targetImage).addClass("hide");
        $(defaultImage).removeClass("hide");
        $(userProfileUploadContainerId).removeClass("hide");
        $(userProfileImageInputTextId).text("Upload");
        $(messageElement).removeClass("hide");
    }
}

function setImage(imageData, imageId, removeImageId, defaultImageId) {
    if (imageData) {
        $(imageId).attr("src", imageData);
    }

    if (imageId && removeImageId && defaultImageId) {
        hideShowUserImage(imageId, removeImageId, defaultImageId, userProfileImageDragAndDropContainerClass);
    }
}

function registerCloseMessageModal(messageData) {
    closeModalRedirection(messageData);
}

function loginCloseMessageModal() {
    closeMessageModal();
}

function userProfileCloseMessageModal(messageData) {
    closeModalRedirection(messageData);
}

function sendPasswordResetLinkSuccessShowMessageModal(result) {
    var messageData = setMessageData(result.IsRedirect, result.Controller, result.Action);
    setMessageModelData("Password Reset Link", "<span>" + result.SuccessMessage ? result.SuccessMessage : "" + "</span>", okText, closeText, sendPasswordResetLinkCloseMessageModal, sendPasswordResetLinkCloseMessageModal, messageData, messageData, "success");
    showMessageModal();
}

function sendPasswordResetLinkErrorShowMessageModal(result) {
    setMessageModelData("Password ResetError", "<span>" + result.ErrorMessage + "</span>", okText, closeText, closeMessageModal, closeMessageModal, null, null, "error");
    showMessageModal();
}

function resetPasswordCloseMessageModal(messageData) {
    closeModalRedirection(messageData);
}

function sendPasswordResetLinkCloseMessageModal(messageData) {
    closeModalRedirection(messageData);
}

function changeUserEmailCloseMessageModal(messageData) {
    closeModalRedirection(messageData);
}

function changeUserPasswordCloseMessageModal(messageData) {
    closeModalRedirection(messageData);
}

function initChangePasswordPage() {
    preventCopyPaste(changePasswordConfirmPasswordId);
}

function initRegisterPage() {
    preventCopyPaste(registerConfirmPasswordId);

    $(registerDateOfBirthId).datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        maxDate: 0
    });
}

function initLocationListPage() {
    $(locationSearchClearIconClass).addClass("hide");
    $(locationSearchAdvancedFilterContainerClass).removeClass("hide");

    $(locationSearchFilterCriteriaPriceSliderId).slider({
        range: true,
        min: parseInt(locationMinimumPrice),
        max: parseInt(locationMaximumPrice),
        values: [locationMinimumPrice, locationMaximumPrice],
        slide: function (event, ui) {
            $(locationSearchFilterCriteriaMinimumPriceId).val(ui.values[0]);
            $(locationSearchFilterCriteriaMaximumPriceId).val(ui.values[1]);
        }
    });

    $(locationSearchFilterCriteriaTemperatureSliderId).slider({
        range: true,
        min: parseInt(locationMinimumTemperature),
        max: parseInt(locationMaximumTemperature),
        values: [locationMinimumTemperature, locationMaximumTemperature],
        slide: function (event, ui) {
            $(locationSearchFilterCriteriaMinimumTemperatureId).val(ui.values[0]);
            $(locationSearchFilterCriteriaMaximumTemperatureId).val(ui.values[1]);
        }
    });

    toggleLeftHandIcon();

    var parameters;
    var paramterKeyValue;
    var urlParameter = "searchString=";
    var searchStringValue = windowLocationSearch.split(urlParameter).pop();
    if (windowLocationSearch.indexOf(urlParameter) > -1 && searchStringValue) {
        $(locationSearchClearIconClass).removeClass("hide");

        var searchValue = searchStringValue.substring(0, searchStringValue.indexOf("&"));

        if (searchValue) {
            parameters = searchStringValue.substring(searchValue.length);
        }
        else {
            searchValue = searchStringValue.substring(searchValue.length);
        }

        $(locationSearchValueClass).val(decodeURIComponent(searchValue));
    }
    else {
        parameters = searchStringValue.substring("?".length);
    }

    if (parameters) {
        parameters.split("&").forEach((parameter) => {
            if (parameter) {
                paramterKeyValue = parameter.split("=");
                var value = decodeURI(paramterKeyValue[1]);

                switch (paramterKeyValue[0]) {
                    case "activitySearchString":
                        $(locationSearchFilterCriteriaActivityId).val(value);
                        break;
                    case "weatherSearchString":
                        $(locationSearchFilterCriteriaWeatherId).val(value);
                        break;
                    case "minRate":
                        $(locationSearchFilterCriteriaMinimumPriceId).val(value);
                        $(locationSearchFilterCriteriaPriceSliderId).slider("values", 0, value);
                        break;
                    case "maxRate":
                        $(locationSearchFilterCriteriaMaximumPriceId).val(value);
                        $(locationSearchFilterCriteriaPriceSliderId).slider("values", 1, value);
                        break;
                    case "minTemperature":
                        $(locationSearchFilterCriteriaMinimumTemperatureId).val(value);
                        $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 0, value);
                        break;
                    case "maxTemperature":
                        $(locationSearchFilterCriteriaMaximumTemperatureId).val(value);
                        $(locationSearchFilterCriteriaTemperatureSliderId).slider("values", 1, value);
                        break;
                    case "isShowAdvanceFilter":
                        if (value && value.toLowerCase() == "true") {
                            toggleAdvanceSearchContainer();
                        }
                        break;
                }
            }
        });
    }
}

function initLocationDetailPage() {
    var locationDetailAvailableTicket = parseInt($(locationDetailAvailableTicketId).text());
    var maxTicketAllowedToBook = parseInt($(maxTicketAllowedToBookId).val());
    maxTicketAllowedToBookValue = Math.min(locationDetailAvailableTicket, maxTicketAllowedToBook);
    toggleLeftHandIcon();
}

initBookingListPage = function initBookingListPage(bookingList) {

    var isDestroy = tempBookingListData;
    setMaxDataTableColumnLength("", "", 30);

    if (!tempBookingListData && bookingList) {
        tempBookingListData = bookingList;
    }

    if (bookingList) {
        if (bookingList.length) {
            if (!isLargeView) {
                $(bookingListContainerClass).addClass("hide");
                $(responsiveMessageClass).removeClass("hide");
            }
            else {
                $(bookingListContainerClass).removeClass("hide");
                $(responsiveMessageClass).addClass("hide");
            }

            var columns = [
                { title: "Id" },
                {
                    title: "Ticket Number",
                    render: function (data, type, rowData) {
                        return "<a href='" + bookingDetailPath + rowData[0] + "'>" + data + "</a>";
                    }
                },
                {
                    title: "Location",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[2], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Number of Ticket",
                    render: function (data) {
                        data = data.toString();
                        return data.length == 1 ? ("0" + data) : data;
                    }
                },
                {
                    title: "Trip Date",
                    render: function (data) {
                        return getLocalDate(data);
                    }
                },
                { title: "Amount" },
                { title: "Booked By" },
                {
                    title: "Booking Email",
                    render: function (data, type, rowData) {
                        return setDataTableColumnText(rowData[7], maxDataTableColumnLength);
                    }
                },
                {
                    title: "Status",
                    render: function (data, type, rowData) {
                        return "<span class=" + (rowData[13] ? textSuccessClass : textDangerClass) + ">" + (rowData[13] ? "Active" : "Expired") + "</span>";
                    }
                }
            ];

            var columnDefs = [{
                target: 0,
                visible: false,
                searchable: false
            }];

            var order = [[8, orderAsc], [4, orderDesc]];

            setTableData    (
                isDestroy,
                bookingListContainerId,
                bookingList,
                columns,
                columnDefs,
                order
            );
        }
    }
}

function initBookingDetail() {
    if (isLargeView) {
        $(bookingDetailContainerWrapperClass).removeClass("hide");
        $(responsiveMessageClass).addClass("hide");
    }
    else {
        $(bookingDetailContainerWrapperClass).addClass("hide");
        $(responsiveMessageClass).removeClass("hide");
    }
}

function toggleLeftHandIcon() {
    if (localStorage.getItem(isFirstTimeLocationPageVisitKey) == "false") {
        $(leftHandIconContainerClass).addClass("hide");
    }
}

function toggleAdvanceSearchContainer() {
    if ($(locationSearchAngleUpClass).hasClass("hide")) {
        $(locationSearchAngleUpClass).removeClass("hide");
        $(locationSearchAngleDownClass).addClass("hide");
        $(locationSearchFilterCriteriaContainerClass).removeClass("hide");
    }
    else {
        $(locationSearchAngleUpClass).addClass("hide");
        $(locationSearchAngleDownClass).removeClass("hide");
        $(locationSearchFilterCriteriaContainerClass).addClass("hide");
    }
}

function initContactMap() {
    setMapDimension(contactMapElementId);
    setMapWidthHeight(contactMapElementId);

    var contactMapElement = getTargetElementSelector(hash_selector, contactMapElementId);
    initMap(contactMapElementId, contactMapElement.data(dataLattitudeName), contactMapElement.data(dataLongitudeName), contactMapElement.data(dataLocationNameName));

    if (windowLocationSearch == "?isStaff=true") {
        scrollTo(contactTeamContainerClass);
    }
}

function initMap(targetElementId, lattidue, longitude, markerTitle, zoom) {
    const myLatLng = { lat: lattidue, lng: longitude };

    const map = new google.maps.Map(document.getElementById(targetElementId), {
        zoom: zoom ? zoom : 18,
        center: myLatLng,
    });

    new google.maps.Marker({
        position: myLatLng,
        map,
        title: markerTitle,
    });
}

function focusNextElementOnNumberInput(targetElementId, event) {
    var isNumeric = (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105);
    var targetElementValue = $(targetElementId).val();

    if (isNumeric) {
        targetElementId.value = event.key;

        if (targetElementValue) {
            $(targetElementId).next().focus();
        }
    }
    else if (!targetElementValue && event.keyCode == 8) {
        $(targetElementId).prev().focus();
        $(targetElementId).prev().focus();
    }
}

function codeInputFormat(targetElement, event, isMaxLengthValidate) {
    var isInvalidMaxLength = false;

    if (isMaxLengthValidate) {
        isInvalidMaxLength = targetElement.value.length >= targetElement.maxLength;
    }

    if (isInvalidMaxLength && !clearKeyCodes.includes(event.keyCode)) {
        event.preventDefault();
    }
}

function formatClassStyle(isValid, targetElementSpecifier, specifiedClass) {
    if (isValid) {
        $(targetElementSpecifier).removeClass(specifiedClass);
    }
    else {
        $(targetElementSpecifier).addClass(specifiedClass);
    }
}

function setMapWidthHeight(targetElementId) {
    $(window).on("resize", function () {
        setMapDimension(targetElementId);
    });
}

function setMapDimension(targetElementId) {
    var mapContainerWidth = getTargetElementSelector(hash_selector, targetElementId).parent().width();
    getTargetElementSelector(hash_selector, targetElementId).css("width", mapContainerWidth + "px");
    getTargetElementSelector(hash_selector, targetElementId).css("height", mapContainerWidth + "px");
}

function setEqualElementHeight(targetElementId) {
    var items = $(targetElementId);
    var itemsHeight = [];

    items.each(function (index, value) {
        itemsHeight.push(($(value).height()));
    });

    var maxRoomItemHeight = Math.max(...itemsHeight);

    items.each(function (index, value) {
        $(value).height(maxRoomItemHeight);
    });
}

function setAcceptForFileUpload(targetElementId, acceptValue) {
    $(targetElementId).attr("accept", acceptValue);
}

function arrayToString(array, separator) {
    return array.join(separator);
}

// Drag and Drop
function highlightContainer(dropArea) {
    dropArea.addClass(containerHighlight);
}

function unhighlightContainer(dropArea) {
    dropArea.removeClass(containerHighlight);
}

function handleDrop(event) {
    handleUploadedFiles(event.dataTransfer.files, userProfileImageId, userProfile, imageFileType, "", true);
}

function handleUploadedFiles(files, previewTargetElementId, pageName, fileTypeValidation, errorMessageId, isErrorMessageModal) {
    let file = files[0];
    var maxFileSize = $(userProfileImageMaxSizeValueId).val();

    if (file) {
        if (fileTypeValidation && !isValidFile(fileTypeValidation, file.type, errorMessageId, isErrorMessageModal)) {
            return;
        }
        else if (file.size > maxFileSize) {
            showToastNotification("User Profile Image", "Image size should be less than " + bytesToMb(maxFileSize), "warning");
            return;
        }

        let reader = new FileReader();
        reader.onload = function (event) {
            $(previewTargetElementId).attr("src", event.target.result);

            switch (pageName) {
                case userProfile:
                    userProfileFileName = file.name;
                    userProfileFileType = event.target.result.substring(0, event.target.result.indexOf("base64,")) + "base64,";
                    userProfileImageData = event.target.result.substring(event.target.result.indexOf("base64,") + "base64,".length);
                    break;
            }
        };

        reader.readAsDataURL(file);
    }
}

function isValidFile(fileTypeValidation, fileType, errorMessageId, isErrorMessageModal) {
    var isValid;
    var supportedFileTypes;

    if (errorMessageId) {
        $(errorMessageId).addClass("hide").text("");
    }

    switch (fileTypeValidation) {
        case imageFileType:
            isValid = imageFileTypeList.includes(fileType);
            supportedFileTypes = arrayToString(imageFileTypeList, ", ");
            break;
    }

    if (!isValid) {
        if (isErrorMessageModal) {
            var fileTypeList = "";
            supportedFileTypes.split(comma).forEach(supportedFileType => {
                fileTypeList += "<li>" + supportedFileType + "</li>";
            })
            supportedFileTypes = "<ul class='ml-55'>" + fileTypeList + "</ul>"
        }

        var errorMessage = "Please upload a valid " + imageFileType + ". Supported file types are <br />" + supportedFileTypes;

        if (errorMessageId) {
            $(errorMessageId).removeClass("hide").text(errorMessage);
        }
        else if (isErrorMessageModal) {
            setMessageModelData("Invalid File", "<span>" + errorMessage + "</span>", okText, "", closeMessageModal, closeMessageModal, null, null, "warning");
            showMessageModal();
        }
    }

    return isValid;
}

function initDragAndDrop(targetElementId) {
    var dropArea = $(targetElementId);

    ["dragenter", "dragover", "dragleave", "drop"].forEach(eventName => {
        dropArea[0].addEventListener(eventName, preventDefaults, false);
        document.body.addEventListener(eventName, preventDefaults, false);
    });

    // Highlight drop area when dragging over
    ["dragenter", "dragover"].forEach(eventName => {
        dropArea[0].addEventListener(eventName, function (event) {
            highlightContainer(dropArea);
        }, false);
    });

    // Remove highlight when leaving drop area
    ["dragleave", "drop"].forEach(eventName => {
        dropArea[0].addEventListener(eventName, function (event) {
            unhighlightContainer(dropArea);
        }, false);
    });

    // Handle dropped files
    dropArea[0].addEventListener("drop", handleDrop, false);
}

function resetChecklistItemNameControls(checklistItemId) {
    var isUpdate;
    if ($(myChecklistItemTableNameId + checklistItemId).text().toLowerCase() != $(myChecklistItemTableNameInputId + checklistItemId).val().toLowerCase()) {
        isUpdate = true;
    }
    else {
        $(myChecklistItemTableNameId + checklistItemId).removeClass("hide");
        $(myChecklistItemTableNameInputId + checklistItemId).addClass("hide");
    }
    return isUpdate;
}

// Prevent default drag behaviors
function preventDefaults(event) {
    event.preventDefault();
    event.stopPropagation();
}

function getTargetElementSelector(selector, targetElement) {
    return $(selector + targetElement);
}

function getUrlAppender(value) {
    return value ? "&" : "?";
}

function copyToClipboard(value) {
    if (value) {
        try {
            navigator.clipboard.writeText(value);
        }
        catch (error) {
            const textArea = document.createElement("textarea");
            textArea.value = value;

            // Move textarea out of the viewport so it's not visible
            textArea.style.position = "absolute";
            textArea.style.left = "-999999px";

            document.body.prepend(textArea);
            textArea.select();

            try {
                document.execCommand('copy');
            } catch (error) {
                console.error(error);
            } finally {
                textArea.remove();
            }
        }
    }
}

function preventCopyPaste(targetElementSelector) {
    $(targetElementSelector).on("cut copy paste", function (e) {
        e.preventDefault();
    });
}

function bytesToMb(bytes) {
    bytes = bytes ? bytes : 0;
    return (bytes / (1024 * 1024)).toFixed(2) + " MB";
}

// Recaptcha spinner
$(".g-recaptcha").asyncReCAPTCHA({
    spinner: {
        attach: true,
        remove: true
    }
});

// Recaptcha callback
function passwordResetRecaptchaCallback(response) {
    googleRecaptchaResponse = response;
    recaptchaErrors(resetPasswordRecaptchaId, resetPasswordRecaptchaErrorMessageId, resetPasswordEmailId);
}

function passwordResetRecaptchaExpired() {
    googleRecaptchaResponse = "";
    recaptchaErrors(resetPasswordRecaptchaId, resetPasswordRecaptchaErrorMessageId, resetPasswordEmailId, "1px solid #f00", "0 0 0 0.1rem rgb(254 165 22 / 24%)", "5px");
}

function recaptchaErrors(recaptchaId, recaptchaErrorMessageId, targetElementId, borderCss, boxShadowCss, borderRadiusCss) {
    borderCss = borderCss ? borderCss : "";
    boxShadowCss = boxShadowCss ? boxShadowCss : "";
    borderRadiusCss = borderRadiusCss ? borderRadiusCss : "";
    $(recaptchaErrorMessageId).addClass("hide");

    var recaptchaErrorInterval = setInterval(function () {
        $(recaptchaId + " iframe").css("border", borderCss).css("box-shadow", boxShadowCss).css("border-radius", borderRadiusCss);

        borderCss ? $(recaptchaErrorMessageId).removeClass("hide") : null;

        var recaptchaBorderColor = $(targetElementId).css("border-color");

        if (recaptchaBorderColor == "rgb(206, 212, 218)") {
            clearInterval(recaptchaErrorInterval);
        }
    }, 100);
}