using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GeneratedAPI
{
	/// <summary>
	/// Program
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Create the host builder.
		/// </summary>
		/// <param name="args"></param>
		/// <returns>IHostBuilder</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureKestrel(serverOptions =>
					{
						serverOptions.ListenAnyIP(5000); // HTTP
						serverOptions.ListenAnyIP(5001, listenOptions =>
						{
							listenOptions.UseHttps(); // HTTPS
						});
					});
					webBuilder.UseStartup<Startup>();
				});
	
	}
}
