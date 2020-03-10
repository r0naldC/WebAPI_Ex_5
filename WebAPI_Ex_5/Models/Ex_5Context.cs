using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI_Ex_5.Models
{
    public class Ex_5Context: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }

        public Ex_5Context()
            : base("name=DefaultConnection")
        {

        }
    }
}