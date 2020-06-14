using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ComplaintsApplication.IS4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource{
                                    Name = "ComplaintsApplicationReadWrite",

                                    Scopes =
                                    {
                                        new Scope()
                                        {
                                            Name = "ComplaintsApplicationReadWrite.full_access",
                                            DisplayName = "Full access to ComplaintsApplicationReadWrite"
                                        },
                                        new Scope
                                        {
                                            Name = "ComplaintsApplicationReadWrite.read_only",
                                            DisplayName = "Read only access to ComplaintsApplicationReadWrite"
                                        }
                                    }
                                },
                new ApiResource{
                                    Name = "ComplaintsApplicationTransfer",

                                    Scopes =
                                    {
                                        new Scope()
                                        {
                                            Name = "ComplaintsApplicationTransfer.full_access",
                                            DisplayName = "Full access to ComplaintsApplicationTransfer"
                                        },
                                        new Scope
                                        {
                                            Name = "ComplaintsApplicationTransfer.read_only",
                                            DisplayName = "Read only access to ComplaintsApplicationTransfer"
                                        }
                                    }
                                }
            };

        public static IEnumerable<Client> GetClients =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = {
                                      "ComplaintsApplicationReadWrite",
                                      "ComplaintsApplicationReadWrite.full_access",
                                      "ComplaintsApplicationReadWrite.read_only",
                                      "ComplaintsApplicationTransfer",
                                      "ComplaintsApplicationTransfer.full_access",
                                      "ComplaintsApplicationTransfer.read_only"
                                    }
                },
                 // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                                      "ComplaintsApplicationReadWrite",
                                      "ComplaintsApplicationReadWrite.full_access",
                                      "ComplaintsApplicationReadWrite.read_only",
                                      "ComplaintsApplicationTransfer",
                                      "ComplaintsApplicationTransfer.full_access",
                                      "ComplaintsApplicationTransfer.read_only"
                                    }
                },
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                
                    // // where to redirect to after login
                    RedirectUris = { "http://localhost:5002/signin-oidc" },

                    //// where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ComplaintsApplicationReadWrite",
                        "ComplaintsApplicationReadWrite.full_access",
                        "ComplaintsApplicationReadWrite.read_only",
                        "ComplaintsApplicationTransfer",
                        "ComplaintsApplicationTransfer.full_access",
                        "ComplaintsApplicationTransfer.read_only"
                    },

                    AllowOfflineAccess = true
                },
                // OpenID Connect hybrid flow client (MVC)
                new Client
                {
                    ClientId = "mvc.OpenId",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ComplaintsApplicationReadWrite",
                        "ComplaintsApplicationReadWrite.full_access",
                        "ComplaintsApplicationReadWrite.read_only",
                        "ComplaintsApplicationTransfer",
                        "ComplaintsApplicationTransfer.full_access",
                        "ComplaintsApplicationTransfer.read_only"
                    },

                    AllowOfflineAccess = true
                },
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =           { "http://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:5003" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ComplaintsApplicationReadWrite",
                        "ComplaintsApplicationReadWrite.full_access",
                        "ComplaintsApplicationReadWrite.read_only",
                        "ComplaintsApplicationTransfer",
                        "ComplaintsApplicationTransfer.full_access",
                        "ComplaintsApplicationTransfer.read_only"

                    }
                }
            };
    }
}
