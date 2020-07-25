using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Command
    {
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }

    }
}
