using AuthServer.Application.CustomResponses;
using AuthServer.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AuthServer.Application.Middlewares
{
    public static class UseCustomExceptionHandler
    {

        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        ErrorResponse errorResponse = null;

                        if (ex is CustomException)
                        {
                            errorResponse = new ErrorResponse(ex.Message, true);
                        }
                        else
                        {
                            errorResponse = new ErrorResponse(ex.Message, false);
                        }

                        var response = CustomResponse<NoContentResponse>.Fail(errorResponse, 500);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }

}

