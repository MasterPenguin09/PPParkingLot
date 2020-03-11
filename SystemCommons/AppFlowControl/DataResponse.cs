using System;
using System.Collections.Generic;
using System.Text;

namespace SystemCommons
{
    public class DataResponse<T> : Response
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
