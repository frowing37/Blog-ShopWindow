using System;
namespace Blog.Models.Dtos
{
	public class PostDto
	{
        public int PostID { get; set; }

        public string PostName { get; set; }

        public string PostContent { get; set; }

        public int PostNumberofLike { get; set; }

        public int PostNumberofDisslike { get; set; }

        public int CommentID { get; set; }

        public string CommentContent { get; set; }

        public string CommentName { get; set; }

        public int CategoryID { get; set; }
    }
}

