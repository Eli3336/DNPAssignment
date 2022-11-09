using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeLoggedIn", a =>
                a.RequireAuthenticatedUser());
    
            
                
        });
    }
}