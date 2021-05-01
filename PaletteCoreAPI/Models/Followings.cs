using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Followings
    {
        public int FollowingsId { get; set; }
        public int UserId { get; set; }
        public int FollowingId { get; set; }
        public DateTime FollowedDate { get; set; }

        public virtual Users Following { get; set; }
        public virtual Users User { get; set; }
    }
}
