using Hotel.WindowsForms.Controllers;
using Hotel.WindowsForms.Views;
using Microsoft.Extensions.Configuration;

namespace Hotel.WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            string apiUrl = config["ApiSettings:BaseUrl"] ?? "http://localhost:5295";
            var appContext = new HotelAppContext(apiUrl);

            Application.Run(new FrmLogin(appContext));
        }
    }
}
