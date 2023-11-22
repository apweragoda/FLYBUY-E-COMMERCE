using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext db;
        private readonly ILogger<ProductCategoryController> logger;

        public ProductCategoryController(ApplicationDbContext db, ILogger<ProductCategoryController> logger)
        {
            this.db = db;
            this.logger = logger;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            //var data = _db.ProductTypes.ToList();
            return Ok(db.ProductCategories.ToList());
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategories productCategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(productCategory);
                await db.SaveChangesAsync();
                //logger.LogInformation = "Product category has been saved";
                return Ok(productCategory);
            }

            return Ok(productCategory);
        }


        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductCategories productCategory)
        {
            if (ModelState.IsValid)
            {
                db.Update(productCategory);
                await db.SaveChangesAsync();
                logger.LogInformation("Product category has been updated");
                return RedirectToAction(nameof(Index));
            }
            return Ok(productCategory);
        }


        [HttpPost]
        [Route("Details")]
        [ValidateAntiForgeryToken]
        public  IActionResult Details(ProductCategories productCategory)
        {
            return RedirectToAction(nameof(Index));
            
        }


        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductCategories productCategory)
        {
            if(id==null)
            {
                return NotFound();
            }

            if(id!= productCategory.Id)
            {
                return NotFound();
            }

            var productType = db.ProductCategories.Find(id);
            if(productType==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                db.Remove(productType);
                await db.SaveChangesAsync();
                logger.LogInformation("Product type has been deleted");
                return RedirectToAction(nameof(Index));
            }

            return Ok(productType);
        }

    }
}