using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        TodoItem GetById(Guid id, string user);
        void Create(TodoItem todo);
        void Update(TodoItem todo);
    }
}