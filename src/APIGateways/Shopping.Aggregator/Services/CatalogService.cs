using Shopping.Aggregator.Dtos;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CatalogDto>> GetCatalog()
    {
        var response = await _httpClient.GetAsync("/api/v1/Catalog");
        return await response.ReadcontentAs<List<CatalogDto>>();
    }

    public async Task<CatalogDto> GetCatalog(string id)
    {
        var response = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");
        return await response.ReadcontentAs<CatalogDto>();
    }

    public async Task<IEnumerable<CatalogDto>> GetCatalogByCategory(string category)
    {
        var response = await _httpClient.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
        return await response.ReadcontentAs<List<CatalogDto>>();
    }
}
