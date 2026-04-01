using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task1
{
    public class TaskItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title = "undefined", bool isCompleted = false)
        {
            Title = title;
            IsCompleted = isCompleted;
        }
    }
}
