using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        HttpClient client = new HttpClient();
        public NhanVienController()
        {
            client = new HttpClient();
        }
        // GET: NhanVienController
        public ActionResult Index()
        {
            string requestURL = "https://localhost:7198/api/NhanVien/get-all";
            var response = client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<NhanVien>>(response);
            return View(data);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(Guid id)
        {
            string requestURL = $"https://localhost:7198/api/NhanVien/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<NhanVien>(response);
            return View(data);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            NhanVien nv = new NhanVien() ///Fake dữ liệu lên Form
            {
                Id = Guid.NewGuid(),
                Ten = "Huy Jun",
                Email = "HuyJun@gmail.com",
                Luong = new Random().Next(5000000,30000000),
                TrangThai = true
            };
            return View(nv);
        }

        // POST: NhanVienController/Create
        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            string requestURL = $"https://localhost:7198/api/NhanVien/create-nhanvien";
            var response = client.PostAsJsonAsync(requestURL, nv).Result;
            return RedirectToAction("Index");
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(Guid id)
        {
            string requestURL = $"https://localhost:7198/api/NhanVien/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<NhanVien>(response);
            return View(data);
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien nv)
        {
            string requestURL = $"https://localhost:7198/api/NhanVien/create-nhanvien";
            var response = client.PutAsJsonAsync(requestURL, nv).Result;
            return RedirectToAction("Index");
        }

        // GET: NhanVienController/Delete/5
        public ActionResult Delete(Guid id)
        {
            string requestURL = $"https://localhost:7198/api/NhanVien/delete-by-id?id={id}";
            var response = client.DeleteAsync(requestURL).Result;
            return RedirectToAction("Index");
        }


       
    }
    public class NhanVien
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100, ErrorMessage = "Độ dài không quá 30 kí tự")]

        public string Ten { get; set; }
        [Range(18, 50, ErrorMessage = "Tuổi chỉ từ 18 - 50")]

        public int Tuoi { get; set; }
        [EmailAddress(ErrorMessage = "Email phải đúng định dạng")]
        public string Email { get; set; }

        [Range(5000000, 30000000, ErrorMessage = "Lương phải từ 5 triệu - 30 triệu")]
        public int Luong { get; set; }

        public bool TrangThai { get; set; }

    }
}
