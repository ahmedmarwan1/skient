using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithtypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithtypesAndBrandsSpecification(ProductSpecParams productParams) 
            : base( x=> 
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.brandId.HasValue || x.ProductBrandId == productParams.brandId) &&
                (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
            )
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;

                    default:
                        AddOrderBy(x => x.Name);
                        break;

                }
            }
        }

        public ProductsWithtypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}