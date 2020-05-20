using Microsoft.AspNetCore.Mvc;
using RestAPI_Project.Contract;
using RestAPI_Project.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await _postService.GetPostsAsync());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
                return NotFound();
            
            return Ok(post);

        }
        
        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                Id = postId,
                Name = request.Name
            };

            var updated = await _postService.UpdatePostAsync(post);

            if (updated)
                return Ok(post);
            
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            var deleted = await _postService.DeletePostAsync(postId);

            if (deleted)
                return NoContent();

            return NotFound();

        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post {Name = postRequest.Name};

            await _postService.CreatePostAsync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", Convert.ToString(post.Id));

            var response = new PostResponse { Id = post.Id };
            return Created(locationUri, response);

        }
    }
}
