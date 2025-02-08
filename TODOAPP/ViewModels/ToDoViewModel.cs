using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOAPP.Models;

namespace TODOAPP.ViewModels
{
    public partial class ToDoViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ToDoItem> _todoList = new();

        public void AddTodo(ToDoItem todo)
        {
            if (!string.IsNullOrWhiteSpace(todo.Title))
            {
                _todoList.Add(todo);
            }
        }


        public void RemoveTodo(ToDoItem todo) => _todoList.Remove(todo);
    }
}
