using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirdEye.Bll.Interface;
using BirdEye.Common.Entity;

namespace BirdEye.Bll
{
	public class UserService : IUserService
	{
		private UserRepository repository;

		internal UserService()
		{
			this.repository = new UserRepository();
		}

		public bool CreateUser(Common.Entity.CommonUser user)
		{
			return this.repository.CreateUser(user);
		}

		public bool ValidateUser(string accountid, string pwd, out string username)
		{
			return this.repository.ValidateUser(accountid, pwd, out username);
		}

		public bool ValidateUser2(string accountid, string pwd, out string username, out bool haveSetUserName)
		{
			return this.repository.ValidateUser(accountid, pwd, out username, out haveSetUserName);
		}

		public Common.Entity.CommonUser GetUser(string id)
		{
			CommonUser user = this.repository.GetUser(id);
			return user;
		}

		public string GetUserNameById(string id)
		{
			return this.repository.GetUserNameById(id);
		}

		public Common.Enum.UpdateUserStatus UpdateUser(Common.Entity.CommonUser user)
		{
			return this.repository.UpdateUser(user);
		}

		public bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			return this.repository.ChangePassword(username, oldPassword, newPassword);
		}

		public bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			return this.repository.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
		}

		public bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			return this.repository.DeleteUser(username, deleteAllRelatedData);
		}
	}
}
