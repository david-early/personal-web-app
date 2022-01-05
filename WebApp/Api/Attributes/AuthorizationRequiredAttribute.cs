using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Api.Utilities;

namespace WebApp.Api.Attributes
{
    public class AuthorizationRequiredAttribute : TypeFilterAttribute
    {
        public AuthorizationRequiredAttribute(): base(typeof(AuthorizationRequiredFilter))
        {
            System.Console.WriteLine("Hello");
        }
    }

    public class AuthorizationRequiredFilter: IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var principal = new ClientPrincipal();

            if (context.HttpContext.Request.Headers.TryGetValue("x-ms-client-principal", out var header))
            {
                var data = header[0];
                var decoded = Convert.FromBase64String(data);
                var json = Encoding.UTF8.GetString(decoded);
                principal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            principal.UserRoles = principal.UserRoles?.Except(new string[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase);

            var userRoles = principal.UserRoles.ToList();
            if (!userRoles.Contains("authenticated"))
                context.Result = new ForbidResult();
        }
    }
}