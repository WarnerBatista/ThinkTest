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

        public ICollection<Domain.Entities.Task> Index()
        {
            var lista = _taskService.FindAll();
            return lista;
        }

        //[HttpPost]
        //public string Create()
        //{
        //    try
        //    {
        //        Domain.Entities.Task task = new Domain.Entities.Task { Name = "Web Api", IsDone = true };
        //        _taskService.AddTask(task);
        //        return "OK";
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return "Not Ok";
        //}

        //[HttpPost]
        //public bool Update(Domain.Entities.Task task)
        //{
        //    try
        //    {
        //        _taskService.UpdateTask(task);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return false;
        //}

        //[HttpPost]
        //public bool Delete(Domain.Entities.Task task)
        //{
        //    try
        //    {
        //        _taskService.DeleteTask(task);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return false;
        //}

        //public Domain.Entities.Task Details(int id)
        //{
        //    Domain.Entities.Task task = _taskService.FindOne(id);
        //    return task;
        //}
    }
}
