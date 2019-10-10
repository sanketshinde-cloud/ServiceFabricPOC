using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Utility
{
    public interface IUtility
    {
        Task<string> GetToken(string authority, string resource, string scope);

        KeyVaultClient GetKeyClient(string KeyVaultName);

        SecretBundle GetSecret(string KeyVaultName);
    }
}
