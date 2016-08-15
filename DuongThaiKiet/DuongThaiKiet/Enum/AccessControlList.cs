using DuongThaiKiet.DTKEF;

namespace DuongThaiKiet.Enum
{
    public enum ActionEnum
    {
        Query = 1,
        Create = 2,
        Update = 3,
        Delete = 4,
        Logon = 5
    }

    public enum DomainEnum
    {
        Blog = 100,
        Word = 101,
        Idiom = 102,
        User = 103,
        Group = 104
    }

    public class UserGroupPermission
    {
        //private DuongThaiKietDBEntities db = new DuongThaiKietDBEntities();
        public UserGroupPermission()
        {
           
        }

        public void GetUserGroupACL(int userID)
        {
            // db.Blog.find   
        }
    }
}