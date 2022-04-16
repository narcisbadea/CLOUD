namespace CLOUD.Auth;

public class Temperatura:EntityBase
{
    public float Valoare { get; set; }
    public Pacient Pacient { get; set; }
}