using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Blog_Entities.Concrete;

namespace Blog_Data.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DBSiparisBlog;User Id=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;Encrypt=false;");
        }
        public DbSet<Cart> carts { get; set; }

        public DbSet<CategoryPost> categoryPosts { get; set; }

        public DbSet<CategoryProduct> categoryProducts { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Product> products { get; set; }

    }
}

