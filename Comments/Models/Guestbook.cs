using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Comments.Models
{
    public class Guestbook
    {
        public int Id { get; set; }
        [DisplayName("姓名")]
        [Required]
        public string Name { get; set; }
        [DisplayName("電子信箱")]
        [Required]
        public string Email { get; set; }
        [DisplayName("內容")]
        [Required]
        public string Content { get; set; }
    }
}