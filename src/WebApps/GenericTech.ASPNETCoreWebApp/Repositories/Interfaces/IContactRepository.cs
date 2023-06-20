using GenericTech.ASPNETCoreWebApp.Entities;

namespace GenericTech.ASPNETCoreWebApp.Repositories.Interfaces;

public interface IContactRepository
{
    Task<Contact> SendMessage(Contact contact);
    Task<Contact> Subscribe(string address);
}
