using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Apikeys
    {
        public int ApikeyId { get; set; }
        public int UserId { get; set; }
        public string Apirole { get; set; }
        public Guid UserKey { get; set; }
        public DateTime KeyCreateDate { get; set; }

        public virtual Users User { get; set; }
    }
}
