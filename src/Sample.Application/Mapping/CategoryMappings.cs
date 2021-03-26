using AutoMapper;
using Sample.Application.Categories.Commands.CreateCategory;
using Sample.Application.Categories.Queries.GetAllCategories;
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
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            

            CreateMap<Category, CreateCategoryRequest>()
                .ReverseMap();
            CreateMap<Category, CreateCategoryResponse>()
                .ReverseMap();

            CreateMap<Category, GetAllCategoriesRequest>()
                .ReverseMap();
            CreateMap<Category, GetAllCategoriesResponse>()
                .ReverseMap();


            
            CreateMap<Category, CreateProductWithCategoryRequest>()
                .ForMember(req => req.CategoryName, p => p.MapFrom(r => r.Name))
                .ReverseMap();

            
        }
    }
}
