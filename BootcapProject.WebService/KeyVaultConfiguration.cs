using System.IO;
using System.Text.Json;

namespace BootcapProject.WebService
{	
	public class KeyVaultConfiguration
    {
		public string VaultUri { get; set; }

		public string GetVaultUri()
		{
			string jsonString = File.ReadAllText("Configurations/KeyVault.json");
			return JsonSerializer.Deserialize<KeyVaultConfiguration>(jsonString).VaultUri;
		}
	}	
}
