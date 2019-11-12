using System.Web.Http;
using System.Collections.Generic;
using CustomMvc.Models.CustomMvcClass;
using Newtonsoft.Json.Linq;
using System.Linq;
namespace CustomMvc.Controllers
{
    public class MyApiController : ApiController
    {

        //public IList<FormTable> Get()
        //{
        //    FormTable ObjTable = new FormTable();
        //    IList<FormTable> ListOfFormTable = ObjTable.TableList();
        //    return ListOfFormTable;
        //}
        public JObject Get()
        {
            JObject Jobj = new JObject();
            FormTable ObjTable = new FormTable();
            List<FormTable> ListOfFormTable = ObjTable.TableList();
            Jobj["User"] = JArray.FromObject(ListOfFormTable.Select(x => new { x.FormName ,x.FormType,x.FormJavaScript})) ;

            return Jobj;
        }
      
    }
}
