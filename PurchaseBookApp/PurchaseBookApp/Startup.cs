using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PurchaseBookApp.Models;

[assembly: FunctionsStartup(typeof(PurchaseBookApp.Startup))]
namespace PurchaseBookApp
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = "Server=tcp:digitalbookmanagement.database.windows.net,1433;Initial Catalog=DigitalBookManagementdb;Persist Security Info=False;User ID=pramod;Password=prmd@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.Services.AddDbContext<DigitalBookManagementContext>(
                options => options.UseSqlServer(SqlConnection));
        }
    }
}
