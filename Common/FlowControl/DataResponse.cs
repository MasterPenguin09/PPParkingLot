using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FlowControl
{
    class DataResponse<T> : Response
    {
        public DataResponse()
        {

        }

        public DataResponse(List<T> data)
        {
            Data = data;
        }

        public List<T> Data { get; set; } 
    }
}
