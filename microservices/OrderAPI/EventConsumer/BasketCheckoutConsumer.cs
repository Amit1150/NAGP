﻿using AutoMapper;

using EventBus.Messages.Event;

using MassTransit;

using MediatR;

using OrderAPI.Features.Commands.CheckoutOrder;

using System;
using System.Threading.Tasks;

namespace OrderAPI.EventConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BasketCheckoutConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);
        }
    }
}
