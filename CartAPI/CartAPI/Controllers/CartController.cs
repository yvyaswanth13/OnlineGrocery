using CartAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CartController : ControllerBase
    {
        
        private readonly amazonContext _context;
        public string tmail = "test@gmail.com";

        public CartController(amazonContext context)
        {
            _context = context;
        }
        [HttpPost]
        public string insert(int id,string email)
        {
            //"test@gmail.com"
            if (id == null)
            {
                return "";
            }
            try
            {

                var product =  _context.Products.Find(id);
                if (product == null)
                {
                    return "";
                }
                Cart c = new Cart();
                c.Email = email;
                c.Price = product.Price;
                c.ProductId = product.Id;
                c.Pname = product.Name;
                var update =
             _context.Carts.Where(x => x.ProductId == product.Id && x.Email == email)
              .FirstOrDefault();

                // int count = _context.Carts.Count(a => a.ProductId == product.Id && a.Email == "test@gmail.com");
                //if (update.Quantity >= 1 && update!=null)
                //{

                //}


                if (update == null)
                {
                   // ViewBag.message = "added";
                    c.Quantity = 1;
                    c.Total = c.Quantity * c.Price;
                    _context.Carts.Add(c);
                    _context.SaveChanges();
                    return "added";
                }
                else
                {
                    //ViewBag.message = "extra";
                    c.Quantity = update.Quantity + 1;
                    c.Total = c.Quantity * c.Price;
                    var updatequery = _context.Carts.Where(x => x.ProductId == product.Id && x.Email == email)
                  .FirstOrDefault();
                    updatequery.Quantity = c.Quantity;
                    updatequery.Total = c.Total;
                    _context.SaveChanges();

                    return "extra";
                }
                         }
            catch (Exception e)
            {
                return "invalid";
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cart>> Get( string email)
        {
            List<Cart> carts = _context.Carts.Where(x => x.Email == email).ToList();
            return carts;
        }
        //async Task<ActionResult>
        [HttpPut]
        public string Remove(int id, string email)
        {
            //if (id == null)
            //{
            //    return ;
            //}

            var cart =  _context.Carts.Find(id);
            //if (cart == null)
            //{
            //    return "";
            //}
            var update =
         _context.Carts.Where(x => x.ProductId == cart.ProductId && x.Email == email)
          .FirstOrDefault();


            if (update != null && update.Quantity == 1)
            {

                _context.Carts.Remove(cart);
                _context.SaveChangesAsync();
                return "success";
            }
            else
            {
                cart.Quantity = update.Quantity - 1;
                cart.Total = cart.Quantity * cart.Price;
                var updatequery = _context.Carts.Where(x => x.ProductId == cart.ProductId && x.Email == email)
              .FirstOrDefault();
                updatequery.Quantity = cart.Quantity;
                updatequery.Total = cart.Total;
                _context.SaveChanges();

                 _context.SaveChanges();
                return "success";
            }
            
        }
        
        //public async Task<IActionResult> myCart()
        //{
        //    int total = (from ca in _context.Carts where ca.Email == "test@gmail.com" select ca).Sum(x => x.Total).Value;
        //    ViewBag.total = total;
        //    return View(await _context.Carts.ToListAsync());
        //}

    }
}
