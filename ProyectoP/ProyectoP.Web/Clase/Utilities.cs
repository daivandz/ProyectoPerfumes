using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoP.Web.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@mail.com");

            if (userAsp == null)
            {
                CreateUserASP("admin@mail.com", "admin123", "Admin");
            }
        }

        internal static void CheckClientDefault()
        {
            var clientdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userClient = clientdb.FindByName("userdefault@user.com");

            if (userClient == null)
            {
                CreateUserASP("userdefault@user.com", "cliente123", "Client");
            }
        }

        public static void CreateUserASP(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, rol);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}