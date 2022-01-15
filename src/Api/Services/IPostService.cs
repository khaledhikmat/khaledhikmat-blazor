using System.Collections.Generic;
using System.Threading.Tasks;
using khaledhikmat.Shared.Models;

namespace khaledhikmat.Api.Services
{
    public interface IPostService 
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPost(string id);
    }
}