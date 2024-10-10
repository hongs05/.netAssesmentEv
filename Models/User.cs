// Define una entidad Usuario con las siguientes propiedades:
// ▪ Id (int)
// ▪ Nombre (string)
// ▪ CorreoElectronico (string)
// ▪ FechaRegistro (DateTime)
using System;
namespace evertectAssesment.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public User()
    {

    }

}
