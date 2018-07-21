using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.ViewModel
{
    public class MainViewModel
    {
        
        public MainViewModel(TodoTaskViewModel todoTaskViewModel)
        {
            TodoTaskViewModel = todoTaskViewModel;
        }

        public TodoTaskViewModel TodoTaskViewModel { get; set; }
    }
}
