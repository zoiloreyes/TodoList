using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.ViewModel
{
    public class TodoTaskViewModel
    {
        private readonly ITodoTaskRepository _repo;
        public TodoTaskViewModel(ITodoTaskRepository repo)
        {
            repo = _repo;
            Tasks = new ObservableCollection<TodoTask>();
            LoadAsync();
        }

        public async Task LoadAsync()
        {
            var tasks = await _repo.GetAllAsync();

            foreach(var item in tasks)
            {
                Tasks.Add(item);
            }
        }

        public ObservableCollection<TodoTask> Tasks { get;}
    }
}
