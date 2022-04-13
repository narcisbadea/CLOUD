namespace CLOUD.Auth;

public class Temperatura:EntityBase
{
    public int Valoare { get; set; }
    public Pacient Pacient { get; set; }
}