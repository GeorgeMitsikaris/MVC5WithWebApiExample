using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5WithWebApiExample.Models
{
    public class ItemType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5)]
        [RegularExpression(@"\d+")]
        [Required]
        public int Code { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
    }
}