using _0._Models;
using _2._Data_Layer_Abstraction;
using System;
using System.Linq;
using Xunit;

namespace Assignment4.Tests
{
    public class DataServiceTests
    {
        /* Categories */
        [Fact]
        public void Category_Object_HasIdNameAndDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.Id);
            Assert.Null(category.Name);
            Assert.Null(category.Description);
        }

        [Fact]
        public void GetAllCategories_NoArgument_ReturnsAllCategories()
        {
            ICategoryRepository service = null;
            var categories = service.GetAll().ToList();
            Assert.Equal(8, categories.Count);
            Assert.Equal("Beverages", categories.First().Name);
        }

        [Fact]
        public void GetCategory_ValidId_ReturnsCategoryObject()
        {
            ICategoryRepository service = null;
            var category = service.GetById(1);
            Assert.Equal("Beverages", category.Name);
        }

        [Fact]
        public void CreateCategory_ValidData_CreteCategoryAndRetunsNewObject()
        {
            ICategoryRepository service = null;
            var category = service.Create("Test", "CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");
            Assert.True(category.Id > 0);
            Assert.Equal("Test", category.Name);
            Assert.Equal("CreateCategory_ValidData_CreteCategoryAndRetunsNewObject", category.Description);

            // cleanup
            service.Delete(category.Id);
        }

        [Fact]
        public void DeleteCategory_ValidId_RemoveTheCategory()
        {
            ICategoryRepository service = null;
            var category = service.Create("Test", "DeleteCategory_ValidId_RemoveTheCategory");
            var result = service.Delete(category.Id);
            Assert.True(result);
            category = service.GetById(category.Id);
            Assert.Null(category);
        }

        [Fact]
        public void DeleteCategory_InvalidId_ReturnsFalse()
        {
            ICategoryRepository service = null;
            var result = service.Delete(-1);
            Assert.False(result);
        }

        [Fact]
        public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        {
            ICategoryRepository service = null;
            var category = service.Create("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");

            var result = service.Update(category.Id, "UpdatedName", "UpdatedDescription");
            Assert.True(result);

            category = service.GetById(category.Id);

            Assert.Equal("UpdatedName", category.Name);
            Assert.Equal("UpdatedDescription", category.Description);

            // cleanup
            service.Delete(category.Id);
        }

        [Fact]
        public void UpdateCategory_InvalidID_ReturnsFalse()
        {
            ICategoryRepository service = null;
            var result = service.Update(-1, "UpdatedName", "UpdatedDescription");
            Assert.False(result);
        }


        /* products */

        [Fact]
        public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
        {
            var product = new Product();
            Assert.Equal(0, product.Id);
            Assert.Null(product.Name);
            Assert.Equal(0.0, product.UnitPrice);
            Assert.Null(product.QuantityPerUnit);
            Assert.Equal(0, product.UnitsInStock);
        }

        [Fact]
        public void GetProduct_ValidId_ReturnsProductWithCategory()
        {
            IProductRepository service = null;
            var product = service.GetById(1);
            Assert.Equal("Chai", product.Name);
            Assert.Equal("Beverages", product.Category.Name);
        }

        [Fact]
        public void GetProductsByCategory_ValidId_ReturnsProductWithCategory()
        {
            IProductRepository service = null;
            var products = service.GetByCategoryId(1).ToList();
            Assert.Equal(12, products.Count);
            Assert.Equal("Chai", products.First().Name);
            Assert.Equal("Beverages", products.First().Category.Name);
            Assert.Equal("Lakkalikööri", products.Last().Name);
        }

        [Fact]
        public void GetProduct_NameSubString_ReturnsProductsThatMachesTheSubString()
        {
            IProductRepository service = null;
            var products = service.GetByContainedSubstringInName("em").ToList();
            Assert.Equal(4, products.Count);
            Assert.Equal("NuNuCa Nuß-Nougat-Creme", products.First().Name);
            Assert.Equal("Flotemysost", products.Last().Name);
        }

        /* orders */
        [Fact]
        public void Order_Object_HasIdDatesAndOrderDetails()
        {
            var order = new Order();
            Assert.Equal(0, order.Id);
            Assert.Equal(new DateTime(), order.Date);
            Assert.Equal(new DateTime(), order.Required);
            Assert.Null(order.OrderDetails);
            Assert.Null(order.ShipName);
            Assert.Null(order.ShipCity);
        }

        [Fact]
        public void GetOrder_ValidId_ReturnsCompleteOrder()
        {
            IOrderRepository service = null;
            var order = service.GetById(10248);
            Assert.Equal(3, order.OrderDetails.Count);
            Assert.Equal("Queso Cabrales", order.OrderDetails.First().Product.Name);
            Assert.Equal("Dairy Products", order.OrderDetails.First().Product.Category.Name);
        }

        [Fact]
        public void GetOrders()
        {
            IOrderRepository service = null;
            var orders = service.GetAll().ToList();
            Assert.Equal(830, orders.Count);
        }


        /* orderdetails */
        [Fact]
        public void OrderDetails_Object_HasOrderProductUnitPriceQuantityAndDiscount()
        {
            var orderDetails = new OrderDetails();
            Assert.Equal(0, orderDetails.OrderId);
            Assert.Null(orderDetails.Order);
            Assert.Equal(0, orderDetails.ProductId);
            Assert.Null(orderDetails.Product);
            Assert.Equal(0.0, orderDetails.UnitPrice);
            Assert.Equal(0.0, orderDetails.Quantity);
            Assert.Equal(0.0, orderDetails.Discount);
        }

        [Fact]
        public void GetOrderDetailByOrderId_ValidId_ReturnsProductNameUnitPriceAndQuantity()
        {
            IOrderDetailsRepository service = null;
            var orderDetails = service.GetByOrderId(10248).ToList();
            Assert.Equal(3, orderDetails.Count);
            Assert.Equal("Queso Cabrales", orderDetails.First().Product.Name);
            Assert.Equal(14, orderDetails.First().UnitPrice);
            Assert.Equal(12, orderDetails.First().Quantity);
        }

        [Fact]
        public void GetOrderDetailByProductId_ValidId_ReturnsOrderDateUnitPriceAndQuantity()
        {
            IOrderDetailsRepository service = null;
            var orderDetails = service.GetByProductId(11).ToList();
            Assert.Equal(38, orderDetails.Count);
            Assert.Equal("1997-05-06", orderDetails.First().Order.Date.ToString("yyyy-MM-dd"));
            Assert.Equal(21, orderDetails.First().UnitPrice);
            Assert.Equal(3, orderDetails.First().Quantity);
        }
    }
}
