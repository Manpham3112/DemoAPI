using System;
using System.Collections.Generic;
using System.Text;

namespace SaleManagement
{
    public class ErrorResult
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }
        public int StatusCode { get; set; }
    }
}
