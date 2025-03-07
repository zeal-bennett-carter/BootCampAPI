using BootCampAPI.Application.Data.Repositories;
using BootCampAPI.Application.Models.DTO;
using BootCampAPI.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Authors.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDTO>
    {

        private readonly IAuthorRepository _authorRepository;

        public async Task<AuthorDTO> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
           
            var author = Author.Create(command.Name, command.Age, command.Status);

            await _authorRepository.Save(author);

            return new AuthorDTO
            {
                Name = author.Name,
                Age = author.Age,
                Status = author.Status.ToString()
            };
        }
    }
}
