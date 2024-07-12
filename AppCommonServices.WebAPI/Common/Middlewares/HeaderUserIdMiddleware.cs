using System.IdentityModel.Tokens.Jwt;
using AppCommonServices.Application.Common.Interfaces;

namespace AppCommonServices.WebAPI.Common.Middlewares
{
    public class HeaderUserIdMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderUserIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthenticatedUserService UserId)
        {
            // Add Custom Header
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null) {

                var handler = new JwtSecurityTokenHandler();

                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var userIdClaim = jsonToken?.Claims.FirstOrDefault(claim => claim.Type == "femsa_id");

                var userId = userIdClaim?.Value;

                UserId.UserId = userId!;

                await _next(context);

            }
            else
            {
                UserId.UserId = "0";

                await _next(context);
            }
        }
    }
}