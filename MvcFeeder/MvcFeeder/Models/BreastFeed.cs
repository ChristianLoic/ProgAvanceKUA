using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFeeder.Models
{
    public class BreastFeed
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [StringLength(5, MinimumLength = 1)]
        [Required]
        
        public string Side { get; set; }

        [Range(0, 24)]
        [Required]
        [Column(TypeName = "Int(0,24)")]
        public decimal hour { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        public string Note { get; set; }
    }
}
//hour type modifier 