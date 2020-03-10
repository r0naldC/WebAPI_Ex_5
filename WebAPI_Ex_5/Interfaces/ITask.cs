using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Ex_5.Models;


namespace WebAPI_Ex_5.Interfaces
{
    public interface ITask
    {
        List<Task> GetAllTasks();
        Task GetTaskById(int id);
        List<Task> GetTaskByTypeId(int id);
        Task UpdateTask(int id, Task data);
        Task DeleteTask(int id);
        void CreateTask(Task task);

    }
}