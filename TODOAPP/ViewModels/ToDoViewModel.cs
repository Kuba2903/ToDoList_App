using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TODOAPP.Models;

namespace TODOAPP.ViewModels
{
    public partial class ToDoViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ToDoItem> _todoList = new();

        private const string TodoListKey = "TodoList";
        public void AddTodo(ToDoItem todo)
        {
            if (!string.IsNullOrWhiteSpace(todo.Title))
            {
                _todoList.Add(todo);
            }
        }


        public void RemoveTodo(ToDoItem todo) => _todoList.Remove(todo);


        public void SaveTodos()
        {
            var json = JsonSerializer.Serialize(TodoList);
            Preferences.Set(TodoListKey, json);
        }

        public void LoadTodos()
        {
            if (Preferences.ContainsKey(TodoListKey))
            {
                var json = Preferences.Get(TodoListKey, string.Empty);
                if (!string.IsNullOrEmpty(json))
                {
                    var todos = JsonSerializer.Deserialize<ObservableCollection<ToDoItem>>(json);
                    if (todos != null)
                    {
                        TodoList = todos;
                    }
                }
            }
        }
    }
}
