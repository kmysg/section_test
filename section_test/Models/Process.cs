using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace section_test.Models
{
    public class Process
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }
        public int InspCount { get; set; } = 0;
    }
}
