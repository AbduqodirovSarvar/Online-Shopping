using AutoMapper;
using Shop.App.Moduls;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Mapper
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<User, ViewUser>().ReverseMap();
            CreateMap<CreateUser, User>().ReverseMap();
            CreateMap<Product, ViewProduct>().ReverseMap();
            CreateMap<CreateProduct, Product>().ReverseMap();
        }
    }
}
