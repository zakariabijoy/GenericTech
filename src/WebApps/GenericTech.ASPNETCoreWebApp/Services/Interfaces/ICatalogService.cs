﻿using GenericTech.ASPNETCoreWebApp.Models;

namespace GenericTech.ASPNETCoreWebApp.Services.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<CatalogModel>> GetCatalog();
    Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
    Task<CatalogModel> GetCatalog(string id);
    Task<CatalogModel> CreateCatalog(CatalogModel model);
}
