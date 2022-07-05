using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly amazonContext _context;

        public UsersController(amazonContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,MobileNumber,SecurityQuestion,Answer,Password,Address,City,State,Country")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

       

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Email == id);
        }


        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Login(User u)
        {
            try
            {
                if (u.Email != null)
                {
                    HttpContext.Session.SetString("Email", u.Email);
                    var res = (from i in _context.Users
                               where (i.Email == u.Email)
                        && (i.Password == u.Password)
                               select i).FirstOrDefault();
                    if (res != null)
                    {
                        return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Users");
        }

    }
}
