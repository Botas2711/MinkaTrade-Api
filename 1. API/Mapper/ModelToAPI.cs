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

            CreateMap<Category, CategoryRequest>();
            CreateMap<Category, CategoryResponse>();

            CreateMap<PostImage, PostImageRequest>();
            CreateMap<PostImage, PostImageResponse>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => Convert.ToBase64String(src.Images)));

            CreateMap<Post, PostRequest>();
            CreateMap<Post, PostResponse>();

            CreateMap<Review, ReviewRequest>();
            CreateMap<Review, ReviewResponse>();

            CreateMap<Chat, ChatRequest>();
            CreateMap<Chat, ChatResponse>();

            CreateMap<Message, MessageRequest>();
            CreateMap<Message, MessageReponse>();

            CreateMap<Premiun, PremiunRequest>();
            CreateMap<Premiun, PremiunResponse>();
        }
    }
}
