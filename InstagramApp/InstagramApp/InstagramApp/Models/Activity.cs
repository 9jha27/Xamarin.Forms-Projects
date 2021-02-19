using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramApp.Models
{
    public class Activity
    {
        public int UserId  { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get { return $"https://picsum.photos/id/{UserId}/100"; } }
    }
}
