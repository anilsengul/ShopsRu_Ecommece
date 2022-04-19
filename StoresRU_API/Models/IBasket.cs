namespace StoresRU_API.Models
{
    public interface IBasket:IGeneric<Basket>
    {
        IEnumerable<Basket> getBasketByMemberId(int id);
        void deleteBasketByMemberId(int id,string orderNo);
    }
}
