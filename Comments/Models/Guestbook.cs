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
        [MaxLength(5, ErrorMessage = "中文姓名不可超過5個字")]
        [Required(ErrorMessage = "請輸入姓名")]
        public string Name { get; set; }
        [DisplayName("電子信箱")]
        [Required(ErrorMessage = "請輸入Email地址")]
        [MaxLength(250, ErrorMessage = "Email地址無法超過250個字元")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("內容")]
        [Required(ErrorMessage = "請輸入內容")]
        public string Content { get; set; }
    }
}