using Common.FlowControl;
using DataAccessLayer.Interfaces_EFCore_;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories_EFCore_
{
    public class ModelRepository : IModelRepository
    {
        public async Task<Response> Delete(int idModel)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Disable(int idModel)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ModelDTO>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ModelDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse<ModelDTO>> GetByID(int modelID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Insert(ModelDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Update(ModelDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
