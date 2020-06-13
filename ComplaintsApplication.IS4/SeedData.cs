using ComplaintsApplication.IS4.Data;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;


namespace ComplaintsApplication.IS4
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider provider)
        {
            provider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
            provider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
            provider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();

            {
                var userMgr = provider.GetRequiredService<UserManager<ApplicationUser>>();
                var haris = userMgr.FindByNameAsync("mks786@gmail.com").Result;
                if (haris == null)
                {
                    haris = new ApplicationUser
                    {
                        UserName = "mks786@gmail.com",
                        Email = "mks786@gmail.com",
                        EmailConfirmed = true
                    };
                    var result = userMgr.CreateAsync(haris, "Asdf@123").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    haris = userMgr.FindByNameAsync("mks786@gmail.com").Result;

                    result = userMgr.AddClaimsAsync(haris, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Kashif Saeed"),
                                new Claim(JwtClaimTypes.GivenName, "Kashif"),
                                new Claim(JwtClaimTypes.FamilyName, "Saeed"),
                                new Claim(JwtClaimTypes.Email, "mks786@gmail.com"),
                                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                                new Claim(JwtClaimTypes.WebSite, "http://haris.com"),
                                new Claim("account_type", "New Registered"),
                                new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Street Address ', 'locality': 'city', 'postal_code': 01234, 'country': 'country' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "somewhere")
                            }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Console.WriteLine("mks786@gmail.com created");
                }
                else
                {
                    Console.WriteLine("mks786@gmail.com already exists");
                }

                ////////////////////////////////////////////////////////////////////////////////////////////

                var context = provider.GetRequiredService<ConfigurationDbContext>();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.Ids)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.Apis)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
