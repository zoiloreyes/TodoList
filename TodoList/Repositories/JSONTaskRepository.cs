using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using TodoList.Models;
using System.Configuration;
using Newtonsoft.Json;

namespace TodoList.Repositories
{
    class JSONTaskRepository : ITodoTaskRepository
    {

        public List<TodoTask> Tasks { get; set; }
        private string directory { get; set; }
        private string file { get; set; }
        public JSONTaskRepository()
        {
            loadData();
        }

        private void loadData()
        {
            string exeDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string relativePath = ConfigurationManager.AppSettings["RelativeJsonStoreLocation"];

            directory = Path.GetFullPath(Path.Combine(exeDirectory, relativePath));
            file = Path.Combine(directory, "Tasks.json");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            try
            {
                Tasks = JsonConvert.DeserializeObject<TodoTask[]>(File.ReadAllText(file)).ToList();

            }catch(Exception e)
            {
                Tasks = new List<TodoTask>();
                Console.Write("Cant read");
            }
        }

        public void Add(TodoTask model)
        {
            int newId = Tasks.Max(t => t.TodoTaskID) + 1;
            model.TodoTaskID = newId;
            Tasks.Add(model);
        }

        public async Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<TodoTask>>(Tasks);
        }

        public Task<TodoTask> GetByIdAsync(int id)
        {
            var selectedTask = Tasks.FirstOrDefault(t => t.TodoTaskID == id);
            return Task.FromResult<TodoTask>(selectedTask);
        }

        public void Remove(TodoTask model)
        {
            var toRemove = Tasks.FirstOrDefault(task => task == model);
            Tasks.Remove(toRemove);
        }

        public Task SaveAsync()
        {
            string json = JsonConvert.SerializeObject(Tasks.ToArray());
            File.WriteAllText(file,json);
            return Task.FromResult(0);
        }
    }
}
