using System;
using System.Configuration; 
using System.Web.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace WebAppKeyVault.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();

            try
            {
               // var keyVaultClient = new KeyVaultClient(
                 //   new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

               // var secret = await keyVaultClient.GetSecretAsync("https://aspnet-kv.vault.azure.net/secrets/secret")
                 //   .ConfigureAwait(false);

                var secret = ConfigurationManager.AppSettings["secret"];

                //ViewBag.Secret = $"Secret: {secret.Value}";
                ViewBag.Secret = $"Secret: {secret}";

            }
            catch (Exception exp)
            {
                ViewBag.Error = $"Something went wrong: {exp.Message}";
            }

            ViewBag.Principal = azureServiceTokenProvider.PrincipalUsed != null ? $"Principal Used: {azureServiceTokenProvider.PrincipalUsed}" : string.Empty;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}