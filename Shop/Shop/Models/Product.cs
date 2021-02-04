using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage ="Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage ="Este campo deve conter entre e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage ="Este campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage ="O preço do produto deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [Range(1L, long.MaxValue, ErrorMessage ="Categoria inválida")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
