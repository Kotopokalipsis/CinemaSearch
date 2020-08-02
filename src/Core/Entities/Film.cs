using System;
using System.Collections.Generic;
using SharedKernel;

namespace Core.Entities
{
    public class Film: BaseEntity
    {
        private string _title;
        private string _description;
        private DateTime _dateOfCreation;
        private int _genreId;
        
        private Genre _genre;
        private List<FilmActor> _filmActors;

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
        
        public DateTime DateOfCreation
        {
            get => _dateOfCreation;
            set => _dateOfCreation = value;
        }
        
        public int GenereId
        {
            get => _genreId;
            set => _genreId = value;
        }
        
        public Genre Genere
        {
            get => _genre;
            set => _genre = value;
        }
        
        public List<FilmActor> FilmActors
        {
            get => _filmActors;
            set => _filmActors = value;
        }
    }
}