using Clean.Architecture.Domain.Entities;
using Clean.Architecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User> _userRepository;

        public UserController(
            ILogger<UserController> logger,
            IRepository<User> userRepository
            )
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        // Test Endpoints - Using User Entity only for test

        [HttpPost()]
        public async Task<User> Create(string name, string email, string password)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password
            };

            await _userRepository.CreateAsync(user);

            return user;
        }

        [HttpGet()]
        public async Task<List<User>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return user;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = await _userRepository.RemoveAsync(id);
            return result;
        }
    }
}
