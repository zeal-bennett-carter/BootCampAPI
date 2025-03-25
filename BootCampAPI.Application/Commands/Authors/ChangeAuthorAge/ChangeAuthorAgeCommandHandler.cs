using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Application.Models.DTO;
using BootCampAPI.Domain.Models.AuthorContent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Authors.ChangeAuthorAge
{
    public class ChangeAuthorAgeCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<ChangeAuthorAgeCommand, AuthorDTO>
    {

        public async Task<AuthorDTO> Handle(ChangeAuthorAgeCommand command, CancellationToken cancellationToken)
        {

            var author = await authorRepository.Get(command.AuthorId);

            author.ChangeAge(command.Age);

            await authorRepository.Save(author);

            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Age = author.Age,
                Status = author.Status.ToString()
            };
        }
    }
}
