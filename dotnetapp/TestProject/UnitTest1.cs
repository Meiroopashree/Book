using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using System.Collections.Generic;
using System.Reflection;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _bcontroller;
        private IBookService _bookService;
        private OrderController _ocontroller;
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _bookService = new BookService(new BookRepository());
            _bcontroller = new BookController(_bookService);
            _orderService = new OrderService(new OrderRepository());
            _ocontroller = new OrderController(_orderService);
        }

        [Test]
        public void GetAllBooks_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _bcontroller.GetAllBooks() as ActionResult<List<Book>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetBook_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingBookId = 999;

            // Act
            var result = _bcontroller.GetBook(nonExistingBookId) as ActionResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddBook_ValidData_ReturnsOk()
        {
            // Arrange
            var newBook = new Book
            {
                BookId = 2,
                BookName = "New Book",
                Category = "Fiction",
                Price = 15.99M
            };

            // Act
            var result = _bcontroller.AddBook(newBook) as ActionResult<Book>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void DeleteBook_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingBookId = 999;

            // Act
            var result = _bcontroller.DeleteBook(nonExistingBookId) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void GetAllOrders_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _ocontroller.GetAllOrders() as ActionResult<List<Order>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetOrder_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingOrderId = 999;

            // Act
            var result = _ocontroller.GetOrder(nonExistingOrderId) as ActionResult<Order>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddOrder_ValidData_ReturnsOk()
        {
            // Arrange
            var newOrder = new Order
            {
                OrderId = 2,
                CustomerName = "John Doe",
                TotalAmount = 100
            };

            // Act
            var result = _ocontroller.AddOrder(newOrder) as ActionResult<Order>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void DeleteOrder_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingOrderId = 999;

            // Act
            var result = _ocontroller.DeleteOrder(nonExistingOrderId) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
      // Test to check whether Book Model Class exists
        [Test]
        public void Book_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type bookType = assembly.GetType(typeName);
            Assert.IsNotNull(bookType);
        }
         // Test to check whether Order Model Class exists
        [Test]
        public void Order_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Order";
            Assembly assembly = Assembly.Load(assemblyName);
            Type orderType = assembly.GetType(typeName);
            Assert.IsNotNull(orderType);
        }
// Test to check whether BookRepository Class exists
        [Test]
        public void BookRepository_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.BookRepository";
            Assembly assembly = Assembly.Load(assemblyName);
            Type cType = assembly.GetType(typeName);
            Assert.IsNotNull(cType);
        }
         // Test to check whether OrderRepository Class exists
        [Test]
        public void OrderRepository_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.OrderRepository";
            Assembly assembly = Assembly.Load(assemblyName);
            Type orderType = assembly.GetType(typeName);
            Assert.IsNotNull(orderType);
        }
// Test to check whether BookService Class exists
        [Test]
        public void BookService_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.BookService";
            Assembly assembly = Assembly.Load(assemblyName);
            Type cType = assembly.GetType(typeName);
            Assert.IsNotNull(cType);
        }
// Test to check whether OrderService Class exists
        [Test]
        public void OrderService_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.OrderService";
            Assembly assembly = Assembly.Load(assemblyName);
            Type cType = assembly.GetType(typeName);
            Assert.IsNotNull(cType);
        }
        [Test]
        public void BookControllerExists()
        {
            Assert.That(typeof(BookController), Is.Not.Null);
        }
[Test]
        public void OrderControllerExists()
        {
            Assert.That(typeof(OrderController), Is.Not.Null);
        }

         [Test]
        public void BookModel_Should_Have_BookName_Property()
        {
            // Arrange
            var BookModel = new Book();

            // Act

            // Assert
            Assert.That(HasProperty(BookModel, "BookName"), Is.True);
        }
         [Test]
        public void BookModel_Should_Have_Category_Property()
        {
            // Arrange
            var BookModel = new Book();

            // Act

            // Assert
            Assert.That(HasProperty(BookModel, "Category"), Is.True);
        }
         [Test]
        public void OrderModel_Should_Have_CustomerName_Property()
        {
            // Arrange
            var orderModel = new Order();

            // Act

            // Assert
            Assert.That(HasProperty(orderModel, "CustomerName"), Is.True);
        }
         [Test]
        public void orderModel_Should_Have_TotalAmount_Property()
        {
            // Arrange
           var orderModel = new Order();

            // Act

            // Assert
            Assert.That(HasProperty(orderModel, "TotalAmount"), Is.True);
        }

        private bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
    }
}
