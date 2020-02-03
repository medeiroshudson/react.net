using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using react.net.Models;
using react.net.Repositories.Task;

namespace react.net.Controllers
{
    [Route("/api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITaskRepository _taskRepository;
        public TaskController(IConfiguration configuration, ITaskRepository taskRepository)
        {
            _configuration = configuration;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var todos = _taskRepository.GetAll();
                return new ObjectResult(todos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskModel obj)
        {
            try
            {
                // validating empty name
                if (string.IsNullOrWhiteSpace(obj.Name))
                    return BadRequest(new { message = "Please specify name" });

                TaskModel task = _taskRepository.Create(obj);
                return Ok(new { task });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult Remove(int id){
            try
            {
                var task = _taskRepository.Remove(id);
                return Ok(new { task });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}