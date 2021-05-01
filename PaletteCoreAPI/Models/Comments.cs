using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int CommenterId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedDate { get; set; }

        public virtual Users Commenter { get; set; }
        public virtual Posts Post { get; set; }
    }
}
