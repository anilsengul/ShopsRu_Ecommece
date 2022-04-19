namespace StoresRU_API.Models
{
    public class BasketRepository : GenericRepository<Basket>,IBasket
    {
        private readonly DataContext _dbContext;
        public BasketRepository(DataContext context):base(context)
        {
            this._dbContext = context;
        }

        public void deleteBasketByMemberId(int id, string orderNo)
        {
            var order = _dbContext.Orders.Where(d=>d.MemberID == id && d.OrderNo == orderNo).FirstOrDefault();
            var productsInBasket = _dbContext.Basket.Where(d=>d.MemberID == id);
            foreach (var product in productsInBasket)
            {
                OrderDetails newDetails = new OrderDetails()
                {
                    OrderID = order.ID,
                    OrderNo = orderNo,
                    ProductID = product.ProductID,
                    Quantity = product.Quantity,
                    Price = product.Price
                };
                _dbContext.OrderDetails.Add(newDetails);
            }
            _dbContext.RemoveRange(productsInBasket);
            _dbContext.SaveChanges();

        }

        public IEnumerable<Basket> getBasketByMemberId(int id)
        {
            return _dbContext.Basket.Where(d => d.MemberID == id).ToList();
        }
    }
}
