using RestAPI_Project.Domain;
using System;
using System.Collections.Generic;

namespace RestAPI_Project.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPostById(Guid postId);

        bool UpdatePost(Post postToUpdate);

        bool DeletePost(Guid postId);
    }
}