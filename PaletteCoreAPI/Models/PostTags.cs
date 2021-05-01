using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class PostTags
    {
        public int PostTagId { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
