using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class DonHangChiTiet
    {
        public Guid MaDh { get; set; }
        public Guid MaHH { get; set; }
        public int SoLuong { get; set; }
        public Double DonGia { get; set; }
        public byte GiamGia { get; set; }

        // relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }
    }
}
