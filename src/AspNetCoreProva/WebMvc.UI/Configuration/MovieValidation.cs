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
                .WithMessage("Rating must be between 0 and 10");

            RuleFor(x => x.Rating)
                .Matches(@"^\d+(\,\d{1,2})?$")
                .WithMessage("Must be a number.");

            RuleFor(x => x.Gross)
                .Matches(@"^\d+(\,\d{1,2})?$")
                .WithMessage("Must be a number.")
                .NotNull()
                .NotEmpty()
                .WithMessage("This field is required");
        }

        private bool VerificarZeroADez(string valor) 
        {
            var dotValue = valor.Replace('.', ',');
            var doubleValue = Double.Parse(dotValue);

            if(doubleValue >= 0 && doubleValue <= 10)
                return true;

            return false;
        }
    }
}
