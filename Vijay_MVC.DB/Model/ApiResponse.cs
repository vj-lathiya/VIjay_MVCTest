using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vijay_MVC.DB.Model
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = string.Empty;
        public dynamic? Data { get; set; }

    }
}
