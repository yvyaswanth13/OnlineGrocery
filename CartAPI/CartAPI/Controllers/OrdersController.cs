using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CartAPI.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace CartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly amazonContext _context;

        public OrdersController(amazonContext context)
        {
            _context = context;
        }

        //GET: Orders by id
       [HttpGet]
        public async Task<ActionResult> GetById(string email)
        {
            var Order = await _context.Orders.Where(x => x.Email == email && (x.Status != null)).ToListAsync();
            // Product p = _context.products.Find(id);
            return Ok(Order);

        }
        [Route("AllOrders")]
        public async Task<ActionResult> AllOrders()
        {
            var Order = await _context.Orders.Where(x =>  (x.Status != null)).ToListAsync();
            // Product p = _context.products.Find(id);
            return Ok(Order);

        }
        [Route("GetOrders")]
        public async Task<IActionResult> OrderDetails(string email)
        {
             List<Cart> carts = new List<Cart>();
            List<Product> products = new List<Product>();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44353/Cart?email=" + email);
                if (Res.IsSuccessStatusCode)
                {
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;
                    carts = JsonConvert.DeserializeObject<List<Cart>>(ProResponse);

                }
                return Ok(carts.Where(x => x.Email == email));//(IActionResult)(carts.Where(x =>  x.Email == email));
            }

            //int total = (from ca in _context.Carts where ca.Email == "test@gmail.com" select ca).Sum(x => x.Total).Value;
            ////ViewBag.total = total;
            //var cart = await _context.Carts.ToListAsync();
            //ViewData["cart"] = cart;
            ////Order o = new Order();

            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> placeOrder([Bind("Email,MyEmail,Pname,ProductId,Address,City,State,Country,MobileNumber,OrderDate,DeliveryDate,PaymentMethod,TransactionId,Status")] Order order)
        {
            //if (id != order.Id)
            //{
            //    return NotFound();
            //}


            try
            {
                var cart = await _context.Carts.ToListAsync();
                foreach (var c in cart)
                {
                    int customerId = 100;

                    long ticks = DateTime.UtcNow.Ticks;

                    long orderId = customerId + ticks;

                    order.Id = orderId.GetHashCode();
                    order.Email = "test@gmail.com";
                    order.Pname = c.Pname;
                    order.Price = c.Price;
                    order.Quantity = c.Quantity;
                    order.ProductId = c.ProductId;
                    order.Status = "Processing";
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                }
                if (cart != null)
                {
                    _context.Carts.RemoveRange(cart);
                    _context.SaveChanges();
                    return Ok();

                }


                //  RemoveAll(x => x.Email == "test@gmail.com");


            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OrderExists(order.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            return Ok(); 
        }

    }
}
