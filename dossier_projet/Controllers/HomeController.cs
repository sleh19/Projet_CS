using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging; 
using projet.Data;
using projet.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace projet.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public ViewResult Connexion() { return View(); }

    [HttpPost]
    public ViewResult Connexion(Admin admin)
    {
        if (admin.Username == "Sleh1910" && admin.Password == "Sleh1910")
        {
            return View("Confirm", admin);
        }
        else { return View(); }

    }

        private ProdDbContexte db = new ProdDbContexte();
        // GET: Employee

        public ActionResult Stocks()
        {
            var stock = from e in db.prods
                            orderby e.Id
                            select e;
            return View("Stocks", stock);
        }


        // GET: Employee/Create
        public ActionResult Create_prod()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create_prod(Produit prod_ajout)
        {
            try
            {
                db.prods.Add(prod_ajout);
                db.SaveChanges();
                return RedirectToAction("Stocks");
            }
            catch
            {
                return View();
            }
        }



    public ActionResult Supprimer_prod(int id)
    {
        Produit produit = db.prods.Find(id);
        db.prods.Remove(produit);
        db.SaveChanges();
        return View("Stocks");
    }

        // GET: Employee/Edit/5
    public ActionResult Modifier_prod(int id)
        {
            var prod = db.prods.Single(m => m.Id == id);
            return View(prod);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Modifier_prod(int id, FormCollection collection)
        {
            try
            {
                var prod = db.prods.Single(m => m.Id == id);
                if (TryUpdateModel(prod))
                {
                    //To Do:- database code
                    db.SaveChanges();
                    return RedirectToAction("Stocks");
                }
                return View(prod);
            }
            catch
            {
                return View();
            }
        }

    private bool TryUpdateModel(Produit prod)
    {
        throw new NotImplementedException();
    }
}

