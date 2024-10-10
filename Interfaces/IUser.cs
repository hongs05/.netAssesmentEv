using System;
using evertectAssesment.Models;

namespace evertectAssesment.Interfaces;

public interface IUser
{
    IEnumerable<User> ObtenerTodos();
    IEnumerable<User> FiltrarPorDominio(string dominio);
    User GetById(int id);
    void AgregarUsuario(User usuario);
    void ActualizarUsuario(User usuario);
    void EliminarUsuario(int id);

}
