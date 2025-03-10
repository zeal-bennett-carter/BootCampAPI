using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Authors.CreateAuthor
{
    public record CreateAuthorCommand(
        int AuthorId,
        string Name,
        int Age,
        string Status
        ): CommandBase<AuthorDTO>
    {
    }
}
