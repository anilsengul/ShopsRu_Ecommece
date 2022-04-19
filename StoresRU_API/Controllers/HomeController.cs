using Microsoft.AspNetCore.Mvc;
using StoresRU_API.Models;

namespace StoresRU_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGeneric<Members> _members;
        private readonly IGeneric<Products> _products;
        private readonly IGeneric<Orders> _orders;
        //private readonly IGeneric<Basket> _basket;
        private readonly IBasket _basket;
        public HomeController(IGeneric<Members> members, IGeneric<Products> products, IGeneric<Orders> orders, IBasket basket)
        {
            this._members = members;
            this._products = products;
            this._orders=orders;
            this._basket = basket;
        }
        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            var model = _members.GetAll().FirstOrDefault(d=>d.Email == email && d.Password == password);
            if (model != null)
            {
                HttpContext.Session.SetInt32("uid",model.ID);
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult addMembers()
        {
            var newMember = new Members()
            {
                Name="Anıl",
                Surname="Şengül",
                Email="anilsengul92@gmail.com",
                isEmployee=true,
                isMember=false,
                DateOfRegistration = DateTime.Now,
                Password="1234"
            };
            _members.Create(newMember);
            return Ok();
        }
        [HttpPost]
        public IActionResult addBasket(int productID,int quantity)
        {
            if (HttpContext.Session.GetInt32("uid") != null)
            {   
                int memberID = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                var product = _products.GetByID(productID);
                var hasSameProduct = _basket.GetByID(productID);
                if (hasSameProduct != null)
                {
                    hasSameProduct.Quantity += 1;
                    hasSameProduct.Price = product.SalePrice;
                    _basket.Update(hasSameProduct);
                }
                else
                {
                    var basket = new Basket()
                    {
                        MemberID = memberID,
                        ProductID = productID,
                        Quantity = quantity,
                        Price = product.SalePrice
                    };
                    _basket.Create(basket);
                }
                
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpGet]
        public string getRandomString()
        {
            Random rnd = new Random();
            string pool = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz";
            string orderNo = "";
            for (int i = 0; i < 6; i++)
            {
                orderNo += pool[rnd.Next(pool.Length)];
            }
            return orderNo;
        }
        [HttpGet]
        public decimal calcultaTotalPrice(int memberID,decimal totalPrice)
        {
            var member = _members.GetByID(memberID);
            decimal discountAmount = 0;
            if (member.isEmployee)
            {
                discountAmount = (totalPrice * 30) / 100;
            }else if (member.isMember)
            {
                discountAmount = (totalPrice * 10) / 100;
            }else if ((DateTime.Now - member.DateOfRegistration).TotalDays > 2)
            {
                discountAmount = (totalPrice * 5) / 100;
            }
            decimal tempPrice = totalPrice - discountAmount;
            int lastDiscount = Convert.ToInt32(tempPrice / 100);

            return tempPrice - (lastDiscount*5);
        }
        [HttpPost]
        public IActionResult giveOrder()
        {
            if (HttpContext.Session.GetInt32("uid") != null)
            {
                decimal totalPrice = 0;
                int memberID = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                var allProduct = _basket.getBasketByMemberId(memberID);
                foreach (var product in allProduct)
                {
                    totalPrice += product.Quantity * product.Price;
                }
                decimal lastPrice = this.calcultaTotalPrice(memberID,totalPrice);
                string orderNo = this.getRandomString();
                Orders newOrder = new Orders()
                {
                    MemberID = memberID,
                    OrderDate = DateTime.Now,
                    TotalPrice = lastPrice,
                    OrderNo = orderNo,
                };
                _orders.Create(newOrder);
                _basket.deleteBasketByMemberId(memberID,orderNo);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
