using System.Collections.Generic;
using SharedKernel;

namespace Core.Entities
{
    public class Genre: BaseEntity
    {
        private string _title;
        private List<Film> _films;

        public string Title
        {
            get => _title;
            set => _title = value;
        }
        
        public virtual  List<Film> Films
        {
            get => _films;
            set => _films = value;
        }
    }
}