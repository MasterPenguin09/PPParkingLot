using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    internal interface IModelService
    {
        Task Insert(ModelDTO model);
        Task<List<ModelDTO>> GetAll(ModelDTO model);
        Task Update(ModelDTO model);
        Task<List<ModelDTO>> GetActives(ModelDTO model);
        Task Disable(ModelDTO model);
        Task Delete(ModelDTO model);
        Task<List<ModelDTO>> GetLocationByID(int ID);
    }
}
