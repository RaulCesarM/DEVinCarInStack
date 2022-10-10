using Microsoft.AspNetCore.Authorization;

namespace DEVinCar.Domain.Util.AttributesPersonalisad
{
    public class PermissaoAuthorizeAttribute : AuthorizeAttribute
    {
        public PermissaoAuthorizeAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("roles");

            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        } 
    }
}