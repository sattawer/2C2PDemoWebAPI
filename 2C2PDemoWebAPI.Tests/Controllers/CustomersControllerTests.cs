using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using _2C2PDemoWebAPI.Controllers;

namespace _2C2PDemoWebAPI.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {

        [TestMethod]
        public void Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var unitUnderTest = mocker.Create<CustomersController>();

            // Act
            var result = unitUnderTest.Get();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Get_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var unitUnderTest = mocker.Create<CustomersController>();
            int id = 123456;

            // Act
            var result = unitUnderTest.Get(
                id);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Get_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var unitUnderTest = mocker.Create<CustomersController>();
            string email = "sattawee.r@gmail.com";

            // Act
            var result = unitUnderTest.Get(
                email);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Get_StateUnderTest_ExpectedBehavior3()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var unitUnderTest = mocker.Create<CustomersController>();
            string customerID = "123456";
            string email = "sattawee.r@gmail.com";

            // Act
            var result = unitUnderTest.Get(
                customerID,
                email);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void IsEmailValid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var unitUnderTest = mocker.Create<CustomersController>();
            string emailaddress = "sattawee.r@gmail.com";

            // Act
            var result = unitUnderTest.IsEmailValid(
                emailaddress);

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void IsCustomerIDValid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var unitUnderTest = mocker.Create<CustomersController>();
            string customerID = "123456";

            // Act
            var result = unitUnderTest.IsCustomerIDValid(
                customerID);

            // Assert
            Assert.Fail();
        }
    }
}
