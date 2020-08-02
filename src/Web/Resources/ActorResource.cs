using System.Collections.Generic;
using Core.Entities;

namespace Web.Resources
{
    public class ActorResource
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}