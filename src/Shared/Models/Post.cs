using System.Text.Json.Serialization;

namespace khaledhikmat.Shared.Models
{
    public class PostsQuery 
    {
        public string type { get; set; }
    }

    public class PostsList 
    {
        public int total {get; set;}
        public List<Post> objects {get; set;}
    }

    public class PostObject 
    {
        [JsonPropertyName("object")]
        public Post post {get; set;}
    }

    public class Post 
    {
        public string id { get; set; } = "";
        public string slug { get; set; } = "";
        public string title { get; set; } = "";
        public string content { get; set; } = "";
        public DateTime published_at { get; set; }
        public PostMetadata metadata { get; set; } = new PostMetadata();
    }

    public class PostMetadata 
    {
        public string date { get; set; } = "";
        public string author { get; set; } = "";
        public string markdown { get; set; } = "";
        public List<PostTag> tags { get; set; } = new List<PostTag>();
   }

    public class PostTag 
    {
        public string slug { get; set; } = "";
        public string title { get; set; } = "";
   }
}