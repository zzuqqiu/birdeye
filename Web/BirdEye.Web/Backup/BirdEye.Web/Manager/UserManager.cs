using BirdEye.Common.Entity;
using BirdEye.Common.Enum;
using BirdEye.Web.Repository;

namespace BirdEye.Web.Manager
{
    public class UserManager
    {
        private UserRepository repository;

        internal UserManager()
        {
            this.repository = new UserRepository();
        }

        internal bool CreateUser(CommonUser user)
        {
            return this.repository.CreateUser(user);
        }

        internal bool ValidateUser(string accountid, string pwd, out string username)
        {
            return this.repository.ValidateUser(accountid, pwd, out username);
        }

        internal bool ValidateUser(string accountid, string pwd, out string username, out bool haveSetUserName)
        {
            return this.repository.ValidateUser(accountid, pwd, out username, out haveSetUserName);
        }

        internal CommonUser GetUser(string id)
        {
            return this.repository.GetUser(id);
        }

        internal string GetUserNameById(string id)
        {
            return this.repository.GetUserNameById(id);
        }

        internal UpdateUserStatus UpdateUser(CommonUser user)
        {
            return this.repository.UpdateUser(user);
        }

        #region To Do

        public bool EnablePasswordReset { get; set; }

        public bool EnablePasswordRetrieval { get; set; }

        internal bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return this.repository.ChangePassword(username, oldPassword, newPassword);
        }

        internal bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return this.repository.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
        }

        internal bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return this.repository.DeleteUser(username, deleteAllRelatedData);
        }

        #endregion
    }
}
