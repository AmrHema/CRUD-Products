using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSON_Select_Update_Delete.Models
{
    [MetadataType(typeof(Products_Custom))]
    public partial class Products
    {
        
    }
    public class Products_Custom
    {
        [Required]
        public int Cat_id { get; set; }
        [Required]

        public int Product_id { get; set; }
        [Required]

        public string Product_Name { get; set; }
        [Required]

        public decimal Product_Price { get; set; }
        [Required]
        public int Product_QTY { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Product_Writing_Date { get; set; }
        public string Product_Description { get; set; }
        public string Product_Image { get; set; }
    }
}