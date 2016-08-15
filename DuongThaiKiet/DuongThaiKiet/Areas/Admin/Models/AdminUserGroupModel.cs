using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DuongThaiKiet.DTKEF
{
    public interface IAdminUserMetadata
    {
        [DisplayName("Username")]
        string UserName { get; set; }

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        [Required]
        [RegularExpression("@^((?=.*[a-z])(?=.*[A-Z])(?=.*\\d)).+$")]
        [DataType(DataType.Password)]
        string Password { get; set; }

        [DisplayName("First Name")]
        string FirstName { get; set; }

        [DisplayName("Middle Name")]
        string MiddleName { get; set; }

        [DisplayName("Last Name")]
        string LastName { get; set; }

        string Email { get; set; }
        Nullable<System.DateTime> DateCreated { get; set; }
        Nullable<System.DateTime> DateModified { get; set; }
        Nullable<int> Gender { get; set; }
        Nullable<bool> IsSubscribed { get; set; }
    }

    //TODO: Allow data annotation retained after updating EF model from database
    [MetadataType(typeof (IAdminUserMetadata))]
    public partial class AdminUser : IAdminUserMetadata
    {

    }

    public interface IAdminGroupMetadata
    {
        [DisplayName("Group Name")]
        string GroupName { get; set; }

        [DisplayName("Is Active")]
        Nullable<bool> IsActive { get; set; }
    }

    [MetadataType(typeof (IAdminGroupMetadata))]
    public partial class AdminGroup : IAdminGroupMetadata
    {

    }

    public class AdminUserModel : AdminUser
    {

    }

    public class AdminGroupModel : AdminGroup
    {

    }

    public class AdminUserGroupModel
    {
        public string sorting = string.Empty;
        private bool _isUser = true;
        private int _id = 0;
        private readonly DTKEntities _db = new DTKEntities();
        public AdminUserGroupModel()
        {

        }

        public AdminUserGroupModel(bool isUser, int id)
        {
            _isUser = isUser;
            _id = id;
        }
        /*
        public AdminUser User {
            get {
                return _isUser ? _db.AdminUsers.Find(_id) : null;
            }
        }*/

        public AdminUser User
        {
            get;
            set;
        }

        public AdminGroup Group
        {
            get
            {
                return _isUser ? null : _db.AdminGroups.Find(_id);
            }
        }

        public IEnumerable<SelectListItem> Items { get; set; }
        public string[] SelectedItemIds { get; set; }
    }
}