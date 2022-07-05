using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly amazonContext _context;
        public string email;// "test@gmail.com";

        public OrdersController(amazonContext context)
        {
            
            _context = context;
        }

        //// GET: Orders
        //public async Task<IActionResult> Index()
        //{
        //    var amazonContext = _context.Orders.Where(x => x.Email == "test@gmail.com");
        //    //int total = (from ca in _context.Carts where ca.Email == "test@gmail.com" select ca).Sum(x => x.Total).Value;
        //    //ViewBag.total = total;
        //    //return View(await _context.Carts.ToListAsync());
        //    return View(await amazonContext.ToListAsync());
        //}

        //// GET: Orders/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Orders
        //        .Include(o => o.EmailNavigation)
        //        .Include(o => o.Product)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //// GET: Orders/Create
        //public IActionResult Create()
        //{
        //    ViewData["Email"] = new SelectList(_context.Users, "Email", "Email");
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
        //    return View();
        //}

        //// POST: Orders/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Email,MyEmail,Pname,ProductId,Address,City,State,Country,MobileNumber,OrderDate,DeliveryDate,PaymentMethod,TransactionId,Status")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(order);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Email"] = new SelectList(_context.Users, "Email", "Email", order.Email);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", order.ProductId);
        //    return View(order);
        //}

        //// GET: Orders/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Email"] = new SelectList(_context.Users, "Email", "Email", order.Email);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", order.ProductId);
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Email,MyEmail,Pname,ProductId,Address,City,State,Country,MobileNumber,OrderDate,DeliveryDate,PaymentMethod,TransactionId,Status")] Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(order);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderExists(order.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Email"] = new SelectList(_context.Users, "Email", "Email", order.Email);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", order.ProductId);
        //    return View(order);
        //}

        //// GET: Orders/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Orders
        //        .Include(o => o.EmailNavigation)
        //        .Include(o => o.Product)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);
        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrderExists(int id)
        //{
        //    return _context.Orders.Any(e => e.Id == id);
        //}

        public async Task<IActionResult> OrderDetails()
        {
            int total = (from ca in _context.Carts where ca.Email == "test@gmail.com" select ca).Sum(x => x.Total).Value;
            ViewBag.total = total;
            var cart = await _context.Carts.ToListAsync();
            ViewData["cart"] = cart;
            //Order o = new Order();
            //http://localhost:35974/Orders/GetOrders?email="+ email
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> placeOrder([Bind("Email,MyEmail,Pname,ProductId,Address,City,State,Country,MobileNumber,OrderDate,DeliveryDate,PaymentMethod,TransactionId,Status")] Order order)
        {
            //if (id != order.Id)
            //{
            //    return NotFound();

            //}
            email = HttpContext.Session.GetString("Email").ToString();
            Order o = new Order();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:35974/Orders?email="+ email, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    o = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }

            //    try
            //    {
            //    var cart = await _context.Carts.ToListAsync();
            //    foreach (var c in cart)
            //    {
            //        int customerId = 100;

            //        long ticks = DateTime.UtcNow.Ticks;

            //        long orderId = customerId + ticks;

            //        order.Id = orderId.GetHashCode();
            //        order.Email = "test@gmail.com";
            //        order.Pname = c.Pname;
            //        order.Price = c.Price;
            //        order.Quantity = c.Quantity;
            //        order.ProductId = c.ProductId;
            //        order.Status = "Processing";
            //        _context.Add(order);
            //        await _context.SaveChangesAsync();
            //    }
            //    if (cart != null)
            //    {
            //        _context.Carts.RemoveRange(cart);
            //        _context.SaveChanges();

            //    }


            //    //  RemoveAll(x => x.Email == "test@gmail.com");


            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    //if (!OrderExists(order.Id))
            //    //{
            //    //    return NotFound();
            //    //}
            //    //else
            //    //{
            //    //    throw;
            //    //}
            //}
            return RedirectToAction("showBill");
        }
        public List<Order> orders = new List<Order>();
        public async Task<IActionResult> showBill()
        {
            email = HttpContext.Session.GetString("Email").ToString();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("http://localhost:35974/Orders?email=" + email);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    orders = JsonConvert.DeserializeObject<List<Order>>(ProResponse);

                }
                //returning the employee list to view  
                //return View(orders);
                ViewData["Order"] = orders;
            }
           // var Order = await _context.Orders.Where(x => x.Email == "test@gmail.com").ToListAsync();
           
            return View();
        }

        public async Task<IActionResult> myOrders()
        {
            email = HttpContext.Session.GetString("Email").ToString();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("http://localhost:35974/Orders?email=" + email);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    orders = JsonConvert.DeserializeObject<List<Order>>(ProResponse);

                }
                //returning the employee list to view  
                //return View(orders);
                ViewData["Order"] = orders;
            }
            return View();
        }
        public async Task<IActionResult> OrdersRecived()
        {
            //email = HttpContext.Session.GetString("Email").ToString();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("http://localhost:35974/Orders/AllOrders");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    orders = JsonConvert.DeserializeObject<List<Order>>(ProResponse);

                }
                //returning the employee list to view  
                //return View(orders);
                ViewData["Order"] = orders.Where(x => x.Status == "Processing").ToList();
            }
            return View();
        }
        public async Task<IActionResult> OrderCancel(int id)
        {

            var update =
            _context.Orders.Where(x => x.Id ==id)
             .FirstOrDefault();
            update.Status = "Cancelled";
            _context.SaveChanges();

            return  RedirectToAction( "OrdersRecived");
        }
        public async Task<IActionResult> OrderDeliver(int id)
        {

            var update =
            _context.Orders.Where(x => x.Id == id)
             .FirstOrDefault();
            update.Status = "Delivered";
            _context.SaveChanges();

            return RedirectToAction("OrdersRecived"); ;
        }
        public async Task<IActionResult> CancelledOrders()
        {
            //email = HttpContext.Session.GetString("Email").ToString();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("http://localhost:35974/Orders/AllOrders");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    orders = JsonConvert.DeserializeObject<List<Order>>(ProResponse);

                }
                //returning the employee list to view  
                //return View(orders);
                List<Order>o = orders.Where(x => x.Status == "Cancelled").ToList();
                ViewData["Order"] = o;
            }
            return View("CancelledOrders");
        }

        public async Task<IActionResult> DeliveredOrders()
        {
            //email = HttpContext.Session.GetString("Email").ToString();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("http://localhost:35974/Orders/AllOrders");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    orders = JsonConvert.DeserializeObject<List<Order>>(ProResponse);

                }
                //returning the employee list to view  
                //return View(orders);
                //orders = 
                ViewData["Order"] = orders.Where(x => x.Status == "Delivered").ToList();
            }
            return View("DeliveredOrders");
        }

    }
}
