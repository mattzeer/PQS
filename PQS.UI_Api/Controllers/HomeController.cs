﻿using Microsoft.Practices.Unity;
using PQS.Business;
using PQS.Business.Admin;
using PQS.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PQS.UI_Api.Controllers
{
    public partial class HomeController : Controller
    {

        [Dependency]
        public IUserService UserService => UnityConfig.Resolve<IUserService>();

        // GET: Home
        public virtual async System.Threading.Tasks.Task<ActionResult> Index()
        {
            PERSON p = await UserService.getPersonByIdAsync(1);
            ViewBag.test = p.MAIL;
            return View();
        }

        // GET: Home/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
