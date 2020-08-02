using System.Collections.Generic;
using SharedKernel;

namespace Core.Entities
{
    public class Actor: BaseEntity
    {
        private string _name;
        private List<FilmActor> _filmActors;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public List<FilmActor> FilmActors
        {
            get => _filmActors;
            set => _filmActors = value;
        }
    }
}