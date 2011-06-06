using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using VentanaTuristica.Model;
using VentanaTuristica.Repositorios;

namespace VentanaTuristica.Controllers
{
    [HandleError] 
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Index(string empresa)
        {
            IRepositorio<Empresa> myRepoEmpresa = new EmpresaRepositorio();
            IList<Empresa> listaEmpresa = myRepoEmpresa.GetAll();
            IList<Empresa> empresasBuscadas = new List<Empresa>();
            if (empresa != null)
            {
                foreach (var empresa1 in listaEmpresa)
                {
                    if (empresa1.Nombre == empresa)
                    {
                        empresasBuscadas.Add(empresa1);
                    }
                }
                return View(empresasBuscadas);
            }
            return View(listaEmpresa);
        }

        //
        // GET: /Empresa/Details/5
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Empresa/Create
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Create()
        {
           return View();
        } 

        //
        // POST: /Empresa/Create

        [HttpPost]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Create(Empresa E)
        {
            if (ModelState.IsValid)
            {
                IRepositorio<Empresa> repo = new EmpresaRepositorio();
                repo.Save(E);
               
                IRepositorio<Telefono> repositorioTelefono = new TelefonoRepositorio();
                E.Telefonos[0].IdEmpresa = E.IdEmpresa;
                E.Telefonos[0].Tipo = "E";
                repositorioTelefono.Save(E.Telefonos[0]);

                IRepositorio<Contacto> repositorioContacto = new ContactoRepositorio();
                E.Contacto[0].IdEmpresa = E.IdEmpresa;
                E.Contacto[0].Tipo = "E";
                repositorioContacto.Save(E.Contacto[0]);

                foreach (var telefono in E.Contacto[0].ListaTelefonos)
                {
                    telefono.Tipo = "E";
                    telefono.IdContacto = E.Contacto[0].IdContacto;
                    repositorioTelefono.Save(telefono);
                }
                return RedirectToAction("Index");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            while (E.Contacto[0].ListaTelefonos.Count < 4)
            {
                E.Contacto[0].ListaTelefonos.Add(new Telefono());
            }
            return View(E);
        }
        
        //
        // GET: /Empresa/Edit/5
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Edit(int id)
        {
            IRepositorio<Empresa> myRepoEmpresa = new EmpresaRepositorio();
            Empresa empresa = myRepoEmpresa.GetById(id);

            IRepositorio<Telefono> repositorioTelefono = new TelefonoRepositorio();
            IList<Telefono> telefonos = repositorioTelefono.GetAll();
            IList<Telefono> telefonosBuscados = new List<Telefono>();
            foreach (var telefono in telefonos)
            {
                if (telefono.IdEmpresa == id)
                {
                    telefonosBuscados.Add(telefono);
                }
            }
            empresa.Telefonos = telefonosBuscados;

            IRepositorio<Contacto> repositorioContacto = new ContactoRepositorio();
            IList<Contacto> contactos = repositorioContacto.GetAll();
            IList<Contacto> contactosBuscados = new List<Contacto>();
            telefonosBuscados = new List<Telefono>();

            foreach (var contacto in contactos)
            {
                if (contacto.IdEmpresa == id)
                {
                    foreach (var telefono in telefonos)
                    {
                        if (telefono.IdContacto == contacto.IdContacto)
                        {
                            telefonosBuscados.Add(telefono);
                        }
                    }
                    contacto.ListaTelefonos = telefonosBuscados;
                    contactosBuscados.Add(contacto);
                }
            }
            empresa.Contacto = contactosBuscados;

            while (empresa.Contacto[0].ListaTelefonos.Count < 4)
            {
                empresa.Contacto[0].ListaTelefonos.Add(new Telefono());
            }
            return View(empresa);
        }

        //
        // POST: /Empresa/Edit/5

        [HttpPost]
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Edit(Empresa empresa)
        {
            if (empresa.Nombre != null && empresa.Rif != null && empresa.Direccion != null && empresa.Ciudad != null && empresa.Localidad != null && 
                empresa.Telefonos[0].CodigoLoc != 0 && empresa.Telefonos[0].CodigoInt != 0 && empresa.Telefonos[0].Numero != 0 && 
                empresa.Contacto[0].Nombre != null && empresa.Contacto[0].ListaTelefonos[0].CodigoInt != 0 &&
                empresa.Contacto[0].ListaTelefonos[0].CodigoLoc != 0 && empresa.Contacto[0].ListaTelefonos[0].Numero != 0)
            {
                IRepositorio<Empresa> myRepoEmpresa = new EmpresaRepositorio();
                myRepoEmpresa.Update(empresa);

                IRepositorio<Telefono> repositorioTelefono = new TelefonoRepositorio();
                empresa.Telefonos[0].IdEmpresa = empresa.IdEmpresa;
                empresa.Telefonos[0].Tipo = "E";
                repositorioTelefono.Update(empresa.Telefonos[0]);

                IRepositorio<Contacto> repositorioContacto = new ContactoRepositorio();
                empresa.Contacto[0].IdEmpresa = empresa.IdEmpresa;
                empresa.Contacto[0].Tipo = "E";
                repositorioContacto.Update(empresa.Contacto[0]);

                foreach (var telefono in empresa.Contacto[0].ListaTelefonos)
                {
                    telefono.Tipo = "E";
                    telefono.IdContacto = empresa.Contacto[0].IdContacto;
                    if (telefono.CodigoInt != 0 && telefono.CodigoLoc != 0 && telefono.Numero != 0)
                        if (telefono.IdTelefono != 0)
                            repositorioTelefono.Update(telefono);
                        else
                            repositorioTelefono.Save(telefono);
                }
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        //
        // GET: /Empresa/Delete/5
        [Authorize(Users = "admin,j2lteam")]
        public ActionResult Delete(int id)
        {
            IRepositorio<Empresa> repo = new EmpresaRepositorio();
            Empresa E = repo.GetById(id);
            repo.Delete(E);
            return RedirectToAction("Index");
        }

       
        public ActionResult Find(string q)
        {
            IRepositorio<Empresa> repoP = new EmpresaRepositorio();
            IList<Empresa> empresas = repoP.GetAll();
            IList<Empresa> posiblesEmpresas = new List<Empresa>();

            foreach (var item in empresas)
            {
                if (item.Nombre.Contains(q.ToUpper()) || item.Nombre.Contains(q.ToLower()))
                {
                    posiblesEmpresas.Add(item);
                }
            }
            string[] emp = new string[posiblesEmpresas.Count];
            int i = 0;
            foreach (var empresa in posiblesEmpresas)
            {
                emp[i] = empresa.Nombre;
                i++;
            }

            return Content(string.Join("\n", emp)); ;
        }
    }
}
