using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Ex_5.Models;
using WebAPI_Ex_5.Services;

namespace WebAPI_Ex_5.Controllers
{
    public class TasksController : ApiController
    {
        private readonly Ex_5Context db = new Ex_5Context();
        private readonly TaskService _taskService = new TaskService();

        [HttpGet]
        [Route("api/tasks")]
        public List<Task> GetTasks()
        {
            return _taskService.GetAllTasks();
        }

        [HttpGet]
        [Route("api/task/{id}")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask([FromUri] int id)
        {
            var task = _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut]
        [Route("api/updateTask/{id}")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult PutTask([FromUri] int id, [FromBody] Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            return Ok(_taskService.UpdateTask(id, task));
        }

        [HttpPost]
        [Route("api/createTask")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask([FromBody] Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _taskService.CreateTask(task);

            return Ok(task);
        }

        [HttpDelete]
        [Route("api/deleteTask/{id}")]
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask([FromUri] int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.DeleteTask(id);

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.Id == id) > 0;
        }
    }
}