using System.Net.Http.Headers;
using System.Text;

namespace GitHubUserMVC.Extensions
{
    //Class created to get the HttpClient with static constructor to only be instantiated once
    public class ClientClass
    {
        public static HttpClient client;

        static ClientClass()
        {
            //Parameters stored in appsettings.json
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().
                GetSection("AppSettings");

            string myuser = configuration["MyUser"];
            string mytoken = configuration["MyToken"];
            string baseadress = configuration["BaseAdress"];

            client = new HttpClient
            {
                BaseAddress = new Uri(baseadress)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "GitHubUserMVC");
            string basicValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{myuser}:{mytoken}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicValue);


        }
    }
}
