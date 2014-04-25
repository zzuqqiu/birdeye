using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BirdEye.Common.Entity;
using BirdEye.Common.Enum;

namespace BirdEye.Bll.Interface
{
	[ServiceContract]
	public interface IUserService
	{
		[OperationContract]
		bool CreateUser(CommonUser user);

		[OperationContract]
		bool ValidateUser(string accountid, string pwd, out string username);

		[OperationContract]
		bool ValidateUser2(string accountid, string pwd, out string username, out bool haveSetUserName);

		[OperationContract]
		CommonUser GetUser(string id);

		[OperationContract]
		string GetUserNameById(string id);

		[OperationContract]
		UpdateUserStatus UpdateUser(CommonUser user);

		[OperationContract]
		bool ChangePassword(string username, string oldPassword, string newPassword);

		[OperationContract]
		bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);

		[OperationContract]
		bool DeleteUser(string username, bool deleteAllRelatedData);
	}
}
