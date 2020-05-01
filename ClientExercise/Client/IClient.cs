namespace ClientExercise.Client
{
    using System.Net.Http;

    public interface IClient
    {
       abstract HttpClient GetClient();
    }
}
