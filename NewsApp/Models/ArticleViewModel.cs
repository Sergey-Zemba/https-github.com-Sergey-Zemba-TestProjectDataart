using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsApp.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A short description is required")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "A content is required")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        //[Required(ErrorMessage = "A picture path is required")]
        //[Display(Name = "Picture Path")]
        public HttpPostedFileBase Image { get; set; }

        public string ImageName { get; set; }

        public string CreationDate { get; set; }
    }
}