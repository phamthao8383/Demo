using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopClient_MVC.Models
{
    public class ItemUpload
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string File { get; set; }

        public Item ItemFlow { get; set; } = new Item();
    }
}