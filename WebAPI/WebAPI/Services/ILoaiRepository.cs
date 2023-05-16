using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiVM loai);
        void Delete(int id);
    }
}
