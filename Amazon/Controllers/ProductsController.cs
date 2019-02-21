using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amazon.DAL;
using Amazon.Models;
using System.Net.Http;

namespace Amazon.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["Id"] = id;

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Inventory inventory)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55761/");
            var response = await client.PutAsJsonAsync($"api/inventories/{inventory.ID}", inventory);

            return RedirectToAction("Details", new { Id = inventory.ID });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
