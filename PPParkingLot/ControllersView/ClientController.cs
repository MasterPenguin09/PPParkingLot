using AutoMapper;
using BusinessLogicalLayer.Impl;
using BusinessLogicalLayer.Interfaces;
using DAL.Context_EFCore_;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using PPParkingLot.Models.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPParkingLot.Controllers
{
    public class ClientController:Controller
    {
        IClientService _service;
        public ClientController(IClientService service)
        {
            this._service = service;
        }



    }

}
