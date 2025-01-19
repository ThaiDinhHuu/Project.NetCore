using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.ProductImage
{
    public class ProductImageUpdateRequest
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOder { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
