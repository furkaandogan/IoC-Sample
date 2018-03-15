using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Result<T>
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }

        public void Set(bool isOk, string message, T data)
        {
            IsOk = isOk;
            Message = message;
            Data = data;
        }
        public void SetError(string message, T data = default(T))
        {
            Set(false, message, data);
        }
        public void SetError(Exception ex, T data = default(T))
        {
            SetError(ex.Message, data);
        }
        public void SetSucces(string message=null, T data = default(T))
        {
            Set(true, message, data);
        }
    }
}
