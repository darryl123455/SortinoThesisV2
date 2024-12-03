using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SortinoThesisV2.Shared.Models
{
    public class PointsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
