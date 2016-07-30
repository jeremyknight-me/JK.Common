using System;
using System.Web.Security;

namespace DL.Core.Web.Security
{
    /// <summary>
    /// Data transfer object for MembershipUser.
    /// </summary>
    public class ProviderUser
    {
        /// <summary>
        /// Initializes a new instance of the ProviderUser class.
        /// </summary>
        public ProviderUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProviderUser class
        /// and loads the properties from a MembershipUser object.
        /// </summary>
        /// <param name="user">MembershipUser object to load data from.</param>
        public ProviderUser(MembershipUser user)
        {
            this.ProviderKey = user.ProviderUserKey;
            this.Comment = user.Comment;
            this.Email = user.Email;
            this.PasswordQuestion = user.PasswordQuestion;
            this.UserName = user.UserName;
            this.CreationDate = user.CreationDate;
            this.LastActivityDate = user.LastActivityDate;
            this.LastLockoutDate = user.LastLockoutDate;
            this.LastLoginDate = user.LastLoginDate;
            this.LastPasswordChangedDate = user.LastPasswordChangedDate;
            this.IsApproved = user.IsApproved;
            this.IsLockedOut = user.IsLockedOut;
            this.IsOnline = user.IsOnline;
        }

        public object ProviderKey { get; private set; }

        public string Comment { get; set; }

        public string Email { get; set; }

        public string PasswordQuestion { get; private set; }

        public string UserName { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime LastActivityDate { get; set; }

        public DateTime LastLockoutDate { get; private set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime LastPasswordChangedDate { get; private set; }

        public bool IsApproved { get; set; }

        public bool IsLockedOut { get; private set; }

        public bool IsOnline { get; private set; }
    }
}
