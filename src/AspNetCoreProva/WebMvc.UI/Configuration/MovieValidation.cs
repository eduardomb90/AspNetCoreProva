using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.UI.Models;

namespace WebMvc.UI.Configuration
{
    public class MovieValidation : AbstractValidator<MovieViewModel>
    {
        public MovieValidation()
        {
            RuleFor(x => VerificarZeroADez(x.Rating))
                .Equal(true)
                .WithMessage("Rating must be between 0 and 10..");
        }

        private bool VerificarZeroADez(string valor) 
        {
            return true;
        }
    }
}
