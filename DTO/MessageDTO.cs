using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citasmedicas.DTO
{
    public class MessageDTO
    {
        public int Code { get; set; }

        public object Data { get; set; }

        public MessageDTO(int code, object data)
        {
            Code = code;
            Data = data;
        }
    }
}
