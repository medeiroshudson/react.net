using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using react.net.Models;
using react.net.Repositories.Todo;

namespace react.net.Controllers
{
    [Route("/api/[Controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITodoRepository _todoRepository;
        public TodoController(IConfiguration configuration, ITodoRepository todoRepository)
        {
            _configuration = configuration;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var todos = _todoRepository.GetAll();
                return new ObjectResult(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoModel obj)
        {
            try
            {
                // validating empty name
                if (string.IsNullOrWhiteSpace(obj.Name))
                    return BadRequest(new { message = "Please specify name" });

                _todoRepository.Create(obj);
                return Ok(new { obj.Name });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}