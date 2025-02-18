using _1._API.Controllers;
using _1._API.Response;
using _2._Domain;
using _3._Data.Clients;
using _3._Data.Model;
using AutoMapper;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1._API.Tests
{
    public class ClientControllerTest
    {
        private IClientDomain _clientDomainMock;
        private IClientData _clientDataMock;
        private IMapper _mapperMock;
        public ClientControllerTest() 
        {
            _clientDomainMock = Substitute.For<IClientDomain>();
            _clientDataMock = Substitute.For<IClientData>();
            _mapperMock = Substitute.For<IMapper>();
        }
        [Fact]
        public async Task GetAsync_ReturnOk()
        {
            //Arrange     
            // Moq GetAll  
            List<Client> clients = new List<Client>();
            clients.Add(new Client
            {
                first_name = "Test1",
                last_name = "Client1",
                gender = "M",
                birthdate = DateTime.Parse("2002-05-23"),
                email = "example1@gmail.com",
                dni = "10345678",
                phone_number = "907456321",
            });
            clients.Add(new Client
            {
                first_name = "Test2",
                last_name = "Client2",
                gender = "F",
                birthdate = DateTime.Parse("2004-09-11"),
                email = "example2@gmail.com",
                dni = "12305678",
                phone_number = "987456021",
            });
            clients.Add(new Client
            {
                first_name = "Test3",
                last_name = "Client3",
                gender = "M",
                birthdate = DateTime.Parse("2008-09-11"),
                email = "example3@gmail.com",
                dni = "12115678",
                phone_number = "987456360",
            });
            _clientDataMock.GetAllAsycnc().Returns(Task.FromResult(clients));

            // Moq Mapper
            List<ClientResponse> clientsResponse = new List<ClientResponse>();
            clientsResponse.Add(new ClientResponse
            {
                first_name = "Test1",
                last_name = "Client1",
                gender = "M",
                birthdate = DateTime.Parse("2002-05-23"),
                email = "example1@gmail.com",
                dni = "10345678",
                phone_number = "907456321",
            });
            clientsResponse.Add(new ClientResponse
            {
                first_name = "Test2",
                last_name = "Client2",
                gender = "F",
                birthdate = DateTime.Parse("2004-09-11"),
                email = "example2@gmail.com",
                dni = "12305678",
                phone_number = "987456021",
            });
            clientsResponse.Add(new ClientResponse
            {
                first_name = "Test3",
                last_name = "Client3",
                gender = "M",
                birthdate = DateTime.Parse("2008-09-11"),
                email = "example3@gmail.com",
                dni = "12115678",
                phone_number = "987456360",
            });

            _mapperMock.Map<List<Client>,List<ClientResponse>>(clients).Returns(clientsResponse);

            //Act
            ClientController clientController = new ClientController(_clientDataMock, _clientDomainMock, _mapperMock);
            var actualResult =  await clientController.GetAsync();

            //Assert
            Assert.Equal(3, actualResult.Count());
        }

        [Fact]
        public async Task GetAsync_ReturnException()
        {
            //Arrange
            _clientDataMock.GetAllAsycnc().Returns(Task.FromException<List<Client>>(new Exception()));
            ClientController clientController = new ClientController(_clientDataMock, _clientDomainMock, _mapperMock);


            //Act
            var act = async () => await clientController.GetAsync();

            //Assert
            Assert.ThrowsAsync<Exception>(act);
        }
    }
}