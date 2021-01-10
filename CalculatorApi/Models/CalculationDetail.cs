using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorAPI.Models
{
    public class CalculationDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int FirstInput { get; set; }

        [Required]
        public int SecontInput { get; set; }

        public int Result { get; set; }

    }
}
