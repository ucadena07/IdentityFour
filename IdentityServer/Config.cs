﻿
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "movieClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"movieAPI"}
                },
                new Client
                {
                    ClientId = "movies_mvc_client",
                    ClientName = "Movies MVC Web App",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:7116/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                         "https://localhost:7116/signout-callback-oidc"
                    },
                    
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("movieAPI","Movie API")
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
              
            };
        public static IEnumerable<TestUser> TestUsers =>
            new TestUser[]
            {
                new TestUser()
                {
                    SubjectId = "xxx-xxx-xxx",
                    Username = "nigel",
                    Password = "nigel",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName,"nigel"),
                        new Claim(JwtClaimTypes.FamilyName,"cadena")
                    }
                },
               
            };
    }
}
