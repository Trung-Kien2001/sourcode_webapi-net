using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class HangHoaRepository : IHangHoaResposity
    {
        private MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public HangHoaRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1)
        {
            var AllProduct = _context.HangHoas.Include(hh => hh.Loai).AsQueryable();

            #region Filltering
            // tìm kiếm theo tên
            if (!string.IsNullOrEmpty(search))
            {
                AllProduct = AllProduct.Where(hh => hh.TenHH.Contains(search));
            }

            // tìm các sp có giá >= from (nhập vào từ màn hình)
            if (from.HasValue)
            {
                AllProduct = AllProduct.Where(hh => hh.DonGia >= from);
            }

            // tìm các sp có giá <= to (nhập vào từ màn hình)
            if (to.HasValue)
            {
                AllProduct = AllProduct.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name (TenHh)    ---- tìm kiếm theo câu truy vấn giảm dần nhỏ dần
            AllProduct = AllProduct.OrderBy(hh => hh.TenHH);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc": AllProduct = AllProduct.OrderByDescending(hh => hh.TenHH); break;
                    case "gia_asc": AllProduct = AllProduct.OrderBy(hh => hh.DonGia); break;
                    case "gia_desc": AllProduct = AllProduct.OrderByDescending(hh => hh.DonGia); break;
                }
            }
            #endregion

            //#region Paging
            //AllProduct = AllProduct.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = AllProduct.Select(hh => new HangHoaModel
            //{
            //    MaHangHoa = hh.MaHh,
            //    TenHangHoa = hh.TenHh,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.Loai.TenLoai
            //});

            //return result.ToList();

            var result = PaginatedList<WebAPI.Data.HangHoa>.Create(AllProduct, page, PAGE_SIZE);
            // lấy giá trị rồi show

            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHH,
                TenHangHoa = hh.TenHH,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();
        }
    }
}
