using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task2
{
    public class TaskService
    {
        private List<StudentItem> StudentItems;

        public TaskService(List<StudentItem> StudentItems)
        {
            this.StudentItems = StudentItems ?? new List<StudentItem>();
        }

        public void Add(string name, int age, double averageScore)
        {
            StudentItems.Add(new StudentItem(name, age, averageScore));
        }

        public void Delete(int index)
        {
            StudentItems.RemoveAt(index);
        }

        public List<StudentItem> GetAll() => StudentItems;

        public bool IsEmpty() => !StudentItems.Any();
    }
}
