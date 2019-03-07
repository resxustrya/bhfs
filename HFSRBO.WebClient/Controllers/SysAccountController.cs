using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HFSRBO.WebClient.Models;

namespace HFSRBO.WebClient.Controllers
{
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
    }
}