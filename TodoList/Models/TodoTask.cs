using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TodoTask
    {
        public int TodoTaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is TodoTask))
            {
                return false;
            }

            var compared = obj as TodoTask;
            if(compared.TodoTaskID != TodoTaskID || 
                compared.Title != Title ||
                compared.Description != Description)
            {
                return false;
            }

            return true;
        }

        public static bool operator == (TodoTask x, TodoTask y)
        {
            return x.Equals(y);
        }

        public static bool operator != (TodoTask x, TodoTask y)
        {
            return !(x == y);
        }

    }
}
