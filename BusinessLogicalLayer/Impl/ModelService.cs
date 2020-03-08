using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces_EFCore_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class ModelService : IModelService
    {
        private IModelRepository _iModelRepository;
        public ModelService(IModelRepository iModelRep)
        {
            this._iModelRepository = iModelRep;
        }
    }
}
