using AppMvcNHibernate.Models;
using AppMvcNHibernate.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace AppMvcNHibernate.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(NHibernate.ISession session) => productRepository = new ProductRepository(session);

        // GET: Products
        public ActionResult Index()
        {
            return View(productRepository.FindAll().ToList());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            Product product = await productRepository.FindByID(id.Value);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(product);
        }

        //GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Quantity,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                await productRepository.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Product product = await productRepository.FindByID(id.Value);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Name,Quantity,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                await productRepository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Product product = await productRepository.FindByID(id.Value);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await productRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
