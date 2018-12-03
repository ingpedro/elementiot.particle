using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElementIoT.Particle.Infrastructure.Api
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ApiStartup
    {
        #region Fields

        private const string AAD_INSTANCE = "AzureAd:Instance";
        private const string AAD_TENANT = "AzureAd:Tenant";
        private const string AAD_CLIENT = "AzureAd:Client";
        private const string AAD_ISSUER = "AzureAd:Issuer";
        private const string AAD_SECRETKEY = "AzureAd:SecretKey";
       

        private const string SWAGGER_TITLE = "Swagger:Title";
        private const string SWAGGER_VERSION = "Swagger:Version";
        private const string SWAGGER_DESCRIPTION = "Swagger:Description";
        private const string SWAGGER_ENDPOINT = "Swagger:Endpoint";
        

        #endregion

        #region Properties

        /// <summary>
        /// Gets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        protected IConfiguration ConfigService
        { get;  }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiStartup"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        public ApiStartup(IConfiguration configService)
        {
            this.ConfigService = ConfigService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the authentication services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureAuthenticationServices(IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = String.Format(ConfigService[AAD_INSTANCE], ConfigService[AAD_TENANT]);
                    options.Audience = ConfigService[AAD_CLIENT];
                    options.IncludeErrorDetails = true;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = ConfigService[AAD_ISSUER],

                        ValidateAudience = true,
                        ValidAudience = ConfigService[AAD_CLIENT],

                        ValidateLifetime = true,
                    };
                });
        }

        /// <summary>
        /// Configures the swagger services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = ConfigService[SWAGGER_TITLE],
                    Version = ConfigService[SWAGGER_VERSION],
                    Description = ConfigService[SWAGGER_DESCRIPTION],
                });

                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = $"https://login.microsoftonline.com/{ConfigService[AAD_TENANT]}/oauth2/authorize",
                    Scopes = new Dictionary<string, string>
                    {
                      { "user_impersonation", "Access API" }
                    }
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                  {
                    { "oauth2", new[] { "user_impersonation" } }
                  });
            });
        }


        /// <summary>
        /// Configures the swagger application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void ConfigureSwaggerApp(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ConfigService[SWAGGER_ENDPOINT], ConfigService[SWAGGER_TITLE]);
                c.OAuthClientId(ConfigService[AAD_CLIENT]);
                c.OAuthClientSecret(ConfigService[AAD_SECRETKEY]);
                c.OAuthRealm(ConfigService[AAD_CLIENT]);
                c.OAuthAppName(ConfigService[SWAGGER_TITLE]);
                c.OAuthScopeSeparator(" ");
                c.OAuthAdditionalQueryStringParams(new { resource = ConfigService[AAD_CLIENT] });
            });
        }

        #endregion
    }

}
