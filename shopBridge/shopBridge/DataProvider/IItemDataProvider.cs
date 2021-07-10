using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using shopBridge.Models;

namespace shopBridge.DataProvider
{
    //Interface for the Item controller
    public interface IItemDataProvider
    {
        Task<IEnumerable<Inventory>> GetItems();

        Task AddItem(Inventory item);

        Task UpdateItem(Inventory item);

        Task DeleteItem(int itemID);

        Task<Inventory> GetOne(int itemID);
    }
}
