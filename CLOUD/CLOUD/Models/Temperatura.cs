namespace CLOUD.Auth;

public class Temperatura:Entity
{
    public int Valoare { get; set; }
    public Pacient Pacient { get; set; }
}