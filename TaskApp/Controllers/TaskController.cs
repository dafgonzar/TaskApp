using Microsoft.AspNetCore.Mvc;
using TaskApp.Api.Responses;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces;
using TaskApp.Core.QueryFilters;

namespace TaskApp.Api.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public TaskController(ITaskService taskService) 
        {
            _taskService = taskService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllTasks([FromQuery]TaskQueryFilter filter) 
        { 
            var tasks = await _taskService.GetAllTasks(filter);
            if (tasks == null) { return NotFound(); }

            var response = new ApiResponse<IEnumerable<TbTask>>(tasks);
            return Ok(response);
        }
    }
}
