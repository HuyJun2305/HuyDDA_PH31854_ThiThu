using AppData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        AppDbContext _context = new AppDbContext();
        [HttpGet("get-all")]
        public ActionResult Get()
        {
            return Ok(_context.NhanVien.ToList());
        }

        [HttpGet("get-by-id")]
        public ActionResult Get(Guid id)
        {
            return Ok(_context.NhanVien.Find(id));
        }

        [HttpPost("create-nhanvien")]
        public ActionResult Post(NhanVien nv)
        {
            try
            {
                _context.Add(nv);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



        [HttpPut("update-nhanvien")]
        public ActionResult Put(NhanVien nv)
        {
            try
            {
                var updateItem = _context.NhanVien.Find(nv.Id);
                updateItem.Ten = nv.Ten;
                updateItem.Tuoi = nv.Tuoi;
                updateItem.Luong = nv.Luong;
                updateItem.Email = nv.Email;
                _context.Update(updateItem);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("delete-by-id")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var updateItem = _context.NhanVien.Find(id);
                _context.Remove(updateItem);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
    }
}
