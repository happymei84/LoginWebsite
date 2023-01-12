using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ContentController : Controller
    {
        readonly LoginContext _loginContext;
        public ContentController(LoginContext loginContext)
        {
            _loginContext = loginContext;
        }

        [HttpPost]
        public IActionResult insertContent([FromBody] ContentModel model)
        {
            var result = new APIResponseModel<Articletable>();

            Articletable data = new Articletable();
            data.PostContent = model.PostContent;
            data.PostAccount = model.PostAccount;
            data.PostDatetime = DateTime.Now;
            data.PostTitle = model.PostTitle;

            if (data.PostContent == "" || data.PostTitle == "") //為甚麼不適null(是"")
            {
                result.SusseccStatus = false;
                result.ReturnData = data;
                result.ReturnMessage = "fail";

                return Ok(result);

            }
            else
            {
                _loginContext.Add(data); //ef core新增資料
                _loginContext.SaveChanges(); //更新資料

                var compare = _loginContext.Articletables.Where(w => model.PostContent == w.PostContent).FirstOrDefault();
                if (compare == null)
                {
                    result.SusseccStatus = false;
                    result.ReturnData = compare;
                    result.ReturnMessage = "fail";
                }
                else
                {
                    result.SusseccStatus = true;
                    result.ReturnData = compare;
                    result.ReturnMessage = "成功";
                }
                return Ok(result);
            }
       
        }

        [HttpPost]
        public IActionResult outputContent([FromBody] ContentModel model)
        {
            var result = new APIResponseModel<List<Articletable>>();
           var data = new List<Articletable>();
            if (model.RowId != 0)
            {

                data = _loginContext.Articletables.Where(w => model.RowId == w.RowId).ToList();
                if (data.Count > 0)
                {
                    result.SusseccStatus = true;
                    result.ReturnData = data;
                    result.ReturnMessage = "成功";

                }
                else
                {
                    result.SusseccStatus = false;
                    result.ReturnData = data;
                    result.ReturnMessage = "fail";
                }
                return Ok(result);
            }
            else
            {
                data = _loginContext.Articletables.ToList();
                if (data.Count > 0)
                {
                    result.SusseccStatus = true;
                    result.ReturnData = data;
                    result.ReturnMessage = "成功";

                }
                else
                {
                    result.SusseccStatus = false;
                    result.ReturnData = data;
                    result.ReturnMessage = "fail";
                }
                return Ok(result);
            }
        }
    }
}
