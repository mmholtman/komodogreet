using System;
using System.Collections.Generic;
using System.Net.Mime;
using KomodoGreet.BLL;
using KomodoGreet.Contracts;
using KomodoGreet.Data;

namespace KomodoGreet.UI
{
    public class ProgramUI
    {
        private readonly IConsole _console;
        private readonly CustomerService _customerService = new CustomerService();

        public ProgramUI(IConsole consoleForAllReadsAndWrites)
        {
            _console = consoleForAllReadsAndWrites;
        }

        public void Run()
        {
            var finished = false;
            do
            {
                _console.Write("\nMain Menu\n\nWhat would you like to do?\n 1. Add a customer\n 2. See all customers \n 3. Search for customers \n 4. Exit Program\n");
                var command = _console.ReadLine().ToLower();

                if (String.IsNullOrWhiteSpace(command))
                {
                    finished = true;
                }
                else switch (command)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        List();
                        break;
                    case "3":
                        Search();
                        break;
                    case "4":
                        finished = true;
                        break;
                }
            } while (!finished);
        }

        public void Add()
        {
            var first = GetFirstName();
            var last = GetLastName();
            var address = GetAddress();
            var cityAndState = GetCityAndState();
            var zip = GetZip();
            var type = GetCustomerType();

            _customerService.CreateCustomer(first, last, address, cityAndState, zip, type);
            CreatedCustomerConfirmationMessage(first);
        }

        private string GetFirstName()
        {
            _console.WriteLine("First Name: ");
            var response = _console.ReadLine();
            return response;
        }

        private string GetLastName()
        {
            _console.WriteLine("Last Name: ");
            var response = _console.ReadLine();
            return response;
        }

        private string GetAddress()
        {
            _console.WriteLine("Address: ");
            var response = _console.ReadLine();
            return response;
        }

        private string GetCityAndState()
        {
            _console.WriteLine("City and State (City, State): ");
            var response = _console.ReadLine();
            return response;
        }

        private int GetZip()
        {
            _console.WriteLine("Zip Code: ");
            var response = _console.ReadLine();
            return Convert.ToInt32(response);
        }

        private CustomerType GetCustomerType()
        {
            _console.WriteLine("Customer Type (1 for Past, 2 for Potential, 3 for Current): ");
            var response = _console.ReadLine();
            var responseNumber = Convert.ToInt32(response);
            var type = CustomerType.Past;
            switch (responseNumber)
            {
                case 1:
                    type = CustomerType.Past;
                    break;
                case 2:
                    type = CustomerType.Potential;
                    break;
                case 3:
                    type = CustomerType.Current;
                    break;
            }
            return type;
        }

        private void CreatedCustomerConfirmationMessage(string first)
        {
            foreach (var i in _customerService._customerList)
            {
                var carAdded = _customerService._customerList.IndexOf(i);
                if (carAdded == _customerService._customerList.Count - 1)
                {
                    _console.WriteLine($"\n{first} was added.");
                }
            }
        }

        private void List()
        {
            _console.WriteLine("\n**Customer List**\nLastName   FirstName    Type");
            foreach (var i in _customerService._customerList)
            {
                _console.WriteLine(_customerService._customerList == null
                ? "Customer list is empty."
                : $"{i.LastName}   {i.FirstName}     {i.Type}");
            }
        }

        private void Search()
        {
            var response = GetNameToSearch();
            var firstLast = GetFirstAndLastNameFromInput(response);
            var customerFound = _customerService.SearchForCustomer(firstLast);

            if (customerFound.Equals(new Customer()))
            {
                CustomerNotFoundOutput();
            }
            else
            {
                CustomerFoundOutput(customerFound);
            }
        }

        private string GetNameToSearch()
        {
            _console.WriteLine("What is the name of the customer?");
            var response = _console.ReadLine();
            return response;
        }

        private static List<string> GetFirstAndLastNameFromInput(string name)
        {
            var words = name.Split(' ');
            var firstLast = new List<string>();
            var count = 0;

            foreach (var i in words)
            {
                count++;
                if (count <= 2)
                {
                    firstLast.Add(i);
                }
                
            }
            return firstLast;
        }

        private void CustomerFoundOutput(Customer customer)
        {
            _console.WriteLine($"\nCustomer Found. \nHere are {customer.FirstName}'s details");
            _console.WriteLine($"\n{customer.FirstName}, {customer.LastName}, Address - {customer.Address}, " +
            $"City/State - {customer.CityAndState} Zip - {customer.ZipCode}");
        }

        private void CustomerNotFoundOutput()
        {
            _console.WriteLine("Customer not found.");
        }

    }
}