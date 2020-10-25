using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThinkTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public ICollection<Domain.Entities.Task> Get()
        {
            var lista = _taskService.FindAll();
            return lista;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Domain.Entities.Task task)
        {
            try
            {
                _taskService.AddTask(task);
                return StatusCode(200);
            }
            catch (Exception e)
            {

            }
            return StatusCode(400);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Domain.Entities.Task task)
        {
            try
            {
                _taskService.UpdateTask(task);
                return StatusCode(200);
            }
            catch (Exception)
            {

            }
            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
            }
            catch (Exception)
            {

            }
        }

        [HttpGet ("{id}")]
        public Domain.Entities.Task Details(int id)
        {
            return _taskService.FindOne(id);
        }
    }
}
