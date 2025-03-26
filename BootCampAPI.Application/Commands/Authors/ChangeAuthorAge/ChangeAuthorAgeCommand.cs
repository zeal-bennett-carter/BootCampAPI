using BootCampAPI.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands.Authors.ChangeAuthorAge
{
    public record ChangeAuthorAgeCommand(
        int AuthorId,
        int Age
        ): CommandBase<AuthorDTO>
    {
    }
}
