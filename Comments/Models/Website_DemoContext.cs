using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Comments.Models
{
    public class Website_DemoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Website_DemoContext() : base("name=Website_DemoContext")
        {
        }

        public System.Data.Entity.DbSet<Comments.Models.Guestbook> Guestbooks { get; set; }
        public System.Data.Entity.DbSet<Comments.Models.Member> Member { get; set; }
    }
}
