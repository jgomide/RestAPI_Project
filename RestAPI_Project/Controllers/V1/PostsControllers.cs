using Microsoft.AspNetCore.Mvc;
using RestAPI_Project.Contract;
using RestAPI_Project.Domain;
using System;
using System.Collections.Generic;




namespace RestAPI_Project.Controllers
{
    public class PostsControllers : Controller
    {
        private List<Post> _posts;

        public PostsControllers()
        {
            _posts = new List<Post>();

            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Post{Id = Guid.NewGuid().ToString()});
            }
        }

        //"api/v1/posts"
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }
    }
}
