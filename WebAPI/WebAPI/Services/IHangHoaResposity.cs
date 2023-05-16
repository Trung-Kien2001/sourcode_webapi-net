using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IHangHoaResposity
    {
        // interface kết nối giữa controller và model
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}
