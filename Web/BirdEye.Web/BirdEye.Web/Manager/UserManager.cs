using System.IO;
using BirdEye.Common.Entity;
using BirdEye.Common.Enum;
using BirdEye.Web.UserService;

namespace BirdEye.Web.Manager
{
	public class UserManager
	{
		private readonly UserServiceClient client;

		internal UserManager()
		{
			this.client = new UserServiceClient();
		}

		internal bool CreateUser(CommonUser user)
		{
			return client.CreateUser(user);
			//return client.CreateUser(user);
		}

		internal bool ValidateUser(string accountid, string pwd, out string username)
		{
			return client.ValidateUser(out username, accountid, pwd);
		}

		internal bool ValidateUser(string accountid, string pwd, out string username, out bool haveSetUserName)
		{
			return client.ValidateUser2(out username, out haveSetUserName, accountid, pwd);
		}

		internal CommonUser GetUser(string id)
		{
			CommonUser user = client.GetUser(id);
			return user;
		}

		internal string GetUserNameById(string id)
		{
			return client.GetUserNameById(id);
		}

		internal UpdateUserStatus UpdateUser(CommonUser user)
		{
			return client.UpdateUser(user);
		}

		#region To Do

		public bool EnablePasswordReset { get; set; }

		public bool EnablePasswordRetrieval { get; set; }

		internal bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			return client.ChangePassword(username, oldPassword, newPassword);
		}

		internal bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			return client.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
		}

		internal bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			return client.DeleteUser(username, deleteAllRelatedData);
		}

		#endregion
	}
}
