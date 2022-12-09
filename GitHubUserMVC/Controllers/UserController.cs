using GitHubUserMVC.Extensions;
using GitHubUserMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace GitHubUserMVC.Controllers
{
    public class UserController : Controller
    {

        public async Task<IActionResult> Details()
        {
            //The models to be used are instantiated (user, developer list and repository list)
            GitHubUserViewModel? user = new GitHubUserViewModel();
            List<GitHubDevViewModel>? devList = new List<GitHubDevViewModel>();
            List<GitHubRepoViewModel>? repoList = new List<GitHubRepoViewModel>();

            // Top 10 developers with the most followers
            var response = await ClientClass.client.GetAsync(string.Format("search/users?q={0}&page={1}&per_page={2}&sort={3}&order={4}", "followers:>1000", 1, 4, "followers", "desc"));

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var items = JObject.Parse(data)["items"].ToString();

                devList = JsonConvert.DeserializeObject<List<GitHubDevViewModel>>(items);


            }

            // Top 10 repositories with the most stars
            response = await ClientClass.client.GetAsync(string.Format("search/repositories?q={0}&page={1}&per_page={2}&sort={3}&order={4}", "q", 1, 4, "stars", "desc"));

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var items = JObject.Parse(data)["items"].ToString();

                repoList = JsonConvert.DeserializeObject<List<GitHubRepoViewModel>>(items);


            }


            user = TempData.Get<GitHubUserViewModel>("user") as GitHubUserViewModel;

            //detailViewModel stores the 3 viewmodels that will be used in the view
            GitHubDetailsViewModel detailViewModel = new GitHubDetailsViewModel();


            if (user != null) detailViewModel.UserViewModel = user;
            if (devList != null) detailViewModel.DevViewModelList = devList;
            if (repoList != null) detailViewModel.RepoViewModelList = repoList;


            return View(detailViewModel);

        }
    }
}
