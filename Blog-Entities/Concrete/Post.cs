using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Entities.Concrete
{
	public class Post
	{
        [Key]
        public int PostID { get; set; }

        public string PostName { get; set; }

        public string PostContent { get; set; }

        public int PostNumberofLike { get; set; }

        public int PostNumberofDisslike { get; set; }

        //public List<Comment> comments { get; set; }

        [ForeignKey("AppUser")]
        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }

        [ForeignKey("CategoryPost")]
        public int CategoryID { get; set; }

        public CategoryPost CategoryPost { get; set; }
    }
}

