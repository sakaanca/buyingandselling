﻿namespace ProjectWebAPI.Models.Products.ResponeModels
{
    public class ProductResponseModel
    {
        public int ID { get; set; } 
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
