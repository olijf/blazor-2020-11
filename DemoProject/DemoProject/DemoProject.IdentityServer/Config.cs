﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace DemoProject.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("demoprojectbackend", "De supercoole backend van demoproject")
				{
                    UserClaims = { JwtClaimTypes.Name }
				}
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "demoprojectspa",
                    ClientName = "Demoproject SPA",
                    ClientUri = "https://localhost:5001",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "https://localhost:5001/",
                        "https://localhost:5001/authentication/login-callback",
                        "https://localhost:5001/authentication/silent",
                        "https://localhost:5001/authentication/popup",
                    },

                    PostLogoutRedirectUris = { "https://localhost:5001/" },
                    AllowedCorsOrigins = { "https://localhost:5001" },

                    AllowedScopes = { "openid", "profile", "demoprojectbackend" }
                }
            };
    }
}
