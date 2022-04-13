namespace CLOUD;

public class ECG:EntityBase
{
    public List<float> Valori { get; set; }
    public Pacient Pacient { get; set; }
}