using System;
using System.ComponentModel.DataAnnotations;

namespace Books.Application.DTO
{
    public class BookDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "O valor precisa ser positivo")]
        public decimal Price { get; set; }

        [Required]
        public SpecificationDTO Specifications { get; set; }
    }
}
