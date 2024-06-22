using Clean.Architecture.Application.Features;
using Clean.Architecture.Domain.Entities;
using Clean.Architecture.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Api.Controllers
{
    [ApiController]
    [Route("users")]
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
        public async Task<IActionResult> Create(string name, string email, string password)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password
            };

            await _userRepository.CreateAsync(user);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, user));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.GetAsync(id);
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userRepository.RemoveAsync(id);
            return StatusCode(StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, message: "Record deleted"));
        }
    }
}
