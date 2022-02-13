using AutoMapper;
using Core.Entities.OrderAggregate;
using API.Dtos;
using Microsoft.Extensions.Configuration;
namespace API.Helpers
{ 
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration config;
        public OrderItemUrlResolver(IConfiguration config)
        {
            this.config = config;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destmember,
        ResolutionContext context)
        { 
            if(!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
            {
                return this.config["ApiUrl"] + source.ItemOrdered.PictureUrl;
            }
            return null;
        }
    }
}