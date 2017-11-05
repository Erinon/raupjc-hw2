
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Razredi.Zad2;
using System.Collections.Generic;

namespace Zad3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());
        }

        [TestMethod]
        public void TestGetAll()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());

            for(int i = 0; i < 50; i++)
            {
                TodoItem item = new TodoItem($"No. {i} ");
                rep1.Add(item);
            }
            List<TodoItem> list = rep1.GetAll();
            
            Assert.AreEqual(50, list.Count);
        }

        [TestMethod]
        public void TestGetActive()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());

            for(int i = 0; i < 50; i++)
            {
                TodoItem item = new TodoItem($"No. {i} ");
                rep1.Add(item);
            }
            List<TodoItem> list = rep1.GetActive();

            Assert.IsTrue(list.Count == 50);
        }

        [TestMethod]
        public void TestGetCompleted()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());

            for(int i = 0; i < 50; i++)
            {
                TodoItem item = new TodoItem($"No. {i} ");
                item.MarkAsCompleted();
                rep1.Add(item);
            }
            List<TodoItem> list = rep1.GetCompleted();

            Assert.IsTrue(list.Count == 50);
        }
        
        [TestMethod]
        public void TestGetFiltered()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());

            for (int i = 0; i < 50; i++)
            {
                TodoItem item = new TodoItem($"No. {i} ");
                rep1.Add(item);
            }

            for (int i = 0; i < 25; i++)
            {
                rep1.MarkAsCompleted(rep1.GetAll()[i].Id);
            }

            List<TodoItem> list = rep1.GetFiltered(x => x.IsCompleted);

            Assert.IsTrue(list.Count == 25);
        }

        [TestMethod]
        public void TestRemove()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());

            for (int i = 0; i < 50; i++)
            {
                TodoItem item = new TodoItem($"No. {i} ");
                rep1.Add(item);
            }

            for (int i = 0; i < 25; i++)
            {
                rep1.Remove(rep1.GetAll()[i].Id);
            }
            List<TodoItem> list = rep1.GetAll();

            Assert.IsTrue(list.Count == 25);
        }

        [TestMethod]
        public void TestUpdate()
        {
            ITodoRepository rep1 = new TodoRepository(new GenericList<TodoItem>());

            for (int i = 0; i < 100; i++)
            {
                TodoItem item = new TodoItem($"No. {i} ");
                rep1.Add(item);
            }

            for (int i = 0; i < 90; i++)
            {
                TodoItem item = rep1.Get(rep1.GetAll()[i].Id);
                item.Text = "Kobasice";
                rep1.Update(item);
            }
            List<TodoItem> list = rep1.GetFiltered(x => x.Text.Equals("Kobasice"));

            Assert.IsTrue(list.Count == 90);
        }
        [TestMethod]
        public void TestTodoEquals()
        {
            TodoItem item1 = new TodoItem("Kobasica");
            TodoItem item2 = new TodoItem("Kobasica");
            TodoItem item3 = item1;
            TodoItem item4 = new TodoItem("Lollipop")
            {
                Id = item1.Id
            };

            Assert.IsTrue(!item1.Equals(item2) && !item2.Equals(item3) && item1.Equals(item3) && item4.Equals(item1));
        }
    }
}
