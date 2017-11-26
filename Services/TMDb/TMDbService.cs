using Common;
using TMDbLib.Client;

namespace Services.TMDb
{
    [Singleton]
    public class TMDbService : ITMDbService
    {
        //TODO: this has to come from a config file-- but not app.config cause this will be called from another project too
        private static readonly string apiKey = "a0e9a2a4bf20414f55c0f3c1b0910ec9";

        private TMDbClient Client
        {
            get;
        }

        public TMDbService()
        {
            Client = new TMDbClient(apiKey)
            {
                MaxRetryCount = 5
            };
        }

        public string GetImagePath(string size, string filePath)
        { //GetConfig is what calls the API, only done once so we're free to call this method in a loop without the risk of triggering api call limit
            if (!Client.HasConfig)
                Client.GetConfig();

            var url = Client.GetImageUrl(size, filePath, false); //TODO: change this once SSL is enabled on the site
            return url.AbsoluteUri;
        }
    }
}