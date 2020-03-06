using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FlowControl
{
    public class Response
    {
       
        public Response(bool success, List<string> errors)
        {
            Success = success;
            Errors = errors;
        }
        public Response()
        {

        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public string GetErrors() 
        {
            return this.Errors.ToString();
        }

    }
}
