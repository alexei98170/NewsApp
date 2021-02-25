using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace NewsApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return View("Index");
        }
        [Authorize]
            public IActionResult Index()
            {
                return View("Index");
            }
            public async Task<IActionResult> Details(int? id)
            {
                if (id != null)
                {
                    User user = await db.News.FirstOrDefaultAsync(p => p.Id == id);
                    if (user != null)
                        return View(Index());
                }
                return NotFound();
            }
    }

    }


