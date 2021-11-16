using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BootcapProject.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyVaultAccessController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var t = new KeyVaultConfiguration();
            string vault = t.GetVaultUri();
            string key = "secretString";

            KeyVaultProvider kvProvider = new KeyVaultProvider(vault);
            string secret = await kvProvider.GetSecretAsync(key).ConfigureAwait(false);


            if (secret == null)
                return ("Hello World!");
            
            return ("Hello World, we got a secret: " + secret);
        }
    }
}
