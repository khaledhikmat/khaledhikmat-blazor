using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

using khaledhikmat.Shared.Models;
using khaledhikmat.Api.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace khaledhikmat.Api.Functions
{
    public class PostFunctionApp
    {
        private readonly ILogger _logger;
        private readonly HttpClient _http;
        private readonly IPostService _postService;

        public PostFunctionApp(ILoggerFactory loggerFactory, IHttpClientFactory httpClientFactory, IPostService service)
        {
            _logger = loggerFactory.CreateLogger<PostFunctionApp>();
            _http = httpClientFactory.CreateClient();
            _postService = service;
        }

        [Function("posts")]
        public async Task<HttpResponseData> RunPosts([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "posts")] 
            HttpRequestData req,
            FunctionContext context)
        {
            var logger = context.GetLogger("PostFunctionApp");
            logger.LogInformation("RunPosts started....");

            List<Post> posts = await _postService.GetPosts();
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(posts);
            return response;
        }

        [Function("post")]
        public async Task<HttpResponseData> RunPost([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "posts/{id}")] 
            HttpRequestData req, 
            string id,
            FunctionContext context)
        {
            var logger = context.GetLogger("PostFunctionApp");
            logger.LogInformation("RunPost started....");

            Post post = await _postService.GetPost(id);
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(post);
            return response;
        }
    }
}
