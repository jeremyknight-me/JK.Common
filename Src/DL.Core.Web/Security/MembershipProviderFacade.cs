using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace DL.Core.Web.Security
{
    public sealed class MembershipProviderFacade
    {
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            MembershipUser user = Membership.GetUser(userName);
            return user != null && user.ChangePassword(oldPassword, newPassword);
        }

        public void ChangePasswordQuestionAndAnswer(
            string userName,
            string currentPassword,
            string newQuestion,
            string newAnswer)
        {
            MembershipUser user = Membership.GetUser(userName);

            if (user != null)
            {
                user.ChangePasswordQuestionAndAnswer(currentPassword, newQuestion, newAnswer);
            }
        }

        public ProviderUser CreateUser(string username, string password, string email)
        {
            MembershipUser membershipUser = Membership.CreateUser(username, password, email);
            return new ProviderUser(membershipUser);
        }

        public bool DeleteUser(string userName)
        {
            return Membership.DeleteUser(userName, true);
        }

        public IEnumerable<ProviderUser> FindByEmail(string emailToMatch)
        {
            MembershipUserCollection membershipUsers = Membership.FindUsersByEmail(emailToMatch);
            return this.GetProviderUsersFromMembershipUserCollection(membershipUsers);
        }

        public IEnumerable<ProviderUser> FindByUserName(string userNameToMatch)
        {
            MembershipUserCollection membershipUsers = Membership.FindUsersByName(userNameToMatch);
            return this.GetProviderUsersFromMembershipUserCollection(membershipUsers);
        }

        public IEnumerable<ProviderUser> GetAllUsers()
        {
            MembershipUserCollection membershipUsers = Membership.GetAllUsers();
            return this.GetProviderUsersFromMembershipUserCollection(membershipUsers);
        }

        public ProviderUser GetUserByProviderKey(object providerKey)
        {
            MembershipUser membershipUser = Membership.GetUser(providerKey);
            return new ProviderUser(membershipUser);
        }

        public ProviderUser GetUserByUserName(string userName)
        {
            MembershipUser membershipUser = Membership.GetUser(userName);
            return new ProviderUser(membershipUser);
        }

        public string GetUserNameByEmail(string email)
        {
            return Membership.GetUserNameByEmail(email);
        }

        public bool IsValidUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }

        public string ResetPassword(string userName)
        {
            MembershipUser membershipUser = Membership.GetUser(userName);

            if (membershipUser == null)
            {
                throw new ArgumentException("No user for given 'userName' found.");
            }

            return membershipUser.ResetPassword();    
        }

        public bool UnlockUser(string userName)
        {
            MembershipUser user = Membership.GetUser(userName);
            return user != null && user.UnlockUser();
        }

        public void UpdateUser(ProviderUser providerUser)
        {
            MembershipUser membershipUser = Membership.GetUser(providerUser.UserName);

            if (membershipUser == null)
            {
                return;
            }

            membershipUser.Comment = providerUser.Comment;
            membershipUser.Email = providerUser.Email;
            membershipUser.IsApproved = providerUser.IsApproved;
            membershipUser.LastActivityDate = providerUser.LastActivityDate;

            Membership.UpdateUser(membershipUser);
        }

        private IEnumerable<ProviderUser> GetProviderUsersFromMembershipUserCollection(IEnumerable membershipUserCollection)
        {
            return (from MembershipUser membershipUser in membershipUserCollection 
                    select new ProviderUser(membershipUser)).ToList();
        }
    }
}
