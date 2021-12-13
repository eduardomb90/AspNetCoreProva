using System.Collections.Generic;

namespace Application.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public virtual ICollection<Movie> Movies { get;  set; }

        public Genre()
        {
        }

        public Genre(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
