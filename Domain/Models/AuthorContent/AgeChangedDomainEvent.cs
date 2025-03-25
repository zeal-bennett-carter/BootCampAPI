using BootCampAPI.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain.Models.AuthorContent
{
    public class AgeChangedDomainEvent(Author author): DomainEvent<Author> (author)
    {
    }
}
