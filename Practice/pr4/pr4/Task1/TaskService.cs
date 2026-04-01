using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task1
{
    public class TaskService
    {
        private List<TaskItem> taskItems;

        public TaskService(List<TaskItem> taskItems)
        {
            this.taskItems = taskItems ?? new List<TaskItem>();
        }

        public void Add(string title, bool status)
        {
            taskItems.Add(new TaskItem(title, status));
        }

        public void Delete(int index)
        {
            taskItems.RemoveAt(index);
        }

        public void UpdateStatus(int index, bool status)
        {
            taskItems[index].IsCompleted = status;
        }

        public List<TaskItem> GetAll() => taskItems;

        public bool IsEmpty() => !taskItems.Any();
    }
}
