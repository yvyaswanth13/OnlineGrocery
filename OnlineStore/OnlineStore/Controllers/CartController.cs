using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private readonly amazonContext _context;
        //public string email;

        public CartController(amazonContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Add(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string email = HttpContext.Session.GetString("Email");
            try
            {
                using (var httpClient = new HttpClient())
                {
                      StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44353/Cart?id=" + id + "&email=" + email, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        // p = JsonConvert.DeserializeObject<Product>(apiResponse);
                        ViewBag.message = apiResponse.ToLower();

                    }
                }


                return RedirectToRoute(new { action = "ByCategorey", controller = "Products", cat = _context.Products.Find(id).Category });
               // RedirectToAction("ByCategorey", "Products",_context.Products.Find(id).Category,);
            }
            catch(Exception e)
            {
                ViewBag.message = "invalid";
                return RedirectToAction("Index", "Products");
            }
        }

       
        public async Task<IActionResult> Remove(int id)
        {
       // https://localhost:44353/Cart?id=32&email=test%40gmail.com

            if (id == null)
            {
                return NotFound();
            }
            try
            {
                string email = HttpContext.Session.GetString("Email");

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync("https://localhost:44353/Cart?id=" + id + "&email=" + email, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        // p = JsonConvert.DeserializeObject<Product>(apiResponse);
                        string res = apiResponse.ToLower();
                        if (res.Equals("success"))
                            ViewBag.message = 1;

                    }
                }


                return RedirectToAction("myCart"); 
            }
            catch (Exception e)
            {
                ViewData["message"] = "invalid";
                return RedirectToAction("myCart");
            }
       
            return RedirectToAction("myCart");
        }

        public async Task<IActionResult> myCart()
        {
            string email= HttpContext.Session.GetString("Email");
            ViewBag.person = "user";
            List<Cart> carts = new List<Cart>();
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
                int total = (from ca in carts where ca.Email == "test@gmail.com" select ca).Sum(x => x.Total).Value;
                ViewBag.total = total;
                return View(carts);
                            }
        }

       
    }
}

//   var cart = await _context.Carts.FindAsync(id);
//   if (cart == null)
//   {
//       return NotFound();
//   }
//   //Cart c = new Cart();
//   //c.Email = "test@gmail.com";
//   //c.Price = product.Price;
//   //c.ProductId = product.Id;
//   //c.Pname = product.Name;
//   var update =
//_context.Carts.Where(x => x.ProductId == cart.ProductId && x.Email == "test@gmail.com")
// .FirstOrDefault();

//   // int count = _context.Carts.Count(a => a.ProductId == product.Id && a.Email == "test@gmail.com");
//   //if (update.Quantity >= 1 && update!=null)
//   //{

//   //}


//   if (update != null && update.Quantity==1)
//   {

//       _context.Carts.Remove(cart);
//       await _context.SaveChangesAsync();
//   }
//   else
//   {
//       cart.Quantity = update.Quantity - 1;
//       cart.Total = cart.Quantity * cart.Price;
//       var updatequery = _context.Carts.Where(x => x.ProductId == cart.ProductId && x.Email == "test@gmail.com")
//     .FirstOrDefault();
//       updatequery.Quantity = cart.Quantity;
//       updatequery.Total = cart.Total;
//       _context.SaveChanges();

//       await _context.SaveChangesAsync();
//   }
//   //User u = new User();
//   //u.Name = "Bobby";
//   //u.Email = "bob@gmail.com";
