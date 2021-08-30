﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.CommandManager
{
    public class CommandManager : ICommandManager
    {
        private readonly IMediator _mediator;

        public CommandManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default) 
            => await _mediator.Send<TResponse>(request, cancellationToken);

        public async Task<object> Send(object request, CancellationToken cancellationToken = default) 
            => await _mediator.Send(request, cancellationToken);
    }
}
