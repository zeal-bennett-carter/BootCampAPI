using BootCampAPI.Application.Data.Queries.ListAuthors;
using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Queries.Author
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDTO>
    {
        private readonly IListAuthorsDataQuery _listAuthorsDataQuery;

        public GetAuthorByIdQueryHandler(IListAuthorsDataQuery listAuthorsDataQuery)
        {
            _listAuthorsDataQuery = listAuthorsDataQuery;
        }

        public async Task<AuthorDTO> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = _listAuthorsDataQuery.Execute()
                .Where(a => a.AuthorId == request.AuthorId)
                .Select(a => new AuthorDTO
                {
                    AuthorId = a.AuthorId,
                    Name = a.Name,
                    Age = a.Age,
                    Status = a.Status
                })
                .FirstOrDefault();

            return await Task.FromResult(author);
        }
    }

}
