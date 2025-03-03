using _1._API.Request;
using _3._Data.Model;
using AutoMapper;

namespace _1._API.Mapper
{
    public class APIToModel : Profile
    {
        public APIToModel() 
        {
            CreateMap<ClientRequest, Client>();

            CreateMap<CategoryRequest, Category>();

            CreateMap<PostImageRequest, PostImage>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => ConvertToByteArray(src.Images)));

            CreateMap<PostRequest, Post>();

            CreateMap<ReviewRequest, Review>();

            CreateMap<ChatRequest, Chat>();

            CreateMap<MessageRequest, Message>();

            CreateMap<PremiunRequest, Premiun>();

            CreateMap<SuscriptionRequest, Suscription>();

            CreateMap<UserCreateRequest, User>();
            CreateMap<UserLoginRequest, User>();
        }

        //Connvertir IformFile a byte[]
        private static byte[] ConvertToByteArray(IFormFile file)
        {
            if (file == null) return null;
            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
