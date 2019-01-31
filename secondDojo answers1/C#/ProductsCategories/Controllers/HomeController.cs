using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using ProductsCategories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ProductsCategories.Controllers
{
    public class HomeController : Controller
    {
        private PCContext _context;

        public HomeController(PCContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Product")]
        public IActionResult productaction(ProdViewModels addproduct)
        {
            if (ModelState.IsValid)
            {
                Product addnew = _context.Products.SingleOrDefault(product => product.Name == addproduct.Name);
                if (addnew != null)
                {
                    ViewBag.Message = "This product already exists in the database. Add something else!";
                    return View("Index", addproduct);
                }
                Product AddProductinDB = new Product
                {
                    Name = addproduct.Name,
                    Description = addproduct.Description,
                    Price = addproduct.Price,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(AddProductinDB);
                _context.SaveChanges();
                AddProductinDB = _context.Products.SingleOrDefault(product => product.Name == AddProductinDB.Name);
                HttpContext.Session.SetInt32("ProductId", AddProductinDB.ProductId);
                return RedirectToAction("ShowP");
            }
            else
            {
                return View("Index", addproduct);
            }
        }

        [HttpGet]
        [Route("category")]
        public IActionResult Category()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("Category");
        }

        [HttpPost]
        [Route("Category")]
        public IActionResult categoryaction(ProductsCategories.Models.CatViewModels addcategory)
        {
            if (ModelState.IsValid)
            {
                // Category addcat = _context.Categories.SingleOrDefault(category => category.Name == addcategory.Name);
                // if (addcat != null)
                // {
                //     ViewBag.Message = "This category already exists in the database. Add something else!";
                //     return View("category", addcategory);
                // }
                Category AddCategoryinDB = new Category
                {
                    CatName = addcategory.CatName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(AddCategoryinDB);
                _context.SaveChanges();
                AddCategoryinDB = _context.Categories.SingleOrDefault(category => category.CatName == AddCategoryinDB.CatName);
                HttpContext.Session.SetInt32("CategoryId", AddCategoryinDB.CategoryId);
                return RedirectToAction("ShowC");
            }
            else {
                return View("category", addcategory);
            }

        }
        
        [HttpGet]
        [Route("ShowAllProducts")]
        public IActionResult ShowP()
        {
            ViewBag.Products = _context.Products.ToList();
            // var result = _context.Products.ToList();
            return View();
        }


        [HttpGet]
        [Route("ShowAllCategories")]
        public IActionResult ShowC()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }


        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View("Success");
        }


        [HttpGet]
        [Route("~/category/{CategoryId}")]
        public IActionResult CategoryShow(int CategoryId)
        {
            List<Product> Products = _context.Products.ToList();

            Category catinfo = _context.Categories
                .SingleOrDefault(p => p.CategoryId == CategoryId);
            ViewBag.catinfo = catinfo;
            ViewBag.Products = Products; 
            return View();
        }

        public IActionResult AddProductToCategory(CatProd CatProds)
        {
            CatProd AddProdtoCat = new CatProd
                {
                    CategoryId = CatProds.CategoryId,
                    ProductId = CatProds.ProductId,
                };
                _context.Add(AddProdtoCat);
                Category Categoryzz = _context.Categories
                    .SingleOrDefault(p=> p.CategoryId == CatProds.CategoryId);
                Product Productszz = _context.Products
                    .SingleOrDefault(x=> x.ProductId == CatProds.ProductId);
                //add to the catprod list for catcategory and prodcategory
                Categoryzz.CatCategory.Add(AddProdtoCat);
                Productszz.CatProduct.Add(AddProdtoCat);
                ViewBag.Categoryzz = Categoryzz;
                ViewBag.Productszz = Productszz;
                _context.SaveChanges();
                return RedirectToAction("ShowC");

                // List<Person> Persons = _context.Persons
                //     .Include( p => p.Subscriptions )
                //         .ThenInclude( s => s.Magazine )
                //     .ToList();

        }
    
        [HttpGet]
        [Route("~/product/{ProductId}")]
        public IActionResult ProductShow(int ProductId)
        {
            List<Category> Categories = _context.Categories.ToList();

            Product prodinfo = _context.Products
                .SingleOrDefault(p => p.ProductId == ProductId);
            ViewBag.prodinfo = prodinfo;
            ViewBag.Categories = Categories;
            return View();
        }

        public IActionResult AddCatToProd(int ProductId)
        {
            return View();
        }



    }

}
