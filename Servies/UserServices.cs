using System;
using evertectAssesment.Controllers;
using evertectAssesment.Interfaces;
using evertectAssesment.Models;

namespace evertectAssesment.Servies;

public class UserServices : IUser
{
    private readonly List<User> _usuarios = new List<User>();

    public IEnumerable<User> ObtenerTodos() => _usuarios;
    public IEnumerable<User> GetAll()
    {

        return _usuarios;
    }

    public User GetById(int id) => _usuarios.FirstOrDefault(u => u.Id == id);


    public async void AgregarUsuario(User usuario)
    {
        try
        {
            usuario.Id = _usuarios.Count + 1; // Assign a new ID
            usuario.CreatedAt = DateTime.UtcNow;
            _usuarios.Add(usuario);

        }
        catch (System.Exception ex)
        {

            throw ex;
        }

    }
    public IEnumerable<User> FiltrarUsuariosPorDominio(string dominio)
    {
        return _usuarios.Where(u => u.Email.EndsWith($"@{dominio}"));
    }
    public void ActualizarUsuario(User usuario)
    {
        var existingUser = GetById(usuario.Id);
        if (existingUser != null)
        {
            existingUser.Name = usuario.Name;
            existingUser.Email = usuario.Email;
        }
    }

    public void EliminarUsuario(int id)
    {
        var usuario = GetById(id);
        if (usuario != null)
        {
            _usuarios.Remove(usuario);
        }
    }

    public IEnumerable<User> FiltrarPorDominio(string dominio)
    {
        return _usuarios.Where(u => u.Email.EndsWith($"@{dominio}")).ToList();
    }
}
