using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Comments.Models
{
    public class Guestbook
    {
        public int Id { get; set; }
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("電子信箱")]
        public string Email { get; set; }
        [DisplayName("內容")]
        public string Content { get; set; }
    }
}