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
        public loginController(LoginContext loginContext) //注入服務
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

        [HttpPost]
        public IActionResult login([FromBody]RegisterModel data)
        {
            
           var loginEnd = _loginContext.Logintables.Where(w => data.Account == w.Account && data.Password == w.Password).ToList();//把where拿掉很多比
           if(loginEnd.Count > 0)
            {
                return Ok(true);
            }
           else
            {
                
                return Ok(false);
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
