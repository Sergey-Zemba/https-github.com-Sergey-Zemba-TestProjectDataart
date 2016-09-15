using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string PicturePath { get; set; }
        public string CreationDate { get; set; }
    }
}