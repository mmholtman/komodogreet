using System;
using System.Collections.Generic;
using KomodoGreet.Data;

namespace KomodoGreet.BLL
{
    public class CustomerService
    {
        public List<Customer> _customerList = new List<Customer>();


        public void CreateCustomer(string first, string last, string address, string cityAndState, int zip, CustomerType type)
        {
                Customer customer = new Customer(first, last, address, cityAndState, zip, type);
                AddCustomerToList(customer);        
        }

        public void AddCustomerToList(Customer customer)
        {
            _customerList.Add(customer);
        }

        public Customer SearchForCustomer(List<string> firstLast)
        {
            var customerFound = new Customer();
            foreach (var c in _customerList)
            {
                    
             foreach (var f in firstLast)
              {
                  if (f != c.FirstName && f != c.LastName)
                    {
                        continue;
                    }

                  customerFound = c;
                  break;
              }
            }

            return customerFound;
        }
    }
}