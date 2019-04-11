using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static string GetKeyVaultName() => "$https://mvckeyvault.vault.azure.net/";

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {

            return WebHost.CreateDefaultBuilder(args)
                                      .ConfigureAppConfiguration(
                                          (ctx, config) =>
                                          {
                                              var azureServiceTokenProvider = new AzureServiceTokenProvider();

                                              var keyVaultClient = new KeyVaultClient(
                                                  new KeyVaultClient.AuthenticationCallback(
                                                      azureServiceTokenProvider.KeyVaultTokenCallback));

                                              config.AddAzureKeyVault(
                                                  "https://tolmachovkeyvault.vault.azure.net/",
                                                  keyVaultClient,
                                                  new DefaultKeyVaultSecretManager());
                                          }
                                      ).UseApplicationInsights()
                                      .UseStartup<Startup>();
        }
    }
}
