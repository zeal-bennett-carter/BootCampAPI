using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Queries
{
    public record class QueryBase
    {
    }

    public record QueryBase<TResponse>
        : QueryBase, IRequest<TResponse>
    {
    }
}
