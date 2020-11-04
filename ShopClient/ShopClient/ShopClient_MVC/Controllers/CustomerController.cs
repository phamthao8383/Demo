using IBatisNet.DataMapper;
using ShopClient_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;


namespace ShopClient_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private static int itemID = 0;
        private static int buyAmount = 0;
        private static ISqlMapper mapper = MappingData.GetInstance.MapperData;


        #region Controller Method
        // GET: Customer
        public ActionResult Index()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var provinceList = GetAllProvinceEntity();

            //add default element, it can't select
            selectListItems.Add(new SelectListItem
            {
                Value = "-1",
                Text = "Chọn Tỉnh/Thành Phố",
                Selected = true,
                Disabled = true
            });

            if (provinceList.Any())
            {
                foreach (var provinceitem in provinceList)
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = provinceitem.ID.ToString(),
                        Text = provinceitem.Name
                    });
                }
            }
            ViewBag.ProvinceList = selectListItems;

            var item = GetAllItemEntity().Where(x => x.ID == itemID).FirstOrDefault();
            ViewData["item"] = item;
            ViewData["Amount"] = buyAmount;

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var customer = new Customer
            {
                Gender = collection["rdbtGender"].ToLower() == "male",
                Name = collection["txtcustommerName"],
                PhoneNumber = collection["txtPhoneNumber"],
                Address = $"{collection["ddlProvince"]}-{collection["ddlDistrict"]}-{collection["ddlCommune"]}"
            };
            var itemID = Int32.Parse(collection["for_itemID"]);
            // check customer info is exist where  PhoneNumber;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("phoneNO", customer.PhoneNumber);
            try
            {
                var findcustomer = mapper.QueryForList<Customer>("FindCustomerEntity", param);
                if (findcustomer != null && findcustomer.Any())
                {
                    // update customer info
                    mapper.Update("UpdateCustomerEntity", customer);
                }
                else
                {
                    //Insert new customer
                    mapper.Insert("AddNewCustomerEntity", customer);
                }

                #region send E-Mail
                // sender email infor id and pass
                var senderEmail = new MailAddress("sender_phamthithuthao8383@gmail.com", "senderName");
                var password = "thuthaocntt";

                var receiverEmail = new MailAddress("recieve@gmail.com", "Receiver");
                var sub = $"[ShopClient][order] have a order {itemID}_{customer.PhoneNumber}_{DateTime.Now}";
                //var body = "thong tin don hng thich ghi j thi ghi";
                var body = $"bạn nhận được một đơn hàng từ sdt{customer.PhoneNumber}{Environment.NewLine}";
                body += $"Địa chỉ người nhận: {customer.Address}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(senderEmail.Address, password)
                };

                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                #endregion send E-Mail
            }
            catch (Exception ex)
            {
                ViewBag.OrderResult = "[ERR] Lỗi hệ thống";
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AjaxGetDistrictByProvice(int provinceID)
        {
            List<District> listFindDistrict = null;
            try
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>();

                // add provinceId into sql query to coditon
                parameters.Add("IDProvince", provinceID);

                listFindDistrict = mapper.QueryForList<District>("FindDistrictEntity", parameters).ToList();
            }
            catch (Exception ex)
            {
                listFindDistrict = new List<District>();
            }

            return Json(new SelectList(listFindDistrict, "ID", "Name"));
        }

        [HttpPost]
        public ActionResult AjaxGetCommuneByDistrict(int districtID)
        {
            List<Commune> listFindcommune = null;
            try
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>();

                // add provinceId into sql query to coditon
                parameters.Add("IDDistrict", districtID);

                listFindcommune = mapper.QueryForList<Commune>("FindCommuneEntity", parameters).ToList();
            }
            catch (Exception ex)
            {
                listFindcommune = new List<Commune>();
            }

            return Json(new SelectList(listFindcommune, "ID", "Name"));
        }


        [HttpPost]
        public ActionResult OrderItem(FormCollection collection)
        {
            try {
                // get itemInfo
                itemID = Int32.Parse( collection["ID"]);
                buyAmount = Int32.Parse(collection["hdBuyAmount"]);
                
            }
            catch(Exception ex)
            {
                //nothing
            }
            return RedirectToAction("Index");
        }
        #endregion
        private static IList<Province> GetAllProvinceEntity()
        {
            try
            {
                return mapper.QueryForList<Province>("GetAllProvinceEntity", null);
            }
            catch (Exception ex)
            {
                return new List<Province>();
                //throw ex;
            }
        }

        private static IList<Province> FindDistricts(int provinceID)
        {
            try
            {
                return mapper.QueryForList<Province>("GetAllProvinceEntity", null);
            }
            catch (Exception ex)
            {
                return new List<Province>();
            }
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
    }
}
