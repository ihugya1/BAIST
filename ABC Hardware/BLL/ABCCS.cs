using ABC_Hardware.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Hardware.BLL
{
    public class ABCCS
    {
        public bool AddAnItem(Item newItem)
        {
            bool Confirmation;
            Items itemManager = new Items();
            Confirmation = itemManager.AddItem(newItem);
            return Confirmation;
        }
        public List<Item> SearchItemsByParam(string searchParam)
        {
            List<Item> itemList = new List<Item>(); 
            Items itemManager = new Items();
            itemList = itemManager.GetItemsBySearchParam(searchParam);
            return itemList;
        }
        public bool DeleteAnItem(string itemCode)
        {
            bool Confirmation;
            Items itemManager = new Items();
            Confirmation = itemManager.DeleteItem(itemCode);
            return Confirmation;
        }

        public bool AddCustomer(Customer newCustomer)
        {
            bool Confirmation;
            Customers customerManager = new Customers();
            Confirmation = customerManager.AddCustomer(newCustomer);
            return Confirmation;
        }
        public bool DeleteCustomer(string customerID)
        {
            bool Confirmation;
            Customers customerManager = new Customers();
            Confirmation = customerManager.DeleteCustomer(customerID);
            return Confirmation;
        }
        public List<Customer> SearchCustomersByParam(string searchParam)
        {
            List<Customer> customerList = new List<Customer>();
            Customers customerManager = new Customers();
            customerList = customerManager.GetCustomerByParam(searchParam);
            return customerList;
        }
        public Item GetAnItem(string itemCode)
        {
            Item item;
            Items itemManager = new Items();
            item = itemManager.GetItem(itemCode);
            return item;
        }
        public Customer GetACustomer(string customerID)
        {
            Customer customer;
            Customers customerManager = new Customers();
            customer = customerManager.GetCustomer(customerID);
            return customer;
        }
        public bool UpdateAnItem(Item item)
        {
            bool Confirmation;
            Items itemsManager = new Items();
            Confirmation = itemsManager.UpdateItem(item);
            return Confirmation;
        }
        public bool UpdateACustomer(Customer customer)
        {
            bool Confirmation;
            Customers customersManager = new Customers();
            Confirmation = customersManager.UpdateCustomer(customer);
            return Confirmation;
        }



    }
}
