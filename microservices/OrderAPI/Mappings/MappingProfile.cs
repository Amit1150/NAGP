using AutoMapper;
using OrderAPI.Features.Commands.CheckoutOrder;
using OrderAPI.Features.Commands.UpdateOrder;
using OrderAPI.Features.Queries.GetOrdersList;
using OrderAPI.Entities;
using EventBus.Messages.Event;

namespace OrderAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
