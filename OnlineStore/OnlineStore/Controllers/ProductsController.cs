using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly amazonContext _context;
        public string Baseurl = "https://localhost:44303/";
        public string person;
        public string uname;
        public ProductsController(amazonContext context)
        {
           

            _context = context;

        }
        public async Task<IActionResult> ByCategorey(string cat)
        {
            try
            {
                ViewBag.cat = cat;
                if (HttpContext.Session.GetString("Email") != null)
                {
                    string s = HttpContext.Session.GetString("Email").ToString();
                    string[] arr = s.Split('@');
                    if (arr[0].Equals("admin"))
                    {
                        person = "admin";
                        uname = arr[0];
                    }
                    else
                    {
                        //uname[]
                        person = "user";
                    }

                    ViewBag.person = person;
                    List<Product> products = new List<Product>();
                    using (var client = new HttpClient())
                    {

                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(Baseurl);
                        HttpResponseMessage Res = await client.GetAsync("https://localhost:44368/Products");

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var ProResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            products = JsonConvert.DeserializeObject<List<Product>>(ProResponse);

                        }
                        //returning the employee list to view  
                        return View(products.Where(x=>x.Category==cat).ToList());
                    }
                }

                else
                {
                    return RedirectToAction("Login", "Users");

                }

            }
            catch (Exception e)
            {
                return View("Error");
            }
            //return View(await _context.Products.ToListAsync());
            //return View(await _context.Products.ToListAsync());
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(Index1("vegetables"));
        //}
        // GET: Products
        public async Task<IActionResult> Index()
              {
            try
            {
                    if (HttpContext.Session.GetString("Email")!=null)
                    {
                        string s = HttpContext.Session.GetString("Email").ToString();
                    string[] arr = s.Split('@');
                    if (arr[0].Equals("admin"))
                    {
                        person = "admin";
                        uname = arr[0];
                    }
                    else
                    {
                        //uname[]
                        person = "user";
                    }

                    ViewBag.person = person;
                    List<Product> products = new List<Product>();
                    using (var client = new HttpClient())
                    {

                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(Baseurl);
                        HttpResponseMessage Res = await client.GetAsync("https://localhost:44368/Products");

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var ProResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            products = JsonConvert.DeserializeObject<List<Product>>(ProResponse);

                        }
                        //returning the employee list to view  
                        return View(products);
                    }
                }

                else
                {
                    return RedirectToAction("Login", "Users");

                }
                
            }
            catch(Exception e)
            {
                return View("Error");
            }
                //return View(await _context.Products.ToListAsync());
                //return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Category,Price,Active")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Category,Price,Active")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
