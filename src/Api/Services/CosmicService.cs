using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using khaledhikmat.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace khaledhikmat.Api.Services
{
    public class CosmicService : IPostService 
    {
        private HttpClient _http;
        private ILogger<CosmicService> _logger;
        private ISettingService _config;

        public CosmicService(HttpClient http, ILogger<CosmicService> logger, ISettingService config) 
        {
            _http = http;
            _logger = logger;
            _config = config;

            _http.BaseAddress = new Uri(_config.GetCosmicBaseUrl());
        }
        
        public async Task<List<Post>> GetPosts() 
        {
            var bucketSlug = _config.GetCosmicPostBucketSlug();
            var readKey = _config.GetCosmicReadKey();

            var queryParameters = new Dictionary<string, string>()
            {
                {"query", $"{JsonSerializer.Serialize(new PostsQuery() {type = "posts"})}"},
                {"read_key", $"{readKey}"},
                {"pretty", $"true"},
                {"props", "id,published_at,slug,title,content,metadata.date,metadata.author,metadata.markdown,metadata.tags.slug,metadata.tags.title"}
            };

            var requestUri = QueryHelpers.AddQueryString($"/v2/buckets/{bucketSlug}/objects", queryParameters);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Add("Accept", "application/json");
            _logger.LogWarning($"GetPosts = {request.RequestUri.ToString()}");

            var response = await _http.SendAsync(request);
            if (!response.IsSuccessStatusCode) 
            {
                throw new ApplicationException($"{response.StatusCode}-{response.ReasonPhrase}");
            }

            var list = await response.Content.ReadFromJsonAsync<PostsList>();
            if (list == null)
            {
                return new List<Post>();
            }

            return list.objects;
        }

        public async Task<Post> GetPost(string id) 
        {
            var bucketSlug = _config.GetCosmicPostBucketSlug();
            var readKey = _config.GetCosmicReadKey();

            var queryParameters = new Dictionary<string, string>()
            {
                {"read_key", $"{readKey}"}
            };

            var requestUri = QueryHelpers.AddQueryString($"/v2/buckets/{bucketSlug}/objects/{id}", queryParameters);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Add("Accept", "application/json");
            _logger.LogWarning($"GetPost = {request.RequestUri.ToString()}");

            var response = await _http.SendAsync(request);
            if (!response.IsSuccessStatusCode) 
            {
                throw new ApplicationException($"{response.StatusCode}-{response.ReasonPhrase}");
            }

            var postObject = await response.Content.ReadFromJsonAsync<PostObject>();
            if (postObject == null) 
            {
                return new Post();
            }

            return postObject.post;
        }
    }
}