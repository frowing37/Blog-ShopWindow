using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Blog.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class CommentController : BaseController
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            _commentService = commentService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int ID)
        {
            var comment = _commentService.SGetByID(ID);

            _commentService.SDelete(comment);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PostDto postDto)
        {
            var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var comment = new Comment()
            {
                CommentName = postDto.CommentName,

                CommentContent = postDto.CommentContent,

                CommentNumberofLike = 0,

                AppUserID = Convert.ToInt32(userId),

                PostID = Convert.ToInt32(TempData["PostID"]),

                ProductID = 0
            };

            _commentService.SInsert(comment);

            return RedirectToAction("PostDetails", "Post" ,new { ID = comment.PostID });
        }

        [HttpPost]
        public async Task<IActionResult> InsertPro(ProductDto productDto)
        {
            var userId = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var comment = new Comment()
            {
                CommentName = productDto.CommentName,

                CommentContent = productDto.CommentContent,

                CommentNumberofLike = 0,

                AppUserID = Convert.ToInt32(userId),

                PostID = 0,

                ProductID = Convert.ToInt32(TempData["ProductID"])
            };

            _commentService.SInsert(comment);

            return RedirectToAction("ProductDetails", "Product", new { ID = comment.ProductID });
        }

        public IActionResult LikeIt(int ID)
        {
            var comment = _commentService.SGetByID(ID);

            comment.CommentNumberofLike += 1;

            _commentService.SUpdate(comment);

            return RedirectToAction("PostDetails", "Post" , new { ID = comment.PostID });
        }

        public IActionResult LikeItPro(int ID)
        {
            var comment = _commentService.SGetByID(ID);

            comment.CommentNumberofLike += 1;

            _commentService.SUpdate(comment);

            return RedirectToAction("ProductDetails", "Product", new { ID = comment.ProductID });
        }
    }
}
