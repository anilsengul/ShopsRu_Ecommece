namespace StoresRU_API.Models
{
    public class Basket
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
