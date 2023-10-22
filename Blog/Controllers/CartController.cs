using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class CartController : BaseController
    {
        private ICartService _cartService;

        public CartController(ICartService cartService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            _cartService = cartService;
        }
    }
}

