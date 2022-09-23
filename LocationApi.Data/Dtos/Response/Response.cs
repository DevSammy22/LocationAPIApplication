using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationApi.Data.Dtos.Response
{
    public class Response<T>
    {
        public string Code { get; set; }
        public bool Successful { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
