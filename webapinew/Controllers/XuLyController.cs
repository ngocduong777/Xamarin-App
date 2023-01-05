using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using webapinew.Models;

namespace webapinew.Controllers
{
    public class XuLyController : ApiController
    {
        [Route("api/XuLy/Chao")]
        [HttpGet]
        public IHttpActionResult Chao()
        {
            try
            {
                string cauchao = "Chao cac ban hihi";
                return Ok(cauchao);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/LoaiHoa/LayDSLoaiHoa")]
        [HttpGet]
        public IHttpActionResult LayDSLoaiHoa()
        {
            try
            {
                DataTable tb = Database.LayDSLoaiHoa();
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/Hoa/LayDSHoaTheoLoai")]
        [HttpGet]
        public IHttpActionResult LayDSHoaTheoLoai(int maloai)
        {
            try
            {
                DataTable tb = Database.LayDSHoaTheoLoai(maloai);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/NguoiDung/LaySoDHtheoIDNguoiDung")]
        [HttpGet]
        public IHttpActionResult LaySoDHtheoIDNguoiDung(int manguoidung)
        {
            try
            {
                DataTable tb = Database.LaySoDHtheoIDNguoiDung(manguoidung);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/NguoiDung/LayMaHoaTheoSoDH")]
        [HttpGet]
        public IHttpActionResult LayMaHoaTheoSoDH(int Ma_DH)
        {
            try
            {
                DataTable tb = Database.LayMaHoaTheoSoDH(Ma_DH);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/NguoiDung/LayTongBillDiaChiLoiNhanTheoSoDH")]
        [HttpGet]
        public IHttpActionResult LayTongBillTheoSoDH(int So_DH)
        {
            try
            {
                DataTable tb = Database.LayTongBillDiaChiLoiNhanTheoSoDH(So_DH);
                return Ok(tb);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/LoaiHoa/ThemLoaiHoa")]
        [HttpPost]
        public IHttpActionResult ThemLoaiHoa(LoaiHoa lh)
        {
            try
            {
                int kq = Database.Them_Loai_Hoa(lh);
                return Ok(kq);
            }
            catch
            {
                return NotFound();

            }
        }

        [Route("api/LoaiHoa/CapNhatLoaiHoa")]
        [HttpPost]
        public IHttpActionResult CapNhatLoaiHoa(LoaiHoa lh)
        {
            try
            {
                int kq = Database.CapNhatLoaiHoa(lh);
                return Ok(kq);
            }
            catch
            {
                return NotFound();

            }
        }

        [Route("api/NguoiDung/CapNhatNguoiDung")]
        [HttpPost]
        public IHttpActionResult CapNhatNguoiDung(NguoiDung nd)
        {
            try
            {
                int kq = Database.CapNhatNguoiDung(nd);
                return Ok(kq);
            }
            catch
            {
                return NotFound();

            }
        }


        [Route("api/LoaiHoa/XoaLoaiHoa")]
        [HttpPost]
        public IHttpActionResult XoaLoaiHoa(LoaiHoa lh)
        {
            try
            {
                int kq = Database.XoaLoaiHoa(lh);
                return Ok(kq);
            }
            catch
            {
                return NotFound();

            }
        }

        [Route("api/NguoiDung/DangNhap")]
        [HttpGet]
        public IHttpActionResult DangNhap(string TenDangNhap, string MatKhau)
        {
            try
            {
                NguoiDung nd = Database.DangNhap(TenDangNhap, MatKhau);

                return Ok(nd);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/NguoiDung/ThemNguoiDung")]
        [HttpPost]
        public IHttpActionResult ThemNguoiDung(NguoiDung nd)
        {
            try
            {
                NguoiDung kq = Database.ThemNguoiDung(nd);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/NguoiDung/ThemGioHang")]
        [HttpPost]
        public IHttpActionResult ThemGioHang(GioHang gh)
        {
            try
            {
                int kq = Database.ThemGioHang(gh);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }


    }
}
