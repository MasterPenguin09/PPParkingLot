﻿
using DAL.Context_EFCore_;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCommons;

namespace DataAccessLayer.Repositories_EFCore_
{
    /// <summary>
    /// Uma Classe publica VehicleRepository que herda de uma interface com mesmo nome (+I na frente),
    /// Essa interface possui todas as ações que a VehicleDTO pode fazer ligadas ao banco de dados
    /// 
    /// Nessa classe as ações herdadas são preenchidas
    /// </summary>

    public class VehicleRepository : IVehicleRepository
    {
        private SmartParkingContext _context;
        public VehicleRepository(SmartParkingContext context)
        {
            _context = context;
        }

        public async Task<Response> Delete(int idVehicle)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Entry<VehicleDTO>(new VehicleDTO() { ID = idVehicle }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Exclusão não executada");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Response> Disable(int idVehicle)
        {
            Response response = new Response();

            try
            {
                using (var context = _context)
                {
                    VehicleDTO vehicle = await context.Vehicles.FindAsync(idVehicle);
                    vehicle.IsActive = false;
                    context.Vehicles.Update(vehicle);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Desabilitação não executada");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<DataResponse<VehicleDTO>> GetActives()
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Vehicles.Where(c => c.IsActive == true).ToListAsync();
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Dados inexitentes");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetAll()
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();

            try
            {
                using (var context = _context)
                {
                    response.Data = await context.Vehicles.ToListAsync();

                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Veículos não encontrados");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetByID(int vehicleID)
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Vehicles.FindAsync(vehicleID));
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Veículo não encontrado");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataResponse<VehicleDTO>> GetByVehicleBoard(string vehicleBoard)
        {
            DataResponse<VehicleDTO> response = new DataResponse<VehicleDTO>();
            try
            {
                using (var context = _context)
                {
                    response.Data.Add(await context.Vehicles.Where(c => c.CarBoard == vehicleBoard).FirstOrDefaultAsync());
                    if (response.Data.Count > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Veículo não encontrado");
                        return response;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> Insert(VehicleDTO vehicle)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    context.Vehicles.Add(vehicle);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows > 0)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Inserção não executada");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response> Update(VehicleDTO vehicle)
        {
            Response response = new Response();
            try
            {
                using (var context = _context)
                {
                    //context.Entry(brand).State = Microsoft.EntityFrameworkCore.EntityState.Modified
                    context.Vehicles.Update(vehicle);
                    int nAffectedRows = await context.SaveChangesAsync();

                    if (nAffectedRows == 1)
                    {
                        response.Success = true;
                        return response;
                    }
                    else
                    {
                        response.Errors.Add("Edição não executada");
                        return response;
                    }
                }  
             
            }
            catch (Exception ex)
            {
                //response.Errors.Add("Erro no banco de dados contate o administrador");
                throw ex;
            }
        }
    }
}
