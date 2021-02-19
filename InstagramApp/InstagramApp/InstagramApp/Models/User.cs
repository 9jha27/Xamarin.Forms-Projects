using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramApp.Models
{
    public class User
    {
        //properties of an instagram user profile
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get { return $"https://picsum.photos/id/{Id}/100"; } }
    }
}
