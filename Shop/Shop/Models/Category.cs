using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace Shop.Models
{
    [Table("Category")]
    public class Category
    {
        public Category() { }

        public Category(string title)
        {
            Title = title;
        }

        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [DataType("nvarchar")]
        public string Title { get; set; }
    }
}
