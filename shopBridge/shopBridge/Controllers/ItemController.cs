using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using shopBridge.Models;
using shopBridge.DataProvider;

namespace shopBridge.Controllers
{
    //Item Controller
    //Routing has been setup as URL/api/controller_name/action
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemDataProvider itemDataProvider;

        //Constructor
        public ItemController(IItemDataProvider itemDataProvider)
        {
            this.itemDataProvider = itemDataProvider;
        }

        //Get action to view all the entries in the table. Action name: view
        [HttpGet, ActionName("view")]        
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await this.itemDataProvider.GetItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            
        }

        //Post action to update an entry. Action Name: update
        [HttpPost, ActionName("update")]
        public async Task<ActionResult<Inventory>> UpdateItem([FromBody] Inventory item)
        {
            try
            {
                await this.itemDataProvider.UpdateItem(item);
                return StatusCode(StatusCodes.Status200OK, "Successfully updated the record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in updating the record");
            }            
        }

        //Post action to insert an item. Action Name: add
        [HttpPost, ActionName("add")]        
        public async Task<ActionResult<Inventory>> PostItem([FromBody] Inventory item)
        {
            try
            {
                await this.itemDataProvider.AddItem(item);
                return StatusCode(StatusCodes.Status200OK, "Successfully inserted the record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in inserting the record");
            }            
        }

        //Delete action to delete an entry. Action Name: delete
        [HttpDelete("{id:int}"), ActionName("delete")]        
        public async Task<ActionResult<Inventory>> DeleteItem(int id)
        {
            try
            {
                await this.itemDataProvider.DeleteItem(id);
                return StatusCode(StatusCodes.Status200OK, "Successfully deleted the record");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in deleting the record");
            }
        }

        //Get action to view only one item. Action: getone
        [HttpGet("{id:int}"), ActionName("getone")]
        public async Task<ActionResult> GetOne(int id)
        {
            try
            {
                
                return Ok(await this.itemDataProvider.GetOne(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }
    }
}
