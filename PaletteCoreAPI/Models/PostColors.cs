using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class PostColors
    {
        public int PostColorId { get; set; }
        public int PostId { get; set; }
        public int ColorHex1 { get; set; }
        public int ColorHex2 { get; set; }
        public int ColorHex3 { get; set; }

        public virtual Posts Post { get; set; }
    }
}
