using System;

namespace khaledhikmat.Api.Services
{
    public class SettingService : ISettingService
    {
        public string GetCosmicBaseUrl()
        {
            return Environment.GetEnvironmentVariable("CosmicBaseUrl");
        }

        public string GetCosmicPostBucketSlug()
        {
            return Environment.GetEnvironmentVariable("CosmicPostsBucket");
        }

        public string GetCosmicReadKey()
        {
            return Environment.GetEnvironmentVariable("CosmicReadKey");
        }
    }
}
