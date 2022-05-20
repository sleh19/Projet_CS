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
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult CreateProd()
    {
        return View();
    }

    // POST: Employee/Create
    [HttpPost]
    public ActionResult CreateProd(Produit prod_ajout)
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
        return RedirectToAction("Stocks");
    }

    // GET: Employee/Edit/5
    public ActionResult ModifierProd(int id)
    {
        var prod = db.prods.Where(p => p.Id == id);

        return View(prod);
    }



    // POST: Employee/Edit/5
    [HttpPost]
    public ActionResult ModifierProd(Produit prod, int id)
    {
            //update student in DB using EntityFramework in real-life application
            
            //update list by removing old student and adding updated student for demo purpose
            var produit = db.prods.Where(p => p.Id == prod.Id).FirstOrDefault();
            db.prods.Remove(produit);
            db.prods.Add(produit);
        db.SaveChanges();
            return RedirectToAction("Stocks");
    }


}

