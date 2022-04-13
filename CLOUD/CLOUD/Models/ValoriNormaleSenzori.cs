namespace CLOUD;

public class ValoriNormaleSenzori:Entity
{
    public Pacient Pacient { get; set; }
    public int TemperaturaMinima { get; set; }
    public int TemperaturaMaxima { get; set; }
    public int UmiditateMinima { get; set; }
    public int UmiditateMaxima { get; set; }
    public int PulsMinim { get; set; }
    public int PulsMaxim { get; set; }
}