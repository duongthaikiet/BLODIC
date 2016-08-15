using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.Mvc;
using DuongThaiKiet.DTKEF;
using DuongThaiKiet.Enum;
using DuongThaiKiet.Utility;


namespace DuongThaiKiet.Areas.Admin.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly DTKEntities _db = new DTKEntities();
        private AdminUserGroupModel _model;
        // GET: Admin/Users
        public ActionResult Index(bool isUser = true)
        {
            if (isUser)
            {
                _model = new AdminUserGroupModel
                {
                    //SelectedItemIds = new[] { "1", "3" },
                    Items = _db.AdminUsers.Select(user => new SelectListItem
                    {
                        Value = user.Id.ToString(),
                        Text = user.UserName + " - " + user.FirstName + " " + user.LastName                      
                    })
                };              
            }
            else
            {
                _model = new AdminUserGroupModel
                {
                    //SelectedItemIds = new[] { "1", "3" },
                    Items = _db.AdminGroups.Select(group => new SelectListItem
                    {
                        Value = group.Id.ToString(),
                        Text = group.GroupName
                    })
                };
            }
            return View(_model);
        }

        public ActionResult Groups()
        {
            var groups = _db.AdminGroups.Select(group => new AdminGroupModel()
            {
                Id = group.Id,
                GroupName = group.GroupName,
            }).AsEnumerable();
            return View(groups);
        }

        public JsonResult GetUserDetail(int userId,bool isUser = true)
        {
            var user = _db.AdminUsers.Find(userId);
            var result = Json(new AdminUserGroupModel()
            {
                User = new AdminUser()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    Email = user.Email,
                    IsSubscribed = user.IsSubscribed
                }
            });
            return result;
        }
    }
}