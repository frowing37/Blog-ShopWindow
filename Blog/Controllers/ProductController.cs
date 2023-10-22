using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Blog.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [Authorize(Roles ="Admin,Customer")]
    public class ProductController : BaseController
    {
        private IProductService _productService;
        private ICommentService _commentService;
        private ICategoryProductService _categoryProductService;

        public ProductController(IProductService productService,
            ICategoryProductService categoryProductService,
            ICommentService commentService,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            _productService = productService;
            _categoryProductService = categoryProductService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var products = _productService.INCSGetList("CategoryProduct");

            return View(products);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int ID)
        {
            var product = _productService.SGetByID(ID);

            _productService.SDelete(product);

            return RedirectToAction("Products", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult NewProduct()
        {
            List<SelectListItem> productcategories = (from x in _categoryProductService.SGetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryId.ToString()
                                                      }).ToList();

            ViewBag.ProductCategories = productcategories;

            return View();
        }

        [HttpPost]
        public IActionResult NewProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
                NumberofLike = 0,
                CategoryID = productDto.CategoryID,
                ProductDetails = productDto.ProductDetails,
                ImageURL = "a.jpg"
            };

            _productService.SInsert(product);

            return RedirectToAction("Products", "Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateProduct(int ID)
        {
            List<SelectListItem> productcategories = (from x in _categoryProductService.SGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.ProductCategories = productcategories;

            var product = _productService.SGetByID(ID);

            var productDto = new ProductDto()
            {
                ProductName = product.ProductName,
                ProductDetails = product.ProductDetails,
                ProductPrice = product.ProductPrice,
                ID = product.ProductID,
                CategoryID = product.CategoryID,
                ImageUrl = product.ImageURL,
                NumberOfLike = product.NumberofLike
            };

            return View(productDto);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            var product = _productService.SGetByID(productDto.ID);

            product.ProductDetails = productDto.ProductDetails;
            product.ProductName = productDto.ProductName;
            product.ImageURL = "a.jpg";
            product.ProductPrice = productDto.ProductPrice;
            product.CategoryID = productDto.CategoryID;
            product.NumberofLike = productDto.NumberOfLike;

            _productService.SUpdate(product);

            return RedirectToAction("Products", "Admin");
        }

        public IActionResult LikeIt(int ID)
        {
            var product = _productService.SGetByID(ID);

            product.NumberofLike += 1;

            _productService.SUpdate(product);

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult ProductDetails(int ID)
        {
            List<Comment> comments = new List<Comment>();

            foreach (var comment in _commentService.SGetList())
            {
                if (comment.ProductID == ID)
                {
                    comments.Add(comment);
                }
            }

            ViewBag.CommentsOfPost = comments;

            var product = _productService.SGetByID(ID);

            var products = _productService.INCSGetList("CategoryProduct");

            string categoryName = null;

            foreach(var p in products)
            {
                if(p.ProductID == ID)
                {
                    categoryName = p.CategoryProduct.CategoryName;
                }
            }

            TempData["ProductID"] = ID;

            ProductDto dto = new ProductDto()
            {
                ProductName = product.ProductName,
                ProductDetails = product.ProductDetails,
                ProductPrice = product.ProductPrice,
                ImageUrl = product.ImageURL,
                NumberOfLike = product.NumberofLike,
                CategoryName = categoryName
            };

            return View(dto);
        }
    }
}

