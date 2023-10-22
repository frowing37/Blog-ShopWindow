using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager) { }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

