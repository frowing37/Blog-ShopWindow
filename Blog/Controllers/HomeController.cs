using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Blog_Entities.Concrete;
using MailKit.Net.Smtp;
using MimeKit;

namespace Blog.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager) : base(userManager, signInManager, roleManager)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        
        if (loginDto.Mail == null || loginDto.Password == null || loginDto.Mail == string.Empty || loginDto.Password == string.Empty)
        {
            ModelState.AddModelError("", "Kullanıcı adı ve şifre boş bırakılamaz");

            return View();
        }
        
        var controlUser = await _userManager.FindByEmailAsync(loginDto.Mail);

        if (controlUser == null)
        {
            ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı");

            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(controlUser, loginDto.Password, loginDto.RememberMe, true);

        if (result.Succeeded)
        {
            if(await _userManager.IsInRoleAsync(controlUser,"Admin"))
            {
                return RedirectToAction("Posts", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Post");
            }
        }

        else
        {
            ModelState.AddModelError("", "Kullanıcı adı ile şifreniz uymuyor");

            return View();
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if (ModelState.IsValid)
        {
            Random rnd = new Random();
            int code = rnd.Next(100000, 1000000);

            string tempUsername = null;

            if(registerDto.Name.Contains(" "))
            {
                tempUsername = registerDto.Name.Replace(" ", "");
            }
            else
            {
                tempUsername = registerDto.Name;
            }

            if(registerDto.SecondName == null)
            {
                registerDto.SecondName = " ";
            }

            AppUser appUser = new AppUser()
            {
                UserName = tempUsername,
                Name = registerDto.Name,
                SecondName = registerDto.SecondName,
                Surname = registerDto.Surname,
                Email = registerDto.Mail,
                Mail = registerDto.Mail,
                PhoneNumber = registerDto.PhoneNumber,
                Password = registerDto.Password,
                ConfirmCod = code.ToString()
            };

            var control = await _userManager.FindByEmailAsync(registerDto.Mail);

            if (control != null)
            {
                ModelState.AddModelError("", "Girdiğiniz mail zaten kullanılmaktadır");

                return RedirectToAction("Register", "Home", ModelState);
            }

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (result.Succeeded)
            {
                var adminControl = await _userManager.GetUsersInRoleAsync("Admin");

                if (adminControl == null)
                {
                    await _userManager.AddToRoleAsync(appUser, "Admin");
                }
                else
                {
                    await _userManager.AddToRoleAsync(appUser, "Customer");
                }

                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Blog Admin", "emrecan8mece@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kayıt işlemini tamamlamak için gerekli kod : " + code;

                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Blog Onay Kodu";

                TempData["Mail"] = registerDto.Mail;

                SmtpClient client = new SmtpClient();
                
                client.Connect("smtp.gmail.com", 587, false);
                
                client.Authenticate("emrecan8mece@gmail.com", "esul jwmo ricm coqt");
                client.Send(mimeMessage);
                
                client.Disconnect(true);

                return RedirectToAction("ConfirmMail", "Home", new { mail = appUser.Email });
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return RedirectToAction("Login", "Home", ModelState);
    }

    [HttpGet]
    public IActionResult ConfirmMail(string Mail)
    {
        ConfirmMailDto confirmMailDto = new ConfirmMailDto();
        confirmMailDto.Mail = Mail;

        return View(confirmMailDto);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmMail(ConfirmMailDto confirmMailDto)
    {
        var controlUser = await _userManager.FindByEmailAsync(confirmMailDto.Mail);

        if (controlUser.ConfirmCod == confirmMailDto.Code)
        {
            controlUser.EmailConfirmed = true;
            await _userManager.UpdateAsync(controlUser);
            await _signInManager.SignInAsync(controlUser, false);

            if (await _userManager.IsInRoleAsync(controlUser, "Admin"))
            {

                return Json(new { redirectUrl = Url.Action("Posts", "Admin") });
            }
            else
            {

                return Json(new { redirectUrl = Url.Action("Index", "Post") });
            }
        }

        else
        {
            return View(confirmMailDto.Mail);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Login", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
