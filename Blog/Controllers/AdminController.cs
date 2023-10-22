using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Blog.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        ICategoryPostService _categoryPostService;
        ICategoryProductService _categoryProductService;
        ICommentService _commentService;
        IPostService _postService;
        IProductService _productService;

        public AdminController(IProductService productService,
            IPostService postService,
            ICommentService commentService,
            ICategoryProductService categoryProductService,
            ICategoryPostService categoryPostService,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            _categoryPostService = categoryPostService;
            _categoryProductService = categoryProductService;
            _commentService = commentService;
            _postService = postService;
            _productService = productService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            var productList = _productService.INCSGetList("CategoryProduct");

            return View(productList);
        }

        [HttpGet]
        public IActionResult Posts()
        {
            var postList = _postService.INCSGetList("CategoryPost");

            return View(postList);
        }

        [HttpGet]
        public IActionResult PostCategories()
        {
            var postCategoriesList = _categoryPostService.SGetList();

            return View(postCategoriesList);
        }

        [HttpGet]
        public IActionResult ProductCategories()
        {
            var productList = _categoryProductService.SGetList();

            return View(productList);
        }
    }
}

