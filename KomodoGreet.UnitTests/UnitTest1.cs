using System;
using System.Collections.Generic;
using KomodoGreet.BLL;
using KomodoGreet.Data;
using KomodoGreet.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoGreet.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly CustomerService _customerService = new CustomerService();

        [TestMethod]
        public void AddCustomerToMasterList_ShouldSucceed()
        {
            //Arrange
            Customer customer = new Customer("Kevin", "Curnow", "123 Soft Skills Lane", "Carmel, IN", 46032, CustomerType.Potential);
            //Act
            _customerService.AddCustomerToList(customer);
            var actuaList = _customerService._customerList;
            var expectedList = new List<Customer> {customer};
            //Assert
            CollectionAssert.AreEqual(expectedList, actuaList);
        }

        [TestMethod]

        public void AddPotentialCustomerType_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new[]
                {"1", "Kevin", "Curnow", "123 Soft Skills Lane", "Carmel, IN", "46220", "1"});

            //Act
            var programUI = new ProgramUI(mockConsole);

            //Act         
            programUI.Run();
            var outputText = mockConsole.Output;
            //Assert
            StringAssert.Contains(outputText, "Kevin was added.");
        }

        [TestMethod]

        public void AddCurrentCustomerType_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new[]
                {"1", "Kevin", "Curnow", "123 Soft Skills Lane", "Carmel, IN", "46220", "2"});
            var programUI = new ProgramUI(mockConsole);

            //Act         
            programUI.Run();
            var outputText = mockConsole.Output;
            //Assert
            StringAssert.Contains(outputText, "Kevin was added.");
        }

        [TestMethod]
        public void SeeAllCustomers_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new[] { "1", "Kevin", "Curnow", "123 Soft Skills Lane", "Carmel, IN",
                "46032", "3", "2", "4" });
            var programUI = new ProgramUI(mockConsole);
            //Act         
            programUI.Run();
            var outputText = mockConsole.Output;
            //Assert
            StringAssert.Contains(outputText, "**Customer List**");
        }

        [TestMethod]

        public void SearchForASpecificCustomer_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new[] { "1", "Kevin", "Curnow", "123 Soft Skills Lane", "Carmel, IN",
                "46032", "3", "2", "1", "Max", "Holtman", "14531 Saddleback Drive", "Indianapolis, IN", "46220", "3", "2", "3", "Max" });
            var programUI = new ProgramUI(mockConsole);
            //Act
            programUI.Run();
            var outputText = mockConsole.Output;
            //Assert
            StringAssert.Contains(outputText, "Customer Found");
        }

        [TestMethod]

        public void CustomerNotFound_ShouldSucceed()
        {
            //Arrange
            var mockConsole = new MockConsole(new[] {"3", "Donkey Kong"});
            var programUI = new ProgramUI(mockConsole);
            //Act
            programUI.Run();
            var outputText = mockConsole.Output;
            //Assert
            StringAssert.Contains(outputText, "Customer not found.");

        }
    }
}
