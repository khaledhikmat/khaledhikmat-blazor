namespace khaledhikmat.Api.Services
{
    public interface ISettingService 
    {
        string GetCosmicBaseUrl();
        string GetCosmicPostBucketSlug();
        string GetCosmicReadKey();
    }
}