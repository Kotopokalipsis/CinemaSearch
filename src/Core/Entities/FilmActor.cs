using SharedKernel;

namespace Core.Entities
{
    public class FilmActor: BaseEntity
    {
        private Actor _actor;
        private Film _film;
        
        private int _actorId;
        private int _filmId;

        public int ActorId
        {
            get => _actorId;
            set => _actorId = value;
        }

        public int FilmId
        {
            get => _filmId;
            set => _filmId = value;
        }
        
        public Actor Actor
        {
            get => _actor;
            set => _actor = value;
        }
        
        public Film Film
        {
            get => _film;
            set => _film = value;
        }
    }
}