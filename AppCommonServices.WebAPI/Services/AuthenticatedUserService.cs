using AppCommonServices.Application.Common.Interfaces;

namespace AppCommonServices.WebAPI.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public string UserId { get; set; }
    }
}