using AutoMapper;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.

            //添加dto到新增编辑dto的映射
            CreateMap<BookDto, CreateUpdateBookDto>();
        }
    }
}
