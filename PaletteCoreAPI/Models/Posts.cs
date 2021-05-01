using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
            Favourites = new HashSet<Favourites>();
            PostColors = new HashSet<PostColors>();
            PostTags = new HashSet<PostTags>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime PublishedDate { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }
        public virtual ICollection<PostColors> PostColors { get; set; }
        public virtual ICollection<PostTags> PostTags { get; set; }
    }
}
