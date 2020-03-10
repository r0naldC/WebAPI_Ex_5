using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebAPI_Ex_5.Interfaces;
using WebAPI_Ex_5.Models;
using WebAPI_Ex_5.Validators;

namespace WebAPI_Ex_5.Services
{
    public class TaskService : ITask
    {
        private readonly Ex_5Context _dbContext = new Ex_5Context();
        private BindingList<string> errors = new BindingList<string>();

        public TaskService()
        {
        }

        public void CreateTask(Task task)
        {
            var taskValidator = new TaskValidator();
            errors.Clear();

            ValidationResult result = taskValidator.Validate(task);

            if (result.IsValid)
            {
                _dbContext.Tasks.Add(task);
                _dbContext.SaveChanges();
            }
            else
            {
                foreach(ValidationFailure failure in result.Errors)
                {
                    errors.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
                }
            }
        }

        public Task DeleteTask(int id)
        {
            var task = _dbContext.Tasks.Find(id);

            _dbContext.Tasks.Remove(task ?? throw new InvalidOperationException());
            _dbContext.SaveChanges();

            return task;
        }

        public List<Task> GetAllTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            return _dbContext.Tasks.Find(id);
        }

        public List<Task> GetTaskByTypeId(int id)
        {
            //return _dbContext.Tasks.Where(x => x.Type.Id == id).ToList();
            return _dbContext.Tasks.Where(x => x.Type.Id == id).ToList();
        }

        public Task UpdateTask(int id, Task task)
        {
            var taskToUpdate = _dbContext.Tasks.Find(id);

            if (taskToUpdate != null)
            {
                //taskToUpdate.Id = task.Id != null ? task.Id : taskToUpdate.Id;
                taskToUpdate.Name = task.Name ?? taskToUpdate.Name;
                taskToUpdate.Complete = task.Complete != null ? task.Complete : taskToUpdate.Complete;
                taskToUpdate.CreateDate = task.CreateDate != null ? task.CreateDate : taskToUpdate.CreateDate;
                taskToUpdate.ModifiedDate = task.ModifiedDate != null ? task.ModifiedDate : taskToUpdate.ModifiedDate;
                taskToUpdate.Type = task.Type ?? taskToUpdate.Type;
            }

            _dbContext.SaveChanges();
            var taskUpdated = _dbContext.Tasks.Find(id);
            
            return taskUpdated;
        }
    }
}