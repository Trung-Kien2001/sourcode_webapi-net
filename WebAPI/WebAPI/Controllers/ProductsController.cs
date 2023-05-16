using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IHangHoaResposity _hanghoaReposity;

        public ProductsController(IHangHoaResposity hangHoaResposity)
        {
            _hanghoaReposity = hangHoaResposity;
        }


        // Gọi lại hangHoaResposity trong services để xử lý (hangHoaResposity gần như các void ngoài main dùng để giảm thời gian xử lý)
        [HttpGet]
        public IActionResult GetAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        {
            try
            {
                var result = _hanghoaReposity.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("không lấy được sản phẩm");
            }
        }
    }
}
