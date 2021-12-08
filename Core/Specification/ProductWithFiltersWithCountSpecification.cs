using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersWithCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersWithCountSpecification(ProductSpecParams productParams)
            : base(x =>
             (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
               (!productParams.brandId.HasValue || x.ProductBrandId == productParams.brandId) &&
               (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
            )
        {
        }
    }
}