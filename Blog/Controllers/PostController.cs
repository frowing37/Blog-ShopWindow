using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Blog.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog_Data.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Blog.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class PostController : BaseController
    {
        private IPostService _postService;
        private ICategoryPostService _categoryPostService;
        private ICommentService _commentService;

        public PostController(IPostService postService, ICategoryPostService categoryPostService, ICommentService commentService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
        {
            _postService = postService;
            _categoryPostService = categoryPostService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var posts = _postService.INCSGetList("CategoryPost");

            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult NewPost()
        {
            List<SelectListItem> postcategories = (from x in _categoryPostService.SGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.PostCategories = postcategories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(PostDto postDto)
        {
            var admin = await _userManager.GetUsersInRoleAsync("Admin");

            var post = new Post()
            {
                PostContent = postDto.PostContent,
                PostName = postDto.PostName,
                PostNumberofLike = 0,
                PostNumberofDisslike = 0,
                CategoryID = postDto.CategoryID,
                AppUserID = admin[0].Id
            };

            _postService.SInsert(post);

            return RedirectToAction("Posts", "Admin");
        }

        [HttpGet]
        public IActionResult PostDetails(int ID)
        {
            List<Comment> comments = new List<Comment>();

            foreach(var comment in _commentService.SGetList())
            {
                if(comment.PostID == ID)
                {
                    comments.Add(comment);
                }
            }

            ViewBag.CommentsOfPost = comments;

            var post = _postService.SGetByID(ID);

            PostDto dto = new PostDto();

            TempData["PostID"] = post.PostID;
            dto.PostID = post.PostID;
            dto.PostContent = post.PostContent;
            dto.PostName = post.PostName;

            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int ID)
        {
            var post = _postService.SGetByID(ID);

            _postService.SDelete(post);

            return RedirectToAction("Posts","Admin");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdatePost(int ID)
        {
            List<SelectListItem> postcategories = (from x in _categoryPostService.SGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();

            ViewBag.PostCategories = postcategories;

            var post = _postService.SGetByID(ID);

            var postDto = new PostDto()
            {
                PostID = post.PostID,
                PostName = post.PostName,
                PostContent = post.PostContent,
                PostNumberofLike = post.PostNumberofLike,
                PostNumberofDisslike = 0,
                CategoryID = post.CategoryID
            };

            return View(postDto);
        }

        [HttpPost]
        public IActionResult UpdatePost(PostDto postDto)
        {
            var post = _postService.SGetByID(postDto.PostID);

            post.PostID = postDto.PostID;
            post.PostName = postDto.PostName;
            post.PostContent = postDto.PostContent;
            post.PostNumberofLike = postDto.PostNumberofLike;
            post.PostNumberofDisslike = 0;
            post.CategoryID = postDto.CategoryID;

            _postService.SUpdate(post);

            return RedirectToAction("Posts", "Admin");
        }

        public IActionResult LikeIt(int ID)
        {
            var post = _postService.SGetByID(ID);

            post.PostNumberofLike += 1;

            _postService.SUpdate(post);

            return RedirectToAction("Index","Post");
        }
    }
}

