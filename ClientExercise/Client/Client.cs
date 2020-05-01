namespace ClientExercise.Client
{
    using System.Net.Http;

    public class Client : IClient
    {
        private static HttpClient httpClient;

        private HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    var handler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                    };

                    httpClient = new HttpClient(handler);
                }

                return httpClient;
            }
        }

        public virtual HttpClient GetClient()
        {
            return this.HttpClient;
        }
    }
}
