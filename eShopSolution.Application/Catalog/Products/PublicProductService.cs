using Azure.Core;
using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        public readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll(string languageId)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };

            int totalRow = await query.CountAsync();
            var data = await query
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    LanguageId = x.pt.LanguageId,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    DateCreated = x.p.DateCreated
                }).ToListAsync();

            var pageResult = new Pagedresult<ProductViewModel>()
            {
                Items = data,
                TotalRecord = totalRow
            };
            return data;
        }

        public async Task<Pagedresult<ProductViewModel>> GetAllByCategoryId(string languageId,GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
           

            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    LanguageId = x.pt.LanguageId,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    DateCreated = x.p.DateCreated
                }).ToListAsync();

            var pageResult = new Pagedresult<ProductViewModel>()
            {
                Items = data,
                TotalRecord = totalRow
            };
            return pageResult;
        }

        public Task<Pagedresult<ProductViewModel>> GetAllByCategoryId(GetManageProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
