using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithtypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithtypesAndBrandsSpecification()
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

        public ProductsWithtypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}