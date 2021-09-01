using System;
using System.Collections.Generic;

#nullable disable

namespace TaskListApi.Models
{
    public partial class TaskList
    {
        public int TaskListId { get; set; }
        public string TaskListTitle { get; set; }
        public string TaskListDetails { get; set; }
        public string AssigneeName { get; set; }
        public string Project { get; set; }
        public DateTime? Date { get; set; }
    }
}
