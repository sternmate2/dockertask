using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace BootcapProject.WebService
{
	public enum KeyVaultAccessMethod
	{
		UseSecret,
		UseCertificate,
		UseMsi
	}

	public class KeyVaultProvider
    {
        private KeyVaultClient _kvProvider;
		string _vault;        

        public KeyVaultProvider(string vault)
        {
			_vault = vault;
			CreateKeyVaultClient();

		}

        private void CreateKeyVaultClient()
		{
			KeyVaultClient keyVaultClient;
			
			KeyVaultAccessMethod accessMethod = KeyVaultAccessMethod.UseMsi;

			switch (accessMethod)
			{
				//case KeyVaultAccessMethod.UseCertificate:
				//	{
				//		keyVaultClient = new KeyVaultClient(accessToken);
				//		break;
				//	}
				//case KeyVaultAccessMethod.UseSecret:
				//	{
				//		keyVaultClient = new KeyVaultClient(GetSecretAuthentication);
				//		break;
				//	}
				case KeyVaultAccessMethod.UseMsi:
					{
						var azureServiceTokenProvider = new AzureServiceTokenProvider();
						keyVaultClient =
							new KeyVaultClient(
								new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
						break;
					}
				default:
					throw new NotSupportedException("Invalid KeyVault access method");
			}

			_kvProvider = keyVaultClient;
		}

		public async Task<string> GetSecretAsync(string key)
        {
			string value = null;
			try
            {
				var bundle = await _kvProvider.GetSecretAsync(_vault, key).ConfigureAwait(false);
				value = bundle.Value;
				
			}
            catch(Exception ex)
            {
                // ignored
            }

            return value;
		}
	}
}
