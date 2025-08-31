using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Hosting;
using MinimalApi.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Teste.Mocks;
using MinimalApi.Dominio;

namespace Teste.Helpers;

public class Setup
{
    public const string PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();

        Setup.http = Setup.http.WithWebHostBuilder(builder =>
        {
            builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAdministradorServico, AdministradorServicoMock>();

                // var conexao = "server=localhost;Database=desafio21dias_dotnet7_teste,Uid=root,pwd=root";
                // services.AddDbContext<DbContexto>(options =>
                // {
                //     options.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
                // })
            });
        });

        Setup.client = Setup.http.CreateClient();
    }


    public static void ClassCleanup()
    {
        Setup.http.Dispose();
    }


}