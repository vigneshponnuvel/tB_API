using System;
using System.Collections.Generic;

#nullable disable

namespace shopBridge.Models
{
    //Model for the Databse. Table Name: Inventory
    public partial class Inventory
    {
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public string Itemdescription { get; set; }
        public int Itemprice { get; set; }
        public int Itemquantity { get; set; }
        public DateTime Itemadddate { get; set; }
    }
}
