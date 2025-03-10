using BootCampAPI.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.Behaviors
{
    internal class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork unitOfWork,
    UnitOfWorkBehaviorState state)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        /// <inheritdoc/>
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is CommandBase)
                return await ProcessCommandHandler(next);

            return await next();
        }

        private async Task<TResponse> ProcessCommandHandler(RequestHandlerDelegate<TResponse> next)
        {
            // Incrementing counter helps determine when root command has completed.
            state.CallLevel += 1;

            TResponse response = await next();

            // Once we got back to the top level of the call stack, we commit the unit of work.
            if (state.CallLevel == 1)
                await unitOfWork.Commit();

            state.CallLevel -= 1;

            return response;
        }
    }
}
