using AutoMapper;
using Core.Entities;
using Web.Resources;

namespace Web.Automapper.Profiles
{
    public class ActorProfile: Profile
    {
        public ActorProfile()
        {
            CreateMap<FilmActor, ActorResource>()
                .ForMember(dest =>
                        dest.Name,
                    opt => opt.MapFrom(src => src.Actor.Name));
        }
    }
}