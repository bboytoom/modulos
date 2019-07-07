﻿using Administrator.App_Start;
using Administrator.Manager.Implementations;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System.Security.Claims;
using System.Threading;
using Administrator.Manager.Helpers;
using System.Collections.Generic;

namespace Administrator.Controllers
{
    [CustomAuthorize]
    public class CatalogsController : Controller
    {
        private ReadAllGroupImp objReadGroup;
        private ReadGroupImp objReadOnlyGroup;
        private ReadAllUserImp objReadUser;

        public CatalogsController()
        {
            objReadGroup = new ReadAllGroupImp();
            objReadOnlyGroup = new ReadGroupImp();
            objReadUser = new ReadAllUserImp();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Inician los controladores del grupo

        public ActionResult ViwerGroups(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var salida = objReadGroup.ReadAllGroup(sortOrder, searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult PartialViewGroupF()
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();

                ViewBag.IdUsuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                return PartialView("_PartialViewGroupF");
            }

            return View("ViwerGroups");
        }

        [HttpPost]
        public JsonResult ReadViewGroup(int Id)
        {
            dynamic showMessageString = string.Empty;

            if (Id != 0)
            {
                List<ViewModelGroup> salida = objReadOnlyGroup.ReadGroup(Id);
                return Json(showMessageString = new { Status = 200, Respuesta = salida }, JsonRequestBehavior.AllowGet);
            }

            return Json(showMessageString = new { Status = 404, Respuesta = "Falta datos necesarios para realizar la peticion" }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Inician los controladores del usuario

        public ActionResult ViwerUsers(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var salida = objReadUser.ReadAllUser(sortOrder, searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult PartialViewUserF()
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();

                ViewBag.IdUsuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                return PartialView("_PartialViewUserF");
            }

            return View("ViwerUsers");
        }

        #endregion
    }
}