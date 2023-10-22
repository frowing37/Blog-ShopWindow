using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Blog.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class CategoryController : BaseController
    {
        private ICategoryPostService _categoryPostService;
        private ICategoryProductService _categoryProductService;

        public CategoryController(ICategoryProductService categoryProductService ,ICategoryPostService categoryPostService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            _categoryPostService = categoryPostService;
            _categoryProductService = categoryProductService;
        }

        [HttpGet]
        public IActionResult ProductCategories()
        {
            var productcategories = _categoryProductService.SGetList();

            return View(productcategories);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CProductDelete(int ID)
        {
            var category = _categoryProductService.SGetByID(ID);

            _categoryProductService.SDelete(category);

            return RedirectToAction("ProductCategories", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult NewProductCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewProductCategory(ProductCategoryDto productCategoryDto)
        {
            var newCategory = new CategoryProduct()
            {
                CategoryName = productCategoryDto.CategoryName
            };

            _categoryProductService.SInsert(newCategory);

            return RedirectToAction("ProductCategories", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CProductUpdate(int ID)
        {
            var category = _categoryProductService.SGetByID(ID);

            ProductCategoryDto dto = new ProductCategoryDto();

            dto.CategoryID = category.CategoryId;
            dto.CategoryName = category.CategoryName;

            return View(dto);
        }

        [HttpPost]
        public IActionResult CProductUpdate(ProductCategoryDto productCategoryDto)
        {
            var category = _categoryProductService.SGetByID(productCategoryDto.CategoryID);

            category.CategoryName = productCategoryDto.CategoryName;

            _categoryProductService.SUpdate(category);

            return RedirectToAction("ProductCategories", "Admin");
        }

        [HttpGet]
        public IActionResult PostCategories()
        {
            var postcategories = _categoryPostService.SGetList();

            return View(postcategories);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CPostDelete(int ID)
        {
            var category = _categoryPostService.SGetByID(ID);

            _categoryPostService.SDelete(category);

            return RedirectToAction("PostCategories", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult NewPostCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPostCategory(PostCategoryDto postCategoryDto)
        {
            var newCategory = new CategoryPost()
            {
                CategoryName = postCategoryDto.CategoryName
            };

            _categoryPostService.SInsert(newCategory);

            return RedirectToAction("PostCategories", "Admin");

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CPostUpdate(int ID)
        {
            var category = _categoryPostService.SGetByID(ID);

            PostCategoryDto dto = new PostCategoryDto();

            dto.CategoryID = category.CategoryId;
            dto.CategoryName = category.CategoryName;

            return View(dto);
        }

        [HttpPost]
        public IActionResult CPostUpdate(PostCategoryDto postCategoryDto)
        {
            var category = _categoryPostService.SGetByID(postCategoryDto.CategoryID);

            category.CategoryName = postCategoryDto.CategoryName;

            _categoryPostService.SUpdate(category);

            return RedirectToAction("PostCategories", "Admin");
        }
    }
}

