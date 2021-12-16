using Application.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.UI.Models;

namespace WebMvc.UI.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MovieViewModel, Movie>().ReverseMap();
            CreateMap<GenreViewModel, Genre>().ReverseMap();
            CreateMap<PagedViewModel<MovieViewModel>, PagedViewModel<Movie>>().ReverseMap();
        }
    }
}
