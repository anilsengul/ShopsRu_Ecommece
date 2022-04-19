namespace StoresRU_API.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string StockCode { get; set; }
        public int Stock { get; set; }
        public string CurrencyCode { get; set; }
        public decimal KDVRate { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int BrandID { get; set; }
    }
}
