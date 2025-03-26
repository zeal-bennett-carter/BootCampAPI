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

            var updatedAuthor = await authorRepository.Get(command.AuthorId);

            return new AuthorDTO
            {
                AuthorId = updatedAuthor.AuthorId,
                Name = updatedAuthor.Name,
                Age = updatedAuthor.Age,
                Status = updatedAuthor.Status.ToString()
            };
        }
    }
}
