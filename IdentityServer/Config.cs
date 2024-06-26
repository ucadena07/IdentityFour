﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            };
        public static IEnumerable<TestUser> TestUsers =>
            new TestUser[]
            {
            };
    }
}
