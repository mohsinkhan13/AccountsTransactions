using System.Collections.Generic;
using System.Linq;
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Web.Http;
using AIP.Common.Web.Server.Tokens;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.WebApi.Authentication.Handler;

namespace AccountsTransactions.Web.Api.App_Start
{
  public class AuthConfig 
	{
		public static void Register(HttpConfiguration globalConfig)
		{
			globalConfig.Filters.Add(new AuthorizeAttribute());
			globalConfig.MessageHandlers.Add(new AuthenticationHandler(BuildConfiguration()));
		}

		private static AuthenticationConfiguration BuildConfiguration()
		{
			var issuer = FederatedAuthentication.FederationConfiguration.WsFederationConfiguration.Issuer;
			var realm = FederatedAuthentication.FederationConfiguration.WsFederationConfiguration.Realm;

			var config = new AuthenticationConfiguration { RequireSsl = true, EnableSessionToken = true };
			config.AddSaml2(BuildSecurityTokenHandlerConfiguration(), AuthenticationOptions.ForAuthorizationHeader("Saml2"), new AuthenticationScheme());
			config.AddMapping(BuildJsonWebTokenMapping(issuer, realm, "o5Tjl+j6pTjQJR9PdZ1fpSyQAgebeXudG3pBw91GFv4=", "Bearer"));

			return config;
		}

		#region helpers
		private static SecurityTokenHandlerConfiguration BuildSecurityTokenHandlerConfiguration()
		{
			var configuration = FederatedAuthentication.FederationConfiguration.IdentityConfiguration;
			var handlerConfig = new SecurityTokenHandlerConfiguration();

			foreach (var itm in configuration.AudienceRestriction.AllowedAudienceUris)
			{
				handlerConfig.AudienceRestriction.AllowedAudienceUris.Add(itm);
			}

			handlerConfig.IssuerNameRegistry = configuration.IssuerNameRegistry;

			handlerConfig.CertificateValidator = X509CertificateValidator.None;
			handlerConfig.ServiceTokenResolver = configuration.ServiceTokenResolver;

			return handlerConfig;
		}


		private static AuthenticationOptionMapping BuildJsonWebTokenMapping(string issuer, string realm, string signingKey, string scheme)
		{
			var certificate = X509.LocalMachine.My.SubjectDistinguishedName.Find("CN=portalsigning", false).FirstOrDefault();

			var validationParameters = new TokenValidationParameters()
			{
				ValidAudience = issuer + "/resources",
				IssuerSigningToken = new X509SecurityToken(certificate),
				ValidIssuer = issuer,
			};

			return new AuthenticationOptionMapping
      {
          TokenHandler = new SecurityTokenHandlerCollection { new IdentityModelJwtSecurityTokenHandler(validationParameters) },
          Options = AuthenticationOptions.ForAuthorizationHeader(scheme),
          Scheme = AuthenticationScheme.SchemeOnly(scheme)
      };
		}
		#endregion	
	}
}