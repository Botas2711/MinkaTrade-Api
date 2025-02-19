using _2._Domain.Clients;
using _3._Data.Clients;
using _3._Data.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Tests
{
    public class ClientDomainTest
    {
        [Theory]
        [InlineData("Test1", "Client1", "M", "2002-05-23", "example1@gmail.com", "10345678", "907456321")]
        [InlineData("Test2", "Client2", "F", "2004-10-01", "example2@gmail.com", "12305678", "987456021")]
        [InlineData("Test3", "Client3", "M", "2008-09-11", "example3@gmail.com", "12115678", "987456360")]
        public async Task Create_ValidClient_ResultTrueAsync(string first_name, string last_name, string gender, string birthdate, string email, string dni, string phone_number)
        {
            //Arrange
            Client client = new Client
            {
                first_name = first_name,
                last_name = last_name,
                gender = gender,
                birthdate = DateTime.Parse(birthdate),
                email = email,
                dni = dni,
                phone_number = phone_number,
            };

            // Debemos probar un objeto aislado (controlado)
            // Usamos Mock
            var clientDataMock = Substitute.For<IClientData>();

            clientDataMock.GetByPhoneNumberAsync(client, false).Returns(Task.FromResult<Client>(null));

            clientDataMock.CreateAsync(client).Returns(true);
            ClientDomain clientDomian = new ClientDomain(clientDataMock);

            //Act
            var actualResult =  await clientDomian.CreateAsync(client);

            //Assert
            Assert.True(actualResult);
            //Assert.Equal(true, actualResult);
        }

        [Theory]
        [InlineData("9074561")]
        [InlineData("9874560211")]
        [InlineData("987456")]
        public async Task Create_InvalidPhoneNumber_ResultFalseAsync(string phone_number)
        {
            //Arrange
            Client client = new Client
            {
                // Esto es lo unico que me importa probar
                phone_number = phone_number,
            };

            // Debemos probar un objeto aislado (controlado)
            // Usamos Mock
            var clientDataMock = Substitute.For<IClientData>();

            clientDataMock.GetByPhoneNumberAsync(client, false).Returns(Task.FromResult<Client>(null));
            clientDataMock.CreateAsync(client).Returns(true);
            ClientDomain clientDomian = new ClientDomain(clientDataMock);

            //Act
            Func<Task> act = async () => await clientDomian.CreateAsync(client);

            //Assert
            await Assert.ThrowsAsync<Exception>(act);
        }
    }
}
