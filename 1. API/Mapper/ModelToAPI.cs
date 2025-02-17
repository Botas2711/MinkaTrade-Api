using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;

namespace _1._API.Mapper
{
    public class ModelToAPI : Profile
    {
        public ModelToAPI() 
        {
            // En algun momento vamos a transformar
            // de Client a ClientRequest
            CreateMap<Client, ClientRequest>();
            CreateMap<Client, ClientResponse>();
        }
    }
}
