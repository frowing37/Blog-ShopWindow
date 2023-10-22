using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Entities.Concrete
{
	public class Comment
	{
        [Key]
        public int CommentID { get; set; }

        public string CommentName { get; set; }

        public string CommentContent { get; set; }

        public int CommentNumberofLike { get; set; }

        [ForeignKey("AppUser")]
        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }

        public int PostID { get; set; }

        public int ProductID { get; set; }
    }
}

