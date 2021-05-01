using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class UserProfile
    {
        public int UserProfileId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public byte[] ProfilePhoto { get; set; }

        public virtual Users User { get; set; }
    }
}
