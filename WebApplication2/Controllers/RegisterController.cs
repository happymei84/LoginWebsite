using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    
    public class RegisterController : Controller
    {
        readonly LoginContext _loginContext;
        public RegisterController(LoginContext loginContext) //注入服務
        {
            _loginContext = loginContext;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult regist([FromBody] RegisterModel model)
        {
           
            var registEnd = _loginContext.Logintables.Where(w => model.Account == w.Account).ToList();//把where拿掉很多比
            if (registEnd.Count > 0)
            {
                return Ok(false);
            }
            else
            {
             Logintable data = new Logintable(); //實體化table
            data.Account = model.Account;  //將前端傳進來的model值帶進data(資料庫中)
            data.Password = model.Password;
            data.Name = model.Name;
            data.Phone = model.Phone;


            _loginContext.Add(data); //ef core新增資料
            _loginContext.SaveChanges(); //更新資料

                return Ok(true);
            }

            
                        
        }

    }
}
