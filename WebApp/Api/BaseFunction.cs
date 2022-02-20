using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using WebApp.Api.Utilities;

namespace WebApp.Api
{
    public abstract class BaseFunction
    {
        protected AppDbContext _context;
        public BaseFunction(AppDbContext context)
        {
            _context = context;
        }

        protected virtual bool IsAuthenticated(HttpRequest req)
            {
                var principal = new ClientPrincipal();

                if (req.Headers.TryGetValue("x-ms-client-principal", out var header))
                {
                    var data = header[0];
                    var decoded = Convert.FromBase64String(data);
                    var json = Encoding.UTF8.GetString(decoded);
                    principal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                principal.UserRoles = principal.UserRoles?.Except(new string[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase);

                var userRoles = principal.UserRoles.ToList();
                return userRoles.Contains("authenticated");
            }
        }
}