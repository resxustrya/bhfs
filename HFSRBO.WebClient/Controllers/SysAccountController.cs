using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HFSRBO.WebClient.Models;
using System.Web.UI;

namespace HFSRBO.WebClient.Controllers
{
    [Authorize]
    [NoCache]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
    public class SysAccountController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> UserManager;
        // GET: SysAccount
        public SysAccountController()
        {
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }
        public ActionResult UserAccounts()
        {
            var userlogins = context.Users.ToList();
            return View(userlogins);
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            var roles = context.Roles.ToList();
            return PartialView(roles);
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection collection)
        {
            String username = collection.Get("username");
            String password = collection.Get("password");
            String role = collection.Get("role");

            var user = new ApplicationUser();
            user.UserName = username;
            user.Email = username+"@gmail.com";

            string userPWD = password;

            var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin   
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, role);
            }

            return RedirectToAction("UserAccounts");
        }
        public ActionResult DeleteUser(String ID)
        {
            var user = context.Users.Where(p => p.Id == ID).FirstOrDefault();
            if (user.UserName != "bhfs_admin")
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("UserAccounts");
        }
    }
}