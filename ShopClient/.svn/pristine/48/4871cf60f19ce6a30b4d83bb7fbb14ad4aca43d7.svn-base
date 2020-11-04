using IBatisNet.DataMapper;
using ShopClient_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopClient_MVC.Controllers
{
    public partial class ShopMangerController : Controller
    {
        private static ISqlMapper mapper = MappingData.GetInstance.MapperData;
        // GET: ShopManger
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewItem()
        {
            return View();
        }

        // GET: ShopManger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopManger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopManger/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopManger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopManger/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopManger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopManger/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file, ItemUpload itemUp)
        {
            try
            {
                Item _item = itemUp.ItemFlow;
                _item.Name = _item.Name.Trim();
                if (!string.IsNullOrEmpty(_item.Name))
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        // setting for image fextension in web.config please search key AllowedImageExtensions
                        var allowedExtensionsStr = ConfigurationManager.AppSettings["AllowedImageExtensions"];
                        var ext = Path.GetExtension(file.FileName).ToLower(); //getting the extension(ex-.jpg)  

                        if (!string.IsNullOrWhiteSpace(allowedExtensionsStr)) //check what type of extension  
                        {
                            allowedExtensionsStr = allowedExtensionsStr.ToLower();
                            if (allowedExtensionsStr.Trim().Split(',').Contains(ext))
                            {
                                // convert inmage to byte buffer
                                _item.ImagePath = new byte[file.ContentLength];
                                file.InputStream.Read(_item.ImagePath, 0, file.ContentLength);
                            }
                            else
                            {
                                ViewBag.AddItemStatus = "<span style='color:red'>Chọn file với định dạng hình ảnh hoặc để trống</span>";
                                return View("AddNewItem");
                            }
                        }
                    }
                    mapper.Insert("AddNewItemEntity", _item);
                    ViewBag.AddItemStatus = "Đã thêm mới một mặt hàng thành công";
                }
                else
                {
                    ViewBag.AddItemStatus = "<span style='color:red'>[ERR]: Tên sản phẩm trống</span>";
                }
            }
            catch (Exception ex)
            {

                ViewBag.AddItemStatus = $"<span style='color:red'>Không thể thêm mới mặt hàng [ERR]: {ex.Message}</span>";
            }
            return View("AddNewItem");
        }
    }
}
