using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class User:BaseEntity
    {
       
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
    }
}
