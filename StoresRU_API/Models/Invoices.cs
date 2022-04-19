namespace StoresRU_API.Models
{
    public class Invoices
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceAddress { get; set; }
        public decimal InvoiceTotalPrice { get; set; }

    }
}
