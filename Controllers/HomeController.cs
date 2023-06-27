﻿using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.DB;
using MVC_TDPC_Net6.DB.Entities;
using MVC_TDPC_Net6.Models;
using System;
using System.Diagnostics;

namespace MVC_TDPC_Net6.Controllers
{
    /*
     esercizio:
        - aggiungere un API controller con una post che crei una Person
        su DB prendendo i dati dall'input dell'utente nel frontend
    passi:
        - creare database con nome arbitrario
        - creare tabella Persons
        - creare la connection string nell'appsettings.json
        - importare i pacchetti nuget necessari (guardare nelle 
        dependencies di questo progetto)
        - creare il DBContext
        - creare la Repository
        - registrare i servizi necessari in Startup.cs
        (dbcontext, repository)
        - creare un API controller con la post di insert
            - esempio nel branch MVCeAPI nel PersonController
        - creare in una view un form di insert con n textbox e un button di insert
        - creare una funzione js collegata al button di insert che
        chiami l'endpoint post del controller
        - nell'endpoint del controller chiamare l'insert della repository
            - esempio nel branch EntityFramework in HomeController
     */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository repository;
        public HomeController(ILogger<HomeController> logger, Repository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ButtonPage()
        {
            return View();
        }
        public IActionResult Users()
        {
            List<User> users = this.repository.GetUsers();
            List<UserModel> model = new List<UserModel>();
            foreach (User u in users)
                model.Add(new UserModel()
                {
                    ID = u.ID.ToString(),
                    FirstName = u.FirstName,
                    LastName = u.LastName
                });
            return View(model);
        }
        public IActionResult UserByID()
        {
            User user = this.repository.GetUserByID("4CF2C67F-25D6-406C-A700-92EA796AFA57");
            UserModel model = new UserModel()
            {
                ID = user.ID.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(model);
        }
        public IActionResult UsersWithFilter()
        {
            List<User> users = this.repository.GetUsersWithFilter("sempr");
            List<UserModel> model = new List<UserModel>();
            foreach (User u in users)
                model.Add(new UserModel()
                {
                    ID = u.ID.ToString(),
                    FirstName = u.FirstName,
                    LastName = u.LastName
                });
            return View(model);
        }
        public IActionResult InsertUser()
        {
            /*
            User user = new User()
            {
                Nome = "Insert Nome",
                Cognome = "Insert Cognome",
                Stipendio = 1000000
            };
            this.repository.InsertUser(user);
            return View(new UserModel()
            {
                Nome = user.Nome,
                Cognome = user.Cognome
            });
            */
            return View();
        }

        public IActionResult UpdateUser()
        {
            List<User> users = this.repository.GetUsers();
            List<UserModel> model = new List<UserModel>();
            foreach (User u in users)
                model.Add(new UserModel()
                {
                    ID = u.ID.ToString(),
                    FirstName = u.FirstName,
                    LastName = u.LastName
                });
            return View(model);
        }

        public IActionResult DeleteUser()
        {
            List<User> users = this.repository.GetUsers();
            List<UserModel> model = new List<UserModel>();
            foreach (User u in users)
                model.Add(new UserModel()
                {
                    ID = u.ID.ToString(),
                    FirstName = u.FirstName,
                    LastName = u.LastName
                });
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}