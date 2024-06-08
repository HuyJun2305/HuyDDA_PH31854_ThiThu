using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("tinh-bmi")]
        public string BMI(double weight, double height)
        {
            return "Chỉ số BMI của bạn là : " + weight / (height * height);
        }

        [HttpPost("tim-solonthu2")]
        public string Find_Largest_2rd_Number(int[] arrNum)
        {
            Array.Sort(arrNum);
            int _2rd = arrNum[arrNum.Length - 1];
            for (int i = arrNum.Length - 2; i >= 0; i--)
            {
                if (arrNum[i] < _2rd)
                {
                    _2rd = arrNum[i];
                    break;
                }
            }
            if (_2rd == arrNum[arrNum.Length - 1])
            {
                return "Không có số nào lớn thứ 2";
            }
            else
            {
                return "Phần tử lớn thứ 2 trong mảng là : " + _2rd;
            }
        }
    }
}
