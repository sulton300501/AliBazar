﻿using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.DTOs;

using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Application.Services.ProductColorServices
{
    public class ProductColorService : IProductColorService
    {
        private readonly IProductColorRepository _repository;

        public ProductColorService(IProductColorRepository repository)
        {
            _repository = repository;
        }



        public async Task<ResponseModel> CreateProductColor(ProductColorDTO color)
        {
            

            var product = new ProductColor()
            {
              Color=color.Color,
              ProductDetailId=color.ProductDetailId
            };

            var result = await _repository.Create(product);

           
            if(result == null)
            {
                return new ResponseModel()
                {
                    Note = "Error",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "ProductColor created successfully!",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteProductColor(int id)
        {
           
            var color = await _repository.Delete(x=>x.Id == id);

            return true;
            

        }

        public async Task<IEnumerable<ProductColor>> GetAllProductColor()
        {
            return await _repository.GetAll();
            
        }

        public async Task<ProductColor> GetProductColorById(int id)
        {
           var result = await _repository.GetByAny(x=>x.Id == id);
            return result;
            
        }

        public async Task<ResponseModel> UpdateProducColor(int id, ProductColorDTO color)
        {



            var productColor = await _repository.GetByAny(x => x.Id == id);

            if (productColor == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "ProductColor not found!"
                };
            }



            productColor.Color = color.Color;
            productColor.ProductDetailId=color.ProductDetailId;

            var result = await _repository.Update(productColor);

           

            return new ResponseModel()
            {
                Note = "ProductColor updated successfully!",
                IsSuccess = true
            };


        }
    }
}