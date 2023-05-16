using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> IF_HangHoa = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(IF_HangHoa);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = IF_HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            IF_HangHoa.Add(hanghoa);
            return Ok(new {
                Success = true, Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = IF_HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // update
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                // LINQ [Object] Query
                var hanghoa = IF_HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                IF_HangHoa.Remove(hanghoa);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
