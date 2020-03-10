using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Ex_5.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Complete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public TaskType Type { get; set; }
    }
}