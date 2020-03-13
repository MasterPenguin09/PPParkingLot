
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Controllers
{
    public class VehicleController: Controller
    {



        public async Task<ActionResult> Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Cadastrar(VehicleViewModel viewModel)
        {
            //Estas 3 linhas utilizarão o AutoMapper pra transformar um ProdutoViewModel em um ProdutoDTO
            var configuration = new MapperConfiguration(cfg =>
            {
                Vehicle= cfg.CreateMap<VehicleViewModel, VehicleDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            VehicleDTO produto = mapper.Map<VehicleDTO>(viewModel);

        
            try
            {
                await svc.Insert(produto);
                return RedirectToAction("Index", "Vehicle");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Errors;
            }
            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }



        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }
    }
}

