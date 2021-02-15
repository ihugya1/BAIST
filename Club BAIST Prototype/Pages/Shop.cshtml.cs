using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC_Hardware.BLL;
using ABC_Hardware.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC_Hardware.Pages.Shared
{
    public class ShopModel : PageModel
    {
        private List<Item> _sampleObjectCollection = new List<Item>();
        public List<Item> SampleObjectCollection
        {
            get
            {
                return _sampleObjectCollection;
            }
        }
       
        [BindProperty]
        public string SearchParameter { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        [BindProperty]
        public string Message { get; set; }


        public Item item { get; set; }
        [BindProperty]
        public List<Item> items { get; set; }
        public void OnGet()
        {
            var items = new List<Item>()
            {
               
            };
            SessionHelper.SetObjectAsJson(HttpContext.Session, "items", items);
            items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "items");
        }
        public void OnPost()
        {
            string Parameter;
            bool confirm;
            ABCCS systemControl = new ABCCS();
            Parameter = SearchParameter;
            string[] subs = Submit.Split(' ');

            switch (subs[0])
            {

                case "Search":
                    _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
                    //  Message = $"OnPost - First - {FirstInputField}";
                    items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "items");
                    break;
                case "Add":
                    try
                    {
                        _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
                        Item item = new Item();
                        item = systemControl.GetAnItem(subs[1]);
                        items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "items");
                        bool flag = false;
                        foreach (var i in items)
                        {
                            if (item.ItemCode == i.ItemCode)
                            {
                                flag = true;
                            }
                        }
                        if (flag == false)
                        {
                            items.Add(item);
                            SessionHelper.SetObjectAsJson(HttpContext.Session, "items", items);
                            Message = $"{subs[1]} added";
                        }
                        else
                        {
                            Message = $"{subs[1]} already exists in the cart";
                        }
                        
                    }
                    catch (Exception e)
                    {

                        Message = $"Error {e}";
                    }

                    break;
                case "Remove":
                    try
                    {
                        _sampleObjectCollection = systemControl.SearchItemsByParam(Parameter);
                        Item item = new Item();
                        item = systemControl.GetAnItem(subs[1]);
                        items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "items");

                        var itemToRemove = items.Single(r => r.ItemCode == subs[1]);
                        items.Remove(itemToRemove);

                        SessionHelper.SetObjectAsJson(HttpContext.Session, "items", items);

                        Message = $"{subs[1]} removed";
                    }
                    catch (Exception e)
                    {

                        Message = $"Error {e}";
                    }
                    break;
                case "CheckOut":
                    
                    break;
                default:
                    break;





            }
        }
    }
}

