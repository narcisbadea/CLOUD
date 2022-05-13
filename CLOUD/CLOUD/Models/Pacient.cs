using System.ComponentModel.DataAnnotations;
namespace CLOUD;

public class Pacient : Entity
{
    [Required] public User User { get; set; }
    [Required] public string Nume { get; set; }
    [Required] public string Prenume { get; set; }
    [Required] public short Varsta { get; set; }
    [Required] public string CNP { get; set; }
    [Required] public Judet? Judet { get; set; }
    [Required] public string Localitate { get; set; }
    [Required] public string Strada { get; set; }
    [Required] public string Numar { get; set; }
    [Required] [Phone] public string Telefon { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Profesie { get; set; }
    [Required] public string LocDeMunca { get; set; }
}