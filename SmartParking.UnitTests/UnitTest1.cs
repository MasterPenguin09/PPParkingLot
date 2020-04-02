using BusinessLogicalLayer.Interfaces;
using DataTransferObject;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using SystemCommons;

namespace SmartParking.UnitTests
{
    public class InsertTests
    {
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;
        private readonly IBrandService _brandService;
        private readonly IVehicleService _vehicleService;
        private readonly IParkingSpotService _parkingSpotService;
        private readonly IModelService _modelService;
        private readonly ILocationSevice _locationSevice;


        public InsertTests(IClientService cliSrvc, IEmployeeService empSrvc, IBrandService brandSrvc, IVehicleService vehicleSrvc, IParkingSpotService psSrvc, IModelService modelSrvc, ILocationSevice locationSrvc)
        {
            this._clientService = cliSrvc;
            this._employeeService = empSrvc;
            this._brandService = brandSrvc;
            this._vehicleService = vehicleSrvc;
            this._parkingSpotService = psSrvc;
            this._modelService = modelSrvc;
            this._locationSevice = locationSrvc;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void Insert_Client_ReturnsTrue()
        {
            //Arrange
            ClientDTO c = new ClientDTO();
            c.BirthDate = DateTime.Parse("02-21-2002"); 
            c.Email = "gabrielcontact@gmail.com";
            c.Name = "Gabriel";
            c.Number = "(47) 99896-1917";
            c.Password = "Repolho123$";
            c.AccessLevel = DataTransferObject.Enums.EAccessLevel.Client;
            c.CPF = "234.935.520-92";


            //Act
            Response response = new Response();
            response = await _clientService.Insert(c);

            //Assert
            //Assert.Pass();

            //Assert.IsTrue(response.Success);
            //Assert.Pass();
        }

    }
}
