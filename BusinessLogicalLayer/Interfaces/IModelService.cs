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
        Task<List<ModelDTO>> GetAll();
        Task Update(ModelDTO model);
        Task<List<ModelDTO>> GetActives();
        Task Disable(ModelDTO model);
        Task Delete(ModelDTO model);
        Task<List<ModelDTO>> GetLocationByID(int ID);
    }
}
