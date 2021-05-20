using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace ProjectWeekendPuzzles.ApiServer
{
    public static class GrpcServiceExtensions
    {
        /// <summary>
        /// Non-generic grpc service mapper.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="serviceTypes"></param>
        public static void MapGrpcServices(this IEndpointRouteBuilder builder, IEnumerable<Type> serviceTypes)
        {
            foreach (var type in serviceTypes)
            {
                var method = 
                    typeof(GrpcEndpointRouteBuilderExtensions)
                    .GetMethod(nameof(GrpcEndpointRouteBuilderExtensions.MapGrpcService))!
                    .MakeGenericMethod(type);

                method.Invoke(null, new[] { builder });
            }
        }
    }
}
