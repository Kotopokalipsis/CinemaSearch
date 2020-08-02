using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Web.Resources;

namespace Web.Automapper.Profiles
{
    public class FilmProfile: Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmResource>()
                .ForMember(dest => 
                    dest.Title, 
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => 
                    dest.Description, 
                opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => 
                        dest.ActorResources, 
                    opt => opt.MapFrom(src => src.FilmActors))
                .ForMember(dest => 
                        dest.Genre, 
                    opt => opt.MapFrom(src => src.Genere.Title));
        }
    }
}