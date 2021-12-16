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
            RuleFor(x => x.Rating)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(10)
                .WithMessage("Rating must be between 0 and 10..");
        }
    }
}
