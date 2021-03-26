using AutoMapper;
using Sample.Application.Products.Commands.CreateProduct;
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
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, GetAllProductsRequest>()
                .ReverseMap();
            CreateMap<Product, GetAllProductsResponse>()
                .ForMember(res=>res.CategoryName, p=>p.MapFrom(pr=>pr.Category.Name))
                .ReverseMap();
            

            CreateMap<Product, GetProductWithFilterRequest>()
                .ReverseMap();
            CreateMap<Product, GetProductWithFilterResponse>()
                .ReverseMap();

            CreateMap<Product, CreateProductWithCategoryRequest>()
                .ForMember(req => req.ProductName, p => p.MapFrom(r => r.Name))
                .ReverseMap();

            CreateMap<Product, CreateProductWithCategoryResponse>()
                .ForMember(p => p.ProductName, resp => resp.MapFrom(r => r.Name))
                .ForMember(p => p.CategoryName, resp => resp.MapFrom(r => r.Category.Name))
                .ForMember(p => p.UnitPrice, resp => resp.MapFrom(r => r.UnitPrice))
                .ReverseMap();

            CreateMap<Product, CreateProductRequest>()
                .ReverseMap();
            CreateMap<Product, CreateProductResponse>()
                .ForMember(c => c.CategoryName, p => p.MapFrom(pr => pr.Category.Name))
                .ReverseMap();


            
        }
    }
}
