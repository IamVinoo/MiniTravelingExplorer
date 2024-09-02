namespace MiniTravelingExplorer.Utils
{
    public static class Constant
    {
        // Authentication
        public const string JWT_TOKEN = "jwtToken";
        public const string SESSION_TIMED_OUT = "Session timed out. Please sign in again.";

        // Regex Pattern
        public const string Email_REGEX_PATTERN = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
        public const string Phone_REGEX_PATTERN = @"^\d{2}\/\d{2}\/\d{4}$";
        public const string Password_REGEX_PATTERN = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$*]).{8,}$";

        // Directions
        public const string NORTH_DIRECTION = "N";
        public const string NORTH_NORTH_EAST_DIRECTION = "NNE";
        public const string NORTH_EAST_DIRECTION = "NE";
        public const string EAST_NORTH_EAST_DIRECTION = "ENE";
        public const string EAST_DIRECTION = "E";
        public const string EAST_SOUTH_EAST_DIRECTION = "ESE";
        public const string SOUTH_EAST_DIRECTION = "SE";
        public const string SOUTH_SOUTH_EAST_DIRECTION = "SSE";
        public const string SOUTH_DIRECTION = "S";
        public const string SOUTH_SOUTH_WEST_DIRECTION = "SSW";
        public const string SOUTH_WEST_DIRECTION = "SW";
        public const string WEST_SOUTH_WEST_DIRECTION = "WSW";
        public const string WEST_DIRECTION = "W";
        public const string WEST_NORTH_WEST_DIRECTION = "WNW";
        public const string NORTH_WEST_DIRECTION = "NW";
        public const string NORTH_NORTH_WEST_DIRECTION = "NNW";

        // Common
        public const string ALPHABETICAL_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string NUMERIC_CHARACTERS = "0123456789";
        public const string NOT_AVAILABLE_ABBREVIATION = "NA";
        public const string USER_IMAGE = "UserImage";
        public const string ADMINISTRATOR = "Administrator";
        public const string TIME_REMAINING = "TimeRemaining";
        public const string METRIC_UNIT = "Metric";
        public const string PRESSURE_UNIT = "hPa";
        public const string SPEED_KMH_UNIT = "KM/H";
        public const string SPEED_CONVERSION_FACTOR = "3.6";
        public const string GET_REQUEST_METHOD = "GET";
        public const string CLOUD_PERCENTAGE_WEATHER_STRING = "Cloud Percentage";
        public const string FEELS_LIKE_WEATHER_STRING = "Feels Like";
        public const string MINIMUM_TEMPERATURE_WEATHER_STRING = "Minimum Temperature";
        public const string MAXIMUM_TEMPERATURE_WEATHER_STRING = "Maximum Temperature";
        public const string WIND_WEATHER_STRING = "Wind";
        public const string GUSTS_WEATHER_STRING = "Gusts";
        public const string PRESSURE_WEATHER_STRING = "Pressure";
        public const string SUNRISE_TIME_WEATHER_STRING = "Sunrise Time";
        public const string SUNSET_TIME_WEATHER_STRING = "Sunset Time";
        public const string CREATE_STRING = "Create";
        public const string UPDATE_STRING = "Update";
        public const string COPY_LINK = "CopyLink";
        public const string EMAIL_LOWER = "email";
        public const string COPY_LINK_LOWER = "copylink";
        public const string HH_MM_TT_TIME_FORMAT = "hh:mm tt";
        public const string DATE_DEFAULT_FORMAT = "MM/dd/yyyy";
        public const string DATETIME_DEFAULT_FORMAT = "MM/dd/yyyy HH:mm";
        public const string DATETIME_EMAIL_FORMAT = "dddd, MMMM dd, yyyy";
        public const string UTC_STRING = "UTC";
        public const string NUMBER_OF_TICKET_LABEL = "Number Of Ticket";
        public const string ACTIVE_STATUS = "Active";
        public const string EXPIRED_STATUS = "Expired";
        public const string USER_LOGIN_EMAIL = "UserLoginEmail";
        public const string FILE_BASE_64_HEADER = "data:{0};base64,";
        public const string HTTP_X_FORWARDED_FOR = "HTTP_X_FORWARDED_FOR";
        public const string REMOTE_ADDR = "REMOTE_ADDR";
        public const string ANONYMOUS = "Anonymous";

        // Path
        public const string SERVER_MAP_PATH = "~/";
        public const string DEFAULT_USER_IMAGE_FILE_PATH = "../../Images/User.jpg";

        // Url
        public const string USER_ACTIVATION_LINK = "Login/UserActivation?activationData=";
        public const string PASSWORD_RESET_LINK = "Login/ResetPassword?allowToReset=true&resetPasswordData=";
        public const string VIEW_CHECK_LIST_ITEM_LINK = "View/ChecklistItem?viewCode=";
        public const string UNSUBSCRIBE_LINK = "Home/Unsubscribe?email=";
        public const string LOCATION_LIST_LINK = "Location/List";
        public const string LOCATION_DETAIL_LINK = "Location/Detail?locationId=";
        public const string CHECKLIST_LIST_LINK = "Account/MyChecklist";
        public const string BOOKING_DETAIL_LINK = "Booking/Detail?bookingId=";

        // Characters
        public const string STRING_WHITE_SPACE = " ";
        public const string FORWARD_SLASH = "/";
        public const string PERIOD = ".";
        public const string ASTERISK = "*";
        public const string S_CHARACTER = "S";
        public const string C_CHARACTER = "C";
        public const string X_CHARACTER = "X";
        public const string DEGREE_CHARACTER = "°";
        public const string COMMA_CHARACTER = ",";
        public const string COLON_CHARACTER = ":";
        public const string PERCENTAGE = "%";

        // Email
        public const string EMAIL_ACTIVATION_SUBJECT = "Activate your account";
        public const string USER_RESET_PASSWORD_SUBJECT = "Reset your Password";
        public const string CHANGE_USER_EMAIL_SUBJECT = "Change your Email";
        public const string CHANGE_USER_PASSWORD_SUCCESSFUL_SUBJECT = "Password changed successfully";
        public const string CHECKLIST_ITEM_SHARED_LINK_SUCCESSFUL_SUBJECT = "Checklist item for {0} trip on {1}";
        public const string SUBSCRIPTION_SUBJECT = "Mini Traveling Explorer - Subscription";
        public const string BOOKED_TICKET_SUBJECT = "Booked Ticket";
        public const string BOOKED_TICKET_REMINDER_SUBJECT = "Your trip is coming soon!";

        // Template
        public const string TEMPLATE_PATH = "Template";
        public const string EMAIL_TEMPLATE_FOLDER = "Email";
        public const string EMAIL_ACTIVATION_TEMPLATE_FILE = "EmailActivation.html";
        public const string USER_RESET_PASSWORD_TEMPLATE_FILE = "UserResetPassword.html";
        public const string USER_EMAIL_CHANGE_TEMPLATE_FILE = "UserEmailChange.html";
        public const string USER_PASSWORD_CHANGE_TEMPLATE_FILE = "UserPasswordChange.html";
        public const string EMAIL_SUBSCRIPTION_TEMPLATE_FILE = "EmailSubscription.html";
        public const string CHECKLIST_SHARE_LINK_TEMPLATE_FILE = "ChecklistShare.html";
        public const string TRIP_BOOKING_CONFIRMATION_TEMPLATE_FILE = "TripBookingConfirmation.html";
        public const string TRIP_BOOKING_REMINDER_TEMPLATE_FILE = "TripReminder.html";
        public const string EMAIL_ACTIVATION_USER_FULL_NAME = "{USER_FULL_NAME}";
        public const string EMAIL_ACTIVATION_HOME_PAGE_URL = "{HOME_PAGE_URL}";
        public const string EMAIL_ACTIVATION_LINK = "{ACTIVATION_LINK}";
        public const string EMAIL_TEMPLATE_PASSWORD_RESET_LINK = "{PASSWORD_RESET_LINK}";
        public const string EMAIL_TEMPLATE_VERIFICATION_CODE = "{EMAIL_VERIFICATION_CODE}";
        public const string EMAIL_FULL_NAME = "{EMAIL_FULL_NAME}";
        public const string EMAIL_VERIFICATION_CODE = "{EMAIL_VERIFICATION_CODE}";
        public const string EMAIL_UNSUBSCRIBE_LINK = "{UNSUBSCRIBE_LINK}";
        public const string EMAIL_PROMO_CODE = "{PROMO_CODE}";
        public const string EMAIL_LOCATION_NAME = "{LOCATION_NAME}";
        public const string EMAIL_CHECKLIST_SHARE_URL = "{CHECKLIST_SHARE_URL}";
        public const string EMAIL_BOOKING_DETAIL_URL = "{BOOKING_DETAIL_URL}";
        public const string EMAIL_TICKET_NUMBER = "{TICKET_NUMBER}";
        public const string EMAIL_TRIP_DATE = "{TRIP_DATE}";
        public const string EMAIL_NUMBER_OF_TICKET = "{NUMBER_OF_TICKET}";
        public const string EMAIL_AMOUNT = "{AMOUNT}";

        // AppSettings Key
        public const string CONNECTION_STRING_KEY = "MiniTravelingExplorerConnection";
        public const string OPEN_WEATHER_API_URL_KEY = "OpenWeatherApiUrl";
        public const string OPEN_WEATHER_CITY_URL_KEY = "OpenWeatherCityUrl";
        public const string OPEN_WEATHER_ICON_URL_KEY = "OpenWeatherIconUrl";
        public const string GOOGLE_MAP_URL_KEY = "GoogleMapUrl";
        public const string GOOGLE_RECAPTCHA_API_URL_PARAMETERS_KEY = "GoogleRecaptchaApiUrlParameters";
        public const string IP_INFO_LINK_KEY = "IpInfoLinkKey";
        public const string JWT_KEY = "config:JwtKey";
        public const string JWT_ISSUER_KEY = "config:JwtIssuer";
        public const string JWT_AUDIENCE_KEY = "config:JwtAudience";
        public const string USER_LOCK_OUT_TIME_KEY = "userLockOutTime";
        public const string USER_LOCK_OUT_MAX_ATTEMPT_KEY = "userLockOutMaxAttempt";
        public const string OPEN_WEATHER_API_KEY_KEY = "openWeatherApiKey";
        public const string GOOGLE_MAP_API_KEY_KEY = "googleMapApiKey";
        public const string GOOGLE_RECAPTCHA_SITE_KEY = "googleRecaptchaSiteKey";
        public const string GOOGLE_RECAPTCHA_SECRET_KEY = "googleRecaptchaSecretKey";
        public const string GOOGLE_RECAPTCHA_API_URL_KEY = "googleRecaptchaApiUrl";
        public const string SMPTP_CLIENT_HOST_KEY = "smtpClientHost";
        public const string SMPTP_CLIENT_PORT_KEY = "smtpClientPort";
        public const string SMPTP_CLIENT_USE_DEFAULT_CREDENTIALS_KEY = "smtpClientUseDefaultCredentials";
        public const string SMPTP_CLIENT_CREDENTIALS_USERNAME_KEY = "smtpClientCredentialsUsername";
        public const string SMPTP_CLIENT_CREDENTIALS_PASSWORD_KEY = "smtpClientCredentialsPassword";
        public const string SMPTP_CLIENT_ENABLE_SSL_KEY = "smtpClientEnableSsl";
        public const string ENCRYTION_KEY = "encryptionKey";
        public const string ACTIVATION_LINK_EXPIRY_DAYS_KEY = "activationLinkExpiryDays";
        public const string PASSWORD_RESET_LINK_EXPIRY_DAYS_KEY = "passwordResetLinkExpiryDays";
        public const string EMAIL_RESEND_CODE_WAITING_TIME_KEY = "emailResendCodeWaitingTime";
        public const string COOKIE_EXPIRATION_TIME_KEY = "cookieExpirationTime";
        public const string COOKIE_LOGOUT_EXPIRATION_TIME_KEY = "cookieLogoutExpirationTime";
        public const string ITERATION_COUNT_KEY = "iterationCount";
        public const string MIN_TEMPERATURE_KEY = "minTemperature";
        public const string MAX_TEMPERATURE_KEY = "maxTemperature";
        public const string TOAST_NOTIFICATION_TIMEOUT_KEY = "toastNotificationTimeout";
        public const string MAX_TICKET_ALLOWED_TO_BOOK_KEY = "maxTicketAllowedToBook";
        public const string TRIP_REMINDER_FROM_DAYS_KEY = "tripReminderFromDays";
        public const string EMAIL_SUBSCRIPTION_PROMOTION_ID_KEY = "emailSubscriptionPromotionId";
        public const string USER_PROFILE_IMAGE_MAX_SIZE_KEY = "userProfileImageMaxSize";
        public const string LOG_FILE_PATH_KEY = "logFilePath";
        public const string BASE_URL_KEY = "baseUrl";

        // Message
        public const string USER_UNSUBSCRIBE_MESSAGE = "Don't forget, you can subscribe again any time, You might miss out exciting offers and deals!";
        public const string BOOK_CARD_EMAIL_MESSAGE = "Booked tickets will be sent to the above entered email.";
        public const string BOOK_CARD_CHECKBOX_TEXT = "Use my login email";

        // Success Message
        public const string USER_ADDED_SUCCESS_MESSAGE = "Registartion has been completed successfully";
        public const string USER_UPDATED_SUCCESS_MESSAGE = "User profile updated successfully.";
        public const string LOGOUT_SUCCESS_MESSAGE = "Logged out successfully.";
        public const string RESET_PASSWORD_EMAIL_SENT_SUCCESS_MESSAGE = "If your account is associated with us, You will receive an email with instructions on how to reset your password.";
        public const string RESET_PASSWORD_SUCCESS_MESSAGE = "Password has been reset successfully";
        public const string USER_EMAIL_CODE_SEND_SUCCESS_MESSAGE = "Verification code has been sent to your email successfully";
        public const string USER_EMAIL_UPDATE_SUCCESS_MESSAGE = "Email has been updated successfully";
        public const string USER_PASSWORD_UPDATE_SUCCESS_MESSAGE = "Password has been updated successfully";
        public const string INSERT_CHECKLIST_SUCCESS_MESSAGE = "Checklist has been inserted successfully.";
        public const string DELETE_CHECKLIST_SUCCESS_MESSAGE = "Checklist has been deleted successfully.";
        public const string INSERT_CHECKLIST_ITEM_SUCCESS_MESSAGE = "Checklist item has been added successfully.";
        public const string UPDATE_CHECKLIST_ITEM_SUCCESS_MESSAGE = "Checklist item has been updated successfully.";
        public const string DELETE_CHECKLIST_ITEM_SUCCESS_MESSAGE = "Checklist item has been deleted successfully.";
        public const string EMAIL_LINK_CHECKLIST_ITEM_SUCCESS_MESSAGE = "Link has been emailed successfully";
        public const string COPY_LINK_CHECKLIST_ITEM_SUCCESS_MESSAGE = "Link has been copied to clipboard";
        public const string USER_SUBSCRIBE_SUCCESS_MESSAGE = "Thank you! You have been subsribed successfully.";
        public const string USER_UNSUBSCRIBE_SUCCESS_MESSAGE = "You have been unsubscribed successfully!";
        public const string BOOK_TICKET_SUCCESS_MESSAGE = "You ticket(s) have been booked and emailed to the specified email successfully!";
        public const string VIEW_CHECKLIST_ITEM_EMPTY_MESSAGE = "Uh oh! Seems like the checklist item for the booking seems to be over past the trip date or not found!";
        public const string VALID_PROMO_CODE_SUCCESS_MESSAGE = "Promo code is valid and has been applied";
        public const string ADMIN_VALIDATION_SUCCESS_MESSAGE = "Valid admin user";
        public const string FILE_DOWNLOAD_SUCCESS_MESSAGE = "File downloaded successfully.";
        public const string SESSION_ALIVE_SUCCESS_MESSAGE = "Session is alive!";

        // Error Messages
        public const string ERROR_OCCURRED_ERROR_MESSAGE = "An error has occurred.";
        public const string REGISTER_ERROR_MESSAGES = "RegisterErrorMessages";
        public const string REGISTER_FIRST_NAME_ERROR_MESSAGE = "Please enter first name";
        public const string REGISTER_LAST_NAME_ERROR_MESSAGE = "Please enter last name";
        public const string REGISTER_DATE_OF_BIRTH_ERROR_MESSAGE = "Please enter date of birth";
        public const string REGISTER_DATE_OF_BIRTH_INVALID_ERROR_MESSAGE = "Please enter valid date of birth";
        public const string REGISTER_SECURITY_QUESTION_ERROR_MESSAGE = "Please select a security question";
        public const string REGISTER_SECURITY_ANSWER_ERROR_MESSAGE = "Please enter security answer";
        public const string REGISTER_GENDER_ERROR_MESSAGE = "Please select a gender";
        public const string CHANGE_PASSWORD_ERROR_MESSAGE = "Please enter current password";
        public const string CHANGE_PASSWORD_SAME_AS_NEW_PASSWORD_ERROR_MESSAGE = "Password should not be same as current password";
        public const string USER_NOT_ACTIVATE_ERROR_MESSAGE = "Account has not been activated yet. Please check your mail to activate your account.";
        public const string RESET_PASSWORD_INVALID_TOKEN_MESSAGE = "Reset password failed. Invalid or expired token.";
        public const string USER_LOCKED_OUT_ERROR_MESSAGE = "Too many invalid attempts. Account has been locked out. Please try again after {0} minute(s).";
        public const string RESET_PASSWORD_ERROR_MESSAGE = "Unable to reset your password at the moment. Please try again later or";
        public const string EMAIL_ALREADY_EXISTS_ERROR_MESSAGE = "Unable to register as the entered email has been already registered.";
        public const string USER_EMAIL_CODE_SEND_ERROR_MESSAGE = "Unable to send verification code at the moment. Please try again later.";
        public const string USER_EMAIL_UPDATE_ERROR_MESSAGE = "Unable to update email at the moment. Please try again later.";
        public const string USER_EMAIL_UPDATE_INVALID_ERROR_MESSAGE = "Invalid attempt to update as enetered email is same as current logged in email.";
        public const string USER_PASSWORD_UPDATE_ERROR_MESSAGE = "Unable to update password at the moment. Please try again later.";
        public const string USER_ACTIVATION_INVALID_TOKEN_MESSAGE = "Invalid or expired token!";
        public const string GOOGLE_RECAPTCHA_INVALID_ERROR_MESSAGE = "Invalid recaptcha response, please try again.";
        public const string EMAIL_SUBSCRIBER_ALREADY_EXISTS_ERROR_MESSAGE = "The provided email has been already subscribed.";
        public const string INSERT_CHECKLIST_ERROR_MESSAGE = "Unable to insert checklist at the moment. Please try again later.";
        public const string CHECKLIST_NAME_ALREADY_EXISTS_ERROR_MESSAGE = "Unable to create the checklist as the entered name has been already been used.";
        public const string DELETE_CHECKLIST_ERROR_MESSAGE = "Unable to delete the checklist at the moment. Please try again later.";
        public const string CHECKLIST_ITEM_ERROR_MESSAGE = "Unable to {0} checklist at the moment. Please try again later.";
        public const string CHECKLIST_ITEM_NAME_ALREADY_EXISTS_ERROR_MESSAGE = "Unable to {0} the checklist item as the entered name has been already been used.";
        public const string EMAIL_LINK_CHECKLIST_ITEM_ERROR_MESSAGE = "Unable to email the link at the moment. Please try again later.";
        public const string COPY_LINK_CHECKLIST_ITEM_ERROR_MESSAGE = "Unable to copy link at the moment. Please try again later.";
        public const string DELETE_CHECKLIST_ITEM_ERROR_MESSAGE = "Unable to delete the checklist item at the moment. Please try again later.";
        public const string CHECKLIST_SHARE_ERROR_MESSAGE = "Unable to share the checklist item at the moment. Please try again later.";
        public const string USER_SUBSCRIBE_ERROR_MESSAGE = "Unable to subscribe at the moment. Please try again later.";
        public const string BOOK_TICKET_ERROR_MESSAGE = "Unable to book ticket at the moment. Please try again later.";
        public const string ADMIN_VALIDATION_ERROR_MESSAGE = UNATUHORIZED_ERROR_MESSAGE + STRING_WHITE_SPACE + "Invalid admin credentials.";
        public const string UNATUHORIZED_ERROR_MESSAGE = "Unauthorized access!";

        // Common Messages
        public const string HTML_TITLE = "Mini Traveling Explorer";
        public const string NO_ROOMS_MESSAGE = "No rooms are available at the moment. Please check again later.";
        public const string NO_STAFFS_MESSAGE = "No staffs are available at the moment. Please check again later.";
        public const string NO_LOCATION_MESSAGE = "No locations are available to explore.";
        public const string NO_CHECKLIST_MESSAGE = "You have no checklist.";
        public const string NO_CHECKLIST_ITEM_MESSAGE = "You have no items yet.";
        public const string CHECKLIST_HEADER_MESSAGE = "Click on the notepad to add your items on the checklist.";
        public const string BOOK_AND_CREATE_CHECKLIST_MESSAGE = "If you do not have any bookings, book a spectacular vacation spot and start creating your checklist!";
        public const string BOOK_TICKET_MESSAGE = "If you do not have any bookings, book a spectacular vacation spot right now and start exploring!";
        public const string RESPONSIVENESS_UNSUPPORT_MESSAGE = "Please view in desktop for better experience.";
        public const string FILE_NOT_GENERATED_MESSAGE = "Log file has not generated yet.";

        // Controller
        public const string LOGIN_CONTROLLER = "Login";
        public const string HOME_CONTROLLER = "Home";
        public const string ACCOUNT_CONTROLLER = "Account";
        public const string LOCATION_CONTROLLER = "Location";
        public const string BOOKING_CONTROLLER = "Booking";
        public const string ADMIN_CONTROLLER = "Admin";

        // Action
        public const string HOME_ACTION = "Home";
        public const string LOGIN_ACTION = "Login";
        public const string USER_LOGIN_ACTION = "UserLogin";
        public const string LIST_ACTION = "List";
        public const string MY_CHECKLIST_ACTION = "MyChecklist";
        public const string BOOKING_LIST_ACTION = "List";
        public const string LOGOUT_ACTION = "Logout";
        public const string KEEP_SESSION_ACTION = "KeepSessionAlive";
        public const string CLEAR_SESSION_ACTION = "ClearSession";

        // Session
        public const string ADMIN_USER_ID = "AdminUserId";
        public const string ADMIN_USER_EMAIL = "AdminUserEmail";
        public const string ADMIN_USER_IMAGE = "AdminUserImage";
        public const string ADMIN_USER_FULL_NAME = "AdminUserFullName";

        // UI Error Message
        public const string RECAPTCHA_ERROR_MESSAGE = "Please validate the captcha";
        public const string ENTER_EMAIL_ERROR_MESSAGE = "Please enter email";
        public const string ENTER_EMAIL_INVALID_ERROR_MESSAGE = "Please enter a valid email";
        public const string ENTER_CONFIRMATION_EMAIL_INVALID_ERROR_MESSAGE = "Confirmation email does not match with entered email";
        public const string ENTER_PASSWORD_ERROR_MESSAGE = "Please enter password";
        public const string ENTER_PASSWORD_INVALID_ERROR_MESSAGE = "Please enter a valid password";
        public const string ENTER_EMAIL_AND_PASSWORD_INVALID_ERROR_MESSAGE = "Please enter a valid email and password";
        public const string ENTER_CONFIRMATION_PASSWORD_ERROR_MESSAGE = "Please enter confirm password";
        public const string ENTER_CONFIRMATION_PASSWORD_INVALID_ERROR_MESSAGE = "Confirmation password does not match with entered password";
        public const string ENTER_PASSWORD_REQUIREMENTS_ERROR_MESSAGE = "Entered password does not meet the requirements. Please check the minimum requirements from the above information icon";
        public const string ENTER_PHONE_ERROR_MESSAGE = "Please enter phone";
        public const string ENTER_PHONE_INVALID_ERROR_MESSAGE = "Please enter a valid phone";
        public const string USER_NOT_FOUND_INVALID_CREDENTIALS_ERROR_MESSAGE = "Email or Password is invalid. Please try again";
        public const string USER_NOT_ADDED_ERROR_MESSAGE = "Unable to register user.";
        public const string USER_NOT_UPDATED_ERROR_MESSAGE = "Unable to update profile.";
        public const string CONTACT_CUSTOMER_SUPPORT_MESSAGE = "Please contact customer support.";
        public const string EMAIL_SEND_VERIFICATION_CODE_ERROR_MESSAGE = "Please get your verification code";
        public const string EMAIL_CODE_VERIFICATION_ERROR_MESSAGE = "Please enter your verification code";
        public const string USER_CURRENT_PASSWORD_INVALID_ERROR_MESSAGE = "Current password is incorrect. Please enter you valid current password.";
        public const string MY_CHECKLIST_CHECKLIST_NAME_ERROR_MESSAGE = "Please enter a name for the checklist";
        public const string MY_CHECKLIST_BOOKING_NAME_ERROR_MESSAGE = "Please select a booking";
        public const string MY_CHECKLIST_ITEM_NAME_ERROR_MESSAGE = "Please enter item name for your checklist";
        public const string ENTER_CARD_NUMBER_ERROR_MESSAGE = "Please enter card number";
        public const string ENTER_CARD_NUMBER_INVALID_ERROR_MESSAGE = "Please enter valid card number";
        public const string ENTER_CARD_NAME_ERROR_MESSAGE = "Please enter card name";
        public const string ENTER_CARD_EXPIRY_ERROR_MESSAGE = "Please enter card expiry month and year";
        public const string ENTER_CARD_EXPIRY_INVALID_ERROR_MESSAGE = "Please enter valid card expiry month and year";
        public const string ENTER_CARD_CVV_ERROR_MESSAGE = "Please enter cvv";
        public const string ENTER_CARD_CVV_INVALID_ERROR_MESSAGE = "Please enter valid cvv";
        public const string ENTER_NUMBER_OF_TICKET_ERROR_MESSAGE = "Please enter the number of ticket";
        public const string ENTER_TRIP_DATE_ERROR_MESSAGE = "Please enter trip date";
        public const string ENTER_TRIP_DATE_INVALID_ERROR_MESSAGE = "Please enter valid trip date";
        public const string INVALID_PROMO_CODE_ERROR_MESSAGE = "Invalid or expired promo code";
        public const string VALIDATE_PROMO_CODE_ERROR_MESSAGE = "Please validate promo code before booking";

        // Stored Procedure
        public const string GET_SECURITY_QUESTION_SP = "MTE.GetSecurityQuestion";
        public const string GET_USER_BY_EMAIL_SP = "MTE.GetUserByEmail";
        public const string GET_USER_BY_EMAIL_AND_ID_SP = "MTE.GetUserByEmailAndId";
        public const string INSERT_UPDATE_USER_SP = "MTE.InsertUpdateUser";
        public const string UPDATE_LOGIN_USER_SP = "MTE.UpdateLoginUser";
        public const string GET_USER_LOCK_OUT_INFO_SP = "MTE.GetUserLockOutInfo";
        public const string UPDATE_USER_EMAIL_SP = "MTE.UpdateUserEmail";
        public const string UPDATE_USER_PASSWORD_SP = "MTE.UpdateUserPassword";
        public const string GET_USER_PASSWORD_SP = "MTE.GetUserPassword";
        public const string GET_HOME_PAGE_DATA_SP = "MTE.GetHomePageData";
        public const string GET_ROOM_LIST_SP = "MTE.GetRoomList";
        public const string GET_STAFF_LIST_SP = "MTE.GetStaffList";
        public const string INSERT_UPDATE_SUBSCRIBER_SP = "MTE.InsertUpdateSubscriber";
        public const string GET_BOOKING_LIST_SP = "MTE.GetBookingList";
        public const string GET_BOOKING_DETAIL_SP = "MTE.GetBookingDetail";
        public const string GET_LOCATION_DATA_SP = "MTE.GetLocationData";
        public const string GET_LOCATION_DETAIL_SP = "MTE.GetLocationDetail";
        public const string GET_CONTACT_PAGE_DATA_SP = "MTE.GetContactPageData";
        public const string GET_BOOKING_BY_USER_ID_SP = "MTE.GetBookingByUserId";
        public const string GET_CHECKLIST_DATA_SP = "MTE.GetChecklistData";
        public const string INSERT_CHECKLIST_SP = "MTE.InsertChecklist";
        public const string DELETE_CHECKLIST_SP = "MTE.DeleteChecklist";
        public const string INSERT_UPDATE_CHECKLIST_ITEM_SP = "MTE.InsertUpdateChecklistItem";
        public const string DELETE_CHECKLIST_ITEM_SP = "MTE.DeleteChecklistItem";
        public const string GET_CHECKLIST_ITEM_SP = "MTE.GetChecklistItem";
        public const string GET_CHECKLIST_SHARE_DATA_SP = "MTE.GetChecklistShareData";
        public const string APPLY_AND_VALIDATE_PROMO_CODE_SP = "MTE.ApplyAndValidatePromoCode";
        public const string BOOK_TICKET_SP = "MTE.BookTicket";
        public const string INSERT_USER_DETAIL_BY_IP_SP = "MTE.InsertUserDetailByIp";
        public const string VALIDATE_ADMIN_USER_SP = "MTE.ValidateAdminUser";
        public const string GET_USER_LIST_SP = "MTE.GetUserList";
        public const string GET_USER_IP_INFO_LIST_SP = "MTE.GetUserIpInfoList";

        // Table
        public const string USER_TABLE = "User";
        public const string SECURITY_QUESTION_TABLE = "SecurityQuestion";
        public const string HOME_PAGE_DATA = "HomePageData";
        public const string CONTACT_PAGE_DATA = "ContactPageData";
        public const string ROOM_TABLE = "Room";
        public const string STAFF_TABLE = "Staff";
        public const string TESTIMONIAL_TABLE = "Testimonial";
        public const string BOOKING_TABLE = "Booking";
        public const string BOOKING_DETAIL = "BookingDetail";
        public const string LOCATION_TABLE = "Location";
        public const string LOCATION_DATA = "LocationData";
        public const string LOCATION_DETAIL = "LocationDetail";
        public const string ACTIVITY_TABLE = "Activity";
        public const string WEATHER_TABLE = "Weather";
        public const string CHECKLIST_TABLE = "Checklist";
        public const string CHECKLIST_DATA = "ChecklistData";
        public const string CHECKLIST_ITEM_TABLE = "ChecklistItem";
        public const string CHECKLIST_SHARE_DATA = "ChecklistShareData";
        public const string USER_IP_INFO_TABLE = "UserIpInfo";
        public const string ADMIN_HOME_PAGE_DATA = "AdminHomePageData";

        // Column
        public const string USER_ID = "UserId";
        public const string EMAIL = "Email";
        public const string FULL_NAME = "FullName";
        public const string SALT_KEY = "SaltKey";
    }
}