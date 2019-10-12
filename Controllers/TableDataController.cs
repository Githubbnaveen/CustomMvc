using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Web.Mvc;
using CustomMvc.Models.CommonModels;
using CustomMvc.Models.CustomMvcClass;

namespace CustomMvc.Controllers
{
    public class TableDataController : Controller
    {
        // GET: TableData
        public ActionResult Index(int Fid)
        {


            FormPropertyTable ObjFPT = new FormPropertyTable();


            
            ViewData["Error"] = null;
            ViewData["ListOfFPT"] = ObjFPT.FormFieldList(Fid);
            ViewData["DoNothing"] = false;
            ViewData["CASE"] = "INDEX";
            ViewBag.ListOfTableData = new List<Object>();
            ViewResult viewresult = View(StaticMembers.SharedFolderName + StaticMembers.FormTablePrefix + Fid.ToString());
            viewresult.ExecuteResult(this.ControllerContext);
            //  ViewData["ListOfTableData"] = viewresult.ViewData["ListOfTableData1"];
            ViewData["ListOfTableData"]=  TempData["ListOfFPTEMP"];
            TempData.Remove("ListOfFPTEMP");
           // ViewData["ListOfTableData"] = ListOfTableData;
            return View();
        }

        // GET: TableData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TableData/Create
        public ActionResult Create(int Fid)
        {
            FormPropertyTable ObjFPT = new FormPropertyTable();
            ViewData["Error"] = null;
            ViewData["ListOfFPT"] = ObjFPT.FormFieldList(Fid);
            ViewData["DoNothing"] = false;
            ViewData["CASE"] = "CREATE";
            ViewBag.ListOfTableData = new List<Object>();
            ViewResult viewresult = View(StaticMembers.SharedFolderName + StaticMembers.FormTablePrefix + Fid.ToString());
            viewresult.ExecuteResult(this.ControllerContext);
            //  ViewData["ListOfTableData"] = viewresult.ViewData["ListOfTableData1"];
            ViewData["OBJFPTEMP"] = TempData["OBJFPTEMP"];
            TempData.Remove("OBJFPTEMP");

            return View();
        }

        // POST: TableData/Create
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

        // GET: TableData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TableData/Edit/5
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

        // GET: TableData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TableData/Delete/5
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
