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
    public class GetAuthorByNameQueryHandler : IRequestHandler<GetAuthorByNameQuery, AuthorDTO>
    {
        private readonly IListAuthorsDataQuery _listAuthorsDataQuery;

        public GetAuthorByNameQueryHandler(IListAuthorsDataQuery listAuthorsDataQuery)
        {
            _listAuthorsDataQuery = listAuthorsDataQuery;
        }

        public async Task<AuthorDTO> Handle(GetAuthorByNameQuery request, CancellationToken cancellationToken)
        {
            var author = _listAuthorsDataQuery.Execute()
                .Where(a => a.Name == request.Name)
                .Select(a => new AuthorDTO
                {
                    Name = a.Name,
                    Age = a.Age,
                    Status = a.Status
                })
                .FirstOrDefault();

            return await Task.FromResult(author);
        }
    }

}
