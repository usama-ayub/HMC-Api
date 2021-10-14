using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Shared
{
    public class BaseResponses<T>
    {
        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public BaseResponses(T data, HttpStatusCode status,string message, bool success, bool error)
        {
            this.Status = status;
            this.Success = success;
            this.Error = error;
            this.Message = message;
            this.Data = data;
        }
    }
}