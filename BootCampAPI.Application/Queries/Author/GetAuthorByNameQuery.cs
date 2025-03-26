using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Queries.Author
{
    public record GetAuthorByNameQuery : QueryBase<AuthorDTO> // why use record?
    {
        public string Name { get; set; }

        public GetAuthorByNameQuery(string name)
        {
            Name = name;
        }
    }
}
