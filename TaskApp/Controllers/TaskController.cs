using Microsoft.AspNetCore.Mvc;
using TaskApp.Api.Responses;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces;
using TaskApp.Core.QueryFilters;

namespace TaskApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllTasks([FromQuery] TaskQueryFilter filter)
        {
            var tasks = await _taskService.GetAllTasks(filter);
            if (tasks == null) { return NotFound(); }

            var response = new ApiResponse<IEnumerable<TbTask>>(tasks);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TbTask task)
        {
            string menx = "Could not insert record";
            var respx = await _taskService.Insert(task);
            if (respx) { menx = "The record was inserted correctly."; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> Get(int Id)
        {
            var task = await _taskService.Get(Id);
            if (task == null) { return NotFound(); }

            var response = new ApiResponse<TbTask>(task);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(int Id, TbTask taskUpdated)
        {
            string menx = "Could not edit the record";
            var task = await _taskService.Get(Id);
            if (task == null) { return NotFound(); }

            taskUpdated.TaskId = Id;
            var respx = await _taskService.Update(taskUpdated);
            if (respx) { menx = "The registry successfully edited"; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int Id)
        {
            string menx = "Could not delete record";
            var task = await _taskService.Get(Id);
            if (task == null) { return NotFound(); }
            var respx = await _taskService.Delete(Id);
            if (respx) { menx = "The record was successfully deleted"; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }
    }
}
