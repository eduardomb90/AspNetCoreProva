using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
