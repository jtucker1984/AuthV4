using AuthV4.Models.Domain;
using AuthV4.Models.Dto;
using AutoMapper;

namespace AuthV4.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ItemDto, Item>().ReverseMap();
            CreateMap<AddItemDto, Item>().ReverseMap();
            CreateMap<UpdateItemDto, Item>().ReverseMap();
            ///////////////////////////////////////////////
            CreateMap<VendorDto, Vendor>().ReverseMap();    
            CreateMap<AddVendorDto, Vendor>().ReverseMap();
            CreateMap<UpdateVendorDto, Vendor>().ReverseMap();
        }
    }
}
