using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces_EFCore_
{
    public interface IModelRepository
    {
        Task Insert(ModelDTO model);
        Task<List<ModelDTO>> GetAll();
        Task Update(ModelDTO model);
        Task<List<ModelDTO>> GetActives();
        Task Disable(ModelDTO model);
        Task Delete(ModelDTO model);
        Task<List<ModelDTO>> GetLocationByID(int ID);
    }
}
