namespace StoresRU_API.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderNo { get; set; }
    }
}
