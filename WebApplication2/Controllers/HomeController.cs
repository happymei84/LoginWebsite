using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        readonly LoginContext _loginContext;
        public HomeController(LoginContext loginContext) 
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

        //下拉式選單，查看使用者資訊
        public IActionResult SelectView(IFormCollection form) 
        {
            var compare = form["accountlist"].ToString(); 
            var compareModel = _loginContext.Logintables.Where(w => compare == w.RowId.ToString()).FirstOrDefault();
            if (compareModel != null)
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

    }
}
