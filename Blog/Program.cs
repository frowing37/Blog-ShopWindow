using Blog_Data.Concrete;
using Blog_Entities.Concrete;
using Blog_Business.Abstract;
using Blog_Business.Concrete;
using Blog_Data.Abstract;
using Blog_Data.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<IPostDal, EFPostDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EFCommentDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<ICategoryPostService, CategoryPostManager>();
builder.Services.AddScoped<ICategoryPostDal, EFCategoryPostDal>();
builder.Services.AddScoped<ICategoryProductService, CategoryProductManager>();
builder.Services.AddScoped<ICategoryProductDal, EFCategoryProductDal>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartDal, EFCartDal>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Home/Login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

//Identity Rollerinin eklenmesi
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var context = services.GetRequiredService<Context>();

    //Tanımlanan rollerin veri tabanına eklenmesi
    if (!context.Roles.Any())
    {
        var adminRole = new AppRole { Name = "Admin" };
        var customerRole = new AppRole { Name = "Customer" };

        roleManager.CreateAsync(adminRole).Wait();
        roleManager.CreateAsync(customerRole).Wait();
    }
}

app.Run();
