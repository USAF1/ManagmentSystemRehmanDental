using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.UsersManagment
{
    public class UsersHandler
    {
        public static User GetUser(User user)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from User in context.Users.Include(u=>u.Role)
                        where(User.UserName == user.UserName && User.Password == user.Password)
                        select User).FirstOrDefault();

            }
        }

        public static List<User> GetUsers()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (context.Users.Include(u=>u.Role).ToList());
            }
        }

        public static List<Role> GetRoles()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Roles.ToList();
            }
        }


    }
}
