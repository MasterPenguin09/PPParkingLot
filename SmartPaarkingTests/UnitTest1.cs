using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using System;
using SystemCommons;
using Xunit;

namespace SmartPaarkingTests
{
    public class UnitTest1
    {

        protected IClientService _service;
        public UnitTest1(IClientService cliSrvc)
        {
            this._service = cliSrvc;
        }


        [Fact]
        public async void Test1()
        {
            int cliID = 7;
            Response response = await _service.Delete(cliID);
            Assert.True(response.Success);
            if (response.Errors.Count > 0)
            {
                Console.WriteLine(response.Errors.ToString());
            }
        }
    }
}

  