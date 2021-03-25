using AutoMapper;
using Sample.Application.Categories.Commands.CreateCategory;
using Sample.Application.Categories.Queries.GetAllCategories;
using Sample.Application.Products.Commands.CreateProductWithCategory;
using Sample.Application.Products.Queries.GetAllProducts;
using Sample.Application.Products.Queries.GetProductWithFilter;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetAllProductsResponse>()
                .ReverseMap();
            CreateMap<Product, GetAllProductsRequest>()
                .ReverseMap();
            
            CreateMap<Product, GetProductWithFilterRequest>()
                .ReverseMap();
            CreateMap<Product, GetProductWithFilterResponse>()
                .ReverseMap();

            CreateMap<Category, CreateCategoryRequest>()
                .ReverseMap();
            CreateMap<Category, CreateCategoryResponse>()
                .ReverseMap();

            CreateMap<Category, GetAllCategoriesRequest>()
                .ReverseMap();
            CreateMap<Category, GetAllCategoriesResponse>()
                .ReverseMap();


            CreateMap<Product, CreateProductWithCategoryRequest>()
                .ForMember(req => req.ProductName, p=> p.MapFrom(r => r.Name))
                .ReverseMap();
            
            CreateMap<Category, CreateProductWithCategoryRequest>()
                .ForMember(req => req.CategoryName, p => p.MapFrom(r => r.Name))
                .ReverseMap();

            CreateMap<Product, CreateProductWithCategoryResponse>()
                .ForMember(p => p.ProductName, resp => resp.MapFrom(r => r.Name))
                .ForMember(p => p.CategoryName, resp => resp.MapFrom(r => r.Category.Name))
                .ForMember(p => p.UnitPrice, resp => resp.MapFrom(r => r.UnitPrice))
                .ReverseMap();

        }
    }
}
