using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PrsServer {
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// Web API configuration and services
			config.EnableCors();
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "AuthApi",
				routeTemplate: "{controller}/{action}/{username}/{password}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
