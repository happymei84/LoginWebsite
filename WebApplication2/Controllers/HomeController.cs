using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        readonly LoginContext _loginContext;
        public HomeController(LoginContext loginContext) //注入服務
        {
            _loginContext = loginContext;
        }
        public IActionResult Index()
        {

            var getaccount = _loginContext.Logintables.ToList();
            var getaccount1 = _loginContext.Logintables.FirstOrDefault();
            ViewBag.output = getaccount;
            ViewBag.abc = getaccount1;

            return View(getaccount);
                                  

        }

        public IActionResult SelectView(IFormCollection form) //傳入form 裡面全部的Control的值
        {
            var compare = form["accountlist"].ToString(); //使用accountlist(這個controller)
            var compareModel = _loginContext.Logintables.Where(w => compare == w.RowId.ToString()).FirstOrDefault();
            if(compareModel != null)
            {
                ViewBag.output = compareModel;
                 
            }
           
            return View();
        }

        [HttpPost]
        public JsonResult DoSomething(int id)
        {
           
            var compareModel = _loginContext.Logintables.Where(w => id == w.RowId).ToList();
            var result = JsonConvert.SerializeObject(compareModel);
            return Json(result);
        }

        [HttpPost]
        public IActionResult SearchFunction(string model)
        {
            var result = new APIResponseModel<List<Articletable>>();

            var compare = _loginContext.Articletables.Where(w => w.PostTitle.Contains(model)).ToList();

            if (compare.Count > 0)
            {
                result.SusseccStatus = true;
                result.ReturnData = compare;
                result.ReturnMessage = "success";
            }
            else
            {
                result.SusseccStatus = false;
                result.ReturnData = compare;
                result.ReturnMessage = "fail";
            }




            return Ok(result);
        }



    }
}
