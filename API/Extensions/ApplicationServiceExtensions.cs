using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepositoy>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var errors = actioncontext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}