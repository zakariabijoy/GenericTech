using Shopping.Aggregator.Dtos;

namespace Shopping.Aggregator.Services;

public interface ICatalogService
{
    Task<IEnumerable<CatalogDto>> GetCatalog();
    Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category);
    Task<CatalogDto> GetCatalog(string id);
}
