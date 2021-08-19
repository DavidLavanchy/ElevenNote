using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryCreate
    {
        public int CategoryId { get; set; }
        [MaxLength(15, ErrorMessage = "Please keep your category name below 15 characters.")] 
        [Required]
        public string CategoryName { get; set; }

    }
}
