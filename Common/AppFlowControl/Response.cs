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
            this.Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public string GetErrorMessage()
        {
            StringBuilder builder = new StringBuilder();
            //Lambda Expression
            //Erros.ForEach(erro => builder.AppendLine(erro));
            foreach (string item in this.Errors)
            {
                builder.AppendLine(item);
            }

            return builder.ToString();
        }

        public bool HasErrors()
        {
            return this.Errors.Count > 0;
        }
    }
}
