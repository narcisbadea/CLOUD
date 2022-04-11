namespace CLOUD.Auth;

public class ECG:Entity     
{
    public List<float> Valori { get; set; }
    public Pacient Pacient { get; set; }
}