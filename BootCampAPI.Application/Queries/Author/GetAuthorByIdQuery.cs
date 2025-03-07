using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Queries.Author
{
    public class GetAuthorByIdQuery : IRequest<AuthorDTO>
    {
        public int AuthorId { get; set; }

        public GetAuthorByIdQuery(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
