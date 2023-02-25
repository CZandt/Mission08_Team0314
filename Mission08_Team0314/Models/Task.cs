using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0314.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required (ErrorMessage = "Please enter a task name")]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required (ErrorMessage = "Please enter a number 1-4")]
        [Range(1, 4, ErrorMessage = "Please enter a number 1-4")]
        public byte Quadrant { get; set; }
        public bool Completed { get; set; }

        //Connect category table using FK
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
