﻿using AthosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthosApp.Areas
{
    public class AssuntoController : Controller
    {
        // GET: Assunto
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public List<Assunto> List(){
            return new List<Assunto>();
        }

        // GET: Assunto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Assunto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assunto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Assunto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assunto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Assunto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assunto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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