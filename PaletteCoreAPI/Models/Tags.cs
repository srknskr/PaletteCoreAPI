using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Tags
    {
        public Tags()
        {
            PostTags = new HashSet<PostTags>();
        }

        public int TagId { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<PostTags> PostTags { get; set; }
    }
}
