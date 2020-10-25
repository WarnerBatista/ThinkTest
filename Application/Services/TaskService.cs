using Data.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class TaskService
    {
        private readonly ThinkTestContext _context;
        
        public TaskService(ThinkTestContext context)
        {
            _context = context;
        }

        public void AddTask(Task task)
        {
            _context.task.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.task.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            _context.task.Remove(FindOne(id));
            _context.SaveChanges();
        }

        public List<Task> FindAll()
        {
            return _context.task.ToList();
        }

        public Task FindOne(int id)
        {
            return _context.task.Find(id);
        }
    }
}
