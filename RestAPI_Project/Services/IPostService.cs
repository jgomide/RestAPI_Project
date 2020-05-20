using RestAPI_Project.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI_Project.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(Guid postId);

        Task<bool> CreatePostAsync(Post post);
        
        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}