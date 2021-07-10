using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Dapper;
using shopBridge.Models;

namespace shopBridge.DataProvider
{
    public class ItemDataProvider : IItemDataProvider
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=SHOPBRIDGE;Trusted_Connection=True;";
        
        public async Task<IEnumerable<Inventory>> GetItems()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Inventory>(
                    "spSelectItemsAll",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddItem(Inventory item)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@p_ITEMNAME", item.Itemname);
                dynamicParameters.Add("@p_ITEMDESCRIPTION", item.Itemdescription);
                dynamicParameters.Add("@p_ITEMPRICE", item.Itemprice);
                dynamicParameters.Add("@p_ITEMQUANTITY", item.Itemquantity);

                await sqlConnection.ExecuteAsync(
                    "spAddItem",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateItem(Inventory item)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@p_ITEMID", item.Itemid);
                dynamicParameters.Add("@p_ITEMNAME", item.Itemname);
                dynamicParameters.Add("@p_ITEMDESCRIPTION", item.Itemdescription);
                dynamicParameters.Add("@p_ITEMPRICE", item.Itemprice);
                dynamicParameters.Add("@p_ITEMQUANTITY", item.Itemquantity);

                await sqlConnection.ExecuteAsync(
                    "spUpdateItem",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteItem(int itemId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@p_ITEMID", itemId);                

                await sqlConnection.ExecuteAsync(
                    "spDeleteItem",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Inventory> GetOne(int itemId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@p_ITEMID", itemId);

                return await sqlConnection.QuerySingleOrDefaultAsync<Inventory>(
                    "spSelectItemsOne",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
