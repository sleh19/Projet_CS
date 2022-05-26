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
        else { return View(""); }

    }

    public ViewResult Confirm()
    {
        return View();

    }
    
//Prod
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
    [HttpGet]
    // GET: Employee/Edit/5
    public ActionResult ModifierProd(int id)
    {
        var prod = db.prods.Find(id);

        return View(prod);
    }



    // POST: Employee/Edit/5
    [HttpPost]
    public ActionResult ModifierProd(Produit prod, int id)
    {
        var produit = db.prods.Where(p => p.Id == prod.Id).FirstOrDefault();
        db.Entry(produit).State = EntityState.Modified;
        db.prods.Remove(produit);
        db.prods.Add(prod);
        db.SaveChanges();
        return RedirectToAction("Stocks");

    }

    CltDbContexte clt_db = new CltDbContexte();

    [HttpGet]
    public ActionResult CreateClient() { return View(); }

    [HttpPost]
    public ActionResult CreateClient(Client clt)
    {
        try
        {
            clt_db.clients.Add(clt);
            clt_db.SaveChanges();
            return RedirectToAction("AllClients");
        }
        catch
        {
            return View();
        }
    }

    public ActionResult AllClients()
    {
        var clients = from e in clt_db.clients
                    orderby e.Id
                    select e;
        return View("AllClients", clients);
    }

    public ActionResult ModifierClient(int id)
    {
        var clt = clt_db.clients.Find(id);

        return View(clt);
    }



    // POST: Employee/Edit/5
    [HttpPost]
    public ActionResult ModifierClient(Client custom, int id)
    {
        var client = clt_db.clients.Where(c => c.Id == custom.Id).FirstOrDefault();
        clt_db.clients.Remove(client);
        clt_db.clients.Add(custom);
        clt_db.SaveChanges();
        return RedirectToAction("AllClients");

    }

    public ActionResult SupprimerClient(int id)
    {
        Client clt = clt_db.clients.Find(id);
        clt_db.clients.Remove(clt);
        clt_db.SaveChanges();
        return RedirectToAction("AllClients");
    }
    public ActionResult Cart()
    {
        var stock = from e in db.prods
                    orderby e.Id
                    select e;
        return View("Cart",stock);
    }


    
}

