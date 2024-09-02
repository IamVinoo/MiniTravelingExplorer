using Hangfire;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using MiniTravelingExplorer.Utils;

[assembly: OwinStartupAttribute(typeof(MiniTravelingExplorer.Startup))]
namespace MiniTravelingExplorer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Configure Hangfire to use SQL Server storage
            GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings[Constant.CONNECTION_STRING_KEY].ConnectionString);

            // Enable Hangfire server and dashboard
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}