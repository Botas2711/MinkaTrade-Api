using _2._Domain.Token;
using _3._Data.Users;

namespace _1._API.Middleware
{
    public class JwtMiddleware
    {
        // Autenticacion de usuario por token
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Authenticate the user by the token
        /// </summary>
        /// <param name="context"></param>
        /// <param name="tokenService"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ITokenService tokenService, IUserData userData)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var username = await tokenService.ValidateToken(token);
            if (username != null)
            {
                context.Items["User"] = await userData.GetByUsernameAsync(username);
            }

            await _next(context);
        }
    }
}
