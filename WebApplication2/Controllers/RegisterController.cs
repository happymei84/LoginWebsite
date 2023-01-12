using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    public class RegisterController : Controller
    {
        readonly LoginContext _loginContext;
        public RegisterController(LoginContext loginContext) 
        {
            _loginContext = loginContext;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult regist(RegisterModel model)
        {

            var registEnd = _loginContext.Logintables.Where(w => model.Account == w.Account).ToList();
            if (registEnd.Count > 0)
            {
                return Ok("已註冊過");
            }
            else
            {
                Logintable data = new Logintable(); 
                data.Account = model.Account;  
                data.Password = model.Password;
                data.Name = model.Name;
                data.Phone = model.Phone;


                _loginContext.Add(data); 
                _loginContext.SaveChanges(); 

                return RedirectToAction("loginIndex", "login");
            }



        }

    }
}
