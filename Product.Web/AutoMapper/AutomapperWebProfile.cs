using Product.Models.Dtos;
using Product.Repository;
using Product.Repository.Models;
using Product.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Web
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<AgreementDto, AgreementVM>();
            CreateMap<AgreementVM, AgreementDto>();
            CreateMap<Agreement, AgreementDto>().ReverseMap();

            CreateMap<ProductDto, ProductVM>();
            CreateMap<ProductVM, ProductDto>();
            CreateMap<Product.Repository.Product, ProductDto>().ReverseMap();

            CreateMap<ProductGroupDto, ProductGroupVM>();
            CreateMap<ProductGroupVM, ProductGroupDto>();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();


            });
        }
       

    }

    public static class ExtensionMethod
    {

        public static string Encrypt(this Int32 num)
        {

            return "Technotips:" + num;
        }
    }
}