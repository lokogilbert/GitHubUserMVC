namespace GitHubUserMVC.Models
{
    public class GitHubDetailsViewModel
    {
        public GitHubUserViewModel? UserViewModel { get; set; }

        public List<GitHubDevViewModel>? DevViewModelList { get; set; }

        public List<GitHubRepoViewModel>? RepoViewModelList { get; set; }
    }
}
