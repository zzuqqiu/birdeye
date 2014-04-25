﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BirdEye.Web.UserService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerName", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerNameResponse")]
        string GetCustomerName(string customerCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomers", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomersResponse")]
        BirdEye.Common.Entity.Customer[] GetAllCustomers();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : BirdEye.Web.UserService.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<BirdEye.Web.UserService.ICustomerService>, BirdEye.Web.UserService.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetCustomerName(string customerCode) {
            return base.Channel.GetCustomerName(customerCode);
        }
        
        public BirdEye.Common.Entity.Customer[] GetAllCustomers() {
            return base.Channel.GetAllCustomers();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CreateUser", ReplyAction="http://tempuri.org/IUserService/CreateUserResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Entity.Customer[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Entity.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Enum.UpdateUserStatus))]
        bool CreateUser(BirdEye.Common.Entity.CommonUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ValidateUser", ReplyAction="http://tempuri.org/IUserService/ValidateUserResponse")]
        bool ValidateUser(out string username, string accountid, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ValidateUser2", ReplyAction="http://tempuri.org/IUserService/ValidateUser2Response")]
        bool ValidateUser2(out string username, out bool haveSetUserName, string accountid, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Entity.Customer[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Entity.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Enum.UpdateUserStatus))]
        BirdEye.Common.Entity.CommonUser GetUser(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserNameById", ReplyAction="http://tempuri.org/IUserService/GetUserNameByIdResponse")]
        string GetUserNameById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Entity.Customer[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Entity.Customer))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BirdEye.Common.Enum.UpdateUserStatus))]
        BirdEye.Common.Enum.UpdateUserStatus UpdateUser(BirdEye.Common.Entity.CommonUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ChangePassword", ReplyAction="http://tempuri.org/IUserService/ChangePasswordResponse")]
        bool ChangePassword(string username, string oldPassword, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ChangePasswordQuestionAndAnswer", ReplyAction="http://tempuri.org/IUserService/ChangePasswordQuestionAndAnswerResponse")]
        bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        bool DeleteUser(string username, bool deleteAllRelatedData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : BirdEye.Web.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<BirdEye.Web.UserService.IUserService>, BirdEye.Web.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateUser(BirdEye.Common.Entity.CommonUser user) {
            return base.Channel.CreateUser(user);
        }
        
        public bool ValidateUser(out string username, string accountid, string pwd) {
            return base.Channel.ValidateUser(out username, accountid, pwd);
        }
        
        public bool ValidateUser2(out string username, out bool haveSetUserName, string accountid, string pwd) {
            return base.Channel.ValidateUser2(out username, out haveSetUserName, accountid, pwd);
        }
        
        public BirdEye.Common.Entity.CommonUser GetUser(string id) {
            return base.Channel.GetUser(id);
        }
        
        public string GetUserNameById(string id) {
            return base.Channel.GetUserNameById(id);
        }
        
        public BirdEye.Common.Enum.UpdateUserStatus UpdateUser(BirdEye.Common.Entity.CommonUser user) {
            return base.Channel.UpdateUser(user);
        }
        
        public bool ChangePassword(string username, string oldPassword, string newPassword) {
            return base.Channel.ChangePassword(username, oldPassword, newPassword);
        }
        
        public bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
            return base.Channel.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
        }
        
        public bool DeleteUser(string username, bool deleteAllRelatedData) {
            return base.Channel.DeleteUser(username, deleteAllRelatedData);
        }
    }
}
