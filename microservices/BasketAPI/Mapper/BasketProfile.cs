using AutoMapper;
using BasketAPI.Entities;
using EventBus.Messages.Event;

namespace BasketAPI.Mapper
{
    public class BasketProfile : Profile
	{
		public BasketProfile()
		{
			CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
