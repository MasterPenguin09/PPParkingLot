using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Controllers
{
    public class EmplloyeeController: Controller
    {
        private IEmployeeService _service;

        public EmplloyeeController(IEmployeeService service)
        {
            this._service = service;
        }

        public async Task<ActionResult> Cadastrar()
        {

        }
    }
}
