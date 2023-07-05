using GenericTech.ASPNETCoreWebApp.Models;
using GenericTech.ASPNETCoreWebApp.Services.Interfaces;

namespace GenericTech.ASPNETCoreWebApp.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _client;

    public CatalogService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public Task<CatalogModel> CreateCatalog(CatalogModel model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogModel>> GetCatalog()
    {
        throw new NotImplementedException();
    }

    public Task<CatalogModel> GetCatalog(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
    {
        throw new NotImplementedException();
    }
}
