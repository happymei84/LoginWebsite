using GridMvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class loginController : Controller
    {
        readonly LoginContext _loginContext;
        public loginController(LoginContext loginContext) 
        {
            _loginContext = loginContext;
        }


        public IActionResult loginIndex()
        {
            return View();
        }

        public IActionResult home(RegisterModel data)
        {

            var loginEnd = _loginContext.Logintables.Where(w => data.Account == w.Account && data.Password == w.Password).FirstOrDefault();
            var value = new RegisterModel();
            value.Account = loginEnd.Account;
            value.Password = loginEnd.Password;
            value.Phone = loginEnd.Phone;
            value.Name = loginEnd.Name;


            return View(value);
        }


        public IActionResult login(RegisterModel data)
        {

            var loginEnd = _loginContext.Logintables.Where(w => data.Account == w.Account && data.Password == w.Password).ToList();
            if (loginEnd.Count > 0)
            {
                return Ok("成功登入");
            }
            else
            {

                return Ok("帳號/密碼錯誤");
            }

        }



        public IActionResult modify(RegisterModel model)
        {


            var modify = _loginContext.Logintables.Where(w => model.Account == w.Account && model.Password == w.Password).FirstOrDefault();
            modify.Account = model.Account;
            modify.Password = model.newPassword;
            modify.Phone = model.Phone;
            modify.Name = model.Name;

            _loginContext.Update(modify);
            _loginContext.SaveChanges();
            return RedirectToAction("loginIndex");


        }


    }
}
