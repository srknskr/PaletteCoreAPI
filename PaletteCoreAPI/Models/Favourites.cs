using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Favourites
    {
        public int FavouriteId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime FavouriteDate { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
