using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<Pagedresult<ProductViewModel>> GetAllByCategoryId(string languageId,GetPublicProductPagingRequest request);
        Task <List<ProductViewModel>> GetAll(string languageId);

    }
}
