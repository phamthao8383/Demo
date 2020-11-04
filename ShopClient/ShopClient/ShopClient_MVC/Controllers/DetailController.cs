﻿using IBatisNet.DataMapper;
using ShopClient_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace ShopClient_MVC.Controllers
{
    public class DetailController : Controller
    {
        private static ISqlMapper mapper = MappingData.GetInstance.MapperData;
        // GET: Detail
        public ActionResult Index()
        {
            var item = new Item();
            try
            {
                //get current Url
                string Uri = HttpContext.Request.Url.AbsoluteUri;
                var urlComponent = Uri.Split('/');
                string detailStr = urlComponent.Where(x => x.Contains("Item")).FirstOrDefault();
                int indexSub = detailStr.IndexOf('=');
                int id = Int32.Parse(detailStr.Substring(indexSub + 1, detailStr.Length - (indexSub + 1)));

                item = GetAllItemEntity().Where(x => x.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            if (item == null) item = new Item();
            return View(item);
        }
        
        private static IList<Item> GetAllItemEntity()
        {
            try
            {
                return mapper.QueryForList<Item>("GetAllItemEntity",null);
            }
            catch (Exception ex)
            {
            return new List<Item>();
                //throw ex;
            }
        }
    }
}