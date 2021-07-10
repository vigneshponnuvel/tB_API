using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using shopBridge.DataProvider;
using shopBridge.Models;

namespace NUnit_shopBridge
{
    public class ItemServiceFake : IItemDataProvider
    {
        private readonly List<Inventory> items;
        private readonly Inventory item_Detail;

        public ItemServiceFake()
        {
            items = new List<Inventory>()
            {
                new Inventory() {
                    Itemid = 150,
                    Itemname = "Monitor",
                    Itemdescription = "Computer accessories - display",
                    Itemprice = 10000,
                    Itemquantity = 20
                },

               new Inventory() {
                    Itemid = 200,
                    Itemname = "Mouse",
                    Itemdescription = "Computer accessories - input",
                    Itemprice = 500,
                    Itemquantity = 25
               }
            };

            item_Detail = new Inventory()
                {
                    Itemid = 150,
                    Itemname = "Monitor",
                    Itemdescription = "Computer accessories - display",
                    Itemprice = 10000,
                    Itemquantity = 20
                };
        }

        public async Task<IEnumerable<Inventory>> GetItems()
        {
            await Task.Run(() =>
            {

            });
            return items;
        }        

        public async Task AddItem(Inventory item)
        {
            
        }

        public async Task UpdateItem(Inventory item)
        {
            
        }

        public async Task DeleteItem(int itemId)
        {

        }

        public async Task<Inventory> GetOne(int itemID)
        {
            await Task.Run(() =>
            {

            });
            return items.Find(x => x.Itemid == 150);
        }
    }
}
