using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomMvc.Models.CustomMvcClass;
using System.Web.Mvc;

namespace CustomMvc.Controllers
{
    public class FormTableController : Controller
    {
        // GET: FormTable
        public ActionResult Index()
        {

            FormTable ObjTable = new FormTable();
            List<FormTable> ListOfFormTable = ObjTable.TableList();
            return View(ListOfFormTable);
        }
        [HttpGet]
        public ActionResult Create()
        {
            FormTable ObjTable = new FormTable();
            return View(ObjTable);
        }

        [HttpPost]
        public ActionResult CreatePost(FormTable formTable)
        {

            if (formTable.TableNameID == 0)
            {
                
                int FormId= formTable.Save();
                if (FormId > 0 && formTable.FormType == "FORMWITHTABLE")
                {
                    formTable.CreateTable();
                }

            }
            else
            {
                formTable.Save();
            }
            
            return RedirectToAction("index");
        }
    }
}