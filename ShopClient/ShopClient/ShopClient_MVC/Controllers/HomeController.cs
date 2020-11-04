using IBatisNet.DataMapper;
using ShopClient_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopClient_MVC.Controllers
{
    public class HomeController : Controller
    {
        private static ISqlMapper mapper = MappingData.GetInstance.MapperData;
        public ActionResult Index()
        {
            var itemList = GetAllItemEntity();
            return View(itemList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static IList<Item> GetAllItemEntity()
        {
            try
            {
                return mapper.QueryForList<Item>("GetAllItemEntity", null);
            }
            catch (Exception ex)
            {
                return new List<Item>();
                //throw ex;
            }
        }

        [HttpPost]
        public ActionResult AjaxCheckLogin(string userName, string password)
        {
            string resultStr = "Login Fail";
            try
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("USER_NAME", userName);
                parameters.Add("PASSWORD", password);

                var user = mapper.QueryForObject<User>("FindUserEntity", parameters);
                if (user != null)
                {
                    resultStr = "Success";
                }
            }
            catch (Exception ex)
            { 
            }
             return Json(resultStr);
        }
    }
}