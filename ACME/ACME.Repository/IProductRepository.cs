using ACME.Model;

namespace ACME.Repository
{
    public interface IProductRepository :IRepository<Product, int?>
    {
        void SaveUOM(UnitOfMeasure saveObj);
        void SaveCategory(Category saveObj);
    }
}
