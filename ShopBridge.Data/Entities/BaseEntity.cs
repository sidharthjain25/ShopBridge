using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataLayer.Interface;

namespace DataLayer.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key,Required]
        public long ID { get; set; }
    }
}
