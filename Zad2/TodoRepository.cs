using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Razredi.Zad2
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }

            _inMemoryTodoDatabase = new GenericList<TodoItem>();
            
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if(this.Get(todoItem.Id) != null)
            {
                throw new DuplicateTodoItemException($" duplicate id: {todoItem.Id }");
            }
            
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
            
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId)).FirstOrDefault();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => i.DateCompleted == null).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Except(this.GetActive()).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => filterFunction(i)).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if(this.Get(todoId) == null)
            {
                return false;
            }

            return this.Get(todoId).MarkAsCompleted();
        }

        public bool Remove(Guid todoId)
        {
            if (this.Get(todoId) != null)
            {
                _inMemoryTodoDatabase.Remove(this.Get(todoId));
                return true;
            }

            return false;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (Get(todoItem.Id) == null)
            {
                Add(todoItem);
            }
            else
            {
                TodoItem temp = Get(todoItem.Id); ;
                temp = todoItem;
            }

            return todoItem;
        }
    }

    [Serializable]
    internal class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}