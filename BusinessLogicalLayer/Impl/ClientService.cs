using BusinessLogicalLayer.Interfaces;
using DataAccessLayer.Interfaces_EFCore_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Impl
{
   public class ClientService : IClientService
    {
        private IClientRepository _iClientRepository;
        public ClientService(IClientRepository iClientRep)
        {
            this._iClientRepository = iClientRep;
        }
    }
}
