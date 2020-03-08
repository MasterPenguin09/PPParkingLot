using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    internal interface IClientService
    {
        Task Insert(ClientDTO client);
        Task<List<ClientDTO>> GetAll(ClientDTO client);
        Task Update(ClientDTO client);
        Task<List<ClientDTO>> GetActives(ClientDTO client);
        Task Disable(ClientDTO client);
        Task Delete(ClientDTO client);
        Task<List<ClientDTO>> GetLocationByID(int ID);
    }
}
