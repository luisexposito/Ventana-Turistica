﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentanaTuristica.Model;
using VentanaTuristica.Repositorios;

namespace VentanaTuristica.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/
        [ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Index()
        {
            IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
            IList<Blog> listaBlog = myRepoBlog.GetAll();
            return View(listaBlog);
        }

        //
        // GET: /Blog/Create
        [ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Blog/
        [ValidateInput(false)]
        public ActionResult Principal(int? anio, string mes)
        {
            IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
            IList<Blog> listaBlog = myRepoBlog.GetAll();

            if (anio != null && mes != null)
            {
                var b = (from blog in listaBlog
                         where blog.Fecha.Year == anio && blog.Fecha.ToString("MMMM") == mes
                         select blog);
                return View(b.ToList());
            }

            if (anio != null)
            {
                var b = (from blog in listaBlog
                         where blog.Fecha.Year == anio
                         select blog);
                return View(b.ToList());
            }

            var c = (from blog in listaBlog
                     where blog.Fecha.Year == DateTime.Now.Year && blog.Fecha.ToString("MMMM") == DateTime.Now.ToString("MMMM")
                     select blog);

            return View(c.ToList());
        }

        //
        // POST: /Blog/Create

        [HttpPost, ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Create(Blog blog, FormCollection collection)
        {
            try
            {
                IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
                myRepoBlog.Save(blog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Blog/Edit/5
        [ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Edit(int id)
        {
            IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
            return View(myRepoBlog.GetById(id));
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost, ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Edit(Blog blog,int id, FormCollection collection)
        {
            try
            {
                IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
                blog.IdBlog = id;
                myRepoBlog.Update(blog);
                return RedirectToAction("Index");
            }
            catch (Exception O)
            {
                return View();
            }
        }

        //
        // GET: /Blog/Delete/5
        [ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Delete(int id)
        {
            try
            {
                IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
                myRepoBlog.Delete(myRepoBlog.GetById(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // POST: /Blog/Delete/5
         
        [HttpPost, ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
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

        public ActionResult Categorias()
        {
            IRepositorio<Blog> myRepoBlog = new BlogRepositorio();
            IList<Blog> listaBlog = myRepoBlog.GetAll();

            IList<IList<string>> a = new List<IList<string>>();
            
            var anios = (from blog in listaBlog
                            select blog.Fecha.Year).Distinct();
            foreach (var anio in anios)
            {
                var b = (from blog in listaBlog where blog.Fecha.Year == anio
                         select blog.Fecha.ToString("MMMM").ToUpperInvariant()).Distinct();
                a.Add(b.ToList());
            }
            ViewData["todosAnios"] = anios;
            ViewData["todosMeses"] = a;
            
            return PartialView();
        }

        [ValidateInput(false)]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Find(string q)
        {
            IRepositorio<Blog> repoC = new BlogRepositorio();
            IList<Blog> blogs = repoC.GetAll();
            IList<Blog> posiblesBlogs = new List<Blog>();

            foreach (var item in blogs)
            {
                if (item.Titulo.Contains(q.ToUpper()) || item.Titulo.Contains(q.ToLower()))
                {
                    posiblesBlogs.Add(item);
                }
            }
            string[] emp = new string[posiblesBlogs.Count];
            int i = 0;
            foreach (var blog in posiblesBlogs)
            {
                emp[i] = blog.Titulo;
                i++;
            }

            return Content(string.Join("\n", emp)); ;
        }
    } 
}
