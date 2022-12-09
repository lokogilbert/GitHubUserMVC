using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GitHubUserMVC.Models
{
    public class GitHubRepoViewModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? full_name { get; set; }
        public string? html_url { get; set; }
        public string? stargazers_url { get; set; }
        public int stargazers_count { get; set; }
        public string? description { get; set; }
    }
}
