using System;
using System.Collections.Generic;
using CustomMvc.Models.CustomMvcClass;
using System.Web;
using System.Web.Mvc;

namespace CustomMvc.Controllers
{
    public class FormFieldPropController : Controller
    {
        // GET: FormFieldProp
        public ActionResult Index(int Fid)
        {
            FormPropertyTable formPropertyTable = new FormPropertyTable();
            List<FormPropertyTable> ListOfFP = formPropertyTable.FormFieldList(Fid);
            return View(ListOfFP);
        }
        [HttpPost]
        public ActionResult Create(FormPropertyTable formPropertyTable)
        {

            formPropertyTable.Save();
          return  RedirectToAction("index",new {Fid=formPropertyTable.FormTableId});
        }
        public ActionResult Create(int Fid)
        {

            FormPropertyTable formPropertyTable = new FormPropertyTable();
            List<FormPropertyTable> ListOfFP = formPropertyTable.FormFieldList(Fid);
            formPropertyTable.FormFieldOrder = ListOfFP.Count + 1;
            formPropertyTable.FormTableId = Fid;
            AddTypToViewData("TEXT");
            return View(formPropertyTable);
        }


        protected bool AddTypToViewData(string selectedId)
        {
            List<object> ListOfTyp = new List<object>();
            ListOfTyp.Add(new { id = "TEXT", name = "TEXT" });
            ListOfTyp.Add(new { id = "TEXT-READONLY", name = "TEXT-READONLY" });
            ListOfTyp.Add(new { id = "TEXT-HIDDEN", name = "TEXT-HIDDEN" });
            ListOfTyp.Add(new { id = "PASSWORD", name = "PASSWORD" });
            ListOfTyp.Add(new { id = "SEPARATOR", name = "SEPARATOR" });
            ListOfTyp.Add(new { id = "HR", name = "HR" });
            ListOfTyp.Add(new { id = "SELECT", name = "SELECT" });
            ListOfTyp.Add(new { id = "SELECT-MULTI", name = "SELECT-MULTI" });
            ListOfTyp.Add(new { id = "SELECT-READONLY", name = "SELECT-READONLY" });
            ListOfTyp.Add(new { id = "NUMBER", name = "NUMBER" });
            ListOfTyp.Add(new { id = "DOUBLE", name = "DOUBLE" });
            ListOfTyp.Add(new { id = "DATE", name = "DATE" });
            ListOfTyp.Add(new { id = "DATE-READONLY", name = "DATE-READONLY" });
            ListOfTyp.Add(new { id = "DATE-HIDDEN", name = "DATE-HIDDEN" });
            ListOfTyp.Add(new { id = "DATETIME", name = "DATETIME" });
            ListOfTyp.Add(new { id = "FILE", name = "FILE" });
            ListOfTyp.Add(new { id = "TEXTAREA", name = "TEXTAREA" });
            ListOfTyp.Add(new { id = "LABEL", name = "LABEL" });
            ListOfTyp.Add(new { id = "DIV-CLEAR", name = "DIV-CLEAR" });
            ListOfTyp.Add(new { id = "CUSTOM-BUTTON", name = "CUSTOM-BUTTON" });
            ListOfTyp.Add(new { id = "CUSTOM-FIELD", name = "CUSTOM-FIELD" });
            ListOfTyp.Add(new { id = "GROUP-OPEN", name = "GROUP-OPEN" });
            ListOfTyp.Add(new { id = "GROUP-CLOSE", name = "GROUP-CLOSE" });
            ListOfTyp.Add(new { id = "SCROLL-OPEN", name = "SCROLL-OPEN" });
            ListOfTyp.Add(new { id = "SCROLL-CLOSE", name = "SCROLL-CLOSE" });
            ListOfTyp.Add(new { id = "GO", name = "GO" });
            ListOfTyp.Add(new { id = "EMPTY-DIV", name = "EMPTY-DIV" });
                  //= new SelectList(ListOfTyp, "id", "name", selectedId);
                  ViewBag.Type=new SelectList(ListOfTyp, "id", "name", selectedId);
            return ListOfTyp.Count > 0;



        }

    }
}