using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using UserManagement.Application.Common.Interfaces;
using UserManagement.Domain;

namespace UserManagement.Infrastructure.Persistance.Repositories
{
    public class FakeRepository : IFakeRepository
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IUserManagementRepository _userManagementRepository;
        private const string baseUrl = "https://jsonplaceholder.typicode.com";
        public HttpClient Client { get; set; }
        public FakeRepository(IUserManagementRepository userManagementRepository, IHttpClientFactory httpClient)
        {
            _userManagementRepository = userManagementRepository;
            _httpClient = httpClient;
            Client = _httpClient.CreateClient("MyApiClient");
        }

        public async Task<string> PostWithComments(int userId)
        {
            var dbUser = await _userManagementRepository.GetUser(userId);

            var post = await Client.GetStringAsync($"{baseUrl}/users/{userId}/posts?_embed=comments");
            return post;
        }

        public async Task<string> Users()
        {
            var users = await Client.GetStringAsync($"{baseUrl}/users");
            return users;
        }
        public async Task<string> Todos(int userId)
        {
            var dbUser = await _userManagementRepository.GetUser(userId);

            var todo = await Client.GetStringAsync($"{baseUrl}/users/{userId}/posts");

            return todo;
        }

        public async Task<string> Album(int userId)
        {
            var dbUser = await _userManagementRepository.GetUser(userId);

            var todo = await Client.GetStringAsync($"{baseUrl}/users/{userId}/albums?_embed=photos");

            return todo;
        }
    }
}
