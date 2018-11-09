using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_NETCoreMVC.Data;
using eShop_NETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShop_NETCoreMVC.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class ProductsController : Controller
  {
    private readonly ApplicationDbContext _db;

    public ProductsController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      return View(_db.Products.ToList());
    }

    //GET Create action method
    public IActionResult Create()
    {
      return View();
    }

    //POST Create action method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
      if (ModelState.IsValid)
      {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(product);
    }
  }
}