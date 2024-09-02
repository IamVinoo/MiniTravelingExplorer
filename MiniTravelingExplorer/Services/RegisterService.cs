using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using MiniTravelingExplorer.Utils;
using MiniTravelingExplorer.Models;

namespace MiniTravelingExplorer.Services
{
    public class RegisterService : BaseService
    {
        public void InsertUpdateUserProfile(User user, bool isAdd, int userId, string serverMapPath = "")
        {
            SqlCommand sqlCommand = new SqlCommand(Constant.INSERT_UPDATE_USER_SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            string saltKey = string.Empty;

            if (isAdd)
            {
                saltKey = System.Web.Helpers.Crypto.GenerateSalt();
            }

            string activationKey = Guid.NewGuid().ToString();
            string activationData = UtilFunction.EncryptString(JsonConvert.SerializeObject(new User
            {
                FullName = user.FullName,
                Email = user.Email,
                ActivationKey = activationKey,
                ExpiryDate = DateTime.UtcNow.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings[Constant.ACTIVATION_LINK_EXPIRY_DAYS_KEY]))
            }));

            sqlCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = isAdd ? 0 : userId;
            sqlCommand.Parameters.Add("@Saltkey", SqlDbType.NVarChar, 50).Value = saltKey;
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = user.FirstName;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = user.LastName;
            sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar, 100).Value = user.FullName;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = isAdd ? UtilFunction.HashPassword(user.Password, saltKey) : string.Empty;
            sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = user.DateOfBirth;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = isAdd ? user.Email : string.Empty;
            sqlCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = user.Phone;
            sqlCommand.Parameters.Add("@SecurityQuestionId", SqlDbType.Int).Value = user.SecurityQuestionId;
            sqlCommand.Parameters.Add("@SecurityAnswer", SqlDbType.NVarChar, 50).Value = user.SecurityAnswer;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = user.Gender;
            sqlCommand.Parameters.Add("@UserPhoto", SqlDbType.VarBinary).Value = isAdd ? (object)DBNull.Value : (user.UserPhoto ?? (object)DBNull.Value);
            sqlCommand.Parameters.Add("@UserPhotoName", SqlDbType.NVarChar, 100).Value = isAdd ? (object)DBNull.Value : (user.UserPhotoName ?? (object)DBNull.Value);
            sqlCommand.Parameters.Add("@UserPhotoType", SqlDbType.NVarChar, 100).Value = isAdd ? (object)DBNull.Value : (user.UserPhotoType ?? (object)DBNull.Value);
            sqlCommand.Parameters.Add("@ActivationKey", SqlDbType.NVarChar, 50).Value = isAdd ? activationKey : (object)DBNull.Value;

            using (connection)
            {
                connection.Open();
                NoOfRowsAffected = sqlCommand.ExecuteNonQuery();
            }

            if (NoOfRowsAffected > 0 && isAdd)
            {
                string activationUrl = string.Concat(ConfigurationManager.AppSettings[Constant.BASE_URL_KEY], Constant.USER_ACTIVATION_LINK, activationData);
                string emailBody = UtilFunction.GetFileData(Path.Combine(serverMapPath, Constant.TEMPLATE_PATH, Constant.EMAIL_TEMPLATE_FOLDER, Constant.EMAIL_ACTIVATION_TEMPLATE_FILE)).Replace(Constant.EMAIL_ACTIVATION_USER_FULL_NAME, user.FullName).Replace(Constant.EMAIL_ACTIVATION_LINK, activationUrl).Replace(Constant.EMAIL_ACTIVATION_HOME_PAGE_URL, ConfigurationManager.AppSettings[Constant.BASE_URL_KEY]);

                EmailService.SendEmail(new MailAddress(user.Email, user.FullName), Constant.EMAIL_ACTIVATION_SUBJECT, emailBody);
            }
        }
    }
}