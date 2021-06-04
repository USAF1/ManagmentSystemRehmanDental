using EntityLibrary.UsersManagment;
using ManagmentSystemRehmanDental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagmentSystemRehmanDental.Helpers
{
    public static class UserHelper
    {
        public static UserModel ToModel(this User entity)
        {
            UserModel user = new UserModel();
            if (entity != null)
            {

                user.Id = entity.Id;
                user.UserName = entity.UserName;
                user.Password = entity.Password;
                user.Role = new RoleModel() { Id = entity.Role.Id, Name = entity.Role.Name };

            }
            return user;
        }

        public static User ToEntity(this UserModel model)
        {
            User entity = new User();
            if (model !=null)
            {
                entity.Id = model.Id;
                entity.UserName = model.UserName;
                entity.Password = model.Password;
            }




            return entity;

        }
    }
}
