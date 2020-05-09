using Microsoft.AspNetCore.Mvc;
using RestAPI_Project.Contract;
using RestAPI_Project.Domain;
using System;
using System.Collections.Generic;
using RestAPI_Project.Contract.V1.Requests;
using RestAPI_Project.Contract.V1.Responses;
using RestAPI_Project.Services;


namespace RestAPI_Project.Controllers
{
    public class PostsControllers : Controller
    {
        private readonly IPostService _postService;

        public PostsControllers(IPostService postService)
        {
            _postService = postService;
        }
        
        //"api/v1/posts"
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if (post == null)
                return NotFound();
            
            return Ok(post);

        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = postRequest.Id,
                Name = $"Post Name {DateTime.Now}"
            };

            if (post.Id != Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }
            
            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", Convert.ToString(post.Id));

            var response = new PostResponse {Id = post.Id};
            return Created(locationUri, response);

        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                Id = postId,
                Name = request.Name
            };

            var updated = _postService.UpdatePost(post);

            if (updated)
                return Ok(post);
            
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public IActionResult Delete([FromRoute] Guid postId)
        {
            var deleted = _postService.DeletePost(postId);

            if (deleted)
                return NoContent();

            return NotFound();

        }
    }
}
