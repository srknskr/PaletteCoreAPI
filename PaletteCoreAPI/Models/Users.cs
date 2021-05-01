using System;
using System.Collections.Generic;

namespace PaletteCoreAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Apikeys = new HashSet<Apikeys>();
            Comments = new HashSet<Comments>();
            Favourites = new HashSet<Favourites>();
            FollowingsFollowing = new HashSet<Followings>();
            FollowingsUser = new HashSet<Followings>();
            Posts = new HashSet<Posts>();
            UserProfile = new HashSet<UserProfile>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Apikeys> Apikeys { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }
        public virtual ICollection<Followings> FollowingsFollowing { get; set; }
        public virtual ICollection<Followings> FollowingsUser { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
