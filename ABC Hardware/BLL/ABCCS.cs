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
        public Item GetAnItem(string itemCode)
        {
            Item item;
            Items itemManager = new Items();
            item = itemManager.GetItem(itemCode);
            return item;
        }


    }
}
