using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WEB.Models.Entities;
using BTL_WEB.Models.Functions;
using BTL_WEB.Models;
using Newtonsoft.Json.Linq;

namespace BTL_WEB.Controllers
{
    [JsonObject(IsReference = true)]
    public class SanPhamController : ApiController
    {
        [HttpGet]
        [Route("api/sanpham/getsanpham/{id}")]
        public string GetSanPham(int id)
        {
            Func_SanPham hamsanpham = new Func_SanPham();
            tbl_sanpham sanpham = hamsanpham.FindEntity(id);
            sanpham newsanpham = hamsanpham.getnewsanpham(sanpham);
            
            string json = JsonConvert.SerializeObject(newsanpham);
            return json;
        }
        [HttpPost]
        [Route("api/sanpham/updatesanpham/")]
        public string UpdatesSanPham([FromBody] string data)
        {
          //  string data = requestdata.Content.ReadAsStringAsync().Result;
            dynamic stuff = JsonConvert.DeserializeObject(data);

            string status = "{\"status\":1, \"sanpham\":" + stuff.id + "}";
            try
            {
                sanpham newsanpham = JsonConvert.DeserializeObject<sanpham>(data);
                Func_SanPham hamsanpham = new Func_SanPham();
                tbl_sanpham sanpham = hamsanpham.getsanpham(newsanpham);
                int? x = hamsanpham.Update(sanpham);
                if (x == null)
                {
                    status = "{\"status\":-1, \"sanpham\":" + stuff.id + "}";
                }

            }
            catch
            {
               status = "{\"status\":0, \"sanpham\":" + stuff.id + "}";
            }
            return status;
        }


    }
}
