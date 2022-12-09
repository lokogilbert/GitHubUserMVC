using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace GitHubUserMVC.Models
{
    public class GitHubUserViewModel
    {
        public string? login { get; set; }
        public int id { get; set; }
        public string? node_id { get; set; }
        public string? avatar_url { get; set; }
        public string? gravatar_id { get; set; }
        public string? url { get; set; }
        public string? html_url { get; set; }
        public string? followers_url { get; set; }
        public string? following_url { get; set; }
        public string? gists_url { get; set; }
        public string? starred_url { get; set; }
        public string? subscriptions_url { get; set; }
        public string? organizations_url { get; set; }
        public string? repos_url { get; set; }
        public string? events_url { get; set; }
        public string? received_events_url { get; set; }
        public string? type { get; set; }
        public bool site_admin { get; set; }
        [Display(Name = "Name")]
        public string? name { get; set; }
        [Display(Name = "Company")]
        public string? company { get; set; }
        public string? blog { get; set; }
        [Display(Name = "Location")]
        public string? location { get; set; }
        [Display(Name = "Email")]
        public string? email { get; set; }
        [Display(Name = "Website")]
        public string? hireable { get; set; }
        [Display(Name = "Bio")]
        public string? bio { get; set; }
        [Display(Name = "Twitter username")]
        public string? twitter_username { get; set; }

        public int public_repos { get; set; }
        public int public_gists { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }

    }
}
