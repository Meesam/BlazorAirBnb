using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.Models.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public T? Response { get; set; }

    }
}
