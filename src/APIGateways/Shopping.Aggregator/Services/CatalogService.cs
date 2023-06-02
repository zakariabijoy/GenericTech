using Shopping.Aggregator.Dtos;

namespace Shopping.Aggregator.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<IEnumerable<CatalogDto>> GetCatalog()
    {
        throw new NotImplementedException();
    }

    public Task<CatalogDto> GetCatalog(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category)
    {
        throw new NotImplementedException();
    }
}
