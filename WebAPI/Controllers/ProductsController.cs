using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntittFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //Attribute araştır - Bir class ile ilgili bilgi verme imzalama
    //ApıController den diyoruz kş bu class bir controllerdir diyoruz.
    //
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention    
        //Ioc Container Inversion of control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //Dependency chain: Bağımlılık zinciri 

            var result = _productService.GetAll();
            return result.Data;

        }
    }
}
