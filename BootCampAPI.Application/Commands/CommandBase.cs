using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Commands
{
    public record class CommandBase
    {
    }

    public record CommandBase<TResponse>
        : CommandBase, IRequest<TResponse>
    {
    }
}
