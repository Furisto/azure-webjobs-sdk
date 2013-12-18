using System;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Jobs.Azure20SdkBinders
{
    internal static class Utility
    {
        // Do a string check on type name first to avoid eagerly loading Azure SDK 2.0 types  if we don't need it. 
        public static bool IsAzureSdk20Type(Type targetType)
        {
            string fullName = targetType.FullName;
            if (fullName.StartsWith("Microsoft.WindowsAzure.Storage."))
            {
                return true;
            }
            return false;
        }
    }

    internal static class IBinderExtensions
    {
        public static CloudStorageAccount GetAccount(this IBinderEx bindingContext)
        {
            var acs = bindingContext.AccountConnectionString;
            CloudStorageAccount account = CloudStorageAccount.Parse(acs);
            return account;
        }
    }
}
