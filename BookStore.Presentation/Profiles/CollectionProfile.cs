using AutoMapper;
using BookStore.BusinessLogic.Dtos.Collections;
using BookStore.DataAccess.Models;

namespace BookStore.Presentation.Profiles
{
    public class CollectionProfile:Profile
    {
        public CollectionProfile()
        {
            CreateMap<CollectionDto, Collection>()
                .ReverseMap();
        }
    }
}
