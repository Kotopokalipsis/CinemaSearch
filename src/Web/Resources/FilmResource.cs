using System.Collections.Generic;
using Core.Entities;

namespace Web.Resources
{
    public class FilmResource
    {
        private string _title;
        private string _description;
        private List<ActorResource> _actorResources;
        private string _genre;
        private string _dateOfCreation;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public List<ActorResource> ActorResources
        {
            get => _actorResources;
            set => _actorResources = value;
        }

        public string Genre
        {
            get => _genre;
            set => _genre = value;
        }

        public string DateOfCreation
        {
            get => _dateOfCreation;
            set => _dateOfCreation = value;
        }
    }
}