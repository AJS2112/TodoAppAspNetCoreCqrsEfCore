using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 01", "Batman", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 02", "Superman", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 03", "Superman", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 04", "Batman", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 05", "Batman", DateTime.Now));

        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_Batman()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Batman"));
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dada_a_consulta_deve_retornar_tarefas_concluidas_apenas_do_usuario_Batman()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("Batman"));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dada_a_consulta_deve_retornar_tarefas_por_concluir_apenas_do_usuario_Batman()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("Batman"));
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dada_a_consulta_deve_retornar_tarefas_apenaspor_concluir_do_usuario_Batman_do_dia_de_hoje()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("Batman", DateTime.Now, false));
            Assert.AreEqual(3, result.Count());
        }
    }
}