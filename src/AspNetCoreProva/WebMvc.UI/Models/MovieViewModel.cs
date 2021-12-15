using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.UI.Models
{
    public class MovieViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Título é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name ="Title")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória!")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "O nome do diretor é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name ="Director")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Este campo deve conter entre {1} e {0} caracteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "O nome do diretor só pode conter letras.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        
        [Display(Name ="Gross")]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal 18,2")]
        public decimal Gross { get; set; }

        //[RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0.0, 10.0, ErrorMessage ="O campo {0} deve ser entre {1} e {2}")]
        public double Rating { get; set; }
              
        [Display(Name ="Genre")]
        public Guid GenreId { get; set; }
        public virtual GenreViewModel Genre { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; } // --> somente para tela

        [Display(Name ="Poster")]
        public string ImagePath { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
