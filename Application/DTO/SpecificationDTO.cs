using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Application.DTO
{
    public class SpecificationDTO
    {
        [Required]
        [StringLength(255)]
        public string OriginallyPublished { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O número de páginas é requerido")]
        public int PageCount { get; set; }

        public object Illustrator { get; set; }

        public object Genres { get; set; }
    }
}
