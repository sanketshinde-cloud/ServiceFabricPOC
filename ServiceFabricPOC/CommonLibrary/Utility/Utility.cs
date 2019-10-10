using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Utility
{
   public class Utility : IUtility
    {

        public static string CLIENTSECRET = "r77P5u6zCpONMGZGOp:E]?jgAG:v.H71";
        public static string CLIENTID = "dcaf8ee3-938a-4211-b50c-3ded910359f6";
        public static string BASESECRETURI = "https://bzservicefabrickeyvault.vault.azure.net";

        public KeyVaultClient GetKeyClient(string KeyVaultName)
        {
            KeyVaultClient kvc = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));
            SecretBundle secret = Task.Run(() => kvc.GetSecretAsync(BASESECRETURI +
                @"/secrets/" + KeyVaultName)).ConfigureAwait(false).GetAwaiter().GetResult();
            return kvc;
        }

        public async Task<string> GetToken(string authority, string resource, string scope)
        {
           
                var authContext = new AuthenticationContext(authority);
                ClientCredential clientCred = new ClientCredential(CLIENTID, CLIENTSECRET);
                AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);
           
            return result.AccessToken;
        }

        public SecretBundle GetSecret(string KeyVaultName)
        {
            KeyVaultClient kvc = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));
            SecretBundle secret = Task.Run(() => kvc.GetSecretAsync(BASESECRETURI +
                @"/secrets/" + KeyVaultName)).ConfigureAwait(false).GetAwaiter().GetResult();
            return secret;

        }
    }
}
