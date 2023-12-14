using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
        }
        public BaseResponse(T data)
        {
            Code = 1;
            Data = data;
            Message = string.Empty;
        }

        public BaseResponse(T data, string code, string message)
        {
            int.TryParse(code, out int c);
            Code = c;
            Result = c == 1 ? true : false;
            Data = data;
            Message = message;
        }

        public bool Result { get; set; }

        public int Code { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }
    }
}
